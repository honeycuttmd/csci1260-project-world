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

    /// <summary>
    /// Creates an owl with its identifying information, intake details, and species.
    /// </summary>
    /// <param name="animalId">Unique ID assigned to the owl.</param>
    /// <param name="name">Owl's name.</param>
    /// <param name="age">Owl's age in years.</param>
    /// <param name="intakeDate">Date the owl entered the rescue center.</param>
    /// <param name="intakeSource">Source from which the owl was received.</param>
    /// <param name="conditionScore">Owl's initial condition score from 1 to 100.</param>
    /// <param name="species">Owl's species.</param>
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
    /// <returns>Formatted description of the owl.</returns>
    public override string Describe()
    {
        return base.Describe() +
            $"{Species,-22}{"",-20}Release Ready: {(IsReleaseReady ? "Yes" : "No")}";
    }

    /// <summary>
    /// Creates a summary of the owl's current treatment needs based on its condition score.
    /// </summary>
    /// <returns>Formatted treatment summary for the owl.</returns>
    public override string CreateTreatmentSummary()
    {
        if (CurrentConditionScore < 50)
        {
            return "Requires close monitoring and limited activity.";
        }
        else if (CurrentConditionScore < 75)
        {
            return "Condition is stable; additional enrichment recommended.";
        }
        else
        {
            return "Routine care recommended.";
        }
    }

    /// <summary>
    /// Gets the daily care instructions for the owl based on its release readiness and condition score.
    /// </summary>
    /// <returns>Formatted set of daily care instructions for the owl.</returns>
    public override string GetDailyCareInstructions()
    {
        List<string> instructions = new List<string>();

        if (!IsReleaseReady)
        {
            instructions.Add("Monitor for signs of stress or illness.");
        }
        else
        {
            instructions.Add("Prepare for potential release into the wild.");
        }

        if (CurrentConditionScore < 50)
        {
            instructions.Add("Monitor the owl closely and limit activity.");
        }
        else if (CurrentConditionScore < 75)
        {
            instructions.Add("Provide additional enrichment and socialization.");
        }
        else
        {
            instructions.Add("Maintain regular care and monitor for potential changes in release readiness.");
        }

        return string.Join(" ", instructions);
    }

    /// <summary>
    /// Marks the owl as ready for release into the wild.
    /// </summary>
    public void MarkReleaseReady()
    {
        _isReleaseReady = true;
    }
}