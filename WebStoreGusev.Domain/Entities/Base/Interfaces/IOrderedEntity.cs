
namespace WebStoreGusev.Domain.Entities.Base.Interfaces
{
    /// <summary>
    /// Сущность с Порядком.
    /// </summary>
    public interface IOrderedEntity
    {
        /// <summary>
        /// Порядок. 
        /// </summary>
        int Order { get; set; }
    }
}
