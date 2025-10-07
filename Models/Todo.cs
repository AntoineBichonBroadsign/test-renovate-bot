namespace TestRenovateBotAPI.Models;

/// <summary>
/// Represents a todo item
/// </summary>
public class Todo
{
    /// <summary>
    /// Unique identifier for the todo item
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Title of the todo item
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Description of the todo item
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Indicates whether the todo item is completed
    /// </summary>
    public bool IsCompleted { get; set; }

    /// <summary>
    /// Date when the todo item was created
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}