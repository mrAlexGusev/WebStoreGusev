using System;
using System.Collections.Generic;
using System.Text;
using WebStoreGusev.Domain.Entities.Base.Interfaces;

namespace WebStoreGusev.Domain.Entities.Base
{
    public abstract class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
    }
}
