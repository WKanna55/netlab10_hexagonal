namespace Lab10_wkana.Application.Dtos.Response;

public class ResponseDto
{
    public int ResponseId { get; set; }

    public int TicketId { get; set; }

    public int ResponderId { get; set; }

    public string Message { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }
}