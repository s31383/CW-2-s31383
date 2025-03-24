namespace ConsoleApp4;

public class LiquidContainer(bool isDanger,double capacity, double height, double depth, double weight) 
    : Container('L',capacity,height,depth,weight), IHazardNotifier
{
    public LiquidContainer(bool isDanger) : this(isDanger,28000.0,259,606,2200) {}
    public override void Load(double weight)
    {
        base.Load(weight);
        if (ProductWeight + weight > Capacity * (isDanger ? 0.5 : 0.9))
            (this as IHazardNotifier).Notify($"try to overload a container with {(isDanger ? " " : "not ")}dangerous liquid");
        else
            ProductWeight += weight;
    }

    public override void Unload(double weight)
    {
        ProductWeight -= weight;
    }
}