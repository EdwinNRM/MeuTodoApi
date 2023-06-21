using MeuTodo.Models;
using Microsoft.EntityFrameworkCore;

namespace MeuTodo.Data
{
    /// <summary>
    /// Representa o contexto do banco de dados da aplicação.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Obtém ou define um conjunto de entidades de tarefas.
        /// </summary>
        public DbSet<Todo> Todos { get; set; }

        /// <summary>
        /// Configura as opções de conexão do contexto do banco de dados.
        /// </summary>
        /// <param name="optionsBuilder">Construtor de opções para o contexto do banco de dados.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
            => optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");
    }
}