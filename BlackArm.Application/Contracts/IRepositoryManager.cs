namespace BlackArm.Application.Contracts;

public interface IRepositoryManager
{
    IArmWrestlerRepository ArmWrestler { get; }
    
    ICompetitionRepository Competition { get; }
    
    Task SaveAsync();
}