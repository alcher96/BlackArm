namespace BlackArm.API.DTOs.FightsDto;

public class FightWithWrestlersNameDto
{
    public Guid FightId { get; set; }
    public string Wrestler1Name { get; set; }
    public string Wrestler2Name { get; set; }
    public string WinnerName { get; set; }

}