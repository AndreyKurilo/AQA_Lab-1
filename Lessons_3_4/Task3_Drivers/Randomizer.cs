namespace Task3_Drivers;

public static class Randomizer
{
    public static int GetRandomNumberBetween(int min, int max)
    {
        var random = new Random();
        var usersRandomAmount = random.Next(min, max);

        return usersRandomAmount;
    }
}