using System.ComponentModel.DataAnnotations;
namespace TaskManagement.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class TaskItem
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string TaskTitle { get; set; }

        [Required]
        [StringLength(500)]
        public string TaskDescription { get; set; }

        [Required]
        public DateTime TaskDueDate { get; set; }

        [Required]
        public string TaskStatus { get; set; }

        public string? TaskRemarks { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public DateTime CreatedOn { get; set; }

        public DateTime LastUpdatedOn { get; set; }

        public string? CreatedBy { get; set; }
        public string? LastUpdatedBy { get; set; }
    }

}
