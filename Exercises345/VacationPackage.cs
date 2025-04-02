namespace ConsoleApp2;

public class VacationPackage
{
    public int Id { get; set; }
    public String Name { get; set; }
    public int GrantedDays { get; set; }
    public int Year { get; set; }

    public VacationPackage(int id, string name, int grantedDays, int year)
    {
        Id = id;
        Name = name;
        GrantedDays = grantedDays;
        Year = year;
    }
}