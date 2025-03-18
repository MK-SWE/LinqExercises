using LinqExercises.Exercises;

namespace LinqExercises;

public static class Program
{
    private static void JoinAndSeparateWithComma<T>(IEnumerable<T> collection)
    {
        Console.WriteLine(string.Join(", ", collection));
    }
    
    public static void Main()
    {
        /* Task 1: Basic Filtering
        Console.WriteLine("""
                          Task 1: Basic Solutions
                          Problem: Use LINQ to return all students from the SampleData.GetPeople() list.
                          Expected Output: Bob, Charlie, Eve

                          """);
        */
        
        Console.WriteLine("Task 1:");
        
        IEnumerable<string> students = Solutions.GetAllStudents();
        JoinAndSeparateWithComma(students);
        Console.WriteLine("\n");

        
        /* Task 2: Projection
        Console.WriteLine("""
                          Task 2: Projection
                          Problem: Return names of people who are older than 23 and not students.
                          Expected Output: Alice, Diana

                          """);
        */
        
        Console.WriteLine("Task 2:");
        IEnumerable<string> students2 = Solutions.NotStudentsOlderThanN(age: 23);

        JoinAndSeparateWithComma(students2);
        Console.WriteLine("\n");
        
        /* Task 3: Ordering
        Console.WriteLine("""
                          Task 3: Ordering
                          Problem: Return people sorted by age in descending order. Include their name and age.
                          Expected Output:
                          Bob (30), Diana (28), Alice (25), Charlie (22), Eve (19)

                          """);
        */
        
        Console.WriteLine("Task 3:");
        
        IEnumerable<string> students3 = Solutions.OrderStudents();

        JoinAndSeparateWithComma(students3);
        Console.WriteLine("\n");
        
        /*Task 4: Aggregation
        Problem: Calculate the total age, average age, max age, and min age of all people.
        Expected Output:

        Total Age: 124
        Average Age: 24.8
        Max Age: 30
        Min Age: 19
        
        */
        
        Console.WriteLine("Task 4:");
        Console.WriteLine(Solutions.Aggregate());
        Console.WriteLine("\n");

        
        /*Task 5: Grouping
        Problem: Group people by whether their age is even or odd.
        Expected Output:

        Even Ages: Bob (30), Charlie (22), Diana (28)
        Odd Ages: Alice (25), Eve (19)
        */
        
        Console.WriteLine("Task 5:");

        Solutions.GroupPeople();
        Console.WriteLine("\n");

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

        Console.WriteLine("Task 6:");

        var joinedPerson =Solutions.JoinPeopleAndCities();
        JoinAndSeparateWithComma(joinedPerson);
        Console.WriteLine("\n");

        /*Task 7: Distinct Values
        Problem: Given numbers = { 1, 2, 2, 3, 3, 3, 4 }:
        Return distinct values sorted in ascending order.
        Expected Output: 1, 2, 3, 4
        
        */
        
        Console.WriteLine("Task 7:");

        JoinAndSeparateWithComma(Solutions.GetDistinctValues());
        Console.WriteLine("\n");

        /* Task 8: Pagination
        Problem: Given numbers = { 10, 20, 30, 40, 50, 60, 70 }:

        Use Skip and Take to return the 3rd and 4th elements (1-based index).
        Expected Output: 30, 40
        */
        
        Console.WriteLine("Task 8:");

        JoinAndSeparateWithComma(Solutions.PaginateListOfInt());
        Console.WriteLine("\n");

        /* Task 9: Complex Filtering
            Problem: Given numbers = { 15, 7, 21, 8, 12, 10 }:

            Return numbers divisible by 3 and greater than 10.
            Expected Output: 15, 21, 12
        */

        Console.WriteLine("Task 9:");
        JoinAndSeparateWithComma(Solutions.DivisibleByThreeAndGreaterThanTen( numbers: [15, 7, 21, 8, 12, 10]));
        Console.WriteLine("\n");

        /*Task 10: Combining Operations
            Problem: Using the people list from Task 2:

            Return the names of people older than 20, ordered alphabetically.
            Expected Output: Alice, Bob, Charlie
            
        */
        
        Console.WriteLine("Task 10:");
        JoinAndSeparateWithComma(Solutions.PeopleBiggerThanTwentyOrderedAlphabetically());
        Console.WriteLine("\n");

    }
}