namespace ConsoleApp2;

public class VacationService
{

// Function used to calculate amount of remaining vacation days in the current for a given employee.
// params:
// employee - an employee record for which the function calculates vacation days.
// vacations - List of Vacation objects related to the employee.
// vacationPackage - VacationPackage record containing information for a vacation package related to the employee.
    public int CountFreeDaysForEmployee(Employee employee, List<Vacation> vacations, VacationPackage vacationPackage)
    {
        int grantedDays = vacationPackage.GrantedDays;
        int daysSpentOnVacation = 0;
        var currentDate = DateTime.Now;
        var beginOfCurrentYear = new DateTime(currentDate.Year, 1, 1);
        foreach (var vacation in vacations)
        {
            // Depending on the case, vacation can start either at:
            // vacation.DateSince if the date is in the current year.
            // Beginning of the current year, if the vacation started in the previous one.
            DateTime start = vacation.DateSince.Year == currentDate.Year - 1
                ? beginOfCurrentYear
                : vacation.DateSince;

            // Depending on the case, vacation can end either at:
            // vacation.DateUntil, if the vacation had already ended. Plus one day, because the ending day of the vacation should also count.
            // current date, if the vacation is supposed to end in the future.
            DateTime end = vacation.DateUntil > currentDate
                ? currentDate
                : vacation.DateUntil.AddDays(1);

            var timeSpan = end.Subtract(start);
            daysSpentOnVacation += timeSpan.Days;
        }

        return grantedDays - daysSpentOnVacation;
    }

// Function used to determine whether an employee can request vacation in the current year.
// params:
// employee - an employee record for which the function calculates vacation.
// vacations - List of Vacation objects related to the employee.
// vacationPackage - VacationPackage record containing information for a vacation package related to the employee.
    public bool IfEmployeeCanRequestVacation(Employee employee, List<Vacation> vacations,
        VacationPackage vacationPackage)
    {
        var countFreeDaysForEmployee = CountFreeDaysForEmployee(employee, vacations, vacationPackage);
        if (countFreeDaysForEmployee <= 0)
        {
            return false;
        }

        return true;
    }
}
