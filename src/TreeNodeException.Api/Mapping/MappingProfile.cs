using AutoMapper;
using TreeNodeException.Api.Dtos;

namespace TreeNodeException.Api.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Node, NodeDto>()
            .ForMember(i => i.NodeId, opt => opt.MapFrom(src => src.NodeId))
            .ForMember(i => i.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(i => i.Children, opt => opt.MapFrom(src => src.Children))
            .ReverseMap();

        CreateMap<TreeDto, Tree>()
            .ForMember(i => i.TreeId, opt => opt.MapFrom(src => src.TreeId))
            .ForMember(i => i.TreeName, opt => opt.MapFrom(src => src.TreeName))
            .ForMember(i => i.Nodes, opt => opt.MapFrom(src => src.Nodes))
            .ReverseMap();
    }
}