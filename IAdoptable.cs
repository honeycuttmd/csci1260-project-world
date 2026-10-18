namespace HappyTails;

/// <summary>
/// Defines the information required for an animal to be adoptable.
/// </summary>
public interface IAdoptable
{
    /// <summary>
    /// Defines the adoption fee for the animal.
    /// </summary>
    public double AdoptionFee
    {
        get;
    }

    /// <summary>
    /// Returns the animal's adoption profile.
    /// </summary>
    /// <returns>Formatted adoption profile for the animal.</returns>
    public string GetAdoptionProfile();
}