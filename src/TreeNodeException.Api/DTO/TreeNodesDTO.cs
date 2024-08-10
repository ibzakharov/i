using TreeNodeException.Dtos;

namespace TreeNodeException.Api.DTO;

public record TreeNodesDTO(int TreeID, string TreeName, ICollection<NodeDTO> Nodes);