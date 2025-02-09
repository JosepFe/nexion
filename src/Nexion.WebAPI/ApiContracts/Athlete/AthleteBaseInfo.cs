namespace Nexion.WebAPI.ApiContracts.Athlete;

public class AthleteBaseInfo
{
    public string Name { get; set; }

    public int Age { get; set; }

    public string CenterId { get; set; }

    public List<string> Sports { get; set; }
}
