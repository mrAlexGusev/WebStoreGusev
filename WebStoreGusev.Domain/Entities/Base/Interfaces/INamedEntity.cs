
namespace WebStoreGusev.Domain.Entities.Base.Interfaces
{
    /// <summary>
    /// Сущность с Наименованием.
    /// </summary>
    public interface INamedEntity : IBaseEntity
    {
        /// <summary>
        /// Наименование.
        /// </summary>
        string Name { get; set; }
    }
}
