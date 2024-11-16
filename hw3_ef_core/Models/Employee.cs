using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace hw3_ef_core.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public ICollection<Task> Tasks { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public ICollection<Project> Projects { get; set; }
        public override string ToString()
        {
            string result = $"Id: {EmployeeId}, Name: {Name}\nTasks:\n";
            if (Tasks != null && Tasks.Count > 0)
            {
                foreach (var task in Tasks)
                {
                    result += "\t" + task.Name + "\n";
                }
            }
            else { result += $"\tThis employee doesn't have any tasks"; }
            result += $"Team: {Team}";
            return result;
        }
    }
}
