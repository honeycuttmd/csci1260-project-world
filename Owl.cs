namespace HappyTails;

/// <summary>
/// Represents an owl, which is a rescue animal undergoing rehabilitation and may be released into the wild.
/// </summary>
public class Owl : RescueAnimal
{
    private string _species;
    private bool _isReleaseReady;

    public string Species
    {
        get { return _species; }
    }

    public bool IsReleaseReady
    {
        get { return _isReleaseReady; }
    }

    public Owl(
        string animalId,
        string name,
        int age,
        DateTime intakeDate,
        string intakeSource,
        int conditionScore,
        string species)
        : base(animalId, name, age, intakeDate, intakeSource, conditionScore)
    {
        _species = species;
    }

    /// <summary>
    /// Returns a description of the owl, including its release readiness.
    /// </summary>
    public override string Describe()
    {
        return $"{base.Describe()} - Release Ready: {IsReleaseReady}";
    }

    /// <summary>
    /// Creates a summary of the owl's treatment history, including any care notes.
    /// </summary>
    public override string CreateTreatmentSummary()
    {
        return $"Current Condition Score: {CurrentConditionScore}\nTreatment History:\n{GetCareHistory()}";
    }

    /// <summary>
    /// Gets the daily care instructions for the owl.
    /// </summary>
    public override string GetDailyCareInstructions()
    {
        string instructions = "Provide regular meals, fresh water, and a safe enclosure.";

        if (!IsReleaseReady)
        {
            instructions += " Monitor for signs of stress or illness.";
        }
        else
        {
            instructions += " Prepare for potential release into the wild.";
        }

        if (CurrentConditionScore < 50)
        {
            instructions += " Monitor the owl closely and limit activity.";
        }
        else if (CurrentConditionScore < 75)
        {
            instructions += " Provide additional enrichment and socialization.";
        }
        else
        {
            instructions += " Maintain regular care and monitor for potential changes in release readiness.";
        }

        if (GetCareHistory() != "")
        {
            instructions += " Review the owl's treatment history and care notes before providing care.";
        }

        return instructions;
    }

    /// <summary>
    /// Marks the owl as ready for release into the wild.
    /// </summary>
    public void MarkReleaseReady()
    {
        _isReleaseReady = true;
    }
}