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
    /// <param name="animalId">Unique ID assigned to the animal.</param>
    /// <param name="intakeDate">Date the animal entered the rescue center.</param>
    /// <param name="breedOrSpecies">Animal's breed or species.</param>
    /// <param name="initialConditionScore">Animal's condition score at intake.</param>
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
    /// <param name="other">The intake record to compare with this record.</param>
    /// <returns>True if both records have the same animal ID and intake date. Otherwise, false.</returns>
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
    /// <param name="obj">The object to compare with this intake record.</param>
    /// <returns>True if the object is an equivalent intake record. Otherwise, false.</returns>
    public override bool Equals(object obj)
    {
        return Equals(obj as IntakeRecord);
    }

    /// <summary>
    /// Returns a hash code based on the animal ID and intake date used to determine equality.
    /// </summary>
    /// <returns>A hash code representing the animal ID and intake date.</returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(AnimalId, IntakeDate);
    }

    /// <summary>
    /// Compares intake records by intake date and uses the animal ID as a secondary sort value.
    /// </summary>
    /// <param name="other">The intake record to compare with this record.</param>
    /// <returns>A value indicating the relative sort order of the two intake records.</returns>
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
    /// <returns>Formatted description of the intake record.</returns>
    public override string ToString()
    {
        return string.Format(
            "{0,-8}{1,-15}{2,-22}{3,-12}",
            AnimalId,
            IntakeDate.ToString("MM/dd/yyyy"),
            BreedOrSpecies,
            InitialConditionScore);
    }
}