using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Domain.Entities;


namespace SistemaEscolar.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<AgendaDoAluno> AgendasDosAlunos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Escola> Escolas { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Nota> Notas { get; set; }
        public DbSet<Notificacao> Notificacoes { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Prova> Provas { get; set; }
        public DbSet<Responsavel> Responsaveis { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
