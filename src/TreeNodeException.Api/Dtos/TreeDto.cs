using System.Text.Json.Serialization;

namespace TreeNodeException.Api.Dtos;

public class TreeDto
{
    [JsonPropertyName("id")]
    public int TreeId { get; set; }
    
    [JsonPropertyName("name")]
    public string TreeName { get; set; }
    
    [JsonPropertyName("children")]
    public ICollection<NodeDto> Nodes { get; set; }
}