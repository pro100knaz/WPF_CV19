using System;
using System.Collections;
using System.Globalization;
using System.Net;
using System.Linq;

const string data_url = @"https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";


var client = new HttpClient();

//var response = client.GetAsync(data_uri).Result;

//var csv_str = response.Content.ReadAsStringAsync().Result;




//foreach (var dataLine in GetDataLines())
//{
//    Console.WriteLine(dataLine);
//}


//foreach (var data in dates)
//{
//            Console.WriteLine(data.ToString());
//}

//var dates = GetDates();
//Console.WriteLine(string.Join("\r\n", dates));

var russia = GetData().First(v => v.Country.Equals("Russia", StringComparison.OrdinalIgnoreCase));

Console.WriteLine(string.Join("\r\n", GetDates().Zip(russia.Counts, (date,count) => $"{date} - {count}")));

var moldova = GetData().First(v => v.Country.Equals("Moldova", StringComparison.OrdinalIgnoreCase));

Console.WriteLine(string.Join("\r\n", GetDates().Zip(moldova.Counts, (date, count) => $"{date:dd:MM} - {count}")));

///
///Поток данных
///     
static async Task<Stream> GetDataStream()
{
    var client = new HttpClient();

    var response = await client.GetAsync(data_url, HttpCompletionOption.ResponseHeadersRead);

    return await response.Content.ReadAsStreamAsync();
}

///Генератор строк
/// разбивает поток на строки

static  IEnumerable<string> GetDataLines()
{
    using var data_stream =  GetDataStream().Result;

    using var data_reader = new StreamReader(data_stream);

    while (!data_reader.EndOfStream)
    {
        var line = data_reader.ReadLine();

        if (string.IsNullOrWhiteSpace(line)) continue;

        yield return line.Replace("Korea," , "Korea -").Replace( "Bonaire," , "Bonaire").Replace("Helena,","Helena");

    }
}

static DateTime[] GetDates() => GetDataLines()
    .First()
    .Split(',')
    .Skip(4)
    .Select(s=> DateTime.Parse(s, CultureInfo.InvariantCulture))
    .ToArray();


static IEnumerable<(string Country, string Province, int[]Counts)> GetData()
{
    var lines = GetDataLines()
        .Skip(1)
        .Select(line => line.Split(','));

    foreach (var row in lines)
    {
        var province = row[0].Trim();
        var country_name = row[1].Trim(' ', '"');
        var counts = row.Skip(4).Select(int.Parse).ToArray();
        yield return (country_name, province, counts);
    }
}


Console.Write("jesfsfef");
Console.ReadLine();