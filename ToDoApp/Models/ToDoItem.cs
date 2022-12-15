using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Models;

public class ToDoItem
{
    [Key] public int ItemId { get; set; }
    [Required] [StringLength(100)] public string Name { get; set; } = "";
    [Required] [StringLength(200)] public string Description { get; set; } = "";
    [Required] [DataType(DataType.Date)] public DateTime DueDate { get; set; }
    [Required] public bool CompletionStatus { get; set; }    
}