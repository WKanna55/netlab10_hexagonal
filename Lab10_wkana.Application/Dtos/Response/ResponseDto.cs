namespace Lab10_wkana.Application.Dtos.Response;

public class ResponseDto
{
    public Guid ResponseId { get; set; }

    public Guid TicketId { get; set; }

    public Guid ResponderId { get; set; }

    public string Message { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }
}