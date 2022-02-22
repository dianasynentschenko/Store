using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxima.Models
{
    public class Test
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TestSize { get; set; }        
        [Range(1, 100, ErrorMessage = "Range of 1 to 100")]
        public int Quantity { get; set; }

        public int TovarId { get; set; }
    }
}
