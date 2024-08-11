namespace TreeNodeException.Api.Dtos;

public class NodeChildDto : NodeDto
{
    public ICollection<NodeChildDto> Child { get; set; }
}