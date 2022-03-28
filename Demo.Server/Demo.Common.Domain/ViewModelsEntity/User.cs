using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Common.Domain.ViewModelsEntity
{
    [Table("UserName1")]
    public class User
    {
        [Key]
        public int PK_ID { get; set; }

        [StringLength(20)]
        public string UserName { get; set; } = string.Empty;
        [StringLength(110)]
        public string PasswordHash { get; set; } = string.Empty;
        [StringLength(50)]
        public string Email { get; set; } = string.Empty;
        [StringLength(10)]
        public string NumberPhone { get; set; } = string.Empty;
    }
}
