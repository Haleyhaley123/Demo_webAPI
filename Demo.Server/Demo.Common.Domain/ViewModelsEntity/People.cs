using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Common.Domain.ViewModelsEntity
{
    [Table("ListData")]
    public class People
    {
        [Key]
        public int PK_IDList { get; set; } 
        public string? ID { get; set; }
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public int Age { get; set; }
        public string? Department { get; set; }
        public DateTime Birthday { get; set; }
        public string? NumberPhone { get; set; }
    }
}
