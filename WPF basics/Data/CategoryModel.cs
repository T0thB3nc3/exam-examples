using Jedlik.EntityFramework.Helper.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szinkronstudio.Data
{
    public class CategoryModel
    {
        public int Id { get; set; }
        [Required]
        [Unique]
        public string Name { get; set; } = null!;
    }
}
