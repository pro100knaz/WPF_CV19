namespace CV19Main.Models;

internal class CountryInfo : PlaceInfo
{
    public IEnumerable<ProvinceInfo> ProvinceCounts { get; set; }
}