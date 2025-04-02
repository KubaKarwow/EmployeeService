namespace ConsoleApp2;

public class Employee
{
    public int Id { get; set; }
    public String Name { get; set; }
    public int PositionId { get; set; }
    public int TeamId { get; set; }
    public int VacationPackageId { get; set; }

    public Employee(int id, string name, int positionId, int teamId, int vacationPackageId)
    {
        Id = id;
        Name = name;
        PositionId = positionId;
        TeamId = teamId;
        VacationPackageId = vacationPackageId;
    }
}