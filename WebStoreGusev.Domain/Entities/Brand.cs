using System;
using System.Collections.Generic;
using System.Text;
using WebStoreGusev.Domain.Entities.Base;
using WebStoreGusev.Domain.Entities.Base.Interfaces;

namespace WebStoreGusev.Domain.Entities
{
    public class Brand : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
    }
}
