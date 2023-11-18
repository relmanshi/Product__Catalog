using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC.BL;
public interface IProductManager
{
    IEnumerable<ReadProductsVM> GetAllProducts();
    IEnumerable<ReadProductsVM> GetCurrentProducts();
    IEnumerable<ReadProductsVM> GetFilter(Guid categoryId);
    void Add(AddProductVM vmproduct, string id);
    ProductDetailsVM GetDetails(Guid productId);
    void Delete (Guid productId);
    ProductUpdateVM GetProducttobeUpdate(Guid productId);
    void update (ProductUpdateVM productUpdate);
}
