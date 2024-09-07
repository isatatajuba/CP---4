using Empresa.Models;
using Empresa.Repository;
using Empresa.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Empresa.Controllers;

[Route("api/departamento")]
[ApiController]
public class DepartamentoController : ControllerBase
{
    private readonly IDepartamentoRepository departamentoRepository;

    public DepartamentoController(IDepartamentoRepository departamentoRepository)
    {
        this.departamentoRepository = departamentoRepository;
    }

    [HttpGet]
    public async Task<ActionResult> GetDepartamentos()
    {
        try
        {
            return Ok(await departamentoRepository.GetDepartamentos());
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
        }
    }

    [HttpGet("{IdDepartament:int}")]
    public async Task<ActionResult<Departamento>> GetDepartamentoById(int IdDepartament)
    {
        try
        {
            var result = await departamentoRepository.GetDepartamentoById(IdDepartament);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
        }
    }

    [HttpGet("empregados/{IdDepartament:int}")]
    public async Task<ActionResult<IEnumerable<Empregado>>> GetEmpregadosByIdDepartament(int IdDepartament)
    {
        try
        {
            var empregados = await departamentoRepository.GetEmpregadosByIdDepartament(IdDepartament);
            if (!empregados.Any()) // Verifica se a lista de empregados está vazia
            {
                return NotFound($"Nenhum empregado encontrado para o departamento ID: {IdDepartament}");
            }
            return Ok(empregados);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
        }
    }

    [HttpPost]
    public async Task<ActionResult<Departamento>> CreateDepartamento([FromBody] Departamento departamento)
    {
        try
        {
            if (departamento == null)
            {
                return BadRequest();
            }

            var createdDepartamento = await departamentoRepository.AddDepartamento(departamento);
            return CreatedAtAction(nameof(GetDepartamentoById), new { 
                IdDepartament = createdDepartamento.IdDepartament }, 
                createdDepartamento);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados no banco de dados");
        }
    }

    [HttpPut("{IdDepartament:int}")]
    public async Task<ActionResult<Departamento>> UpdateDepartamento(int IdDepartament, [FromBody] Departamento departamento)
    {
        try
        {
            if (departamento == null)
            {
                return BadRequest("Dados do departamento inválidos.");
            }

            departamento.IdDepartament = IdDepartament;

            var updatedDepartamento = await departamentoRepository.UpdateDepartamento(departamento);
            if (updatedDepartamento == null)
            {
                return NotFound($"Empregado com ID {IdDepartament} não foi encontrado.");
            }

            return Ok(updatedDepartamento);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar dados no banco de dados");
        }
    }

    [HttpDelete("{IdDepartament:int}")]
    public async Task<ActionResult<Departamento>> DeleteDepartamento(int IdDepartament)
    {
        try
        {
            var result = await departamentoRepository.GetDepartamentoById(IdDepartament);
            if (result == null)
            {
                return NotFound($"Departamento com id = {IdDepartament}, não foi encontrado");
            }
            departamentoRepository.DeleteDepartamentoById(IdDepartament);

            return result;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no banco de dados");
        }
    }
}