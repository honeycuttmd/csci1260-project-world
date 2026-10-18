namespace HappyTails;

/// <summary>
/// Represents a dog, which is a companion mammal and can be adopted.
/// </summary>
public class Dog : CompanionMammal, IAdoptable
{
    private bool _isHouseTrained;

    public bool IsHouseTrained
    {
        get { return _isHouseTrained; }
    }

    public double AdoptionFee
    {
        get { return 150; }
    }

    /// <summary>
    /// Creates a dog with its identifying information, physical characteristics, intake details, breed, spay/neuter status, and house-training status.
    /// </summary>
    /// <param name="animalId">Unique ID assigned to the dog.</param>
    /// <param name="name">Dog's name.</param>
    /// <param name="age">Dog's age in years.</param>
    /// <param name="color">Dog's coat color.</param>
    /// <param name="intakeDate">Date the dog entered the rescue center.</param>
    /// <param name="intakeSource">Source from which the dog was received.</param>
    /// <param name="conditionScore">Dog's initial condition score from 1 to 100.</param>
    /// <param name="breed">Dog's breed.</param>
    /// <param name="isSpayedNeutered">Indicates whether the dog is spayed or neutered.</param>
    /// <param name="isHouseTrained">Indicates whether the dog is house-trained.</param>
    public Dog(
        string animalId,
        string name,
        int age,
        string color,
        DateTime intakeDate,
        string intakeSource,
        int conditionScore,
        string breed,
        bool isSpayedNeutered,
        bool isHouseTrained)
        : base(animalId, name, age, color, intakeDate, intakeSource, conditionScore, breed, isSpayedNeutered)
    {
        _isHouseTrained = isHouseTrained;
    }

    /// <summary>
    /// Returns a description of the dog, including its house-training status.
    /// </summary>
    /// <returns>Formatted description of the dog.</returns>
    public override string Describe()
    {
        return base.Describe() +
            $", House-Trained: {(IsHouseTrained ? "Yes" : "No")}";
    }

    /// <summary>
    /// Creates a summary of the dog's current treatment needs based on its condition score.
    /// </summary>
    /// <returns>Formatted treatment summary for the dog.</returns>
    public override string CreateTreatmentSummary()
    {
        if (CurrentConditionScore < 50)
        {
            return "Requires close monitoring and limited strenuous exercise.";
        }
        else if (CurrentConditionScore < 75)
        {
            return "Condition is stable; moderate exercise recommended.";
        }
        else
        {
            return "Routine care recommended.";
        }
    }

    /// <summary>
    /// Gets the daily care instructions for the dog based on its house-training status and condition score.
    /// </summary>
    /// <returns>Formatted set of daily care instructions for the dog.</returns>
    public override string GetDailyCareInstructions()
    {
        List<string> instructions = new List<string>();

        if (!IsHouseTrained)
        {
            instructions.Add("Provide frequent bathroom breaks and continue house-training.");
        }

        if (CurrentConditionScore < 50)
        {
            instructions.Add("Monitor the dog closely and limit strenuous exercise.");
        }
        else if (CurrentConditionScore < 75)
        {
            instructions.Add("Monitor the dog's condition and provide moderate exercise.");
        }
        else
        {
            instructions.Add("Provide normal daily activity.");
        }

        return string.Join(" ", instructions);
    }

    /// <summary>
    /// Gets the adoption profile for the dog.
    /// </summary>
    /// <returns>Formatted adoption profile containing the dog's name, age, breed, and house-trained status.</returns>
    public string GetAdoptionProfile()
    {
        return $"{Name} is a {Age} year old {Breed}\n" +
       (IsHouseTrained ? "House-Trained" : "Not House-Trained");
    }
}