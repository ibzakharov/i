namespace TreeNodeException.Api.Dtos;

public class TreeNodesDto : TreeDto
{
    public ICollection<NodeChildDto> Nodes { get; set; }
}