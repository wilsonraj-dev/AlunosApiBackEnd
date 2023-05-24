using AlunosApi.Models;

namespace AlunosApi.Services;

public class AlunosService : IAlunoService
{
    public Task<IEnumerable<Aluno>> GetAlunos()
    {
        throw new NotImplementedException();
    }

    public Task<Aluno> GetAluno(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Aluno>> GetAlunoByNome(string nome)
    {
        throw new NotImplementedException();
    }

    public Task CreateAluno(Aluno aluno)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAluno(Aluno aluno)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAluno(Aluno aluno)
    {
        throw new NotImplementedException();
    }
}
