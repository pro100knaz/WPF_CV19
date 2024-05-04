using CV19Main.Models.Decanat;
using CV19Main.Services.Base;

namespace CV19Main.Services;

class GroupRepository : RepositoryInMemory<Group>
{
    protected override void Update(Group source, Group Destination)
    {
        Destination.Name = source.Name;
        Destination.Description = source.Description;
    }
}