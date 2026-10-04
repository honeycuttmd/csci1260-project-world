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
    public override string Describe()
    {
        return $"{base.Describe()} - Bonded: {IsBonded}";
    }

    /// <summary>
    /// Creates a summary of the rabbit's treatment history, including any care notes.
    /// </summary>
    public override string CreateTreatmentSummary()
    {
        return $"Current Condition Score: {CurrentConditionScore}\nTreatment History:\n{GetCareHistory()}";
    }

    /// <summary>
    /// Gets the daily care instructions for the rabbit.
    /// </summary>
    public override string GetDailyCareInstructions()
    {
        string instructions = "Provide regular meals, fresh water, and a clean living area.";

        if (IsBonded)
        {
            instructions += " Ensure the bonded pair is kept together.";
        }

        if (CurrentConditionScore < 50)
        {
            instructions += " Monitor the rabbit closely and limit activity.";
        }
        else if (CurrentConditionScore < 75)
        {
            instructions += " Monitor the rabbit's condition and provide gentle enrichment.";
        }
        else
        {
            instructions += " Ensure the rabbit has a stimulating environment and normal activity.";
        }

        if (GetCareHistory() != "")
        {
            instructions += " Review the rabbit's treatment history and care notes before providing care.";
        }

        return instructions;
    }

    /// <summary>
    /// Gets the adoption profile for the rabbit.
    /// </summary>
    public string GetAdoptionProfile()
    {
        return $"{Name} is a {Age} year old {Breed}. Bonded: {IsBonded}";
    }
}