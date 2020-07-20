using System.Collections.Generic;
using System.Linq;
using WebStoreGusev.DAL;
using WebStoreGusev.Domain;
using WebStoreGusev.Domain.Entities;
using WebStoreGusev.Infrastructure.Interfaces;

namespace WebStoreGusev.Infrastructure.Services
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

        public IEnumerable<Product> GetProducts(ProductFilter filter)
        {
            var query = context.Products.AsQueryable();

            if (filter.BrandId.HasValue)
                query = query.Where(c => c.BrandId.HasValue && c.BrandId.Value.Equals(filter.BrandId.Value));

            if (filter.CategoryId.HasValue)
                query = query.Where(c => c.CategoryId.Equals(filter.CategoryId.Value));

            return query.ToList();
        }
    }
}
