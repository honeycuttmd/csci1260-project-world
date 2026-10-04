namespace HappyTails;

/// <summary>
/// Represents the rescue center that manages rescue animals.
/// </summary>
public class RescueCenter
{
    private List<RescueAnimal> _animals;

    public List<RescueAnimal> Animals
    {
        get { return _animals; }
    }

    public RescueCenter()
    {
        _animals = new List<RescueAnimal>();
    }

    /// <summary>
    /// Adds an animal to the rescue center.
    /// </summary>
    public void Add(RescueAnimal animal)
    {
        _animals.Add(animal);
    }

    /// <summary>
    /// Retrieves the total number of animals currently in the rescue center.
    /// </summary>
    public int GetAnimalCount()
    {
        return _animals.Count;
    }

    /// <summary>
    /// Returns a report describing all animals currently in the rescue center.
    /// </summary>
    public string GetAnimalReport()
    {
        string report = "";

        foreach (var animal in _animals)
        {
            report += $"{animal.Describe()}\n";
        }

        return report;
    }

    /// <summary>
    /// Returns an adoption listing for an adoptable animal, including its adoption fee.
    /// </summary>
    public string GetAdoptionListing(IAdoptable animal)
    {
        return $"{animal.GetAdoptionProfile()} - Adoption Fee: {animal.AdoptionFee:C}";
    }
}