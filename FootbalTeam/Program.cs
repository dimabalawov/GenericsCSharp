using System;
using System.Collections;
using System.Collections.Generic;

FootballTeam team = new FootballTeam(5);
team.AddPlayer(new Forward("Cristiano"));
team.AddPlayer(new Goalkeeper("Manuel"));
team.AddPlayer(new Defender("Sergio"));

foreach (Player player in team)
{
    player.Description();
}

public abstract class Player
{
    public string Name { get; set; }

    public Player(string name)
    {
        Name = name;
    }

    public abstract void Description();
}

public class Forward : Player
{
    public Forward(string name) : base(name) { }

    public override void Description()
    {
        Console.WriteLine($"This is forward {Name}");
    }
}

public class Goalkeeper : Player
{
    public Goalkeeper(string name) : base(name) { }

    public override void Description()
    {
        Console.WriteLine($"This is goalkeeper {Name}");
    }
}

public class Defender : Player
{
    public Defender(string name) : base(name) { }

    public override void Description()
    {
        Console.WriteLine($"This is defender {Name}");
    }
}

public class FootballTeam : IEnumerable<Player>
{
    private Player[] players;
    private int curPos = 0;

    public FootballTeam(int len)
    {
        players = new Player[len];
    }

    public void AddPlayer(Player player)
    {
        if (curPos < players.Length)
        {
            players[curPos] = player;
            curPos++;
        }
        else
        {
            Console.WriteLine("Football team is full!");
        }
    }

    public IEnumerator<Player> GetEnumerator()
    {
        for (int i = 0; i < curPos; i++)
        {
            yield return players[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
