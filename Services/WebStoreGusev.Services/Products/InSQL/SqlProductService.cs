using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebStoreGusev.DAL;
using WebStoreGusev.Domain.DTO.Products;
using WebStoreGusev.Domain.Entities;
using WebStoreGusev.Infrastructure.Interfaces;
using WebStoreGusev.Services.Mapping;

namespace WebStoreGusev.Infrastructure.Services.InSQL
{
    public class SqlProductService : IProductService
    {
        private readonly WebStoreContext context;

        public SqlProductService(WebStoreContext context)
        {
            this.context = context;
        }

        public IEnumerable<Brand> GetBrands()
        {
            return context.Brands.ToList();
        }

        public IEnumerable<Category> GetCategories()
        {
            return context.Categories.ToList();
        }

        public ProductDTO GetProductById(int id)
        {
            //return context.Products.FirstOrDefault(x => x.Id.Equals(id));

            // Жадная загрузка (Eager Load).
            return context.Products
                .Include(x => x.Category)
                .Include(x => x.Brand)
                .FirstOrDefault(x => x.Id.Equals(id))
                .ToDTO();
        }

        public IEnumerable<ProductDTO> GetProducts(ProductFilter filter)
        {
            var query = context.Products
                .Include(x => x.Category)
                .Include(x => x.Brand)
                .AsQueryable();

            if (filter.BrandId.HasValue)
                query = query.Where(c => c.BrandId.HasValue && c.BrandId.Value.Equals(filter.BrandId.Value));

            if (filter.CategoryId.HasValue)
                query = query.Where(c => c.CategoryId.Equals(filter.CategoryId.Value));

            return query.AsEnumerable().ToDTO();
        }
    }
}
