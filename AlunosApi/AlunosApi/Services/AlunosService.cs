﻿using AlunosApi.Context;
using AlunosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AlunosApi.Services;

public class AlunosService : IAlunoService
{
    private readonly AppDbContext _context;

    public AlunosService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Aluno>> GetAlunos()
    {
        try
        {
            return await _context.Alunos.ToListAsync();
        }
        catch
        {
            throw;
        }
    }

    public async Task<IEnumerable<Aluno>> GetAlunoByNome(string nome)
    {
        IEnumerable<Aluno> alunos;

        if (!string.IsNullOrEmpty(nome))
        {
            alunos = await _context.Alunos.Where(x => x.Nome.Contains(nome)).ToListAsync();
        }
        else
        {
            alunos = await GetAlunos();
        }

        return alunos;
    }

    public async Task<Aluno> GetAluno(int id)
    {
        var aluno = await _context.Alunos.FindAsync(id);
        return aluno ?? throw new ArgumentNullException("Informe um valor válido");
    }

    public async Task CreateAluno(Aluno aluno)
    {
        _context.Alunos.Add(aluno);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAluno(Aluno aluno)
    {
        _context.Entry(aluno).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAluno(Aluno aluno)
    {
        _context.Alunos.Remove(aluno);
        await _context.SaveChangesAsync();
    }
}
