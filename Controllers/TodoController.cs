using Microsoft.AspNetCore.Mvc;
using TestRenovateBotAPI.Models;

namespace TestRenovateBotAPI.Controllers;

/// <summary>
/// Controller for managing todo items
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class TodoController : ControllerBase
{
    private static readonly List<Todo> Todos = new()
    {
        new Todo { Id = 1, Title = "Learn .NET Core", Description = "Study .NET Core fundamentals", IsCompleted = true },
        new Todo { Id = 2, Title = "Implement Swagger", Description = "Add Swagger documentation to API", IsCompleted = true },
        new Todo { Id = 3, Title = "Add sample endpoints", Description = "Create sample CRUD endpoints", IsCompleted = false }
    };

    /// <summary>
    /// Gets all todo items
    /// </summary>
    /// <returns>A list of todo items</returns>
    /// <response code="200">Returns the list of todo items</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Todo>), StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<Todo>> GetTodos()
    {
        return Ok(Todos);
    }

    /// <summary>
    /// Gets a specific todo item by id
    /// </summary>
    /// <param name="id">The id of the todo item</param>
    /// <returns>The todo item</returns>
    /// <response code="200">Returns the todo item</response>
    /// <response code="404">If the todo item is not found</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Todo), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Todo> GetTodo(int id)
    {
        var todo = Todos.FirstOrDefault(t => t.Id == id);
        if (todo == null)
        {
            return NotFound();
        }
        return Ok(todo);
    }

    /// <summary>
    /// Creates a new todo item
    /// </summary>
    /// <param name="todo">The todo item to create</param>
    /// <returns>The created todo item</returns>
    /// <response code="201">Returns the newly created todo item</response>
    /// <response code="400">If the todo item is invalid</response>
    [HttpPost]
    [ProducesResponseType(typeof(Todo), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Todo> CreateTodo([FromBody] Todo todo)
    {
        if (string.IsNullOrWhiteSpace(todo.Title))
        {
            return BadRequest("Title is required");
        }

        todo.Id = Todos.Count > 0 ? Todos.Max(t => t.Id) + 1 : 1;
        todo.CreatedAt = DateTime.UtcNow;
        Todos.Add(todo);

        return CreatedAtAction(nameof(GetTodo), new { id = todo.Id }, todo);
    }

    /// <summary>
    /// Updates an existing todo item
    /// </summary>
    /// <param name="id">The id of the todo item to update</param>
    /// <param name="todo">The updated todo item</param>
    /// <returns>The updated todo item</returns>
    /// <response code="200">Returns the updated todo item</response>
    /// <response code="404">If the todo item is not found</response>
    /// <response code="400">If the todo item is invalid</response>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Todo), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Todo> UpdateTodo(int id, [FromBody] Todo todo)
    {
        var existingTodo = Todos.FirstOrDefault(t => t.Id == id);
        if (existingTodo == null)
        {
            return NotFound();
        }

        if (string.IsNullOrWhiteSpace(todo.Title))
        {
            return BadRequest("Title is required");
        }

        existingTodo.Title = todo.Title;
        existingTodo.Description = todo.Description;
        existingTodo.IsCompleted = todo.IsCompleted;

        return Ok(existingTodo);
    }

    /// <summary>
    /// Deletes a todo item
    /// </summary>
    /// <param name="id">The id of the todo item to delete</param>
    /// <returns>No content</returns>
    /// <response code="204">If the todo item was successfully deleted</response>
    /// <response code="404">If the todo item is not found</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteTodo(int id)
    {
        var todo = Todos.FirstOrDefault(t => t.Id == id);
        if (todo == null)
        {
            return NotFound();
        }

        Todos.Remove(todo);
        return NoContent();
    }
}