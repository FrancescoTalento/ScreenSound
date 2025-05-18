# 🎵 ScreenSound

**ScreenSound** é uma aplicação web completa para gerenciamento de músicas, artistas e gêneros musicais.
Desenvolvida em **C# / ASP.NET Core** com **Entity Framework Core** para persistência de dados, ela expõe uma **API REST** documentada automaticamente com **Swagger / OpenAPI**. Ferramentas auxiliares de administração podem ser implementadas em **WPF**.


A solução é composta por **4 projetos** (detalhados abaixo).

---

## 🧰 Tecnologias principais

| Camada           | Tecnologia                                     |
| ---------------- | ---------------------------------------------- |
| **API**          | ASP.NET Core Web API 8.0                       |
| **ORM**          | Entity Framework Core + Migrations             |
| **Banco**        | SQL Server Express / LocalDB                   |
| **Documentação** | Swagger UI (Swashbuckle)                       |
| **IoC / DI**     | Injeção de Dependência nativa do ASP.NET Core  |
| **Serialização** | System.Text.Json + Newtonsoft.Json (loop‑safe) |

---

## 📦 Estrutura dos projetos

```text
ScreenSound.sln                # Solução
├── ScreenSoundAPI/             # Projeto Web API (endpoints REST)
│   ├── Controllers/
│   │   ├── ArtistaController.cs
│   │   ├── GeneroController.cs
│   │   └── MusicaController.cs
│   ├── Program.cs              # Bootstrapping, DI, Swagger
│   └── appsettings*.json       # Configurações / ConnectionStrings
│
├── ScreenSound.Shared.Data/    # Camada de Dados (EF Core)
│   ├── Banco/
│   │   ├── ArtistaDal.cs
│   │   ├── GeneroDal.cs
│   │   ├── MusicaDal.cs
│   │   └── ...
│   └── Migrations/             # Histórico de migrações
│
├── ScreenSound.Shared.Modelos/ # Entidades de Domínio e DTOs
│   ├── Artista.cs
│   ├── Musica.cs
│   ├── Genero.cs
│   └── DTOs/
│
└── ScreenSound/ (opcional)     # Projeto auxiliar / testes locais
```

---

## 🚀 Configuração e execução

```bash
# 1. Clonar o repositório
git clone https://github.com/<seu-usuario>/ScreenSound.git
cd ScreenSound

# 2. Criar o banco e aplicar migrações
dotnet ef database update --project ScreenSound.Shared.Data

# 3. Executar a API
dotnet run --project ScreenSoundAPI
# A API ficará disponível em https://localhost:5001 ou http://localhost:5000
```

### 🔑 ConnectionString

Edite **`ScreenSoundAPI/appsettings.json`** caso queira alterar servidor/credenciais SQL Server:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=ScreenSoundDB;Trusted_Connection=True;"
  }
}
```

---

## 📝 Endpoints REST

### 🎤 `/api/artista`

| Método | Rota                       | Descrição               | Body              |
| ------ | -------------------------- | ----------------------- | ----------------- |
| GET    | `/api/artista`             | Lista todos os artistas | —                 |
| GET    | `/api/artista/id/{id}`     | Busca artista por ID    | —                 |
| GET    | `/api/artista/name/{name}` | Busca artista por nome  | —                 |
| POST   | `/api/artista`             | Cria novo artista       | `ArtistaResumo`   |
| PUT    | `/api/artista/{id}`        | Atualiza artista        | `ArtistaCompleto` |
| DELETE | `/api/artista/{id}`        | Remove artista          | —                 |

### 🎼 `/api/genero`

| Método | Rota                      | Descrição              | Body            |
| ------ | ------------------------- | ---------------------- | --------------- |
| GET    | `/api/genero`             | Lista todos os gêneros | —               |
| GET    | `/api/genero/id/{id}`     | Busca gênero por ID    | —               |
| GET    | `/api/genero/name/{name}` | Busca gênero por nome  | —               |
| POST   | `/api/genero`             | Cria novo gênero       | `GeneroRequest` |
| PUT    | `/api/genero/{id}`        | Atualiza gênero        | `GeneroRequest` |
| DELETE | `/api/genero/{id}`        | Remove gênero          | —               |

### 🎵 `/api/musica`

| Método | Rota                      | Descrição              | Body          |
| ------ | ------------------------- | ---------------------- | ------------- |
| GET    | `/api/musica`             | Lista todas as músicas | —             |
| GET    | `/api/musica/id/{id}`     | Busca música por ID    | —             |
| GET    | `/api/musica/name/{name}` | Busca música por nome  | —             |
| POST   | `/api/musica`             | Cria nova música       | `MusicaInput` |
| PUT    | `/api/musica/{id}`        | Atualiza música        | `MusicaInput` |
| DELETE | `/api/musica/{id}`        | Remove música          | —             |

> Exemplos de payloads podem ser adicionados em `/docs/examples/*.json`.

---

## 📚 Documentação Swagger

O Swagger está configurado em `Program.cs`:

```csharp
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ScreenSound API",
        Version = "v1",
        Description = "API para gerenciamento de artistas, gêneros e músicas",
        Contact = new OpenApiContact
        {
            Name = "Francesco Talento",
            Url = new Uri("https://github.com/FrancescoTalento")
        }
    });
});
```

A UI interativa fica disponível em:

```
https://localhost:5001/swagger
```

### Comentários XML

Para que descrições apareçam no Swagger, adicione ao `.csproj` da API:

```xml
<PropertyGroup>
  <GenerateDocumentationFile>true</GenerateDocumentationFile>
  <NoWarn>$(NoWarn);1591</NoWarn>
</PropertyGroup>
```

E inclua o XML:

```csharp
var xml = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xml));
```

---

## 💡 Futuras melhorias

* 🔐 **Auth/JWT** – autenticação e autorização baseadas em papéis.
* 🗂 **AutoMapper + DTOs** – separação clara entre modelos de domínio e transporte.
* 📈 **Relatórios** – geração de CSV/PDF com estatísticas de músicas.
* 🐳 **Docker** – containerizar aplicação e banco para facilitar o deploy.

---

## 📝 Licença

Distribuído sob a **MIT License**. Veja o arquivo [LICENSE](LICENSE) para detalhes.
