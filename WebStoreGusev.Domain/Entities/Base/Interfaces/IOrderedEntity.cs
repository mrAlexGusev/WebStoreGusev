using System;
using System.Collections.Generic;
using System.Text;

namespace WebStoreGusev.Domain.Entities.Base.Interfaces
{
    public interface IOrderedEntity
    {
        int Order { get; set; }
    }
}
