using WebStoreGusev.Domain.Entities.Base.Interfaces;

namespace WebStoreGusev.Domain.Entities.Base
{
    public abstract class NamedEntity : INamedEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
