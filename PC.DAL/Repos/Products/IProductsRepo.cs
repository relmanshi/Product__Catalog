using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC.DAL;

public interface IProductsRepo
{
    IEnumerable<Products>GetAllProducts();
    IEnumerable<Products> GetProductsByCatId(Guid id);
    IEnumerable<Products> GetCurrent();

    Products GetById(Guid id);

    void Add(Products products);
    void Update(Products products);
    void Delete(Products products);

    int savechanges();


}
