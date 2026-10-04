namespace HappyTails;

/// <summary>
/// Represents a turtle, which is a rescue animal and can be adopted.
/// </summary>
public class Turtle : RescueAnimal, IAdoptable
{
    private string _species;
    private double _shellLengthCm;

    public string Species
    {
        get { return _species; }
    }

    public double ShellLengthCm
    {
        get { return _shellLengthCm; }
    }

    public double AdoptionFee
    {
        get { return 50; }
    }

    public Turtle(
        string animalId,
        string name,
        int age,
        DateTime intakeDate,
        string intakeSource,
        int conditionScore,
        string species,
        double shellLengthCm)
        : base(animalId, name, age, intakeDate, intakeSource, conditionScore)
    {
        _species = species;
        _shellLengthCm = shellLengthCm;
    }

    /// <summary>
    /// Returns a description of the turtle, including its shell length.
    /// </summary>
    public override string Describe()
    {
        return $"{base.Describe()} - Shell Length: {ShellLengthCm}cm";
    }

    /// <summary>
    /// Creates a summary of the turtle's treatment history, including any care notes.
    /// </summary>
    public override string CreateTreatmentSummary()
    {
        return $"Current Condition Score: {CurrentConditionScore}\nTreatment History:\n{GetCareHistory()}";
    }

    /// <summary>
    /// Gets the daily care instructions for the turtle.
    /// </summary>
    public override string GetDailyCareInstructions()
    {
        string instructions = "Provide a clean habitat with access to water and appropriate basking areas.";

        if (ShellLengthCm < 11)
        {
            instructions += " Monitor for growth and ensure proper nutrition.";
        }

        if (CurrentConditionScore < 50)
        {
            instructions += " Monitor the turtle closely and limit handling.";
        }
        else if (CurrentConditionScore < 75)
        {
            instructions += " Provide regular care and monitor for any health issues.";
        }
        else
        {
            instructions += " Maintain regular care and ensure a healthy environment.";
        }

        if (GetCareHistory() != "")
        {
            instructions += " Review the turtle's treatment history and care notes before providing care.";
        }

        return instructions;
    }

    /// <summary>
    /// Returns the adoption profile for the turtle.
    /// </summary>
    public string GetAdoptionProfile()
    {
        return $"{Name} is a {Age} year old {Species}. Shell Length: {ShellLengthCm}cm";
    }
}