using LinqToDB.Mapping;
using System;

namespace HealthDiary.Models;

[Table("RegistroDiario")]
public class RegistroDiario
{
    [PrimaryKey, Identity]
    public int Id { get; set; }
    
    [Column, NotNull]
    public DateTime Data { get; set; }
    
    [Column]
    public int HumorId { get; set; }
    
    [Column]
    public int SonoId { get; set; }
    
    [Column]
    public int AlimentacaoId { get; set; }
    
    [Column]
    public int AtividadeFisicaId { get; set; }
    
    [Association(ThisKey = nameof(HumorId), OtherKey = nameof(Humor.Id))]
    public Humor? Humor { get; set; }
    
    [Association(ThisKey = nameof(SonoId), OtherKey = nameof(QualidadeSono.Id))]
    public QualidadeSono? Sono { get; set; }
    
    [Association(ThisKey = nameof(AlimentacaoId), OtherKey = nameof(Alimentacao.Id))]
    public Alimentacao? Alimentacao { get; set; }
    
    [Association(ThisKey = nameof(AtividadeFisicaId), OtherKey = nameof(AtividadeFisica.Id))]
    public AtividadeFisica? AtividadeFisica { get; set; }
} 