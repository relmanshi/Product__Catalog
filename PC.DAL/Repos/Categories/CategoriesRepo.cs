using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PC.DAL;
public class CategoriesRepo : ICategoriesRepo
{
    private readonly ProductCatalogContext _context;
    public CategoriesRepo(ProductCatalogContext context)
    {
        _context = context;

    }

    public IEnumerable<Categories> GetCategories()
    {
        return _context.Set<Categories>();

    }
}

