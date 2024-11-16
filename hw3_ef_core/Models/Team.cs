﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw3_ef_core.Models
{
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeamId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}
