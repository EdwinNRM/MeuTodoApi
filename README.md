# MeuTodoApi

MeuTodoApi é uma aplicação de lista de tarefas simples, desenvolvida em C# usando o framework ASP.NET Core e o banco de dados SQLite.

## Funcionalidades

- Exibir todas as tarefas
- Exibir uma tarefa por ID
- Criar uma nova tarefa
- Atualizar uma tarefa existente
- Excluir uma tarefa existente

## Requisitos

- .NET 6 SDK ou superior

## Configuração do Banco de Dados

A aplicação utiliza o banco de dados SQLite para armazenar as tarefas. O arquivo do banco de dados é criado automaticamente no diretório da aplicação.

## Instalação e Execução

1. Clone este repositório:

```bash
git clone https://github.com/seu-usuario/meu-todo.git
```

2. Acesse o diretório do projeto:
```bash
cd meu-todo
```

3. Execute a aplicação usando o .NET CLI:
```bash
dotnet run
```

4. Acesse a aplicação no navegador:
```bash
http://localhost:5000
```

## Documentação

### TodoController
Controlador para manipulação de tarefas Todo.

### AppDbContext
Contexto do banco de dados da aplicação.

### Todo
Classe que representa uma tarefa.

### CreateTodoViewModel
Modelo de visualização para criação de uma nova tarefa.

## Contribuição
Contribuições são bem-vindas! Sinta-se à vontade para abrir issues e pull requests.

## Licença
Este projeto está licenciado sob a MIT License.
