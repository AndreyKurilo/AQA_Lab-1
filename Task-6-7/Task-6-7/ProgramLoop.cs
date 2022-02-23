namespace Task_6_7;

public class ProgramLoop
{
    private readonly Output _output;
    private readonly Input _input;

    public ProgramLoop(Input input, Output output)
    {
        _input = input;
        _output = output;
    }
    
    public void Run()
    {
        while (true)
        {
            // menu.DisplayOptions();
            // var command = menu.AskForCommand();
            // menu.Handle(command);
        }
    }
}