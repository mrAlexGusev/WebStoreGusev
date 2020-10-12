using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebStoreGusev.Domain.Entities;
using WebStoreGusev.Infrastructure.Interfaces;
using WebStoreGusev.Services.Mapping;
using WebStoreGusev.ViewModels;

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
                Products = products
                    .FromDTO()
                    .Select(ProductMapping.ToView)
                    .OrderBy(p => p.Order)
            };

            return View(model);
        }

        public IActionResult ProductDetails(int id)
        {
            var product = productService.GetProductById(id);

            if (product is null) { return RedirectToAction("NotFound", "Home"); }

            return View(product.FromDTO().ToView());
        }
    }
}
