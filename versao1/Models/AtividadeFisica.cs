using LinqToDB.Mapping;

namespace HealthDiary.Models;

[Table("AtividadeFisica")]
public class AtividadeFisica
{
    [PrimaryKey, Identity]
    public int Id { get; set; }
    
    [Column, NotNull]
    public string TipoAtividade { get; set; } = string.Empty;
    
    [Column]
    public int DuracaoMinutos { get; set; }
} 