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
    public override string Describe()
    {
        return $"{base.Describe()} - Indoor Only: {IsIndoorOnly}";
    }

    /// <summary>
    /// Creates a summary of the cat's treatment history, including any care notes.
    /// </summary>
    public override string CreateTreatmentSummary()
    {
        return $"Current Condition Score: {CurrentConditionScore}\nTreatment History:\n{GetCareHistory()}";
    }

    /// <summary>
    /// Gets the daily care instructions for the cat.
    /// </summary>
    public override string GetDailyCareInstructions()
    {
        string instructions = "Provide regular meals, fresh water, and a clean litter box.";

        if (IsIndoorOnly)
        {
            instructions += " Ensure the cat has a safe indoor environment.";
        }
        else
        {
            instructions += " Allow supervised outdoor time if safe.";
        }

        if (CurrentConditionScore < 50)
        {
            instructions += " Monitor the cat closely and limit activity.";
        }
        else if (CurrentConditionScore < 75)
        {
            instructions += " Monitor the cat's condition and provide moderate enrichment.";
        }
        else
        {
            instructions += " Ensure the cat has plenty of playtime and social interaction.";
        }

        if (GetCareHistory() != "")
        {
            instructions += " Review the cat's treatment history and care notes before providing care.";
        }

        return instructions;
    }

    /// <summary>
    /// Gets the adoption profile for the cat.
    /// </summary>
    public string GetAdoptionProfile()
    {
        return $"{Name} is a {Age} year old {Breed}. Indoor Only: {IsIndoorOnly}";
    }
}