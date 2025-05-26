namespace Lab10_wkana.Domain.Entities;

public partial class Roles
{
    public Guid RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<UserRoles> UserRoles { get; set; } = new List<UserRoles>();
}
