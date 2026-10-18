namespace HappyTails;

/// <summary>
/// Runs the Happy Tails rescue center demonstrations.
/// </summary>
public class Program
{
    /// <summary>
    /// Runs the Happy Tails rescue center application.
    /// </summary>
    /// <param name="args">Command line arguments.</param>
    public static void Main(string[] args)
    {
        Console.WriteLine(new string('=', 60));
        Console.WriteLine("             HAPPY TAILS RESCUE CENTER");
        Console.WriteLine(new string('=', 60));

        Console.WriteLine($"\n{new string('=', 60)}");
        Console.WriteLine("        1. CLASSES, UML, AND RELATIONSHIPS");
        Console.WriteLine(new string('=', 60));
        Console.WriteLine("\n--- DATA LOADING ---\n");

        string dataPath = Path.Combine(AppContext.BaseDirectory, "data.txt");
        RescueCenter rescueCenter = new RescueCenter();
        List<IntakeRecord> intakeRecords = new List<IntakeRecord>();
        int lineNumber = 0;

        foreach (string line in File.ReadLines(dataPath))
        {
            lineNumber++;

            try
            {
                string[] parts = line.Split('|');
                RescueAnimal animal;
                string breedOrSpecies;

                if (parts[0] == "Dog")
                {
                    animal = new Dog(parts[1], parts[2], int.Parse(parts[3]),
                        parts[4], DateTime.Parse(parts[5]), parts[6],
                        int.Parse(parts[7]), parts[8], bool.Parse(parts[9]),
                        bool.Parse(parts[10]));

                    breedOrSpecies = parts[8];
                }
                else if (parts[0] == "Cat")
                {
                    animal = new Cat(parts[1], parts[2], int.Parse(parts[3]),
                        parts[4], DateTime.Parse(parts[5]), parts[6],
                        int.Parse(parts[7]), parts[8], bool.Parse(parts[9]),
                        bool.Parse(parts[10]));

                    breedOrSpecies = parts[8];
                }
                else if (parts[0] == "Rabbit")
                {
                    animal = new Rabbit(parts[1], parts[2], int.Parse(parts[3]),
                        parts[4], DateTime.Parse(parts[5]), parts[6],
                        int.Parse(parts[7]), parts[8], bool.Parse(parts[9]),
                        bool.Parse(parts[10]));

                    breedOrSpecies = parts[8];
                }
                else if (parts[0] == "Turtle")
                {
                    animal = new Turtle(parts[1], parts[2], int.Parse(parts[3]),
                        DateTime.Parse(parts[4]), parts[5], int.Parse(parts[6]),
                        parts[7], double.Parse(parts[8]));

                    breedOrSpecies = parts[7];
                }
                else if (parts[0] == "Owl")
                {
                    animal = new Owl(parts[1], parts[2], int.Parse(parts[3]),
                        DateTime.Parse(parts[4]), parts[5], int.Parse(parts[6]),
                        parts[7]);

                    breedOrSpecies = parts[7];
                }
                else
                {
                    throw new ArgumentException($"Unknown animal type: {parts[0]}");
                }

                intakeRecords.Add(new IntakeRecord(
                    animal.AnimalId,
                    animal.IntakeDate,
                    breedOrSpecies,
                    animal.CurrentConditionScore));

                rescueCenter.Add(animal);
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Record {lineNumber} rejected: {ex.Message}\n");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Record {lineNumber} rejected: {ex.Message}\n");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine($"Record {lineNumber} rejected: missing data fields.\n");
            }
        }

        Console.WriteLine($"Loaded {rescueCenter.GetAnimalCount()} unique animals from data.txt.");
        Console.WriteLine($"Created {intakeRecords.Count} valid intake records.");

        Console.WriteLine($"\n{new string('=', 60)}");
        Console.WriteLine("                    ANIMAL REPORT");
        Console.WriteLine(new string('=', 60));
        Console.WriteLine($"\n{"ID",-6}{"Intake Date",-15}{"Name",-12}{"Type",-10}{"Breed/Species",-22}{"Age",-6}{"Condition"}\n");

        foreach (RescueAnimal animal in rescueCenter.Animals)
        {
            string breedOrSpecies = "";

            foreach (IntakeRecord record in intakeRecords)
            {
                if (record.AnimalId == animal.AnimalId && record.IntakeDate == animal.IntakeDate)
                {
                    breedOrSpecies = record.BreedOrSpecies;
                    break;
                }
            }

            Console.WriteLine($"{animal.AnimalId,-6}{animal.IntakeDate:MM/dd/yyyy}     {animal.Name,-12}{animal.GetType().Name,-10}{breedOrSpecies,-22}{animal.Age,-6}{animal.CurrentConditionScore}");
        }

