namespace BlackArm.Application.Contracts;

public interface IRepositoryManager
{
    IArmWrestlerRepository ArmWrestler { get; }
    
    Task SaveAsync();
}