## 📦 Estrutura dos Projetos

Esta solução é composta por vários projetos do tipo **Class Library**, cada um com responsabilidades bem definidas:

### 🔹 Util
- **Extensions:** Métodos de extensão como `GetDescription`, `GetTypeAttribute`, e `NotFound` (com suporte a gênero).
- **Mensagens e Responses:** Utilitários para mensagens consistentes e respostas padronizadas.
- **LoggerFactoryConfiguration:** Configuração e personalização do sistema de logging.
- **GlobalizationConfiguration:** Suporte à internacionalização, com recursos de tradução e formatos regionais.
- **Dictionaries:** Classe utilitária que fornece listas fixas (Dictionary<int, string>) para preenchimento de comboboxes e enums simulados no frontend (ex: status, meses, modalidades de curso etc).

### 🔹 Domain
- **Interfaces:** Contratos de serviços e entidades e repositórios.
- **RepositoryBase / IRepositoryBase:** Implementação do padrão repositório genérico para facilitar o acesso e manipulação de dados com suporte a operações assíncronas.
- **Services:** Lógica de negócio reutilizável.
- **Entities:** Representações de dados e modelos base.
- **Notifications:** Sistema de notificações para regras de negócio e feedbacks.
- **Filters:** Representação de classe abstrata de FilterBase

### 🔹 Logger
- **CustomLogger:** Implementação de logger customizado.
- **CustomLoggerProvider:** Provedor adaptável para integração com diversos sistemas de log.
- **CustomLoggerProviderConfiguration:** Configurações ajustáveis para múltiplos ambientes.

### 🔹 Application
- **Filters:** Representação de Classe abstrata FilterBaseDTO

---

## ⚙️ Funcionalidades Principais

### ✅ QueryHelper - Filtros e Ordenação Dinâmica

#### `ApplyFilter<TFilter, TEntity>`
Aplica filtros dinâmicos em uma consulta `IQueryable<TEntity>` usando um objeto `TFilter`. Apenas propriedades marcadas com `[Filterable]` são consideradas.

**Características:**
- Suporte a `==`, `>=`, `<=`, `Contains`
- Intervalos com sufixos `From` e `To`
- Ignora propriedades nulas ou vazias

**Exemplo:**
```csharp
var result = QueryHelper.ApplyFilter<CourseFilter, CourseEntity>(query, filter);
```

#### `ApplySorting<T>`
Aplica ordenação dinâmica com base na propriedade e direção informada (`asc` ou `desc`).

**Exemplo:**
```csharp
var sorted = QueryHelper.ApplySorting<CourseEntity>(query, "Title", "desc");
```
---

## 🗂️ Repository Pattern - Repositório Genérico
O projeto `TKMaster.Common.Domain` implementa um repositório genérico baseado no padrão Repository, com a interface `IRepositoryBase<TEntity>` e sua respectiva implementação `RepositoryBase<TEntity>`. Essa estrutura fornece uma forma padronizada de realizar operações de dados com suporte a LINQ, `IQueryable` e métodos assíncronos.

- **Busca e Consulta**
  - `GetByCodeAsync(int code)`
  - `GetByNameAsync(string name)`
  - `SearchAsync(Expression<Func<TEntity, bool>> predicate)`
  - `ListAllAsync()`
  - `ExistAsync(int code)`
  - `ToObtain()` → Retorna `IQueryable<TEntity>` para composições avançadas

- **Manipulação de Dados**
  - `ToAdd(...)`, `ToUpdate(...)`, `Remover(...)` com sobrecargas para entidades únicas ou múltiplas
  - Suporte à atualização e persistência em dois contextos: principal e de identidade

- **Persistência**
  - `ToSaveAsync()` para salvar no contexto principal
  - `SaveIdentityAsync()` para salvar alterações no contexto de identidade
  
 ### 🔄 Benefícios

- Reutilização de lógica de acesso a dados
- Centralização das operações CRUD
- Interface desacoplada facilita testes e manutenção
- Suporte a múltiplos contextos (`DbContext` e `IdentityContext`)
 
---

## 💡 Extensões Incluídas

- `NotFound(this string subject, bool isFeminine)`: Gera mensagens padronizadas com concordância de gênero.
- Diversos métodos utilitários para manipulação de strings, enums e expressões.

---

## 📦 Dependências Necessárias

```bash
dotnet add package System.Linq.Dynamic.Core
```

```csharp
using TKMaster.Common.Util.Helpers;
```

---

## 🚀 Sugestões Futuras

- Suporte a `List<int>` e `List<string>` com `Contains`
- Combinação de filtros `AND` / `OR`
- Tradução de nomes de campos com `[Filterable("Contains", Target = "Title,Description")]`
- Integração com Swagger para exibição de filtros dinamicamente

---

## 🛠️ Tecnologias

![tecnologias](https://skillicons.dev/icons?i=cs,dotnet,visualstudio)

---

## 📄 Licença

Este projeto é licenciado sob os termos da licença MIT. Consulte o arquivo [LICENSE.txt](./LICENSE.txt) para mais informações.
