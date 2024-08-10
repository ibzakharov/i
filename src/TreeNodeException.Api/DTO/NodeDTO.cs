namespace TreeNodeException.Dtos;

public class NodeDTO
{
    public int NodeID { get; init; }
    public string NodeName { get; init; } 
    public int? ParentNodeID { get; init; }
    public int TreeID { get; init; }
}