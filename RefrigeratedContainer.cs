namespace ConsoleApp4;

public class RefrigeratedContainer(ProductType product, double temperature,double capacity,double height, double depth,double weight) : Container('C',capacity,height,depth,weight)
{
    public static Dictionary<ProductType, double> TemperaturesTable { get; } = new Dictionary<ProductType, double>();
    public ProductType Product { get; set; } = product;
    public double Temperature { get; set; } = temperature;

    public RefrigeratedContainer(ProductType product, double temperature) : 
        this(product, temperature, 28000.0, 259,606, 2200)
    { 
        if(!TemperaturesTable.ContainsKey(product))
            throw new ArgumentException("Temperature out of range");
        if(temperature < TemperaturesTable[product])
            throw new ArgumentException("Temperature out of range");
    }
    public override void Load(double weight)
    {
        base.Load(weight);
        ProductWeight += weight;
    }
    public void Load(double weight, ProductType productType)
    {
        if (productType != Product) return;
        Load(weight);
    }
    public override void Unload(double weight)
    {
        ProductWeight -= weight;
    }
}