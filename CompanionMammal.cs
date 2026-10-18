namespace HappyTails;

/// <summary>
/// Represents common information shared by companion mammals.
/// </summary>
public abstract class CompanionMammal : RescueAnimal
{
    private string _breed;
    private string _color;
    private bool _isSpayedNeutered;

    public string Breed
    {
        get { return _breed; }
    }

    public string Color
    {
        get { return _color; }
    }

    public bool IsSpayedNeutered
    {
        get { return _isSpayedNeutered; }
    }

    /// <summary>
    /// Initializes a new CompanionMammal with the specified identifier, name, age, color, intake information, condition
    /// score, breed, and spay/neuter status.
    /// </summary>
    /// <remarks>Calls the base constructor to initialize common animal properties.</remarks>
    /// <param name="animalId">Unique identifier for the animal.</param>
    /// <param name="name">Animal's name.</param>
    /// <param name="age">Age in years.</param>
    /// <param name="color">Primary color or coat description.</param>
    /// <param name="intakeDate">Date the animal was taken into care.</param>
    /// <param name="intakeSource">Source or location from which the animal was received.</param>
    /// <param name="conditionScore">Numeric score representing the animal's physical condition on intake.</param>
    /// <param name="breed">Breed or primary breed designation.</param>
    /// <param name="isSpayedNeutered">True if the animal is spayed or neutered; otherwise false.</param>
    public CompanionMammal(
        string animalId,
        string name,
        int age,
        string color,
        DateTime intakeDate,
        string intakeSource,
        int conditionScore,
        string breed,
        bool isSpayedNeutered)
        : base(animalId, name, age, intakeDate, intakeSource, conditionScore)
    {
        _breed = breed;
        _color = color;
        _isSpayedNeutered = isSpayedNeutered;
    }

    /// <summary>
    /// Returns a description of the companion mammal, including its breed, color, and spay/neuter status.
    /// </summary>
    /// <returns>Formatted description of the companion mammal.</returns>
    public override string Describe()
    {
        return base.Describe() +
            $"{Breed,-22}{Color,-20}Spayed/Neutered: {(IsSpayedNeutered ? "Yes" : "No")}";
    }
}