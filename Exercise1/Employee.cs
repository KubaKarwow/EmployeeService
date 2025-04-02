namespace ConsoleApp1;

public class Employee
{
    public int Id { get; set; }
    public String Name { get; set; }
    public int? SuperiorId { get; set; }
    public virtual Employee Superior { get; set; }

    public Employee(int id, string name, int? superiorId, Employee superior)
    {
        Id = id;
        Name = name;
        SuperiorId = superiorId;
        Superior = superior;
    }
}