using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using Microsoft.Win32;
using PC.BL;
using PC.DAL;
using System.Net;
using System.Security.Claims;

namespace ProductCatalog.Controllers
{
    public class UserController : Controller
    {

        private readonly UserManager<User> manager;
        private readonly SignInManager<User> _signInManager;

        public UserController(UserManager<User> manager,  SignInManager<User> signInManager)
        {
            this.manager = manager;
           
            _signInManager = signInManager;
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            var user = new User
            {
                FirstName = registerVM.FirstName,
                LastName = registerVM.LastName,
                Email = registerVM.Email,
            };
            var creationResult = await manager.CreateAsync(user, registerVM.Password);
            if (!creationResult.Succeeded)
            {
               
                ModelState.AddModelError(string.Empty, creationResult.Errors.First().Description);
                return View();
            }
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier,user.Id),
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.Role,"Admin")
            };
            await manager.AddClaimsAsync(user, claims);

            return RedirectToAction(nameof(Login));
        }

        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            var user = await manager.FindByEmailAsync(loginVM.Email);
            if(user is null)
            {
                return View();
            }
            var isAuthenticated = await manager.CheckPasswordAsync(user,
           loginVM.Password);
            if (!isAuthenticated)
            {
                                
                return View();
            }

            var claims = await manager.GetClaimsAsync(user);
            await _signInManager.SignInWithClaimsAsync(user, true, claims);

           return RedirectToAction("Index", "Products");
            
        }
        
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("CurrentP", "Products");
        }

    }
}
