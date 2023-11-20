namespace Store.Models.Entities.Common;

public interface IEntity
{
    public int Id { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }
}
