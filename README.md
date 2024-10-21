# sistema-escolar
Sistema criado em .Net
Até o momento criei a estrtutura abaixo.

SistemaEscolar/
    ├── SistemaEscolar.Domain/
    │   ├── Entities/
    │   │   ├── Aluno.cs
    │   │   ├── Escola.cs
    │   │   ├── Pessoa.cs
    │   │   └── Professor.cs
    │   └── Interfaces/
    │       ├── IAlunoRepository.cs
    │       └── IEscolaRepository.cs
    ├── SistemaEscolar.Infrastructure/
    │   ├── Data/
    │   │   └── ApplicationDbContext.cs
    │   ├── Repositories/
    │   │   ├── AlunoRepository.cs
    │   │   └── EscolaRepository.cs
    │   └── Migrations/         
    ├── SistemaEscolar.Services/
    │   ├── Interfaces/
    │   │   ├── IAlunoService.cs
    │   │   └── IEscolaService.cs
    │   └── Implementations/
    │       ├── AlunoService.cs
    │       └── EscolaService.cs
    └── SistemaEscolar.API/
        ├── Controllers/
        │   ├── AlunoController.cs
        │   └── EscolaController.cs
        ├── Startup.cs
        └── Program.cs
