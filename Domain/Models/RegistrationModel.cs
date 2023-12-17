using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class RegistrationModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Qualification { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public byte[] Image { get; set; }
    }
}
