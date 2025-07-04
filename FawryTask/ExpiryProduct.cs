using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryTask
{
    class ExpiryProduct:Product
    {
        public DateTime? ExpiryDate { get; set; }
        public bool IsExpired() =>ExpiryDate.HasValue && DateTime.Now > ExpiryDate.Value;
    }
}
