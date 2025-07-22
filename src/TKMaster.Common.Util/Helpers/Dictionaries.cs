namespace TKMaster.Common.Util.Helpers;

/// <summary>
/// Classe utilitária responsável por fornecer dicionários fixos com chaves e descrições,
/// utilizados geralmente para popular componentes de interface como combos e selects.
/// Exemplos de dados incluídos: status ativo/inativo, meses do ano, modalidades de ensino, status de curso, etc.
///
/// Uso recomendado:
/// - Backend: geração de listas fixas reutilizáveis.
/// - Frontend: consumo via API para popular dropdowns.
/// </summary>
public static class Dictionaries
{
    public static Dictionary<int, string> StatusOptions() => new()
        {
            {0, "Inativo"},
            {1, "Ativo"},
        };

    public static Dictionary<int, string> AttendanceStatusOptions() => new()
        {
            {0, "Falta"},
            {1, "Presente"},
        };

    public static Dictionary<int, string> PaymentStatusOptions() => new()
        {
            {0, "Pendente"},
            {1, "Pago"},
        };

    public static Dictionary<string, string> PermissionProfileOptions() => new()
        {
            {"Master", "Master"},
            {"Padrao", "Padrão"},
        };

    public static Dictionary<int, string> ModalityOptions() => new()
        {
            {1, "Presencial"},
            {2, "Semipresencial"},
            {3, "EAD"},
            {4, "Live"},
        };

    public static Dictionary<int, string> CourseStatusOptions() => new()
        {
            {1, "Interrompido"},
            {2, "Cursando"},
            {3, "Concluído"},
        };

    public static Dictionary<int, string> MonthOptions() => new()
        {
            {1, "Janeiro"}, {2, "Fevereiro"}, {3, "Março"}, {4, "Abril"},
            {5, "Maio"}, {6, "Junho"}, {7, "Julho"}, {8, "Agosto"},
            {9, "Setembro"}, {10, "Outubro"}, {11, "Novembro"}, {12, "Dezembro"}
        };

    public static Dictionary<int, string> StartYearOptions()
    {
        return Enumerable.Range(1930, DateTime.Now.Year - 1930 + 1)
                         .ToDictionary(year => year, year => year.ToString());
    }

    public static Dictionary<int, string> EndYearOptions()
    {
        return Enumerable.Range(1930, DateTime.Now.Year - 1930 + 11)
                         .ToDictionary(year => year, year => year.ToString());
    }
}
