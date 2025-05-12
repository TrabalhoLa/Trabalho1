using System;

namespace Trabalho1.Models;

public class RegistroDiario
{
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public int HumorId { get; set; }
    public int SonoId { get; set; }
    public int AlimentacaoId { get; set; }
    public int AtividadeFisicaId { get; set; }
}