using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebStoreGusev.Domain;
using WebStoreGusev.Infrastructure.Interfaces;
using WebStoreGusev.Models;

namespace WebStoreGusev.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IProductService productService;

        public CatalogController(IProductService productService)
        {
            this.productService = productService;
        }

        //public IActionResult ProductDetails()
        //{
        //    return View();
        //}

        public IActionResult Shop(int? categoryId, int? brandId)
        {
            var products = productService.GetProducts(
                new ProductFilter { BrandId = brandId, CategoryId = categoryId });

            var model = new CatalogViewModel()
            {
                BrandId = brandId,
                CategoryId = categoryId,
                Products = products.Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Order = p.Order,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    Brand = p.Brand?.Name ?? string.Empty
                }).OrderBy(p => p.Order)
                    .ToList()
            };

            return View(model);
        }

        public IActionResult ProductDetails(int id)
        {
            var product = productService.GetProductById(id);

            if (ReferenceEquals(product, null)) return RedirectToAction("NotFound", "Home");

            var model = new ProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Order = product.Order,
                ImageUrl = product.ImageUrl,
                Brand = product.Brand != null ? product.Brand.Name : string.Empty
            };

            return View(model);
        }
    }
}
