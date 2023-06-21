using MeuTodo.Data;
using MeuTodo.Models;
using MeuTodo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeuTodo.Controllers
{
    /// <summary>
    /// Controlador para manipulação de tarefas Todo.
    /// </summary>
    [ApiController]
    [Route("v1")]
    public class TodoController : ControllerBase
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Inicializa uma nova instância do controlador TodoController.
        /// </summary>
        /// <param name="context">Contexto do banco de dados do aplicativo.</param>
        public TodoController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtém todas as tarefas.
        /// </summary>
        /// <returns>Uma lista de todas as tarefas.</returns>
        [HttpGet]
        [Route("todos")]
        public async Task<IActionResult> GetAsync()
        {
            var todos = await _context
                .Todos
                .ToListAsync();

            return Ok(todos);
        }

        /// <summary>
        /// Obtém uma tarefa por ID.
        /// </summary>
        /// <param name="id">O ID da tarefa.</param>
        /// <returns>A tarefa correspondente ao ID fornecido.</returns>
        [HttpGet]
        [Route("todos/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var todo = await _context
                .Todos
                .FirstOrDefaultAsync(x => x.Id == id);

            return todo == null
                ? NotFound()
                : Ok(todo);
        }

        /// <summary>
        /// Cria uma nova tarefa.
        /// </summary>
        /// <param name="model">Os dados para criar a nova tarefa.</param>
        /// <returns>A tarefa recém-criada.</returns>
        [HttpPost]
        [Route("todos")]
        public async Task<IActionResult> PostAsync(CreateTodoViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var todo = new Todo
            {
                Date = DateTime.Now,
                Done = false,
                Title = model.Title
            };

            try
            {
                await _context
                    .Todos
                    .AddAsync(todo);

                await _context
                    .SaveChangesAsync();

                return Created($"v1/todo/{todo.Id}", todo);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Atualiza uma tarefa existente.
        /// </summary>
        /// <param name="model">Os novos dados para atualizar a tarefa.</param>
        /// <param name="id">O ID da tarefa a ser atualizada.</param>
        /// <returns>A tarefa atualizada.</returns>
        [HttpPut]
        [Route("todos/{id}")]
        public async Task<IActionResult> PutAsync(CreateTodoViewModel model, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var todo = await _context
                .Todos
                .FirstOrDefaultAsync(x => x.Id == id);
            if (todo == null)
                return NotFound();

            try
            {
                todo.Title = model.Title;

                _context.Todos.Update(todo);
                await _context.SaveChangesAsync();
                return Ok(todo);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Exclui uma tarefa existente.
        /// </summary>
        /// <param name="id">O ID da tarefa a ser excluída.</param>
        /// <returns>Um resultado de sucesso se a exclusão for bem-sucedida.</returns>
        [HttpDelete]
        [Route("todos/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var todo = await _context
                .Todos
                .FirstOrDefaultAsync(x => x.Id == id);
            try
            {
                _context.Todos.Remove(todo);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
