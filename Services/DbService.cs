using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using System.Threading.Tasks;
using Trabalho1.Models;
using Trabalho1.Models.Relatorio;

namespace Trabalho1.Services;

public class DatabaseService
{
    private readonly string _connectionString;

    public DatabaseService(string dbPath)
    {
        _connectionString = $"Data Source={dbPath}";
    }

    public async Task<IEnumerable<Humor>> ObterHumoresAsync()
    {
        using var connection = new SqliteConnection(_connectionString);
        await connection.OpenAsync();

        var humores = new List<Humor>();
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT Id, Descricao FROM Humor";

        using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            humores.Add(new Humor
            {
                Id = reader.GetInt32(0),
                Descricao = reader.GetString(1)
            });
        }

        return humores;
    }

    public async Task<int> SalvarRegistroDiarioAsync(RegistroDiario registro)
    {
        using var connection = new SqliteConnection(_connectionString);
        await connection.OpenAsync();

        using var command = connection.CreateCommand();
        command.CommandText = @"
            INSERT INTO RegistroDiario (Data, HumorId, SonoId, AlimentacaoId, AtividadeFisicaId)
            VALUES (@Data, @HumorId, @SonoId, @AlimentacaoId, @AtividadeFisicaId)
            RETURNING Id;";

        command.Parameters.AddWithValue("@Data", registro.Data.ToString("yyyy-MM-dd"));
        command.Parameters.AddWithValue("@HumorId", registro.HumorId);
        command.Parameters.AddWithValue("@SonoId", registro.SonoId);
        command.Parameters.AddWithValue("@AlimentacaoId", registro.AlimentacaoId);
        command.Parameters.AddWithValue("@AtividadeFisicaId", registro.AtividadeFisicaId);

        return Convert.ToInt32(await command.ExecuteScalarAsync());
    }

    public async Task<IEnumerable<RegistroCompleto>> ObterRegistrosCompletosAsync(DateTime? dataInicio = null, DateTime? dataFim = null)
    {
        using var connection = new SqliteConnection(_connectionString);
        await connection.OpenAsync();

        var registros = new List<RegistroCompleto>();
        using var command = connection.CreateCommand();
        command.CommandText = @"
            SELECT 
                r.Id,
                r.Data,
                h.Descricao as HumorDescricao,
                s.Descricao as SonoDescricao,
                a.Descricao as AlimentacaoDescricao,
                af.TipoAtividade,
                af.DuracaoMinutos
            FROM RegistroDiario r
            LEFT JOIN Humor h ON r.HumorId = h.Id
            LEFT JOIN QualidadeSono s ON r.SonoId = s.Id
            LEFT JOIN Alimentacao a ON r.AlimentacaoId = a.Id
            LEFT JOIN AtividadeFisica af ON r.AtividadeFisicaId = af.Id
            WHERE (@DataInicio IS NULL OR Date(r.Data) >= Date(@DataInicio))
            AND (@DataFim IS NULL OR Date(r.Data) <= Date(@DataFim))
            ORDER BY r.Data DESC";

        command.Parameters.AddWithValue("@DataInicio", (object?)dataInicio?.ToString("yyyy-MM-dd") ?? DBNull.Value);
        command.Parameters.AddWithValue("@DataFim", (object?)dataFim?.ToString("yyyy-MM-dd") ?? DBNull.Value);

        using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            registros.Add(new RegistroCompleto
            {
                Id = reader.GetInt32(0),
                Data = DateTime.Parse(reader.GetString(1)),
                HumorDescricao = reader.GetString(2),
                SonoDescricao = reader.GetString(3),
                AlimentacaoDescricao = reader.GetString(4),
                TipoAtividade = reader.GetString(5),
                DuracaoMinutos = reader.GetInt32(6)
            });
        }

        return registros;
    }
    
    public async Task<RelatorioEstatisticas> GerarDadosRelatorioAsync(DateTime inicio, DateTime fim)
    {
        using var connection = new SqliteConnection(_connectionString);
        await connection.OpenAsync();

        var relatorio = new RelatorioEstatisticas();

        // Dados de atividade física por dia
        using (var command = connection.CreateCommand())
        {
            command.CommandText = @"
                SELECT 
                    r.Data,
                    af.DuracaoMinutos
                FROM RegistroDiario r
                JOIN AtividadeFisica af ON r.AtividadeFisicaId = af.Id
                WHERE Date(r.Data) BETWEEN Date(@Inicio) AND Date(@Fim)
                ORDER BY r.Data";

            command.Parameters.AddWithValue("@Inicio", inicio.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@Fim", fim.ToString("yyyy-MM-dd"));

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                relatorio.DadosAtividade.Add(new DadosGrafico
                {
                    Data = DateTime.Parse(reader.GetString(0)),
                    Valor = reader.GetDouble(1)
                });
            }
        }

        // Dados de humor
        using (var command = connection.CreateCommand())
        {
            command.CommandText = @"
                SELECT 
                    r.Data,
                    h.Descricao,
                    COUNT(*) as Quantidade
                FROM RegistroDiario r
                JOIN Humor h ON r.HumorId = h.Id
                WHERE Date(r.Data) BETWEEN Date(@Inicio) AND Date(@Fim)
                GROUP BY Date(r.Data), h.Descricao
                ORDER BY r.Data";

            command.Parameters.AddWithValue("@Inicio", inicio.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@Fim", fim.ToString("yyyy-MM-dd"));

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                relatorio.DadosHumor.Add(new DadosGrafico
                {
                    Data = DateTime.Parse(reader.GetString(0)),
                    Categoria = reader.GetString(1),
                    Valor = reader.GetDouble(2)
                });
            }
        }

        return relatorio;
    }
}