namespace TreeNodeException.Api.Models;

using System.Collections.Generic;

public class Node
{
    public int NodeID { get; set; }
    public string NodeName { get; set; }
    public int? ParentNodeID { get; set; }
    public int TreeID { get; set; }
    public Tree Tree { get; set; }
    public Node ParentNode { get; set; }
    public ICollection<Node> ChildNodes { get; set; }
}