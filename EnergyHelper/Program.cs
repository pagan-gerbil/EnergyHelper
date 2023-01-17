// See https://aka.ms/new-console-template for more information
using EnergyHelper;
using EnergyHelper.OctopusAgile;

try
{
    var maximumPrice = 25.0;

    Console.WriteLine("Getting prices...");
    var octopus = new OctopusAgileApi();
    var prices = await octopus.GetStandardUnitRates();
    Console.WriteLine($"Found {prices.Results.Count()} rates");

    var goodTimes = prices.Results.Where(x => x.ValueIncludingVat <= maximumPrice).OrderBy(x => x.ValidFrom).ToList();
    Console.WriteLine($"There are {goodTimes.Count()} good times to use power");
    
    if (!goodTimes.Any())
    {
        return;
    }

    var goodTimeRanges = new List<TimeRange>();

    var startTime = goodTimes[0].ValidFrom;
    var endTime = goodTimes[0].ValidTo;
    for (var i = 1; i < goodTimes.Count(); i++)
    {
        if (goodTimes[i - 1].ValidTo == goodTimes[i].ValidFrom)
        {
            endTime = goodTimes[i].ValidTo;
        }
        else
        {
            goodTimeRanges.Add(new TimeRange { Start = startTime, End = endTime });
            startTime = goodTimes[i].ValidFrom;
            endTime = goodTimes[i].ValidTo;
        }
    }
    goodTimeRanges.Add(new TimeRange { Start = startTime, End = endTime });

    foreach (var range in goodTimeRanges)
    {
        Console.WriteLine($"Good Time Range: {range.Start} to {range.End}");
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}