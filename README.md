```markdown
# PeopleUXComex

## Descrição

PeopleUXComex é um projeto de gerenciamento de cadastros de pessoas e seus endereços. Ele permite criar, editar,
excluir e listar cadastros de pessoas, bem como adicionar endereços aos cadastros existentes. Este projeto foi
desenvolvido utilizando ASP.NET Core, Entity Framework Core e Dapper, com uma integração completa com um projeto
de banco de dados.

## Funcionalidades

- **Cadastro de Pessoas**: Permite criar, editar e excluir cadastros de pessoas.
- **Cadastro de Endereços**: Permite adicionar, editar e excluir endereços para pessoas cadastradas.
- **Listagem de Pessoas e Endereços**: Exibe uma lista de todas as pessoas cadastradas e seus respectivos endereços.

## Estrutura do Projeto

- **PeopleUXComex.Application**: Contém serviços que encapsulam a lógica de negócios.
- **PeopleUXComex.Core**: Contém as entidades e interfaces principais do domínio.
- **PeopleUXComex.Infrastructure**: Contém a implementação dos repositórios, a configuração do DbContext e a integração com o Dapper.
- **PeopleUXComex.Web**: Contém os controladores, modelos de visualização e views.

## Pré-requisitos

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) ou [LocalDB](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver15)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)

## Configuração do Projeto

### Clonar o Repositório

```bash
git clone https://github.com/SeuUsuario/PeopleUXComex.git
cd PeopleUXComex
```

### Configurar o Banco de Dados

1. **Publicar o Projeto de Banco de Dados**:
   - Abra o Visual Studio.
   - No Solution Explorer, clique com o botão direito no projeto `PeopleUXComexDb` e selecione `Publish`.
   - Configure a conexão com o servidor SQL Server local (por exemplo, LocalDB) e clique em `Publish`.

2. **Configurar a String de Conexão**:
   - Abra o arquivo `appsettings.json` no projeto `PeopleUXComex.Web` e configure a string de conexão conforme necessário:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=PeopleUXComexDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*"
}
```

### Executar Migrações

1. **Adicionar e Aplicar Migrações**:
   - Abra o Console do Gerenciador de Pacotes (Tools > NuGet Package Manager > Package Manager Console).
   - Adicione uma nova migração:

   ```powershell
   Add-Migration InitialCreate
   ```

   - Aplique as migrações ao banco de dados:

   ```powershell
   Update-Database
   ```

### Executar o Projeto

1. **Compilar e Executar**:
   - No Visual Studio, selecione o projeto `PeopleUXComex.Web` como o projeto de inicialização.
   - Pressione `F5` para compilar e executar o projeto.

## Estrutura dos Arquivos

- **PeopleUXComex.Application**:
  - `Services`: Contém serviços de aplicação (e.g., `PersonService`, `AddressService`).

- **PeopleUXComex.Core**:
  - `Entities`: Contém as entidades principais (e.g., `Person`, `Address`).
  - `Interfaces`: Contém interfaces dos repositórios (e.g., `IPersonRepository`, `IAddressRepository`).

- **PeopleUXComex.Infrastructure**:
  - `Data`: Contém a implementação dos repositórios, a configuração do `DbContext` e a integração com o Dapper.

- **PeopleUXComex.Web**:
  - `Controllers`: Contém os controladores MVC (e.g., `PersonViewController`, `AddressController`).
  - `Models`: Contém os modelos de visualização (e.g., `EditPersonViewModel`).
  - `Views`: Contém as views Razor (e.g., `Create.cshtml`, `Edit.cshtml`, `Index.cshtml`).

## Etapas de Desenvolvimento

### Funcionalidades Pendentes

- **Cadastro de Endereços**: Atualmente, a funcionalidade de adicionar endereços ao cadastro de pessoas está com problemas e precisa de desenvolvimento adicional. Especificamente, ao tentar adicionar um endereço, a aplicação está retornando erros de validação indicando que campos obrigatórios (CEP, City, State, Street) não estão sendo preenchidos corretamente. Esta etapa requer correção para garantir que os endereços sejam salvos corretamente no banco de dados.


## Licença

Este projeto está licenciado sob a Licença MIT. Consulte o arquivo `LICENSE` para obter mais informações.
