using WebStoreGusev.Domain.DTO.Products;
using WebStoreGusev.Domain.Entities;

namespace WebStoreGusev.Services.Mapping
{
    public static class CategoryMapping
    {
        public static CategoryDTO ToDTO(this Category category)
            => category is null ? null : new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name
            };

        public static Category FromDTO(this CategoryDTO category)
            => category is null ? null : new Category
            {
                Id = category.Id,
                Name = category.Name
            };
    }
}
