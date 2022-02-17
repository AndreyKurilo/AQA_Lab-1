namespace Appointment
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var user = new User();
            var input = new Input();
            user.Name = input.Name();
            user.Surname = input.Surname();
            user.Date = input.Date();
            user.PrintRegistrationTime();
        }
    }
}