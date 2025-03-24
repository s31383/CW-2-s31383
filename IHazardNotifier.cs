namespace ConsoleApp4;

public interface IHazardNotifier
{
    public string Number { get; }
    public void Notify(string str)
    {
        Console.WriteLine($"{Number} error: {str}");
    }
}