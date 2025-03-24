namespace ConsoleApp4;

public class GasContainer(double pressure, double capacity,double height, double depth,double weight) : Container('G',capacity,height,depth,weight), IHazardNotifier
{
    public double Pressure { get; } = pressure;
    private double Min {get;set;}
    public GasContainer(double pressure) : this(pressure,28000.0,259,606,2200){}
    public override void Load(double weight)
    {
        base.Load(weight);
        ProductWeight += weight;
        Min = ProductWeight / 20;
    }
    public override void Unload(double weight)
    {
        if (ProductWeight - weight < Min) 
            (this as IHazardNotifier).Notify("unloaded too much gas, left less then 5%");
        ProductWeight -= weight;
    }
}