using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxima.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Display Orders")]
        [Range(1, 100, ErrorMessage = "Range of 1 to 100")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDataTime { get; set; } = DateTime.Now;
    }
}