        Console.WriteLine($"\nAnimals currently in rescue center: {rescueCenter.GetAnimalCount()}");

        Dog kota = (Dog)rescueCenter.Animals[1];
        Dog roxy = (Dog)rescueCenter.Animals[5];
        Cat cleo = (Cat)rescueCenter.Animals[10];
        Rabbit clover = (Rabbit)rescueCenter.Animals[12];
        Turtle penny = (Turtle)rescueCenter.Animals[17];
        Owl athena = (Owl)rescueCenter.Animals[18];

        roxy.AddCareNote(
            "Jordan",
            new DateTime(2026, 9, 24),
            "Administered prescribed medication and monitored recovery.");

        roxy.AddCareNote(
            "Taylor",
            new DateTime(2026, 9, 26),
            "Condition improved; increased daily activity.");

        cleo.AddCareNote(
            "Jordan",
            new DateTime(2026, 9, 25),
            "Provided supportive care and monitored food intake.");

        Console.WriteLine("\n--- TREATMENT HISTORY ---");
        Console.WriteLine($"\n{"ID",-6}{"Date",-15}{"Staff",-18}Note\n");

        foreach (RescueAnimal animal in rescueCenter.Animals)
        {
            foreach (CareNote note in animal.CareNotes)
            {
                Console.WriteLine($"{animal.AnimalId,-6}{note.NoteDate:MM/dd/yyyy}     {note.StaffName,-18}{note.NoteText}");
            }
        }

        Console.WriteLine($"\n{new string('=', 60)}");
        Console.WriteLine("           2. INHERITANCE AND ABSTRACTION");
        Console.WriteLine(new string('=', 60));

        Console.WriteLine("\n--- TREATMENT SUMMARIES ---");
        Console.WriteLine($"\n{"ID",-6}{"Condition",-16}Treatment Summary\n");

        foreach (RescueAnimal animal in new List<RescueAnimal> { kota, roxy, cleo, clover, penny, athena })
        {
            Console.WriteLine($"{animal.AnimalId,-6}{animal.CurrentConditionScore,-16}{animal.CreateTreatmentSummary()}");
        }

        Console.WriteLine($"\n{kota.Name} Condition Score: {kota.CurrentConditionScore}");
        Console.WriteLine(kota.GetTreatmentDetails());
        Console.WriteLine($"Care Notes: {kota.GetCareHistory()}");

        Console.WriteLine("\n--- DAILY CARE INSTRUCTIONS ---");
        Console.WriteLine($"\n{"ID",-6}{"Condition",-16}Care Instructions\n");

        foreach (RescueAnimal animal in new List<RescueAnimal> { kota, cleo, clover, penny, athena })
        {
            Console.WriteLine($"{animal.AnimalId,-6}{animal.CurrentConditionScore,-16}{animal.GetDailyCareInstructions()}");
        }

        Console.WriteLine("\n--- ADDITIONAL ANIMAL SPECIFIC CARE ---");
        Console.WriteLine($"\n{"Type",-12}{"Special Behavior",-27}Care Instructions\n");

        string dogBehavior = $"House Trained: {(kota.IsHouseTrained ? "Yes" : "No")}";
        string catBehavior = $"Indoor Only: {(cleo.IsIndoorOnly ? "Yes" : "No")}";
        string rabbitBehavior = $"Bonded: {(clover.IsBonded ? "Yes" : "No")}";
        string turtleBehavior = $"Shell Length: {penny.ShellLengthCm:0.0} cm";
        string owlBehavior = $"Release Ready: {(athena.IsReleaseReady ? "Yes" : "No")}";

        Console.WriteLine($"{"Dog",-12}{dogBehavior,-27}{kota.GetDailyCareInstructions()}");
        Console.WriteLine($"{"Cat",-12}{catBehavior,-27}{cleo.GetDailyCareInstructions()}");
        Console.WriteLine($"{"Rabbit",-12}{rabbitBehavior,-27}{clover.GetDailyCareInstructions()}");
        Console.WriteLine($"{"Turtle",-12}{turtleBehavior,-27}{penny.GetDailyCareInstructions()}");
        Console.WriteLine($"{"Owl",-12}{owlBehavior,-27}{athena.GetDailyCareInstructions()}");

        Console.WriteLine($"\n{new string('=', 60)}");
        Console.WriteLine("           3. POLYMORPHISM AND INTERFACES");
        Console.WriteLine(new string('=', 60));

        Console.WriteLine("\n--- POLYMORPHIC DESCRIPTIONS ---");
        Console.WriteLine($"\n{"ID",-6}{"Name",-12}{"Age",-6}{"Breed/Species",-22}{"Color",-20}Additional Details\n");

        List<RescueAnimal> examples = new List<RescueAnimal> { kota, cleo, clover, penny, athena };

