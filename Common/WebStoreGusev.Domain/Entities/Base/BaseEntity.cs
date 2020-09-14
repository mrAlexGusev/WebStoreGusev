using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebStoreGusev.Domain.Entities.Base.Interfaces;

namespace WebStoreGusev.Domain.Entities.Base
{
    /// <summary>
    /// Базовая сущность.
    /// </summary>
    public class BaseEntity : IBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
