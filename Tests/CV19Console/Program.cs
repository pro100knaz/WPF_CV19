using System;
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

var dates = GetDates();
//foreach (var data in dates)
//{
//            Console.WriteLine(data.ToString());
//}

Console.WriteLine(string.Join("\r\n", dates));




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
        yield return line;

    }
}

static DateTime[] GetDates() => GetDataLines()
    .First()
    .Split(',')
    .Skip(4)
    .Select(s=> DateTime.Parse(s, CultureInfo.InvariantCulture))
    .ToArray();



Console.Write("jesfsfef");
Console.ReadLine();