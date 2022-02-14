using Task3_Drivers.Model;

namespace Task3_Drivers;

public class DriverList
{
    public List<Person> Form(IEnumerable<Person> persons)
    {
        var drivers = new List<Person>();

        foreach (var person in persons)
        {
            if (person.IsDriver)
            {
                drivers.Add(person);
            }
        }

        return drivers;
    }
}