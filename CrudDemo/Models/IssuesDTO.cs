using System;
using System.ComponentModel.DataAnnotations;
namespace CrudDemo.Models
{
    public class IssuesDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public string IssueType { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Completed { get; set; }
    }
}

