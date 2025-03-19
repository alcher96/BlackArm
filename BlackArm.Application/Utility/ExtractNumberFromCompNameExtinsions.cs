namespace BlackArm.API.Extensions;

public static class ExtractNumberFromCompNameExtinsions
{
    public static int ExtractNumber(string name)
    {
        if (string.IsNullOrEmpty(name))
            return 0;

        var match = System.Text.RegularExpressions.Regex.Match(name, @"\d+$");
        return match.Success ? int.Parse(match.Value) : 0;
    }
}