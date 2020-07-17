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

        public IActionResult ProductDetails()
        {
            return View();
        }

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
                    Price = p.Price
                }).OrderBy(p => p.Order)
                    .ToList()
            };

            return View(model);
        }
    }
}
