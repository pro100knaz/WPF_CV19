using System.Drawing;

namespace CV19Main.Models;

internal class CountryInfo : PlaceInfo
{
    private Point _Location;

    public override Point Location
    {
        get
        {
            if (ProvinceCounts is null) return default;

            var average_x = ProvinceCounts.Average(p => p.Location.X);
            var average_y = ProvinceCounts.Average(p => p.Location.X);
            return (Point)(_Location = new Point((int)average_x, (int)average_y));
        }
        set => _Location = value;
    }
    public IEnumerable<PlaceInfo> ProvinceCounts { get; set; }
}