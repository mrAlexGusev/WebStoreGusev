using WebStoreGusev.Domain.Entities.Base.Interfaces;

namespace WebStoreGusev.Domain.Entities.Base
{
    public abstract class NamedEntity : BaseEntity, INamedEntity
    {
        public string Name { get; set; }
    }
}
