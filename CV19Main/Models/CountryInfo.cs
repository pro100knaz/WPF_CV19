namespace CV19Main.Models;

internal class CountryInfo : PlaceInfo
{
    public IEnumerable<PlaceInfo> ProvinceCounts { get; set; }
}