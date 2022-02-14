using Bogus;

namespace Task3_Drivers;

public static class Program
{
    public static void Main(string[] args)
    {
        var faker = new Faker();
            
        DateTime startDate = DateTime.Parse("10/01/1970");
        DateTime finishDate = DateTime.Parse("10/01/2022");
        DateTime date;

        date = faker.Date.BetweenOffset(
            new DateTimeOffset(startDate), new DateTimeOffset(finishDate)).Date;

    }
}