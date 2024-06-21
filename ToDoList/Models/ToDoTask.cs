using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class ToDoTask
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }
    }
}
