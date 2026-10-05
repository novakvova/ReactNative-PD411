using System.ComponentModel.DataAnnotations;

namespace WebApiDotNet.Models.Tasks;

/// <summary>Зміна лише статусу задачі.</summary>
public class TaskChangeStatusModel
{
    [Range(1, int.MaxValue, ErrorMessage = "Вкажіть статус")]
    public int StatusId { get; set; }
}
