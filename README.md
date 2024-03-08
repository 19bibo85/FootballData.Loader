# FootballData.Loader

It's a 	![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white) library that allows you to download and parse the **CSV** files hosted on [football-data.co.uk](https://www.football-data.co.uk) or to load the files from a local path.

## How to download historical data files?

You can download the **CSV** files by creating an instance of the `HttpClient` class, injecting it into the `FootballDataHttpLoader` class and calling the `DownloadStatsAsync` method.

```cs
var client = HttpLoader
    .Create()
    .WithBrowserName("your-browser")
    .Build();  	
	
var downloader = new FootballDataHttpLoader(client);

var result = await downloader.DownloadStatsAsync();
```

The `DownloadStatsAsync` method accepts a `FootballDataHttpParams` class to allow filtering the files by country, division and year.

```cs
var param = new FootballDataHttpParams()
{
    Country = Country.Argentina,
    Division = Division.LigaProfesional,
    FromYear = 2012,
    ToYear = 2012
};
```

You can also specify the location where to download the files by assigning it to the `FilePath` property. Notice that the file names are in the format *Y1Y2-DIV (i.e, 1314-I1)*

Notice that when an instance of `FootballDataHttpParams` is not passed as a parameter all files are downloaded.

## How to load historical data files?

You can load the **CSV** files by injecting a rootpath it into the `FootballDataFileLoader` class and call the `LoadStatsAsync` method.

```cs
var rootpath = "my-rootpath";
	
var loader = new FootballDataFileLoader(rootpath);

var result = await loader.LoadStatsAsync();
```

Similar to `DownloadStatsAsync` the method `LoadStatsAsync` accepts a `FootballDataFileParams` class to allow filtering the files by country, league and year.

## How to download the features file?

The method to download the features is `DownloadFeaturesAsync` which accepts an instance of `FootballDataHttpParams`.

## How to load the features file?

The method to load the features is `LoadFeaturesAsync` which accepts an instance of `FootballDataFileParams`.

## How can I check the status of the request?

All methods return a `FootballDataResult` object, by default the propert `Success` is set to `True` and the `Message` to `OK`, when an error occurs `Success` is set to `False` and details of the error can be found in `Message` property.

## Notes

For a full reference of all the `FootballDataEntry` propeties please visit [football-data.co.uk notes](https://www.football-data.co.uk/notes.txt)
