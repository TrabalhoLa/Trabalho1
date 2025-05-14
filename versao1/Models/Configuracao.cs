using LinqToDB.Mapping;

namespace HealthDiary.Models;

[Table("Configuracao")]
public class Configuracao
{
    [PrimaryKey, Identity]
    public int Id { get; set; }
    
    [Column]
    public string? CaminhoBanco { get; set; }
    
    [Column]
    public string Tema { get; set; } = "Claro";
} 