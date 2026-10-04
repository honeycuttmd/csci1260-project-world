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
    public override string Describe()
    {
        return $"{base.Describe()} - Breed: {Breed} Color: {Color} - Spayed/Neutered: {IsSpayedNeutered}";
    }
}