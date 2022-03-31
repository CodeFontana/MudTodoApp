using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MudTodo.Shared.Entities
{
    public class Todo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Required]
        [Column(Order = 1)]
        public bool Completed { get; set; } = false;

        [Required]
        [Column(Order = 2)]
        [MaxLength(200)]
        public string ItemName { get; set; } = "";
    }
}
