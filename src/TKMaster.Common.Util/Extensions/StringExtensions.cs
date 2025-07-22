using System.ComponentModel;

namespace TKMaster.Common.Util.Extensions;

public static class StringExtensions
{
    /// <summary>
    /// Formata a string atual utilizando os parâmetros fornecidos, de forma semelhante a <c>string.Format</c>.
    /// </summary>
    /// <param name="mensagem">A string de formato contendo placeholders, como "{0}", "{1}", etc.</param>
    /// <param name="parametros">Os valores que serão inseridos nos placeholders da mensagem.</param>
    /// <returns>Uma string formatada com os valores substituídos nos respectivos placeholders.</returns>
    public static string ToFormat(this string mensagem, params object[] parametros)
    {
        return string.Format(mensagem, parametros);
    }

    /// <summary>
    /// Este método irá retornar o atributo que for solicitado, nesse caso o Description
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="valorEnum"></param>
    /// <returns></returns>
    public static T GetTypeAttribute<T>(this Enum valorEnum) where T : System.Attribute
    {
        var type = valorEnum.GetType();
        var memInfo = type.GetMember(valorEnum.ToString());
        var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
        return (attributes.Length > 0) ? (T)attributes[0] : null;
    }

    /// <summary>
    /// A extensão GetDescription retorna a descrição (Description) de um elemento. 
    /// Para isso, ela utiliza outra extensão (GetTypeAttribute) responsável por localizar o atributo correspondente.
    /// </summary>
    /// <param name="valorEnum"></param>
    /// <returns></returns>
    public static string GetDescription(this Enum valorEnum)
    {
        return valorEnum.GetTypeAttribute<DescriptionAttribute>().Description;
    }

    /// <summary>
    /// Gera uma mensagem de "não encontrado(a)" com base no sujeito informado e no gênero.
    /// </summary>
    /// <param name="subject">O nome do item ou entidade que não foi encontrado(a), por exemplo, "Curso" ou "Candidatura".</param>
    /// <param name="isFeminine">Indica se o sujeito está no gênero feminino. Se verdadeiro, a mensagem usará "encontrada", caso contrário, "encontrado".</param>
    /// <returns>Uma string no formato "[Sujeito] não encontrado(a)", com concordância de gênero.</returns>
    public static string NotFound(this string subject, bool isFeminine)
    {
        var suffix = isFeminine ? "a" : "o";
        return $"{subject} não encontrad{suffix}";
    }
}