using WebStoreGusev.Domain.DTO.Products;
using WebStoreGusev.Domain.Entities;

namespace WebStoreGusev.Services.Mapping
{
    public static class BrandMapping
    {
        public static BrandDTO ToDTO(this Brand brand)
            => brand is null ? null : new BrandDTO
            {
                Id = brand.Id,
                Name = brand.Name
            };

        public static Brand FromDTO(this BrandDTO brand)
            => brand is null ? null : new Brand
            {
                Id = brand.Id,
                Name = brand.Name
            };
    }
}
