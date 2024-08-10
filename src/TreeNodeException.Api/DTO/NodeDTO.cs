namespace TreeNodeException.Dtos;

public record NodeDTO(int NodeID, string NodeName, int? ParentNodeID, int TreeID, string OtherAttributes);

public record ModifyNodeDTO(string NodeName, int TreeID);