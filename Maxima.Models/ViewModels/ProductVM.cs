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
        public Size Size { get; set; }

        [ValidateNever]
        public IEnumerable<Size> SizeList { get; set; }

        [ValidateNever]
        public AdditionalImg AdditionalImg  { get; set; }

        [ValidateNever]
        public IEnumerable<AdditionalImg> AdditionalImgList { get; set; }

    }
}
