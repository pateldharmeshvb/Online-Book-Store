using OnlineBookstore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBookstore.Domain.Entities
{
    public class Book : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
    }
}
