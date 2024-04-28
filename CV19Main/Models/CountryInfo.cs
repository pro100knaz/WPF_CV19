using System.Drawing;

namespace CV19Main.Models;

internal class CountryInfo : PlaceInfo
{
    private PersonalPoint _Location;

    public override PersonalPoint Location
    {
        get
        {
            if (Provinces is null) return default;

            var average_x = Provinces.Average(p => p.Location.X);
            var average_y = Provinces.Average(p => p.Location.Y);
            return (PersonalPoint)(_Location = new PersonalPoint(average_x, average_y));
        }
        set => _Location = value;
    }
    public IEnumerable<PlaceInfo> Provinces { get; set; }

    private IEnumerable<ConfirmedCount> _Counts;
    public override IEnumerable<ConfirmedCount> Counts
    {
        get
        {
            if(_Counts != null) return _Counts;
            
            var points_count = Provinces?.FirstOrDefault()?.Counts?.Count() ?? 0;

            if (points_count == 0 || points_count == null)
            {
                return Enumerable.Empty<ConfirmedCount>();
            }

            var province_points = Provinces.Select(p => p.Counts.ToArray()).ToArray();

            var points = new ConfirmedCount[points_count];

            foreach (var province in province_points)
            {
                for (var i = 0; i < points_count ; i++)
                {
                    if (points[i].Date == default)
                        points[i] = province[i];
                    else
                        points[i].Count += province[i].Count;
                }
            }
            _Counts = points;
            return _Counts;
        }
        set => _Counts = value;
    }





    public override string ToString()
    {
        return $" {Name}, ({Provinces.Count()} ; {Location.X} , {Location.Y})";
    }
}