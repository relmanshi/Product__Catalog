using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PC.BL;

namespace ProductCatalog.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductManager _productManager;
        private readonly ICategoryManager _categoryManager;
        public ProductsController(IProductManager productManager, ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
            _productManager = productManager;
        }
       [Authorize (Policy="Admin")]
        public IActionResult Index()
        {
            ViewData["Categories"]=_categoryManager.GetAllCategories()
                .Select(c=>new SelectListItem(c.CategoryName,c.CategoryId.ToString())).ToList();
            IEnumerable<ReadProductsVM> products=_productManager.GetAllProducts();
            return View(products);
        }

        [Authorize(Policy="Admin")]
        [HttpPost]
        public IActionResult Add(AddProductVM addProductVM)
        {
            if(!ModelState.IsValid)
            {
                ViewData["Categories"]=_categoryManager.GetAllCategories()
                .Select(s=>new SelectListItem(s.CategoryName,s.CategoryId.ToString())).ToList(); 
                return View();
            }
            var token = Request.Cookies["UserId"];
            _productManager.Add(addProductVM,token);
            return RedirectToAction("Index","Products");
        }

        [HttpGet]
        public IActionResult CurrentP () {
            ViewData["Categories"] = _categoryManager.GetAllCategories()
                .Select(c => new SelectListItem(c.CategoryName, c.CategoryId.ToString())).ToList();

            IEnumerable<ReadProductsVM> products = _productManager.GetCurrentProducts();
            return View(products);
        }

        

        [Authorize]
        [HttpGet]
        public IActionResult Details(Guid id)
        {
            ProductDetailsVM productDetailsVM = _productManager.GetDetails(id);
            return View(productDetailsVM);
        }

        [Authorize(Policy = "Admin")]
        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            _productManager.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Policy = "Admin")]
        [HttpGet]
        public IActionResult Update (Guid id)
        {
            ProductUpdateVM productUpdateVM = _productManager.GetProducttobeUpdate(id);
            ViewData["Categories"] = _categoryManager.GetAllCategories()
                .Select(c => new SelectListItem(c.CategoryName, c.CategoryId.ToString())).ToList();
            return View(productUpdateVM);
        }


        [Authorize(Policy="Admin")]
        [HttpPost]
        public IActionResult Update(ProductUpdateVM productUpdateVM) {
            if (!ModelState.IsValid)
            {
                ViewData["Categories"] = _categoryManager.GetAllCategories()
               .Select(c => new SelectListItem(c.CategoryName, c.CategoryId.ToString()))
               .ToList();
                return View();
            }
            _productManager.update(productUpdateVM);
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public IActionResult Filter(Guid id)
        {
            ViewData["Categories"] = _categoryManager.GetAllCategories()
                .Select(c => new SelectListItem(c.CategoryName, c.CategoryId.ToString()))
                .ToList();

            IEnumerable<ReadProductsVM> FilteredProducts = _productManager.GetFilter(id);

            return View(FilteredProducts);
        }

    }
}
