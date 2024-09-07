using Empresa.Data;
using Empresa.Models;
using Empresa.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Empresa.Repository;

public class DepartamentoRepository : IDepartamentoRepository
{
    private readonly dbContext _dbContext;

    public DepartamentoRepository(dbContext _dbContext)
    {
        this._dbContext = _dbContext;
    }

    public async Task<IEnumerable<Departamento>> GetDepartamentos()
    {
        return await _dbContext.Departamentos.ToListAsync();
    }

    public async Task<Departamento> GetDepartamentoById(int IdDepartament)
    {
        return await _dbContext.Departamentos.FirstOrDefaultAsync(d => d.IdDepartament == IdDepartament);
    }

    public async Task<IEnumerable<Empregado>> GetEmpregadosByIdDepartament(int IdDepartament)
    {
        var departamento = await _dbContext.Departamentos.FindAsync(IdDepartament);

        if (departamento == null)
        {
            return Enumerable.Empty<Empregado>(); // Retorna uma lista vazia se o departamento não existir
        }

        return await _dbContext.Empregados
            .Where(e => e.IdDepartament == IdDepartament)
            .ToListAsync();
    }

    public async Task<Departamento> AddDepartamento(Departamento departamento)
    {
        var result = await _dbContext.Departamentos.AddAsync(departamento);
        await _dbContext.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<Departamento> UpdateDepartamento(Departamento departamento)
    {
        var existingDepartamento = await _dbContext.Departamentos.FirstOrDefaultAsync(d => d.IdDepartament == departamento.IdDepartament);
        if (existingDepartamento == null)
        {
            return null; // Retorna null se o departamento não for encontrado
        }

        // Atualiza o nome do departamento
        existingDepartamento.NameDepartament = departamento.NameDepartament;

        await _dbContext.SaveChangesAsync();
        return existingDepartamento;
    }

    public async void DeleteDepartamentoById(int IdDepartament)
    {
        var result = await _dbContext.Departamentos.FirstOrDefaultAsync(d => d.IdDepartament == IdDepartament);
        if (result != null)
        {
            _dbContext.Departamentos.Remove(result);
            await _dbContext.SaveChangesAsync();
        }
    }
}
