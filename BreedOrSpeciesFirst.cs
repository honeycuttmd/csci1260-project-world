namespace HappyTails;

/// <summary>
/// Compares intake records by breed or species first.
/// </summary>
public class BreedOrSpeciesFirst : IComparer<IntakeRecord>
{
    /// <summary>
    /// Compares two intake records by breed or species and then by animal ID.
    /// </summary>
    /// <param name="a">The first intake record to compare.</param>
    /// <param name="b">The second intake record to compare.</param>
    /// <returns>A value indicating the relative sort order based on breed or species and animal ID.</returns>
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

        int breedComparison = a.BreedOrSpecies.CompareTo(b.BreedOrSpecies);

        if (breedComparison != 0)
        {
            return breedComparison;
        }

        return a.AnimalId.CompareTo(b.AnimalId);
    }
}