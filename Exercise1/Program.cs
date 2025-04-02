using ConsoleApp1;

// Mock Data
List<Employee> employees = new List<Employee>();
employees.Add(new Employee(2, "name2", null, null));
employees.Add(new Employee(1, "name1", 2, employees[0]));
employees.Add(new Employee(3, "name3", 2, employees[0]));
employees.Add(new Employee(4, "name4", 2, employees[0]));
employees.Add(new Employee(5, "name5", 4, employees[3]));

// Creates a tree structure containing superior relations \
EmployeeStructureTree employeeStructure = FillEmployeesStructure(employees);
// Records are put in the tree by their employeeId
// structure example in this case:
//    2 
//  / | \
// 1  3  4 
//        \
//         5

// Function to show the tree structure.
employeeStructure.ShowStructureTree(employeeStructure.Root);

// Example function usage
var superiorRowOfEmployee = GetSuperiorRowOfEmployee(5, 2);

Console.WriteLine(superiorRowOfEmployee == null
    ? "This Id is not a superior to the given employee."
    : superiorRowOfEmployee);

// Function used to find a node by the employeeId.
// params: 
// currentNode - starting node in the tree from which it looks for the result node.
// employeeId - Id of the employee function looks for.
// optional row - if user wants to retrieve information about superior row, default value should be given 0, otherwise null is recommended
// returns:
// null if employee is not in the subtree of a superior, superior row if it is. 
EmployeeStructureNode? FindInTree(EmployeeStructureNode currentNode, int employeeId, int? row)
{
    if (currentNode.EmployeeId == employeeId)
    {
        currentNode.Row = row;
        return currentNode;
    }

    if (currentNode.Children == null)
    {
        return null;
    }

    if (currentNode.Children.Keys.Contains(employeeId))
    {
        var resultNode = currentNode.Children[employeeId];
        resultNode.Row = row + 1;
        return resultNode;
    }

    foreach (var childNode in currentNode.Children.Values)
    {
        var potentialResultNode = FindInTree(childNode, employeeId, row + 1);
        if (potentialResultNode != null)
        {
            return potentialResultNode;
        }
    }

    return null;
}

// Function used to determine the superior row for an employee and its superior
// params: 
// employeeId - Id of the employee.
// superiorId - Id of the superior.
// returns:
// null if employee is not in the subtree of a superior, superior row if it is. 
int? GetSuperiorRowOfEmployee(int employeeId, int superiorId)
{
    // First function finds the node where employeeId matches superiorId given to the function, starting from Root
    EmployeeStructureNode employeeStructureNode = FindInTree(employeeStructure.Root, superiorId, null);

    // Later function looks through the subtree starting from the node found previously (superiorId)
    var findInTree = FindInTree(employeeStructureNode, employeeId, 0);

    // Depending on whether the subtree contains a node with employeeId matching the one given as an argument it returns superior row.
    return findInTree == null ? null : findInTree.Row;
}

// Function responsible for building the tree structure from a list of employees
// params:
// employees - list of employee records
// returns:
// EmployeeStructureTree -  a new dataset that has all the information about superiors in it.
EmployeeStructureTree FillEmployeesStructure(List<Employee> employees)
{
    List<int> employeesAdded = new List<int>();
    var ultimateSuperior = GetUltimateSuperior(employees);
    var root = new EmployeeStructureNode(ultimateSuperior.Id, null);
    employeesAdded.Add(ultimateSuperior.Id);
    employees.Remove(ultimateSuperior);

    while (employees.Count != 0)
    {
        foreach (var employee in employees)
        {
            if (!employeesAdded.Contains((int)employee.SuperiorId))
            {
                continue;
            }

            AddEmployee(employee, root);
            employees.Remove(employee);
            employeesAdded.Add(employee.Id);
            break;
        }
    }

    return new EmployeeStructureTree(root);
}

// Function responsible for finding the right employee by employeeId in the tree
// params:
// employee - employee which is supposed to be added to the tree.
// currentNode - Node from which the search should start.
// returns:
// true if the employee record was added, false if it was not. 
bool AddEmployee(Employee employee, EmployeeStructureNode currentNode)
{
    int superiorId = (int)employee.SuperiorId;
    if (currentNode.EmployeeId == superiorId)
    {
        currentNode.AddChild(employee.Id);
        return true;
    }

    if (currentNode.Children == null)
    {
        return false;
    }

    if (currentNode.Children.Keys.Contains(superiorId))
    {
        currentNode.Children[superiorId].AddChild(employee.Id);
        return true;
    }

    foreach (var employeeStructureNode in currentNode.Children.Values)
    {
        if (AddEmployee(employee, employeeStructureNode))
        {
            return true;
        }
    }

    return false;
}

// Function used at the very beginning of creating a tree, looks for the root node (employee with no superior)
// params:
// employees - list of employees in which it looks for the right employee.
// returns:
// Employee record that has no superior.
// Throws:
// Exception("Wrong employee list, no ultimate superior given.") when there is no ultimate superior in the list.
Employee GetUltimateSuperior(List<Employee> employees)
{
    var employee = employees.Find(emp => emp.SuperiorId == null);
    if (employee == null)
    {
        throw new Exception("Wrong employee list, no ultimate superior given.");
    }

    return employee;
}
