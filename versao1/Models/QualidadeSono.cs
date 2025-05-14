using LinqToDB.Mapping;

namespace HealthDiary.Models;

[Table("QualidadeSono")]
public class QualidadeSono
{
    [PrimaryKey, Identity]
    public int Id { get; set; }
    
    [Column, NotNull]
    public string Descricao { get; set; } = string.Empty;
} 