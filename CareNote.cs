namespace HappyTails;

/// <summary>
/// Represents a care note recorded by rescue staff.
/// </summary>
public class CareNote
{
    private string _staffName;
    private DateTime _noteDate;
    private string _noteText;

    public string StaffName
    {
        get { return _staffName; }
    }

    public DateTime NoteDate
    {
        get { return _noteDate; }
    }

    public string NoteText
    {
        get { return _noteText; }
    }

    /// <summary>
    /// Initializes a new CareNote with the specified staff name, note date, and note text.
    /// </summary>
    /// <param name="staffName">Name of the staff member who authored the note.</param>
    /// <param name="noteDate">Date and time of the note.</param>
    /// <param name="noteText">Text content of the note.</param>
    public CareNote(string staffName, DateTime noteDate, string noteText)
    {
        if (string.IsNullOrWhiteSpace(staffName))
            throw new ArgumentException("Staff name cannot be empty.");

        if (noteDate == default)
            throw new ArgumentException("Note date is required.");

        if (string.IsNullOrWhiteSpace(noteText))
            throw new ArgumentException("Note text cannot be empty.");

        _staffName = staffName;
        _noteDate = noteDate;
        _noteText = noteText;
    }

    /// <summary>
    /// Returns the care note as a formatted string.
    /// </summary>
    /// <returns>Formatted string containing the note date, staff member, and note text.</returns>
    public override string ToString()
    {
        return string.Format(
            "{0,-15}{1,-18}{2}",
            NoteDate.ToString("MM/dd/yyyy"),
            StaffName,
            NoteText);
    }
}