namespace HappyTails;

/// <summary>
/// Represents a cat, which is a companion mammal and can be adopted.
/// </summary>
public class Cat : CompanionMammal, IAdoptable
{
    private bool _isIndoorOnly;

    public bool IsIndoorOnly
    {
        get { return _isIndoorOnly; }
    }

    public double AdoptionFee
    {
        get { return 100; }
    }

    /// <summary>
    /// Creates a cat with its identifying information, physical characteristics, intake details, breed, spay/neuter status, and indoor-only status.
    /// </summary>
    /// <param name="animalId">Unique ID assigned to the cat.</param>
    /// <param name="name">Cat's name.</param>
    /// <param name="age">Cat's age in years.</param>
    /// <param name="color">Cat's coat color.</param>
    /// <param name="intakeDate">Date the cat entered the rescue center.</param>
    /// <param name="intakeSource">Source from which the cat was received.</param>
    /// <param name="conditionScore">Cat's initial condition score from 1 to 100.</param>
    /// <param name="breed">Cat's breed.</param>
    /// <param name="isSpayedNeutered">Indicates whether the cat is spayed or neutered.</param>
    /// <param name="isIndoorOnly">Indicates whether the cat must remain indoors.</param>
    public Cat(
        string animalId,
        string name,
        int age,
        string color,
        DateTime intakeDate,
        string intakeSource,
        int conditionScore,
        string breed,
        bool isSpayedNeutered,
        bool isIndoorOnly)
        : base(animalId, name, age, color, intakeDate, intakeSource, conditionScore, breed, isSpayedNeutered)
    {
        _isIndoorOnly = isIndoorOnly;
    }

    /// <summary>
    /// Returns a description of the cat, including its indoor-only status.
    /// </summary>
    /// <returns>Formatted description of the cat.</returns>
    public override string Describe()
    {
        return base.Describe() +
            $", Indoor Only: {(IsIndoorOnly ? "Yes" : "No")}";
    }

    /// <summary>
    /// Creates a summary of the cat's current treatment needs based on its condition score.
    /// </summary>
    /// <returns>Formatted treatment summary for the cat.</returns>
    public override string CreateTreatmentSummary()
    {
        if (CurrentConditionScore < 50)
        {
            return "Requires close monitoring and limited activity.";
        }
        else if (CurrentConditionScore < 75)
        {
            return "Condition is stable; moderate enrichment recommended.";
        }
        else
        {
            return "Routine care and social interaction recommended.";
        }
    }

    /// <summary>
    /// Gets the daily care instructions for the cat based on its indoor status and condition score.
    /// </summary>
    /// <returns>Formatted set of daily care instructions for the cat.</returns>
    public override string GetDailyCareInstructions()
    {
        List<string> instructions = new List<string>();

        if (IsIndoorOnly)
        {
            instructions.Add("Ensure the cat has a safe indoor environment.");
        }
        else
        {
            instructions.Add("Allow supervised outdoor time if safe.");
        }

        if (CurrentConditionScore < 50)
        {
            instructions.Add("Monitor the cat closely and limit activity.");
        }
        else if (CurrentConditionScore < 75)
        {
            instructions.Add("Monitor the cat's condition and provide moderate enrichment.");
        }
        else
        {
            instructions.Add("Ensure the cat has plenty of playtime and social interaction.");
        }

        return string.Join(" ", instructions);
    }

    /// <summary>
    /// Gets the adoption profile for the cat.
    /// </summary>
    /// <returns>Formatted adoption profile containing the cat's name, age, breed, and indoor-only status.</returns>
    public string GetAdoptionProfile()
    {
        return $"{Name} is a {Age} year old {Breed}\n" +
           (IsIndoorOnly ? "Indoor Only" : "Not Indoor Only");
    }
}