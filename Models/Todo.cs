namespace MeuTodo.Models
{
    /// <summary>
    /// Representa uma tarefa Todo.
    /// </summary>
    public class Todo
    {
        /// <summary>
        /// Obtém ou define o ID da tarefa.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtém ou define o título da tarefa.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Obtém ou define um valor que indica se a tarefa foi concluída.
        /// </summary>
        public bool Done { get; set; }

        /// <summary>
        /// Obtém ou define a data da tarefa.
        /// </summary>
        public DateTime Date { get; set; } = DateTime.Now;
    }
}