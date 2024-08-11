using AutoMapper;
using TreeNodeException.Api.Dtos;

namespace TreeNodeException.Api.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ModifyNodeDto, Node>()
            .ReverseMap();
        
        CreateMap<Node, NodeDto>()
            .ReverseMap();
        
        CreateMap<Node, NodeChildDto>()
            .ForMember(dest => dest.Child, opt => opt.MapFrom(src => src.Child))
            .ReverseMap();

        CreateMap<TreeDto, Node>()
            .ForMember(i => i.NodeId, opt => opt.MapFrom(src => src.TreeId))
            .ForMember(i => i.Name, opt => opt.MapFrom(src => src.TreeName))
            .ReverseMap();
        
        CreateMap<TreeNodesDto, Node>()
            .ForMember(i => i.NodeId, opt => opt.MapFrom(src => src.TreeId))
            .ForMember(i => i.Name, opt => opt.MapFrom(src => src.TreeName))
            .ForMember(i => i.Child, opt => opt.MapFrom(src => src.Nodes))
            .ReverseMap();

        CreateMap<ModifyTreeDto, Node>()
            .ForMember(i => i.Name, opt => opt.MapFrom(src => src.TreeName))
            .ReverseMap();
    }
}