        foreach (RescueAnimal animal in examples)
        {
            Console.WriteLine(animal.Describe());
        }

        Console.WriteLine("\n--- ADOPTION LISTINGS ---");
        Console.WriteLine($"\n{"ID",-6}{"Name",-12}{"Type",-10}{"Breed/Species",-22}{"Status",-22}Adoption Fee\n");

        Console.WriteLine($"{kota.AnimalId,-6}{kota.Name,-12}{"Dog",-10}{kota.Breed,-22}{(kota.IsHouseTrained ? "House-Trained" : "Not House-Trained"),-22}{kota.AdoptionFee:C}");
        Console.WriteLine($"{cleo.AnimalId,-6}{cleo.Name,-12}{"Cat",-10}{cleo.Breed,-22}{(cleo.IsIndoorOnly ? "Indoor Only" : "Not Indoor Only"),-22}{cleo.AdoptionFee:C}");
        Console.WriteLine($"{clover.AnimalId,-6}{clover.Name,-12}{"Rabbit",-10}{clover.Breed,-22}{(clover.IsBonded ? "Bonded" : "Not Bonded"),-22}{clover.AdoptionFee:C}");
        Console.WriteLine($"{penny.AnimalId,-6}{penny.Name,-12}{"Turtle",-10}{penny.Species,-22}{$"Shell: {penny.ShellLengthCm:0.0} cm",-22}{penny.AdoptionFee:C}");

        Console.WriteLine("\n--- INTERFACE CHECK ---\n");

        foreach (RescueAnimal animal in new List<RescueAnimal> { kota, penny, athena })
        {
            Console.WriteLine($"{animal.Name}: {(animal is IAdoptable ? "Implements IAdoptable" : "Not adoptable")}");
        }

        Console.WriteLine("\n--- INDIVIDUAL ADOPTION PROFILES ---\n");
        Console.WriteLine($"{rescueCenter.GetAdoptionListing(kota)}\n");
        Console.WriteLine(rescueCenter.GetAdoptionListing(penny));

        Console.WriteLine("\n--- CONDITION SCORE UPDATES ---\n");

        Console.WriteLine($"{roxy.Name}\nBefore: {roxy.CurrentConditionScore}");
        roxy.UpdateConditionScore(72);
        Console.WriteLine($"After: {roxy.CurrentConditionScore}\nCare Changes: {roxy.GetDailyCareInstructions()}");

        Console.WriteLine($"\n{cleo.Name}\nBefore: {cleo.CurrentConditionScore}");
        cleo.UpdateConditionScore(78);
        Console.WriteLine($"After: {cleo.CurrentConditionScore}\nCare Changes: {cleo.GetDailyCareInstructions()}");

        Console.WriteLine("\n--- SPECIAL ANIMAL BEHAVIOR ---\n");

        Console.WriteLine($"{penny.AnimalId}: Turtle");
        Console.WriteLine($"{"Shell Length:",-18}{penny.ShellLengthCm:0.0} cm");
        Console.WriteLine($"{"Care Changes:",-18}{penny.GetDailyCareInstructions()}");

        Console.WriteLine($"\n{athena.AnimalId}: Owl");
        Console.WriteLine($"{"Before Rehab:",-18}Condition: {athena.CurrentConditionScore}   Release Ready: {(athena.IsReleaseReady ? "Yes" : "No")}");

        athena.UpdateConditionScore(95);
        athena.MarkReleaseReady();

        Console.WriteLine($"{"After Rehab:",-18}Condition: {athena.CurrentConditionScore}   Release Ready: {(athena.IsReleaseReady ? "Yes" : "No")}");
        Console.WriteLine($"{"Care Changes:",-18}Owl marked ready for release after condition improved.");

        Console.WriteLine($"\n{new string('=', 60)}");
        Console.WriteLine("         4. BUILT-IN CONTRACTS AND COLLECTIONS");
        Console.WriteLine(new string('=', 60));

        Console.WriteLine("\n--- HASHSET DUPLICATE RECORD ---\n");

        HashSet<IntakeRecord> intakeSet = new HashSet<IntakeRecord>();

        foreach (IntakeRecord record in intakeRecords)
        {
            intakeSet.Add(record);
        }

        Console.WriteLine($"Intake records before HashSet: {intakeRecords.Count}");
        Console.WriteLine($"Unique intake records after HashSet: {intakeSet.Count}");
        Console.WriteLine($"Duplicates rejected: {intakeRecords.Count - intakeSet.Count}");

        List<IntakeRecord> uniqueRecords = new List<IntakeRecord>(intakeSet);

        string sortedHeader = $"{"ID",-6}{"Intake Date",-15}{"Name",-12}{"Type",-10}{"Breed/Species",-22}{"Age",-6}Condition";

