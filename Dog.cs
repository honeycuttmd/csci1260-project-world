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
    public override string Describe()
    {
        return $"{base.Describe()} - House Trained: {IsHouseTrained}";
    }

    /// <summary>
    /// Creates a summary of the dog's treatment history, including any care notes.
    /// </summary>
    public override string CreateTreatmentSummary()
    {
        return $"Current Condition Score: {CurrentConditionScore}\nTreatment History:\n{GetCareHistory()}";
    }

    /// <summary>
    /// Gets the daily care instructions for the dog.
    /// </summary>
    public override string GetDailyCareInstructions()
    {
        string instructions = "Provide regular meals, fresh water, exercise, and bathroom breaks.";

        if (!IsHouseTrained)
        {
            instructions += " Provide frequent bathroom breaks and continue house-training.";
        }

        if (CurrentConditionScore < 50)
        {
            instructions += " Monitor the dog closely and limit strenuous exercise.";
        }
        else if (CurrentConditionScore < 75)
        {
            instructions += " Monitor the dog's condition and provide moderate exercise.";
        }
        else
        {
            instructions += " Provide normal daily activity.";
        }

        if (GetCareHistory() != "")
        {
            instructions += " Review the dog's treatment history and care notes before providing care.";
        }

        return instructions;
    }

    /// <summary>
    /// Gets the adoption profile for the dog.
    /// </summary>
    public string GetAdoptionProfile()
    {
        return $"{Name} is a {Age} year old {Breed}. House Trained: {IsHouseTrained}";
    }
}