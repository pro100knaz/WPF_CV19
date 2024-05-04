using CV19Main.Models.Interfaces;

namespace CV19Main.Models.Decanat;

internal class Group : IEntity
{
    public string Description { get; set; }
    public string Name { get; set; }
    public ICollection<Student> Students { get; set; }
    public int Id { get; set; }
}