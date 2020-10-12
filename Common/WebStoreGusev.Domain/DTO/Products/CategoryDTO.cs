using WebStoreGusev.Domain.Entities.Base.Interfaces;

namespace WebStoreGusev.Domain.DTO.Products
{
    public class CategoryDTO : INamedEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

    }
}
