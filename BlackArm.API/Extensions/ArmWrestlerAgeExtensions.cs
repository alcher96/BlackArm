namespace BlackArm.API.Extensions;

public static class ArmWrestlerAgeExtensions
{
    public static int CalculateAge(this DateTimeOffset birthDate)
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