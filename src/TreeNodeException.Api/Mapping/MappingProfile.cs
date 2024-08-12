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
    }
}