using MeuTodo.Data;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os controladores ao serviço da aplicação.
builder.Services.AddControllers();

// Adiciona o contexto do banco de dados do aplicativo ao serviço.
builder.Services.AddDbContext<AppDbContext>();

// Constrói a aplicação.
var app = builder.Build();

// Configura o roteamento da aplicação.
app.UseRouting();

// Mapeia a rota padrão para os controladores.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Executa a aplicação.
app.Run();