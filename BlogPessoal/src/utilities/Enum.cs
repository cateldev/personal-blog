using System.Text.Json.Serialization;

namespace BlogPessoal.src.utilities
{
    /// <summary>
    /// <for>Resumo: Enum responsable to define Types of user in system</for>
    /// </summary>

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UserType
    {
    NORMAL,
    ADMINISTRATOR
    }
}