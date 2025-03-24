namespace ConsoleApp4;
public class ContainerShip(double speed, double maxWeight, int capacity)
{
    public IList<Container> Containers { get; set; } = new List<Container>(capacity);
    public double Speed { get; } = speed;
    public int Capacity { get; } = capacity;
    public double MaxWeight { get; } = maxWeight;
    private double _totalWeight;
    public ContainerShip(double speed) : this(speed,50.0,60){}
    
    public void Load(IList<Container> containers)
    {
        foreach (var container in containers)
            Load(container);
    }

    public void Load(Container container)
    {
        if (container.ProductWeight + container.OwnWeight + _totalWeight > MaxWeight * 1000) return;
        if (Capacity < Containers.Count + 1) return;
        _totalWeight += container.ProductWeight + container.OwnWeight;
        Containers.Add(container);
    }

    public Container Change(Container container, int index)
    {
        if (index < 0 || index >= Containers.Count) throw new IndexOutOfRangeException();
        Container cont = Unload(index);
        Containers[index] = container;
        return cont;
    }
    public Container Unload()
    {
        return Unload(Containers.Count - 1);
    }

    public Container Unload(int index)
    {
        if (index < 0 || index >= Containers.Count) throw new IndexOutOfRangeException();
        var container = Containers[index];
        _totalWeight -= container.ProductWeight + container.OwnWeight;
        Containers.Remove(container);
        return container;
    }

    public IList<Container> UnloadAll()
    {
        _totalWeight = 0;
        IList<Container> containers = Containers;
        Containers = new List<Container>(containers.Count);
        return containers;
    } 
    public void ShowContainers()
    {
        Console.WriteLine($"Speed: {Speed} Total Weight: {_totalWeight} number of containers: {Containers.Count}");
        foreach (var container in Containers)
            Console.WriteLine($"{container}");
    }
}