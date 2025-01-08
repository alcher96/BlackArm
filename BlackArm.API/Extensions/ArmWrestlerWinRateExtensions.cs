namespace BlackArm.API.Extensions;

public static class ArmWrestlerWinRateExtensions
{
    public static double CalculateWinRate(this int wins, int loss)
    {
        var total = wins + loss;
        if (total ==0) return 0;
        
        double percentage = ((double)wins / total) * 100;
        
        return Math.Round(percentage, 2);
            
    }
}