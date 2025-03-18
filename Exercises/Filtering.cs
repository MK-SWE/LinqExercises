namespace LinqExercises.Exercises;
using Data;
using Models;

public static class Solutions
{
    private static readonly List<Person> People = SampleData.GetPeople();
    
    /* Task 1: Basic Filtering
     * Problem: Use LINQ to return all students from the SampleData.GetPeople() list.
     * Expected Output: Bob, Charlie, Eve
     */
    
    public static IEnumerable<string> GetAllStudents()
    {
        return People
            .Where(p => p.IsStudent)
            .Select(p => p.Name);
    }
    
    /* Task 2: Projection
     * Problem: Return names of people who are older than 23 and not students.
     * Expected Output: Alice, Diana
     */

    public static IEnumerable<string> NotStudentsOlderThanN(int age)
    {
        return People
            .Where(p => p.Age > age && !p.IsStudent)
            .Select(p => p.Name);
    }
    
    /* Task 3: Ordering
     * Problem: Return people sorted by age in descending order. Include their name and age.
     * Expected Output:
     * Bob (30), Diana (28), Alice (25), Charlie (22), Eve (19)
     */

    public static IEnumerable<string> OrderStudents()
    {
        return People
            .OrderByDescending(p => p.Age)
            .Select(p => $"{p.Name} ({p.Age})");
    }
    
    /*Task 4: Aggregation
        Problem: Calculate the total age, average age, max age, and min age of all people.
        Expected Output:
        
        Total Age: 124  
        Average Age: 24.8  
        Max Age: 30  
        Min Age: 19
    */

    public static string Aggregate()
    {
        int totalAge = People.Sum(p => p.Age);
        double averageAge = People.Average(p => p.Age);
        int maxAge = People.Max(p => p.Age);
        int minAge = People.Min(p => p.Age);
        
        return $"Total Age: {totalAge}\nAverage Age: {averageAge}\nMax Age: {maxAge}\nMix Age: {minAge}";
    }
    
    /*Task 5: Grouping
    Problem: Group people by whether their age is even or odd.
    Expected Output:

    Even Ages: Bob (30), Charlie (22), Diana (28)  
    Odd Ages: Alice (25), Eve (19)
    */

    public static void GroupPeople()
    {
        bool IsEvenAge(int number) => number % 2 == 0;

        var group = People
            .GroupBy(p => IsEvenAge(p.Age) ? "Even Ages" : "Odd Ages")
            .OrderBy(g => g.Key);

        foreach (var g in group)
        {
            string members = string.Join(", ", 
                g.Select(p => $"{p.Name} ({p.Age})"));
            Console.WriteLine($"{g.Key}: {members}");
        }
    }
    
    /*Task 6: Joining
        Problem: Given an additional list of cities and their countries:
        List<CityCountry> cityCountries = new List<CityCountry> {
            new CityCountry { City = "New York", Country = "USA" },
            new CityCountry { City = "London", Country = "UK" },
            new CityCountry { City = "Paris", Country = "France" },
            new CityCountry { City = "Tokyo", Country = "Japan" }
        };
        Return a list of people with their city and country (e.g., "Alice (New York, USA)").
        Expected Output:
            Alice (New York, USA), Bob (London, UK), Charlie (Paris, France), Diana (Tokyo, Japan), Eve (New York, USA)
    */

    public static IEnumerable<string> JoinPeopleAndCities()
    {
        List<CityCountry> cities= SampleData.GetCities();

        return People.Join(
            cities,
            people => people.City,
            theCity => theCity.City,
            (people, city) => $"{people.Name} ({city.City}, {city.Country})"
        );
    }

    /*Task 7: Distinct Values
    Problem: Given numbers = { 1, 2, 2, 3, 3, 3, 4 }:
    Return distinct values sorted in ascending order.
    Expected Output: 1, 2, 3, 4
    */
    
    public static IEnumerable<int> GetDistinctValues()
    {
        int[] numbers = [1, 2, 2, 3, 3, 3, 4];

        return numbers.Distinct();
    }
    
    /* Task 8: Pagination
        Problem: Given numbers = { 10, 20, 30, 40, 50, 60, 70 }:

        Use Skip and Take to return the 3rd and 4th elements (1-based index).
        Expected Output: 30, 40
    */

    public static IEnumerable<int> PaginateListOfInt()
    {
        int[] numbers = [10, 20, 30, 40, 50, 60, 70];

        return numbers.Skip(2).Take(2);
    }
    
    /* Task 9: Complex Filtering
        Problem: Given numbers = { 15, 7, 21, 8, 12, 10 }:

        Return numbers divisible by 3 and greater than 10.
        Expected Output: 15, 21, 12
    */

    public static IEnumerable<int> DivisibleByThreeAndGreaterThanTen(int[] numbers)
    {
        return numbers
            .Where(x => x > 10)
            .Where(x => x % 3 == 0);
    }
    
    /*Task 10: Combining Operations
        Problem: Using the people list from Task 2:

        Return the names of people older than 20, ordered alphabetically.
        Expected Output: Alice, Bob, Charlie
    */

    public static IEnumerable<string> PeopleBiggerThanTwentyOrderedAlphabetically()
    {
        return People
            .Where(person => person.Age > 20)
            .OrderBy(person => person.Name)
            .Select(person => person.Name);
    }
}