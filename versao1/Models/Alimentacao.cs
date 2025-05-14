using LinqToDB.Mapping;

namespace HealthDiary.Models;

[Table("Alimentacao")]
public class Alimentacao
{
    [PrimaryKey, Identity]
    public int Id { get; set; }
    
    [Column, NotNull]
    public string Descricao { get; set; } = string.Empty;
    
    [Column]
    public int? Calorias { get; set; }
} 