namespace Lab10_wkana.Domain.Entities;

public partial class Responses
{
    public Guid ResponseId { get; set; }

    public Guid TicketId { get; set; }

    public Guid ResponderId { get; set; }

    public string Message { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual Users Responder { get; set; } = null!;

    public virtual Tickets Ticket { get; set; } = null!;
}
