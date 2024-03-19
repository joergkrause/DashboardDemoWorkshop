namespace DomainModels;

public class Widget : EntityBase<int>
{
  public string Name { get; set; } = default!;

  public string Description { get; set; } = default!;

  public string Color { get; set; } = default!;

  public int Size { get; set; }
}