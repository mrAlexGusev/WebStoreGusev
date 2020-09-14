namespace WebStoreGusev.Domain.Entities.Base.Interfaces
{
    /// <summary>
    /// Базовая сущность с ID.
    /// </summary>
    public interface IBaseEntity
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        int Id { get; set; }
    }
}
