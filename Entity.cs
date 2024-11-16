using System;

public interface IEntity
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public IEntity()
    {
    }

    public IEntity(int id) : this()
    {
        Id = id;


    }
}
