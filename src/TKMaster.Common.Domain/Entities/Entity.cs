namespace TKMaster.Common.Domain.Entities;

public abstract class Entity
{
    /// <summary>
    /// Codigo
    /// </summary>
    public int? Code { get; set; }

    /// <summary>
    /// Nome
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// DataCadastro
    /// </summary>
    public DateTime DateCreate { get; set; }

    /// <summary>
    /// DataAlteracao
    /// </summary>
    public DateTime? DateChange { get; set; }

    /// <summary>
    /// DataExclusao
    /// </summary>
    public DateTime? DateExclusion { get; set; }

    public bool Status { get; set; }
}