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
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public string Description { get; set; }
        [Range(1, int.MaxValue)]
        public double Price { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }


        [Required]
        [Display(Name = "Size")]
        public int SizeId { get; set; }
        [ForeignKey("SizeId")]
        [ValidateNever]
        public Size Size { get; set; }

        // public List<Test> Test { get; set; }

        [ForeignKey("TovarId")]
        [ValidateNever]
        public List<Test> Test { get; set; }
    }
}
