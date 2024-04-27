using System.Drawing;

namespace CV19Main.Models;

internal class CountryInfo : PlaceInfo
{
    private PersonalPoint _Location;

    public override PersonalPoint Location
    {
        get
        {
            if (ProvinceCounts is null) return default;

            var average_x = ProvinceCounts.Average(p => p.Location.X);
            var average_y = ProvinceCounts.Average(p => p.Location.Y);
            return (PersonalPoint)(_Location = new PersonalPoint(average_x, average_y));
        }
        set => _Location = value;
    }
    public IEnumerable<PlaceInfo> ProvinceCounts { get; set; }

    public override string ToString()
    {
        return $" {Name}, ({ProvinceCounts.Count()} ; {Location.X} , {Location.Y})";
    }
}