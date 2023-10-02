using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public String Title { get; set; }
    }
}
