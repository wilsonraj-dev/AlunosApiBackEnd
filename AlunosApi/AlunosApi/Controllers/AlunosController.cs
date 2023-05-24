using AlunosApi.Models;
using AlunosApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlunosApi.Controllers;

[ApiConventionType(typeof(DefaultApiConventions))]
[Produces("application/json")]
[Route("[controller]")]
[ApiController]
public class AlunosController : ControllerBase
{
    private readonly IAlunoService _alunoService;

    public AlunosController(IAlunoService alunoService)
    {
        _alunoService = alunoService;
    }

    [HttpGet]
    public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAlunos()
    {
        var alunos = await _alunoService.GetAlunos();
        return Ok(alunos);
    }

    [HttpGet("AlunosPorNome")]
    public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAlunosByName([FromQuery] string nome)
    {
        var alunos = await _alunoService.GetAlunoByName(nome);

        if (alunos.Count() == 0)
        {
            return NotFound($"Não existem alunos com o critério {nome}");
        }
        else
        {
            return Ok(alunos);
        }
    }

    [HttpGet("{id:int}", Name = "GetAluno")]
    public async Task<ActionResult<Aluno>> GetAluno(int id)
    {
        var aluno = await _alunoService.GetAluno(id);

        if (aluno == null)
        {
            return NotFound($"Não existe aluno com o id = {id}");
        }
        else
        {
            return Ok(aluno);
        }
    }

    [HttpPost]
    public async Task<ActionResult> Create(Aluno aluno)
    {
        await _alunoService.CreateAluno(aluno);
        return CreatedAtRoute(nameof(GetAluno), new { id = aluno.Id }, aluno);
    }
}
