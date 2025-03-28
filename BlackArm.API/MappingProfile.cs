using AutoMapper;
using BlackArm.API.Controllers;
using BlackArm.API.DTOs;
using BlackArm.API.DTOs.CompetitionsDto;

using BlackArm.API.DTOs.FightsDto;
using BlackArm.API.DTOs.RoundsDto;
using BlackArm.API.DTOs.StylesDto;
using BlackArm.API.Extensions;
using BlackArm.Application.Paging;
using BlackArm.Domain.Models;

namespace BlackArm.API;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ArmWrestler, ArmWrestlerDto>();
            

        CreateMap<ArmWrestlerForCreationDto, ArmWrestler>();
        CreateMap<ArmWrestlerForUpdateDto, ArmWrestler>();
       // CreateMap<ArmwrestlerForUpdateDto, ArmWrestler>().ReverseMap();
       
       CreateMap<Competition, CompetitionDto>();
       CreateMap<CompetitionForCreationDto, Competition>();
       CreateMap<ComtetitionForUpdateDto, Competition>();
       
       // Маппинг PagedList<Competition> -> IEnumerable<CompetitionDto>
       CreateMap<PagedList<Competition>, IEnumerable<CompetitionDto>>()
           .ConvertUsing(src => src.Items.Select(item => new CompetitionDto
           {
               CompetitionId = item.CompetitionId,
               CompetitionName = item.CompetitionName,
               CompetitionDate = item.CompetitionDate
           }));

       
       // Mapping from Fight to FightDto
       CreateMap<Fight, FightDto>()
           .ForMember(dest => dest.FightId, opt => opt.MapFrom(src => src.FightId))
           .ForMember(dest => dest.Wrestler1, opt => opt.MapFrom(src => src.Wrestler1))
           .ForMember(dest => dest.Wrestler2, opt => opt.MapFrom(src => src.Wrestler2))
           .ForMember(dest => dest.Winner, opt => opt.MapFrom(src => src.Winner))
           .ForMember(dest => dest.BestOf, opt => opt.MapFrom(src => src.BestOf))
           .ForMember(dest => dest.Hand, opt => opt.MapFrom(src => src.Hand));
           
       // Mapping to a new DTO that includes first names
       CreateMap<Fight, FightWithWrestlersNameDto>()
           .ForMember(dest => dest.FightId, opt => opt.MapFrom(src => src.FightId))
           .ForMember(dest => dest.Wrestler1Name,
               opt => opt.MapFrom(src => $"{src.Wrestler1.FirstName} {src.Wrestler1.LastName}"))
           .ForMember(dest => dest.Wrestler2Name,
               opt => opt.MapFrom(src => $"{src.Wrestler2.FirstName} {src.Wrestler2.LastName}"))
           .ForMember(dest => dest.WinnerName,
               opt => opt.MapFrom(src => $"{src.Winner.FirstName} {src.Winner.LastName}"))
           .ForMember(dest => dest.Hand, opt => opt.MapFrom(src => src.Hand))
           .ForMember(dest => dest.BestOf, opt => opt.MapFrom(src => src.BestOf));





       CreateMap<FightForCreatingDto, Fight>()
           .ForMember(dest => dest.Wrestler1Id, opt => opt.MapFrom(src => src.Wrestler1Id))
           .ForMember(dest => dest.Wrestler2Id, opt => opt.MapFrom(src => src.Wrestler2Id));
         
       
       CreateMap<Round, RoundDto>()
           .ForMember(dest => dest.RoundId, opt => opt.MapFrom(src => src.RoundId))
           .ForMember(dest => dest.WinnerName , opt=> opt.MapFrom(src => $"{src.Winner.FirstName} {src.Winner.LastName}"))
           .ForMember(dest => dest.StyleUsed, opt => opt.MapFrom(src => src.StyleUsed.StyleName))
           .ForMember(dest => dest.RoundNumber, opt => opt.MapFrom(src => src.RoundNumber));
       
       
       
       CreateMap<RoundForCreationDto, Round>();

       CreateMap<WrestlingStyle, WrestlingStyleDto>()
           .ForMember(dest => dest.StyleId, opt => opt.MapFrom(src => src.StyleId))
           .ForMember(dest => dest.StyleName, opt => opt.MapFrom(src => src.StyleName));


       CreateMap<WrestlingStyleForCreationDto, WrestlingStyle>()
           .ForMember(dest => dest.StyleName, opt => opt.MapFrom(src => src.StyleName));



    }

}