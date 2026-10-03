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
    public void UpdateConditionScore(int newScore)
    {
        if (newScore < 1 || newScore > 100)
            throw new ArgumentException("Condition score must be between 1 and 100.");

        _currentConditionScore = newScore;
    }

    /// <summary>
    /// Adds a new care note to the animal's care history.
    /// </summary>
    public void AddCareNote(string staffName, string noteText)
    {
        CareNote note = new CareNote(staffName, DateTime.Now, noteText);

        _careNotes.Add(note);
    }

    /// <summary>
    /// Returns the animal's care history.
    /// </summary>
    public string GetCareHistory()
    {
        string history = "";

        foreach (var note in _careNotes)
        {
            history += $"{note.ToString()}\n";
        }

        return history;
    }

    /// <summary>
    /// Returns a description of the rescue animal, including its ID, name, age, and treatment summary.
    /// </summary>
    public virtual string Describe()
    {
        return $"{AnimalId} - {Name} Age: {Age} - Treatment Summary: {CreateTreatmentSummary()}";
    }

    /// <summary>
    /// Creates a summary of the animal's treatment needs.
    /// </summary>
    public abstract string CreateTreatmentSummary();

    /// <summary>
    /// Returns the animal's daily care instructions.
    /// </summary>
    public abstract string GetDailyCareInstructions();
}