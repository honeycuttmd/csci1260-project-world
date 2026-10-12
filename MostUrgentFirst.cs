namespace HappyTails;

/// <summary>
/// Compares intake records by initial condition score, with the lowest score first.
/// </summary>
public class MostUrgentFirst : IComparer<IntakeRecord>
{
    /// <summary>
    /// Compares two intake records by initial condition score and then by intake date.
    /// </summary>
    public int Compare(IntakeRecord a, IntakeRecord b)
    {
        // Check for null records before comparing their properties.
        if (a == null && b == null)
        {
            return 0;
        }

        if (a == null)
        {
            return -1;
        }

        if (b == null)
        {
            return 1;
        }

        int conditionComparison = a.InitialConditionScore.CompareTo(b.InitialConditionScore);

        if (conditionComparison != 0)
        {
            return conditionComparison;
        }

        return a.IntakeDate.CompareTo(b.IntakeDate);
    }
}