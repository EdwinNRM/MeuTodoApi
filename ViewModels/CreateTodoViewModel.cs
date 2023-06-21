using System.ComponentModel.DataAnnotations;

namespace MeuTodo.ViewModels
{
    /// <summary>
    /// Representa o modelo de visualização para criação de uma nova tarefa.
    /// </summary>
    public class CreateTodoViewModel
    {
        /// <summary>
        /// Obtém ou define o título da tarefa.
        /// </summary>
        [Required]
        public string? Title { get; set; }
    }
}