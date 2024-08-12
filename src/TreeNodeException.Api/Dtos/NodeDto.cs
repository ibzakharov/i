using System.Text.Json.Serialization;

namespace TreeNodeException.Api.Dtos;

public class NodeDto
{
    [JsonPropertyName("id")]
    public int NodeId { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("children")]
    public ICollection<NodeDto> Children { get; set; }
}