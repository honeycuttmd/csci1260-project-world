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

    /// <summary>
    /// Creates a turtle with its identifying information, intake details, species, and shell length.
    /// </summary>
    /// <param name="animalId">Unique ID assigned to the turtle.</param>
    /// <param name="name">Turtle's name.</param>
    /// <param name="age">Turtle's age in years.</param>
    /// <param name="intakeDate">Date the turtle entered the rescue center.</param>
    /// <param name="intakeSource">Source from which the turtle was received.</param>
    /// <param name="conditionScore">Turtle's initial condition score from 1 to 100.</param>
    /// <param name="species">Turtle's species.</param>
    /// <param name="shellLengthCm">Turtle's shell length in centimeters.</param>
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
    /// <returns>Formatted description of the turtle.</returns>
    public override string Describe()
    {
        return base.Describe() + 
            $"{Species,-22}{"",-20}Shell Length: {ShellLengthCm:0.0} cm";
    }

    /// <summary>
    /// Creates a summary of the turtle's current treatment needs based on its condition score.
    /// </summary>
    /// <returns>Formatted treatment summary for the turtle.</returns>
    public override string CreateTreatmentSummary()
    {
        if (CurrentConditionScore < 50)
        {
            return "Requires close monitoring and limited handling.";
        }
        else if (CurrentConditionScore < 75)
        {
            return "Condition is stable; regular care and monitoring recommended.";
        }
        else
        {
            return "Routine care and a healthy environment recommended.";
        }
    }

    /// <summary>
    /// Gets the daily care instructions for the turtle based on its shell length and condition score.
    /// </summary>
    /// <returns>Formatted set of daily care instructions for the turtle.</returns>
    public override string GetDailyCareInstructions()
    {
        List<string> instructions = new List<string>();

        if (ShellLengthCm < 11)
        {
            instructions.Add("Monitor for growth and ensure proper nutrition.");
        }

        if (CurrentConditionScore < 50)
        {
            instructions.Add("Monitor the turtle closely and limit handling.");
        }
        else if (CurrentConditionScore < 75)
        {
            instructions.Add("Provide regular care and monitor for any health issues.");
        }
        else
        {
            instructions.Add("Maintain regular care and ensure a healthy environment.");
        }

        return string.Join(" ", instructions);
    }

    /// <summary>
    /// Returns the adoption profile for the turtle.
    /// </summary>
    /// <returns>Formatted adoption profile containing the turtle's name, age, species, and shell length.</returns>
    public string GetAdoptionProfile()
    {
        return $"{Name} is a {Age} year old {Species}\n" +
           $"Shell Length: {ShellLengthCm:0.0} cm";
    }
}