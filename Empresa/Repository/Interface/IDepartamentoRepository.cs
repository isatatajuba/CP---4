using Empresa.Models;

namespace Empresa.Repository.Interface;

public interface IDepartamentoRepository
{
    Task<IEnumerable<Departamento>> GetDepartamentos(); // Busca todos os Departamentos
    Task<Departamento> GetDepartamentoById(int IdDepartament); // Busca somente um Departamento
    Task<IEnumerable<Empregado>> GetEmpregadosByIdDepartament(int IdDepartament); // Busca os Empregados pelo Nome do Departamento
    Task<Departamento> AddDepartamento(Departamento departamento); // Adiciona o Departamento
    Task<Departamento> UpdateDepartamento(Departamento departamento); // Atualiza o Departamento
    void DeleteDepartamentoById(int IdDepartament); // Deleta o Departamento
}
