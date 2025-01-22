using AutoMapper;
using BlackArm.API.Controllers;
using BlackArm.API.DTOs;
using BlackArm.API.DTOs.CompetitionsDto;
using BlackArm.API.DTOs.FightsDto;
using BlackArm.API.DTOs.RoundsDto;
using BlackArm.API.Extensions;
using BlackArm.Domain.Models;

namespace BlackArm.API;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ArmWrestler,ArmWrestlerDto>()
            .ForMember(a => a.FullName,
                opt =>
                    opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
            .ForMember(dest => dest.Age, 
                opt => 
                    opt.MapFrom(src => CalculateAge(src.BirthDate)))
            .ForMember(dest => dest.WinRate, opt =>
                opt.MapFrom(src => src.Wins.CalculateWinRate(src.Losses)));

        CreateMap<ArmWrestlerForCreationDto, ArmWrestler>();
        CreateMap<ArmWrestlerForUpdateDto, ArmWrestler>();
       // CreateMap<ArmwrestlerForUpdateDto, ArmWrestler>().ReverseMap();
       
       CreateMap<Competition, CompetitionDto>();
       CreateMap<CompetitionForCreationDto, Competition>();
       CreateMap<ComtetitionForUpdateDto, Competition>();

       
       // Mapping from Fight to FightDto
       CreateMap<Fight, FightDto>()
           .ForMember(dest => dest.FightId, opt => opt.MapFrom(src => src.FightId))
           .ForMember(dest => dest.Wrestler1, opt => opt.MapFrom(src => src.Wrestler1))
           .ForMember(dest => dest.Wrestler2, opt => opt.MapFrom(src => src.Wrestler2))
           .ForMember(dest => dest.Winner, opt => opt.MapFrom(src => src.Winner))
           .ForMember(dest => dest.StyleUsed, opt => opt.MapFrom(src => src.StyleUsedId));
           
       // Mapping to a new DTO that includes first names
       CreateMap<Fight, FightWithWrestlersNameDto>()
           .ForMember(dest => dest.FightId, opt => opt.MapFrom(src => src.FightId))
           .ForMember(dest => dest.Wrestler1Name,
               opt => opt.MapFrom(src => $"{src.Wrestler1.FirstName} {src.Wrestler1.LastName}"))
           .ForMember(dest => dest.Wrestler2Name,
               opt => opt.MapFrom(src => $"{src.Wrestler2.FirstName} {src.Wrestler2.LastName}"))
           .ForMember(dest => dest.WinnerName,
               opt => opt.MapFrom(src => $"{src.Winner.FirstName} {src.Winner.LastName}"));// Assuming you want the winner's first name too

    
           
           
       CreateMap<FightForCreatingDto, Fight>();
       
       CreateMap<Round, RoundDto>()
           .ForMember(dest => dest.RoundId, opt => opt.MapFrom(src => src.RoundId))
           .ForMember(dest => dest.WinnerName , opt=> opt.MapFrom(src => $"{src.Winner.FirstName} {src.Winner.LastName}"))
           .ForMember(dest => dest.StyleUsed, opt => opt.MapFrom(src => src.StyleUsed.StyleName))
           .ForMember(dest => dest.RoundNumber, opt => opt.MapFrom(src => src.RoundNumber));
       
       
       
       CreateMap<RoundForCreationDto, Round>();


    }
    private int CalculateAge(DateTimeOffset birthDate)
    {
        var today = DateTime.Today;
        var age = today.Year - birthDate.Year;
        if (birthDate > today.AddYears(-age))
        {
            age--;
        }
        return age;
    }
}