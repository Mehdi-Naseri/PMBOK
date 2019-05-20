using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pmbok.DomainClasses.Models
{
    [Table("Project", Schema = "Projects")]
    public class Project
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Column(TypeName ="date")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}
