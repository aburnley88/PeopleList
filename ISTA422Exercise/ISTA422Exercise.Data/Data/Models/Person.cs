using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ISTA422Exercise.Data.Data.Models
{
    public class Person
    {
        [Key] 
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Age { get; set; }

        public string Hobby { get; set; }

        public string Sex { get; set; }
    }
}
