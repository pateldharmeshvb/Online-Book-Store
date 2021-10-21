using OnlineBookstore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBookstore.Domain.Entities
{
    public class Author : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string Topic { get; set; }
        public DateTime Dob { get; set; }
    }
}
