namespace ConsoleApp2;

public class Vacation
{
    public int Id { get; set; }
    public DateTime DateSince { get; set; }
    public DateTime DateUntil { get; set; }
    public int NumberOfHours { get; set; }
    public int IsPartialVacation { get; set; }
    public int EmployeeId { get; set; }

    public Vacation(int id, DateTime dateSince, DateTime dateUntil, int numberOfHours, int isPartialVacation, int employeeId)
    {
        Id = id;
        DateSince = dateSince;
        DateUntil = dateUntil;
        NumberOfHours = numberOfHours;
        IsPartialVacation = isPartialVacation;
        EmployeeId = employeeId;
    }
}