namespace HappyTails;

/// <summary>
/// Represents the common information and behavior shared by all rescue animals.
/// </summary>
public abstract class RescueAnimal
{
    private string _animalId;
    private string _name;
    private int _age;
    private DateTime _intakeDate;
    private string _intakeSource;
    private int _currentConditionScore;
    private List<CareNote> _careNotes;

    public string AnimalId 
    {
        get { return _animalId; }
    }
    public string Name
    {
        get { return _name; }
    }
    public int Age
    {
        get { return _age; }
    }
    public DateTime IntakeDate
    {
        get { return _intakeDate; }
    }
    public string IntakeSource
    {
        get { return _intakeSource; }
    }
    public int CurrentConditionScore
    {
        get { return _currentConditionScore; }
    }

    // Provides read-only access to the animal's care notes.
    public IReadOnlyList<CareNote> CareNotes
    {
        get { return _careNotes.AsReadOnly(); }
    }

    /// <summary>
    /// Initializes a new RescueAnimal with the specified animal identifier, name, age, intake date, intake source, and
    /// condition score.
    /// </summary>
    /// <remarks>Initializes internal fields and an empty care notes list.</remarks>
    /// <param name="animalId">Unique identifier for the animal; cannot be null, empty, or whitespace.</param>
    /// <param name="name">Name of the animal; cannot be null, empty, or whitespace.</param>
    /// <param name="age">Age of the animal in years; must be zero or greater.</param>
    /// <param name="intakeDate">Date the animal was taken into care; must be provided (not default).</param>
    /// <param name="intakeSource">Source from which the animal was taken into care; cannot be null, empty, or whitespace.</param>
    /// <param name="conditionScore">Initial condition score for the animal from 1 to 100.</param>
    public RescueAnimal(
        string animalId,
        string name,
        int age,
        DateTime intakeDate,
        string intakeSource,
        int conditionScore)
    {
        if (string.IsNullOrWhiteSpace(animalId))
            throw new ArgumentException("Animal ID cannot be empty.");

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Animal name cannot be empty.");

        if (age < 0)
            throw new ArgumentException("Age cannot be negative.");

        if (intakeDate == default)
            throw new ArgumentException("Intake date is required.");

        if (string.IsNullOrWhiteSpace(intakeSource))
            throw new ArgumentException("Intake source cannot be empty.");

        if (conditionScore < 1 || conditionScore > 100)
            throw new ArgumentException("Condition score must be between 1 and 100.");

        _animalId = animalId;
        _name = name;
        _age = age;
        _intakeDate = intakeDate;
        _intakeSource = intakeSource;
        _currentConditionScore = conditionScore;
        _careNotes = new List<CareNote>();
    }

    /// <summary>
    /// Updates the animal's current condition score.
    /// </summary>
    /// <param name="newScore">New condition score from 1 to 100.</param>
    public void UpdateConditionScore(int newScore)
    {
        if (newScore < 1 || newScore > 100)
            throw new ArgumentException("Condition score must be between 1 and 100.");

        _currentConditionScore = newScore;
    }

    /// <summary>
    /// Adds a new care note to the animal's care history.
    /// </summary>
    /// <param name="staffName">Staff member name recording the note.</param>
    /// <param name="noteDate">Date care note was recorded.</param>
    /// <param name="noteText">Text describing care provided.</param>
    public void AddCareNote(string staffName, DateTime noteDate, string noteText)
    {
        _careNotes.Add(new CareNote(staffName, noteDate, noteText));
    }

    /// <summary>
    /// Returns the animal's care history.
    /// </summary>
    /// <returns>Formatted string containing the animal's care notes.</returns>
    public string GetCareHistory()
    {
        if (_careNotes.Count == 0)
        {
            return "No care notes recorded.";
        }

        string history = "";

        foreach (var note in _careNotes)
        {
            history += $"{note}\n";
        }

        return history;
    }

    /// <summary>
    /// Returns a description of the rescue animal, including its ID, name, and age.
    /// </summary>
    /// <returns>Formatted description of the rescue animal.</returns>
    public virtual string Describe()
    {
        return string.Format(
            "{0,-6}{1,-12}{2,-6}",
            AnimalId,
            Name,
            Age);
    }

    /// <summary>
    /// Returns the animal's current treatment summary.
    /// </summary>
    /// <returns>Formatted treatment details for the animal.</returns>
    public string GetTreatmentDetails()
    {
        return $"Treatment Summary: {CreateTreatmentSummary()}";
    }

    /// <summary>
    /// Creates a summary of the animal's treatment needs.
    /// </summary>
    /// <returns>Formatted summary of the animal's treatment information.</returns>
    public abstract string CreateTreatmentSummary();

    /// <summary>
    /// Returns the animal's daily care instructions.
    /// </summary>
    /// <returns>Formatted set of daily care instructions for the animal.</returns>
    public abstract string GetDailyCareInstructions();
}