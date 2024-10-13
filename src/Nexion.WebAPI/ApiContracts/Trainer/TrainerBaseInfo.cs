namespace Nexion.WebAPI.ApiContracts.Trainer;

using System.Collections.Generic;

public class TrainerBaseInfo
{
    public string Name { get; set; }

    public string CenterId { get; set; }

    public List<string> Specialties { get; set; }

    public int Experience { get; set; }
}
