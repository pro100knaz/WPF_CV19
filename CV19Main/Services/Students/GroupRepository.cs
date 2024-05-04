using CV19Main.Models.Decanat;
using CV19Main.Services.Base;
using CV19Main.Services.Students;

namespace CV19Main.Services;

class GroupRepository : RepositoryInMemory<Group>
{

    public GroupRepository() :base(TestData.Groups)
    {

    }
    protected override void Update(Group source, Group Destination)
    {


        Destination.Name = source.Name;
        Destination.Description = source.Description;
    }

    public Group Get(string groupName) => GetAll().FirstOrDefault(g => g.Name == groupName);
}