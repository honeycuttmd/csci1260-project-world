namespace HappyTails;

/// <summary>
/// Represents the rescue center that manages rescue animals.
/// </summary>
public class RescueCenter
{
    private List<RescueAnimal> _animals;

    // Provides read-only access to the animals managed by the rescue center.
    public IReadOnlyList<RescueAnimal> Animals
    {
        get { return _animals.AsReadOnly(); }
    }

    /// <summary>
    /// Creates an empty rescue center ready to manage rescue animals.
    /// </summary>
    public RescueCenter()
    {
        _animals = new List<RescueAnimal>();
    }

    /// <summary>
    /// Adds an animal to the rescue center.
    /// </summary>
    /// <param name="animal">Rescue animal to add to the center.</param>
    public void Add(RescueAnimal animal)
    {
        if (animal == null)
            throw new ArgumentNullException(nameof(animal));

        foreach (RescueAnimal existingAnimal in _animals)
        {
            if (existingAnimal.AnimalId == animal.AnimalId)
                throw new ArgumentException(
                    $"An animal with ID {animal.AnimalId} already exists.");
        }

        _animals.Add(animal);
    }

    /// <summary>
    /// Retrieves the total number of animals currently in the rescue center.
    /// </summary>
    /// <returns>Number of animals currently managed by the rescue center.</returns>
    public int GetAnimalCount()
    {
        return _animals.Count;
    }

    /// <summary>
    /// Returns a report describing all animals currently in the rescue center.
    /// </summary>
    /// <returns>Formatted report containing a description of each animal.</returns>
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
    /// <param name="animal">The adoptable animal to include in the listing.</param>
    /// <returns>Formatted adoption listing containing the animal's profile and adoption fee.</returns>
    public string GetAdoptionListing(IAdoptable animal)
    {
        return $"{animal.GetAdoptionProfile()}\nAdoption Fee: {animal.AdoptionFee:C}";
    }
}