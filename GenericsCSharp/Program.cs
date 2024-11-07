
using System;
using System.Collections;
using System.Collections.Generic;


Oceanarium arr = new Oceanarium(5);
arr.AddCreature(new Shark("Dori"));
arr.AddCreature(new Whale("Mitty"));
arr.AddCreature(new Octopus("Lily"));

foreach(SeaCreature animal in arr)
{
    animal.Description();
}



public abstract class SeaCreature
{
    public string Name { get; set; }

    public SeaCreature(string name)
    {
        Name = name;
    }

    public abstract void Description();
}
public class Shark : SeaCreature
{
    public Shark(string name) : base(name) { }

    public override void Description()
    {
        Console.WriteLine($"This is shark {Name}");
    }
}

public class Whale : SeaCreature
{
    public Whale(string name) : base(name) { }

    public override void Description()
    {
        Console.WriteLine($"This is whale {Name}");
    }
}

public class Octopus : SeaCreature
{
    public Octopus(string name) : base(name) { }

    public override void Description()
    {
        Console.WriteLine($"This is Octopus {Name}");
    }
}

public class Oceanarium : IEnumerable<SeaCreature>
{
    private SeaCreature[] arr;
    private int curPos = 0;

    public Oceanarium(int len)
    {
        arr = new SeaCreature[len];
    }

    public void AddCreature(SeaCreature creature)
    {
        if (curPos < arr.Length)
        {
            arr[curPos] = creature;
            curPos++;
        }
        else
        {
            Console.WriteLine("Oceanarium is full!");
        }
    }

    public IEnumerator<SeaCreature> GetEnumerator()
    {
        for (int i = 0; i < curPos; i++)
        {
            yield return arr[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

