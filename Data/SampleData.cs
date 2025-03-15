using LinqExercises.Models;
namespace LinqExercises.Data;

public static class SampleData
{
    public static List<Person> GetPeople()
    {
        return
        [
            new Person { Id = 1, Name = "Alice", Age = 25, City = "New York", IsStudent = false },
            new Person { Id = 2, Name = "Bob", Age = 30, City = "London", IsStudent = true },
            new Person { Id = 3, Name = "Charlie", Age = 22, City = "Paris", IsStudent = true },
            new Person { Id = 4, Name = "Diana", Age = 28, City = "Tokyo", IsStudent = false },
            new Person { Id = 5, Name = "Eve", Age = 19, City = "New York", IsStudent = true }
        ];
    }
}