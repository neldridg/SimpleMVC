using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebApp.EntityModels.Models
{
    public class Phone
    {
        [Key]
        public int PhoneId { get; set; }
        [MaxLength(500)]
        public string Name { get; set; }
        [DefaultValue("Android")]
        public string OperatingSystem { get; set; }

        public Manufacturer Manufacturer { get; set; }
    }
}
