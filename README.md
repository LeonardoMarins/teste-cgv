# Gestao de Advogados - CRUD ASP.NET MVC 5

Sistema de cadastro de advogados desenvolvido com **ASP.NET MVC 5** e **.NET Framework 4.8**, seguindo os padroes **MVC**, **Repository Pattern** e **ViewModel**.

---

## Funcionalidades

- CRUD completo: cadastro, edicao, visualizacao e exclusao de advogados
- Campos: Nome, Senioridade e Endereco (logradouro, bairro, estado, CEP, numero e complemento)
- Senioridade via enum (Junior, Pleno, Senior) renderizado como combo
- Estado via enum com todos os estados brasileiros renderizado como combo
- Mascara de CEP (00000-000) e restricao numerica no campo Numero via jQuery Mask Plugin
- Validacoes com DataAnnotations e ValidationMessage por campo
- ViewModels serializaveis com mapeamento manual entre dominio e apresentacao

---

## Tecnologias utilizadas

| Tecnologia | Uso |
|---|---|
| ASP.NET MVC 5 | Framework web |
| .NET Framework 4.8 | Plataforma |
| C# | Linguagem |
| Razor | Engine de views |
| Bootstrap 3 | Estilizacao |
| jQuery + jQuery Mask Plugin | Mascaras de input |
| Repository Pattern | Abstracao de dados |
| Armazenamento em memoria | Singleton LawyerContext |

---

## Estrutura do projeto

```
GestaoAdvogados/
+-- Domain/                          # Camada de dominio
|   +-- Entity/
|       +-- Lawyer.cs                # Entidade principal
|       +-- Address.cs               # Value Object de endereco
|       +-- Seniority.cs             # Enum de senioridade
|       +-- Estado.cs                # Enum de estados brasileiros
|
+-- Repository/                      # Camada de dados
|   +-- Interface/
|   |   +-- ILawyerRepository.cs    # Contrato do repositorio
|   +-- Implements/
|       +-- LawyerContext.cs         # Contexto em memoria (Singleton)
|       +-- LawyerRepository.cs      # Implementacao do repositorio
|
+-- GestaoAdvogados/                 # Projeto web (MVC)
    +-- Controllers/
    |   +-- LawyerController.cs      # Controller com mapeamento ViewModel <-> Entity
    +-- ViewModels/
    |   +-- LawyerViewModel.cs       # ViewModel do advogado
    |   +-- AddressViewModel.cs      # ViewModel do endereco
    +-- Views/
        +-- Lawyer/
            +-- Index.cshtml         # Listagem
            +-- Create.cshtml        # Cadastro
            +-- Edit.cshtml          # Edicao
            +-- Details.cshtml       # Detalhes
            +-- Delete.cshtml        # Confirmacao de exclusao
```

---

## Como executar

### Pre-requisitos

- **Visual Studio 2019 ou 2022** (Community ou superior)
- **.NET Framework 4.8** instalado (incluso no Windows 10/11)
- **NuGet Package Manager** (incluso no Visual Studio)

### Passo a passo

1. **Clone o repositorio:**
   ```bash
   git clone https://github.com/LeonardoMarins/teste-cgv.git
Abra a solucao GestaoAdvogados.sln no Visual Studio

Defina o projeto de inicializacao: clique direito em GestaoAdvogados > Set as Startup Project

Limpe e recompile a solucao:

Menu Build > Clean Solution
Menu Build > Rebuild Solution
Execute: pressione F5 ou clique em IIS Express

A aplicacao abrira automaticamente em http://localhost:{porta}/Lawyer

Nota: os dados sao armazenados em memoria e serao perdidos ao reiniciar a aplicacao. Nao e necessario configurar banco de dados.
