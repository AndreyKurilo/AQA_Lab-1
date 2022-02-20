namespace Task_5_Store.Tools;

public class Input
{
    private readonly Output _output;

    public Input(Output output)
    {
        _output = output;
    }

    public int ReadNumber()
    {
        int number;

        while (true)
        {
            var line = Console.ReadLine();
            var isParsed = int.TryParse(line, out number);

            if (!isParsed)
            {
                _output.PrintNumberInputErrorMessage();
            }
            else
            {
                break;
            }
        }

        return number;
    }

    public string ReadLine()
    {
        string? line;
        
        while (true)
        {
             line = Console.ReadLine();

            if (line != null && line.Length > 0 && !line.StartsWith(" "))
            {
                break;
            }
            
            _output.PrintLineInputErrorMessage();
        }

        return line;
    }
}