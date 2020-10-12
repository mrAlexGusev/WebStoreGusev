using System.Collections.Generic;
using System.Linq;
using WebStoreGusev.Domain.DTO.Products;
using WebStoreGusev.Domain.Entities;

namespace WebStoreGusev.Services.Mapping
{
    public static class ProductMapping
    {
        public static ProductDTO ToDTO(this Product product)
            => product is null ? null : new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Order = product.Order,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                Brand = product.Brand.ToDTO(),
                Category = product.Category.ToDTO()
            };

        public static Product FromDTO(this ProductDTO product)
            => product is null ? null : new Product
            {
                Id = product.Id,
                Name = product.Name,
                Order = product.Order,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                BrandId = product.Brand?.Id,
                Brand = product.Brand.FromDTO(),
                CategoryId = product.Category.Id,
                Category = product.Category.FromDTO()
            };

        public static IEnumerable<Product> FromDTO(this IEnumerable<ProductDTO> products)
            => products?.Select(FromDTO);
    }
}
