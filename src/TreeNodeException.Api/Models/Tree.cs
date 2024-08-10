using System.Xml;

namespace TreeNodeException.Api.Models;

public class Tree
{
    public int TreeID { get; set; }
    public string TreeName { get; set; }
    public ICollection<Node> Nodes { get; set; }
}