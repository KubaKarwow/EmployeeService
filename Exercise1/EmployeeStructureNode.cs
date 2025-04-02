namespace ConsoleApp1;

public class EmployeeStructureNode
{
    public int EmployeeId { get; set; }
    public int? SuperiorId { get; set; }
    public int? Row { get; set; }
    public Dictionary<int,EmployeeStructureNode>? Children  { get; set; }
    public EmployeeStructureNode(int employeeId, int? superiorId)
    {
        EmployeeId = employeeId;
        SuperiorId = superiorId;
    }

    public void AddChild(int childId)
    {
        if (Children == null)
        {
            Children = new Dictionary<int, EmployeeStructureNode>();
        }
        Children.Add(childId,new EmployeeStructureNode(childId,EmployeeId));
    }
    public override string ToString()
    {
        return "Employee ID:" + EmployeeId + ", Superior ID:" + SuperiorId;
    }
}