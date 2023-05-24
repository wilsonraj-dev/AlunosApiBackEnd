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
}
