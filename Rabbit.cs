namespace HappyTails;

/// <summary>
/// Represents a rabbit, which is a companion mammal and can be adopted.
/// </summary>
public class Rabbit : CompanionMammal, IAdoptable
{
    private bool _isBonded;

    public bool IsBonded
    {
        get { return _isBonded; }
    }

    public double AdoptionFee
    {
        get { return 75; }
    }

    /// <summary>
    /// Creates a rabbit with its identifying information, physical characteristics, intake details, breed, spay/neuter status, and bonded status.
    /// </summary>
    /// <param name="animalId">Unique ID assigned to the rabbit.</param>
    /// <param name="name">Rabbit's name.</param>
    /// <param name="age">Rabbit's age in years.</param>
    /// <param name="color">Rabbit's coat color.</param>
    /// <param name="intakeDate">Date the rabbit entered the rescue center.</param>
    /// <param name="intakeSource">Source from which the rabbit was received.</param>
    /// <param name="conditionScore">Rabbit's initial condition score from 1 to 100.</param>
    /// <param name="breed">Rabbit's breed.</param>
    /// <param name="isSpayedNeutered">Indicates whether the rabbit is spayed or neutered.</param>
    /// <param name="isBonded">Indicates whether the rabbit is part of a bonded pair.</param>
    public Rabbit(
        string animalId,
        string name,
        int age,
        string color,
        DateTime intakeDate,
        string intakeSource,
        int conditionScore,
        string breed,
        bool isSpayedNeutered,
        bool isBonded)
        : base(animalId, name, age, color, intakeDate, intakeSource, conditionScore, breed, isSpayedNeutered)
    {
        _isBonded = isBonded;
    }

    /// <summary>
    /// Returns a description of the rabbit, including its bonded status.
    /// </summary>
    /// <returns>Formatted description of the rabbit.</returns>
    public override string Describe()
    {
        return base.Describe() +
            $", Bonded: {(IsBonded ? "Yes" : "No")}";
    }

    /// <summary>
    /// Creates a summary of the rabbit's current treatment needs based on its condition score.
    /// </summary>
    /// <returns>Formatted treatment summary for the rabbit.</returns>
    public override string CreateTreatmentSummary()
    {
        if (CurrentConditionScore < 50)
        {
            return "Requires close monitoring and limited activity.";
        }
        else if (CurrentConditionScore < 75)
        {
            return "Condition is stable; gentle enrichment recommended.";
        }
        else
        {
            return "Normal activity and a stimulating environment recommended.";
        }
    }

    /// <summary>
    /// Gets the daily care instructions for the rabbit based on its bonded status and condition score.
    /// </summary>
    /// <returns>Formatted set of daily care instructions for the rabbit.</returns>
    public override string GetDailyCareInstructions()
    {
        List<string> instructions = new List<string>();

        if (IsBonded)
        {
            instructions.Add("Ensure the bonded pair is kept together.");
        }

        if (CurrentConditionScore < 50)
        {
            instructions.Add("Monitor the rabbit closely and limit activity.");
        }
        else if (CurrentConditionScore < 75)
        {
            instructions.Add("Monitor the rabbit's condition and provide gentle enrichment.");
        }
        else
        {
            instructions.Add("Ensure the rabbit has a stimulating environment and normal activity.");
        }

        return string.Join(" ", instructions);
    }

    /// <summary>
    /// Gets the adoption profile for the rabbit.
    /// </summary>
    /// <returns>Formatted adoption profile containing the rabbit's name, age, breed, and bonded status.</returns>
    public string GetAdoptionProfile()
    {
        return $"{Name} is a {Age} year old {Breed}\n" +
           (IsBonded ? "Bonded" : "Not Bonded");
    }
}