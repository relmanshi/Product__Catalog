using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PC.DAL;

namespace PC.BL;

public class ProductManager : IProductManager
{
    private readonly IProductsRepo _productrepo;
    public ProductManager (IProductsRepo productrepo)
    {
        _productrepo = productrepo;
    }

    #region add
    public void Add(AddProductVM vmproduct, string id)
    {
        Products products = new Products
        {
            ProductName=vmproduct.ProductName,
            CreationDate=DateTime.Now,
            StartDate=vmproduct.StartDate,
            duration=vmproduct.Duration,
            price=vmproduct.Price,
            CategoryId=vmproduct.CategoryId,
            createdBy=id
        };
        _productrepo.Add(products);
        _productrepo.savechanges();
    }
    #endregion

    #region delete

    public void Delete(Guid productId)
    {
        Products? dbproducts = _productrepo.GetById(productId);
        if(dbproducts is null)
        {
            return;
        }
        _productrepo.Delete(dbproducts);
        _productrepo.savechanges();
    }
    #endregion

    #region GetAllProducts
    public IEnumerable<ReadProductsVM> GetAllProducts()
    {
        IEnumerable<Products>dbproducts=_productrepo.GetAllProducts();
        if (dbproducts is null)
        { return null; }
            IEnumerable<ReadProductsVM> vmproducts = dbproducts
                .Select(p => new ReadProductsVM
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    Price = p.price,
                    Category = p.Categories.CategoryName
                });
            return vmproducts;
        
    }
    #endregion

    #region currentproducts
    public IEnumerable<ReadProductsVM> GetCurrentProducts()
    {
        IEnumerable<Products> dbproducts = _productrepo.GetCurrent();
        if (dbproducts is null)
        {
            return null;
        }
        IEnumerable<ReadProductsVM> vmproducts = dbproducts
            .Select(p => new ReadProductsVM
            {
                ProductId= p.ProductId,
                ProductName= p.ProductName,
                Price = p.price,
                Category= p.Categories.CategoryName
            });
        return vmproducts;
    }
    #endregion

    #region Details

    public ProductDetailsVM GetDetails(Guid productId)
    {
        Products dbproducts=_productrepo.GetById(productId);
        if(dbproducts is null)
        {
            return null;
        }
        ProductDetailsVM vmdetails = new ProductDetailsVM
        {
            ProductID = dbproducts.ProductId,
            ProductName = dbproducts.ProductName,
            Price = dbproducts.price,
            CreationDate = dbproducts.CreationDate,
            StartDate = dbproducts.StartDate,
            Duration = dbproducts.duration,
            CreatedBy=dbproducts.User.FirstName + ""+ dbproducts.User.LastName,
            Category=dbproducts.Categories.CategoryName
        };
        return vmdetails;
    }
    #endregion

    #region filter
    public IEnumerable<ReadProductsVM> GetFilter(Guid categoryId)
    {
        IEnumerable<Products>dbproducts= _productrepo.GetProductsByCatId(categoryId);
        if (dbproducts is null)
        {
            return null;
        }
        IEnumerable<ReadProductsVM> vmproducts = dbproducts
            .Select(p => new ReadProductsVM
            {
                ProductId=p.ProductId,
                ProductName= p.ProductName,
                Price= p.price,
                Category= p.Categories.CategoryName
            });
        return vmproducts;
    }


    #endregion


    #region Update
    public ProductUpdateVM GetProducttobeUpdate(Guid productId)
    {
        {
            Products? dbproduct = _productrepo.GetById(productId);

            if (dbproduct is null)
            {
                return null;
            }

            ProductUpdateVM vmproduct = new ProductUpdateVM
            {
                ProductId = dbproduct.ProductId,
                ProductName = dbproduct.ProductName,
                Price = dbproduct.price,
                StartDate = dbproduct.StartDate,
                Duration = dbproduct.duration,
                CategoryId = dbproduct.CategoryId
            };

            return vmproduct ;
        }
    }
    public void update(ProductUpdateVM productUpdate)
    {
        Products dbproducts=_productrepo.GetById(productUpdate.ProductId);
        if(dbproducts is null)
        {
             return;
        }
        dbproducts.ProductName = productUpdate.ProductName;
        dbproducts.price = productUpdate.Price;
        dbproducts.StartDate = productUpdate.StartDate;
        dbproducts.duration= productUpdate.Duration;
        dbproducts.CategoryId= productUpdate.CategoryId;
        _productrepo.savechanges();
    }
    #endregion
}
