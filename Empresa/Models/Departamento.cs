using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Empresa.Models;

[Table("Departamentos_PX")]
public class Departamento
{
    [Key]
    public int IdDepartament { get; set; }
    public string NameDepartament { get; set; }
}
