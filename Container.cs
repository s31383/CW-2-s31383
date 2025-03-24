namespace ConsoleApp4;

public abstract class Container(char type, double capacity, double height, double depth,double weight)
{
    private static int _number;
    public double ProductWeight { get; protected set; }
    public double Capacity { get; } = capacity;
    public double OwnWeight { get; } = weight;
    public double Height { get; set; } = height;
    public double Depth { get; set; } = depth;
    public string Number { get; } = $"KON-{type}-{_number++}";
    public virtual void Load(double weight) 
    {
        if (weight + ProductWeight > Capacity) throw new OverfillException();
    }
    public abstract void Unload(double weight);
    public override string ToString()
    {
        return $"{Number}: product weight = {ProductWeight}, own weight = {OwnWeight}";
    }
}