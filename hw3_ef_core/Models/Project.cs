using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw3_ef_core.Models
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectId { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public ICollection<Task> Tasks { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
