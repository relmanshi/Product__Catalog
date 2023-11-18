using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PC.DAL;
namespace PC.BL;

public class CategoryManager : ICategoryManager

{
    private readonly ICategoriesRepo _categorieRepo;
    public CategoryManager (ICategoriesRepo categorieRepo)
    {
        _categorieRepo = categorieRepo;
    }
    public IEnumerable<ReadCategoriesVM> GetAllCategories()
    {
        IEnumerable<Categories>dbcategories=_categorieRepo.GetCategories();
        if (dbcategories is null)
        {
            return null;
        }
        IEnumerable<ReadCategoriesVM> vmcategories = dbcategories
            .Select(c => new ReadCategoriesVM
            {
                CategoryId= c.CategoryId,
                CategoryName= c.CategoryName,
            });
        return vmcategories;
    }
}
