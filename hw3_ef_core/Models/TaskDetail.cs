using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;


namespace hw3_ef_core.Models
{
    public class TaskDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskDetailId { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        public Task Task { get; set; }
    }
}
