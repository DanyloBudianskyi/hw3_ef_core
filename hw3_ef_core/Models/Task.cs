using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw3_ef_core.Models
{
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public TaskDetail Detail { get; set; }
    }
}
