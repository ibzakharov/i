using AutoMapper;
using TreeNodeException.Api.DTO;
using TreeNodeException.Api.Models;
using TreeNodeException.Dtos;

namespace TreeNodeException.Api.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Tree, TreeDTO>().ReverseMap();
        CreateMap<ModifyTreeDTO, Tree>().ReverseMap();
        CreateMap<Tree, TreeNodesDTO>().ReverseMap();

        CreateMap<ModifyNodeDTO, Node>().ReverseMap();
        

        CreateMap<Node, NodeDTO>().ReverseMap();
        
        
        
        CreateMap<ExceptionLog, ExceptionLogDTO>().ReverseMap();
    }
}