//Implementação própria de classe, nada pedido no enunciado

using System;

namespace Trabalho1.Models;

public class RegistroCompleto
{
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public string HumorDescricao { get; set; }
    public string SonoDescricao { get; set; }
    public string AlimentacaoDescricao { get; set; }
    public string TipoAtividade { get; set; }
    public int DuracaoMinutos { get; set; }
}