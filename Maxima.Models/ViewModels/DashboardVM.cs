using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxima.Models.ViewModels
{
    public class DashboardVM
    {
        public IEnumerable<Product> ProductVM { get; set; }
        public IEnumerable<Category> CategorieVM { get; set; }      
        public IEnumerable<OrderHeader> OrderHeaderVM { get; set; }
        public IEnumerable<OrderDetail> OrderDetailVM { get; set; }



    }
}
