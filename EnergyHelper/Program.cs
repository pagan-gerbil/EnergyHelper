// See https://aka.ms/new-console-template for more information
using EnergyHelper.OctopusAgile;

Console.WriteLine("Hello, World!");

try
{
    Console.WriteLine("Getting prices...");
    var octopus = new OctopusAgileApi();
    var prices = await octopus.GetStandardUnitRates();
    Console.WriteLine($"Found {prices.Results.Count()} rates");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

