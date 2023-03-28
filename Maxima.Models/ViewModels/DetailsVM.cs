using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxima.Models.ViewModels
{
    public class DetailsVM
    {

        public DetailsVM()
        {
            Product = new Product();
        }

        public Product Product { get; set; }
    }
}
