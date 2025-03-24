namespace ConsoleApp4;
public class Program{
    public static void Main(string[] args)
    {
        ContainerShip firstShip = new ContainerShip(100), otherShip = new ContainerShip(200);
        List<LiquidContainer> containers = new List<LiquidContainer>();
        for(var i = 0; i < 20; i++)
            containers.Add(new LiquidContainer(true));
        double totalWeight = 0;
        foreach (var container in containers)
        {
            container.Load(totalWeight += 100);
            firstShip.Load(container);
        }
        otherShip.Load(firstShip.Unload());
        firstShip.Change(otherShip.Unload(0), 4);
        otherShip.Load(firstShip.Unload());
        otherShip.Load(firstShip.Unload());
        firstShip.Load(otherShip.UnloadAll());
        firstShip.ShowContainers();
        otherShip.ShowContainers();
    }
}
