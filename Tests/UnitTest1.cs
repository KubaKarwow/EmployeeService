using ConsoleApp2;

namespace Tests;

[TestClass]
public class UnitTest1
{
    private VacationService _vacationService;

    [TestInitialize]
    public void Setup()
    {
        _vacationService = new VacationService();
    }

    [TestMethod]
    public void Employee_can_request_vacation()
    {
        // Arrange
        Employee employee = new Employee(1, "Smith", 1, 1, 1);
        List<Vacation> vacations = new List<Vacation>();

        vacations.Add(new Vacation(1,
            new DateTime(2025, 03, 20),
            new DateTime(2025, 04, 01),
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

        // 21 is an edge case, if it was any lesser the function should return false.
        var vacationPackage = new VacationPackage(1, "Self-care", 21, DateTime.Now.Year);

        // Act
        var ifEmployeeCanRequestVacation =
            _vacationService.IfEmployeeCanRequestVacation(employee, vacations, vacationPackage);

        // Assert
        Assert.IsTrue(ifEmployeeCanRequestVacation, "Error with calculating ability of an employee to go on vacation.");
    }

    [TestMethod]
    public void Employee_cant_request_vacation()
    {
        Employee employee = new Employee(1, "Smith", 1, 1, 1);
        List<Vacation> vacations = new List<Vacation>();

        vacations.Add(new Vacation(1,
            new DateTime(2025, 03, 20),
            new DateTime(2025, 04, 01),
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

        vacations.Add(new Vacation(3,
            new DateTime(2025, 02, 05),
            new DateTime(2025, 02, 20),
            14,
            1,
            1));

        // 36 is an edge case, if it was any bigger the function should return true.
        var vacationPackage = new VacationPackage(1, "Self-care", 36, DateTime.Now.Year);

        // Act
        var ifEmployeeCanRequestVacation =
            _vacationService.IfEmployeeCanRequestVacation(employee, vacations, vacationPackage);

        // Assert
        Assert.IsFalse(ifEmployeeCanRequestVacation,
            "Error with calculating ability of an employee to go on vacation.");
    }
}