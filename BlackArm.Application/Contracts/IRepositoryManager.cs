namespace BlackArm.Application.Contracts;

public interface IRepositoryManager
{
    IArmWrestlerRepository ArmWrestler { get; }
    
    ICompetitionRepository Competition { get; }
    


    IFightRepository Fight { get; }
    
    IRoundRepository Round { get; }
    
    IStyleRepository Style { get; }
    Task SaveAsync();
}