namespace HappyTails;

/// <summary>
/// Represents a record of an animal's intake into the rescue center.
/// </summary>
public class IntakeRecord : IEquatable<IntakeRecord>, IComparable<IntakeRecord>
{
    private string _animalId;
    private DateTime _intakeDate;
    private string _breedOrSpecies;
    private int _initialConditionScore;

    public string AnimalId
    {
        get { return _animalId; }
    }

    public DateTime IntakeDate
    {
        get { return _intakeDate; }
    }

    public string BreedOrSpecies
    {
        get { return _breedOrSpecies; }
    }

    public int InitialConditionScore
    {
        get { return _initialConditionScore; }
    }

    /// <summary>
    /// Creates an intake record containing the animal's ID, intake date, breed or species, and initial condition score.
    /// </summary>
    public IntakeRecord(
        string animalId,
        DateTime intakeDate,
        string breedOrSpecies,
        int initialConditionScore)
    {
        _animalId = animalId;
        _intakeDate = intakeDate;
        _breedOrSpecies = breedOrSpecies;
        _initialConditionScore = initialConditionScore;
    }

    /// <summary>
    /// Determines whether two intake records have the same animal ID and intake date.
    /// </summary>
    public bool Equals(IntakeRecord other)
    {
        if (other == null)
        {
            return false;
        }

        return AnimalId == other.AnimalId && IntakeDate == other.IntakeDate;
    }

    /// <summary>
    /// Determines whether this intake record is equal to another object.
    /// </summary>
    public override bool Equals(object obj)
    {
        return Equals(obj as IntakeRecord);
    }

    /// <summary>
    /// Returns a hash code based on the animal ID and intake date used to determine equality.
    /// </summary>
    public override int GetHashCode()
    {
        return HashCode.Combine(AnimalId, IntakeDate);
    }

    /// <summary>
    /// Compares intake records by intake date and uses the animal ID as a secondary sort value.
    /// </summary>
    public int CompareTo(IntakeRecord other)
    {
        if (other == null)
        {
            return 1;
        }

        int dateComparison = IntakeDate.CompareTo(other.IntakeDate);

        if (dateComparison != 0)
        {
            return dateComparison;
        }

        return AnimalId.CompareTo(other.AnimalId);
    }

    /// <summary>
    /// Returns a description of the intake record, including the animal ID, breed or species, intake date, and initial condition score.
    /// </summary>
    public override string ToString()
    {
        return $"{AnimalId} - Breed/Species: {BreedOrSpecies} - Intake Date: {IntakeDate:d} - Initial Condition Score: {InitialConditionScore}";
    }
}