        Console.WriteLine("\n--- NATURAL SORT: INTAKE DATE, ID ---");

        uniqueRecords.Sort();
        Console.WriteLine($"\n{sortedHeader}\n");

        foreach (IntakeRecord record in uniqueRecords)
        {
            foreach (RescueAnimal animal in rescueCenter.Animals)
            {
                if (animal.AnimalId == record.AnimalId)
                {
                    Console.WriteLine($"{record.AnimalId,-6}{record.IntakeDate:MM/dd/yyyy}     {animal.Name,-12}{animal.GetType().Name,-10}{record.BreedOrSpecies,-22}{animal.Age,-6}{record.InitialConditionScore}");
                    break;
                }
            }
        }

        Console.WriteLine("\n--- BREED/SPECIES SORT ---");

        uniqueRecords.Sort(new BreedOrSpeciesFirst());
        Console.WriteLine($"\n{sortedHeader}\n");

        foreach (IntakeRecord record in uniqueRecords)
        {
            foreach (RescueAnimal animal in rescueCenter.Animals)
            {
                if (animal.AnimalId == record.AnimalId)
                {
                    Console.WriteLine($"{record.AnimalId,-6}{record.IntakeDate:MM/dd/yyyy}     {animal.Name,-12}{animal.GetType().Name,-10}{record.BreedOrSpecies,-22}{animal.Age,-6}{record.InitialConditionScore}");
                    break;
                }
            }
        }

        Console.WriteLine("\n--- MOST URGENT SORT: LOWEST CONDITION SCORE, INTAKE DATE ---");

        uniqueRecords.Sort(new MostUrgentFirst());
        Console.WriteLine($"\n{sortedHeader}\n");

        foreach (IntakeRecord record in uniqueRecords)
        {
            foreach (RescueAnimal animal in rescueCenter.Animals)
            {
                if (animal.AnimalId == record.AnimalId)
                {
                    Console.WriteLine($"{record.AnimalId,-6}{record.IntakeDate:MM/dd/yyyy}     {animal.Name,-12}{animal.GetType().Name,-10}{record.BreedOrSpecies,-22}{animal.Age,-6}{record.InitialConditionScore}");
                    break;
                }
            }
        }

        Console.WriteLine($"\n{new string('=', 60)}");
        Console.WriteLine("                5. EXCEPTIONS AND FILES");
        Console.WriteLine(new string('=', 60));

        Console.WriteLine("\n--- INVALID CONDITION SCORE ---\n");

        try
        {
            roxy.UpdateConditionScore(101);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Attempted: 101\nResult: Rejected\nReason: {ex.Message}");
        }

        Console.WriteLine("\n--- INVALID DATA ENTRY ---\n");
        Console.WriteLine("The invalid age in data.txt was rejected during loading; later records were still loaded.");

        Console.WriteLine($"\n{new string('=', 60)}");
        Console.WriteLine("                     RESCUE LOG");
        Console.WriteLine(new string('=', 60));

        string logPath = Path.Combine(AppContext.BaseDirectory, "rescue_log.txt");

        if (File.Exists(logPath))
        {
            File.Delete(logPath);
        }

        Console.WriteLine("\n--- FIRST SESSION ---\n");

        RescueLog firstLog = new RescueLog(logPath);

        try
        {
            using (firstLog)
            {
                firstLog.Write("Happy Tails rescue log started.");
                firstLog.Write($"Animals loaded: {rescueCenter.GetAnimalCount()}");
                firstLog.Write($"Intake records created: {intakeRecords.Count}");
                firstLog.Write($"Condition score updated for {roxy.Name}.");
                firstLog.Write($"Condition score updated for {cleo.Name}.");

                throw new InvalidOperationException("Intentional exception inside using block.");
            }
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Result: {ex.Message}");
            Console.WriteLine($"Messages Written: {firstLog.Count}\nLog Closed: {(firstLog.IsClosed ? "Yes" : "No")}");
        }

        firstLog.Dispose();
        Console.WriteLine($"Closed after second Dispose: {(firstLog.IsClosed ? "Yes" : "No")}");

        Console.WriteLine("\n--- APPEND SESSION ---\n");

        RescueLog secondLog = new RescueLog(logPath);

        using (secondLog)
        {
            secondLog.Write("Second logging session.");
            secondLog.Write("This message was appended to the existing log.");
        }

        Console.WriteLine($"Messages Written: {secondLog.Count}\nLog Closed: {(secondLog.IsClosed ? "Yes" : "No")}");

        Console.WriteLine("\n--- FINAL LOG CONTENTS ---\n");

        foreach (string logLine in File.ReadLines(logPath))
        {
            Console.WriteLine(logLine);
        }
    }
}