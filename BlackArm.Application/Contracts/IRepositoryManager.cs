namespace BlackArm.Application.Contracts;

public interface IRepositoryManager
{
    IArmWrestlerRepository ArmWrestler { get; }
    
    ICompetitionRepository Competition { get; }
    


    IFightRepository Fight { get; }
    
    IRoundRepository Round { get; }
    Task SaveAsync();
}