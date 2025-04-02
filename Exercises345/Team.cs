namespace ConsoleApp2;

public class Team
{
    public int Id { get; set; }
    public String Name { get; set; }

    public Team(int id, string name)
    {
        Id = id;
        Name = name;
    }
}