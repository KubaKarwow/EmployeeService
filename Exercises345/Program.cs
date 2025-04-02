using ConsoleApp2;

//Mock data
Employee employee = new Employee(1, "Smith", 1, 1, 1);
List<Vacation> vacations = new List<Vacation>();

vacations.Add(new Vacation(1,
    new DateTime(2025, 03, 20),
    new DateTime(2025, 04, 02),
    14,
    1,
    1));

vacations.Add(new Vacation(2,
    new DateTime(2025, 02, 20),
    new DateTime(2025, 02, 25),
    14,
    1,
    1));

vacations.Add(new Vacation(3,
    new DateTime(2024, 12, 24),
    new DateTime(2025, 01, 01),
    14,
    1,
    1));

var vacationPackage = new VacationPackage(1, "Self-care", 30, DateTime.Now.Year);

var vacationService = new VacationService();
// Usage of the function counting remaining days for employee in the current year.
var countFreeDaysForEmployee = vacationService.CountFreeDaysForEmployee(employee, vacations, vacationPackage);
Console.WriteLine("Remaining free days for employee:" + countFreeDaysForEmployee);

// Usage of the function returning whether employee can request vacation in the current year.
var ifEmployeeCanRequestVacation = vacationService.IfEmployeeCanRequestVacation(employee,vacations,vacationPackage);
Console.WriteLine("Can employee request vacation:" + ifEmployeeCanRequestVacation);
