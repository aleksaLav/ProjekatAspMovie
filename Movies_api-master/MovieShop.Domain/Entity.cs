using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Domain
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? SoftDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}
