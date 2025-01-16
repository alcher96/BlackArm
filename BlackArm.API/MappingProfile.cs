using AutoMapper;
using BlackArm.API.Controllers;
using BlackArm.API.DTOs;
using BlackArm.API.DTOs.CompetitionsDto;
using BlackArm.API.DTOs.FightsDto;
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


       CreateMap<Fight, FightDto>();
       CreateMap<FightForCreatingDto, Fight>();


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