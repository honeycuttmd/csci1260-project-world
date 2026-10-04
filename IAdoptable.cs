namespace HappyTails;

/// <summary>
/// Defines the information required for an animal to be adoptable.
/// </summary>
public interface IAdoptable
{
    public double AdoptionFee
    {
        get;
    }

    /// <summary>
    /// Returns the animal's adoption profile.
    /// </summary>
    public string GetAdoptionProfile();
}