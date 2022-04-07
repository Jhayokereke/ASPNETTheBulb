using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDemo.Models
{
    public class ClassViewModel
    {
        [Required]
        [Range(0, 15, ErrorMessage = "Not within range!")]
        public int Capacity { get; set; }
        [Required]
        [RegularExpression(@"^[^*|\"":<>[\]{}?#`\%_\()'=;@&$]+$", ErrorMessage = "Not a valid name!")]
        public string Name { get; set; }
        public Dictionary<string, List<string>> BestStudents { get; set; }
    }
}
