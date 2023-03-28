using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxima.Models
{
    public class AdditionalImg
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ValidateNever]         
        public string AdditionalImgUrl { get; set; }
        public int TovarId { get; set; }


    }
}
