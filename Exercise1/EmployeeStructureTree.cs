using ConsoleApp1;

public class EmployeeStructureTree
{
    public EmployeeStructureNode Root { get; set; }

    public EmployeeStructureTree(EmployeeStructureNode root)
    {
        Root = root;
    }

    public void ShowStructureTree(EmployeeStructureNode currentNode, string indent = "")
    {
        Console.WriteLine($"{indent}- Employee ID: {currentNode.EmployeeId} (Superior ID: {(currentNode.SuperiorId == null ? "None" : currentNode.SuperiorId.ToString())})");

        if (currentNode.Children == null )
        {
            return;
        }

        foreach (var child in currentNode.Children.Values)
        {
            ShowStructureTree(child, indent + "   ");
        }
    }
}