using Jedlik.EntityFramework.Helper.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szinkronstudio.Data
{
    public class MovieModel
    {
        [Required]
        public string? Id { get; set; }
        [Required]
        public string? Title  { get; set; }
        [Required]
        public int Length { get; set; } = 0;
        [Required]
        public string? DubProducer { get; set; }
        public CategoryModel Category { get; set; } = null!;
        public int CategoryId { get; set; }
        public DateTime? AnnouncedInHungary { get; set; }
    }
}
