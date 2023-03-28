using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxima.Models
{
    public class Size
    {
        [Key]
        public int Id { get; set; }
        [Required]    
        public string DisplayName { get; set; }
        [Required]
        public string Name { get; set; }        
        [Range(1, 100, ErrorMessage = "Range of 1 to 100")]
        public int Count { get; set; }
        public int TovarId { get; set; }

    }
}
