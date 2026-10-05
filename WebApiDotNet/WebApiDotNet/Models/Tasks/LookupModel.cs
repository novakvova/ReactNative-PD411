namespace WebApiDotNet.Models.Tasks;

/// <summary>Елемент довідника (статус або пріоритет).</summary>
public class LookupModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
