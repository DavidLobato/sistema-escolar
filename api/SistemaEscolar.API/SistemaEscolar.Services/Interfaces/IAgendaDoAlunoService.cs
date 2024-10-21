﻿using SistemaEscolar.Domain.Entities;

namespace SistemaEscolar.Services.Interfaces
{
    public interface IAgendaDoAlunoService
    {
        Task<AgendaDoAluno> BuscarPorId(int id);
        Task<IEnumerable<AgendaDoAluno>> ListarTodos();
        Task<AgendaDoAluno> Adicionar(AgendaDoAluno agendaDoAluno);
        Task<AgendaDoAluno> Atualizar(AgendaDoAluno agendaDoAluno);
        Task<bool> Excluir(int id);

    }
}