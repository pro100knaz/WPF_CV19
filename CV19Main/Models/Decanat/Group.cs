using CV19Main.Models.Interfaces;

namespace CV19Main.Models.Decanat;

internal class Group : IEntity
{
    public string Description { get; set; }
    public string Name { get; set; }
    public IList<Student> Students { get; set; } = new List<Student>();
    public int Id { get; set; }
}