using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context.Entity
{
    public class SubCategory
    {
        public int SubCategoryId { get; set; }
        public string? SubCategoryName { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }
    }
}
