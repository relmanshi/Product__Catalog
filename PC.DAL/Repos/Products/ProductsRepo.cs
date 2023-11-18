using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC.DAL;

public class ProductsRepo : IProductsRepo
{
    private readonly ProductCatalogContext _context;
    public ProductsRepo(ProductCatalogContext context)
    {
        _context = context;

    }

    public void Add(Products products)
    {
        _context.Set<Products>().Add(products);
    }

    public void Delete(Products products)
    {
        _context.Set<Products>().Remove(products);
    }

    public void Update(Products products)
    {

    }

    public IEnumerable<Products> GetAllProducts()
    {
        return _context.Set<Products>();
    }

    public Products? GetById(Guid id)
    {
        return _context.Products.Include(x => x.Categories)
            .Include(x => x.User)
            .FirstOrDefault(x => x.ProductId == id);
    }

    public IEnumerable<Products> GetCurrent()
    {
        return _context.Products.Where(x=>x.StartDate.AddDays(x.duration)>DateTime.Now);
    }

    public IEnumerable<Products> GetProductsByCatId(Guid id)
    {
        return _context.Products.Where(x => x.CategoryId == id);
    }

    public int savechanges()
    {
        return _context.SaveChanges();
    }

   
}

