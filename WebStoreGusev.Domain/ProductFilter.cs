using System;
using System.Collections.Generic;
using System.Text;

namespace WebStoreGusev.Domain
{
    /// <summary>
    /// Класс фильтрации товаров.
    /// </summary>
    public class ProductFilter
    {
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
    }
}
