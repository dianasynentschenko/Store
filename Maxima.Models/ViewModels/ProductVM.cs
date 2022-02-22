using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Maxima.Models.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> CategoryList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> SizeList { get; set; }

        [ValidateNever]
        public IEnumerable<Test> TestList { get; set; }

        [ValidateNever]
        public Test Test { get; set; }
    }
}
