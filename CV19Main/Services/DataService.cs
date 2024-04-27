using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CV19Main.Models;

namespace CV19Main.Services
{
    internal class DataService
    {

        const string _DataSouceAddress = @"https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";


        static async Task<Stream> GetDataStream()
        {
            var client = new HttpClient();

            var response = await client.GetAsync(_DataSouceAddress, HttpCompletionOption.ResponseHeadersRead);

            return await response.Content.ReadAsStreamAsync();
        }


        static IEnumerable<string> GetDataLines()
        {
            using var data_stream = (SynchronizationContext.Current is null
                ? GetDataStream()
                : Task.Run(GetDataStream)).Result;

            using var data_reader = new StreamReader(data_stream);

            while (!data_reader.EndOfStream)
            {
                var line = data_reader.ReadLine();

                if (string.IsNullOrWhiteSpace(line)) continue;

                yield return line
                    .Replace("Korea,", "Korea -")
                    .Replace("Bonaire,", "Bonaire")
                    .Replace("Helena,", "Helena");
            }
        }

        static DateTime[] GetDates() => GetDataLines()
            .First()
            .Split(',')
            .Skip(4)
            .Select(s => DateTime.Parse(s, CultureInfo.InvariantCulture))
            .ToArray();


        static IEnumerable<(String Province, string Country, (double Lat, double Lot) Place, int[] Counts)> GetCountriesData()
        {
            var lines = GetDataLines()
                .Skip(1)
                .Select(line => line.Split(','));

            foreach (var row in lines)
            {
                var province = row[0].Trim();
                var country_name = row[1].Trim(' ', '"');
                double latitude = 0;
                double longtitude = 0;
                if (!(string.IsNullOrWhiteSpace(row[2]) || string.IsNullOrWhiteSpace(row[3])))
                {
                     latitude = double.Parse(row[2], CultureInfo.InvariantCulture);
                     longtitude = double.Parse(row[3], CultureInfo.InvariantCulture);

                }
                var counts = row.Skip(4).Select(int.Parse).ToArray();

                yield return (province, country_name, (latitude, longtitude), counts);
            }
        }

        public IEnumerable<CountryInfo> GetData()
        {
            var dates = GetDates();

            var data = GetCountriesData().GroupBy(d => d.Country);

            foreach (var country_info in data)
            {
                var country = new CountryInfo()
                {
                    Name = country_info.Key,
                    ProvinceCounts = country_info.Select(c => new PlaceInfo()
                    {
                        Name = c.Province,
                        Location = new PersonalPoint(c.Place.Lat, c.Place.Lot),
                        Counts = dates.Zip(c.Counts, (dates, count) => new ConfirmedCount()
                        {
                            Date = dates,
                            Count = count
                        })
                    })
                };

                yield return country;

            }
        }
    }
}
