using WebStoreGusev.Domain.Entities.Base.Interfaces;

namespace WebStoreGusev.Domain.DTO.Products
{
    public class BrandDTO : INamedEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
    }
}
