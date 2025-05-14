using LinqToDB.Mapping;

namespace HealthDiary.Models;

[Table("Humor")]
public class Humor
{
    [PrimaryKey, Identity]
    public int Id { get; set; }
    
    [Column, NotNull]
    public string Descricao { get; set; } = string.Empty;
} 