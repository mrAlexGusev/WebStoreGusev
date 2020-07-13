using System;
using System.Collections.Generic;
using System.Text;

namespace WebStoreGusev.Domain.Entities.Base.Interfaces
{
    public interface INamedEntity : IBaseEntity
    {
        string Name { get; set; }
    }
}
