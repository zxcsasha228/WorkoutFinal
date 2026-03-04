namespace WorkoutApi.Models;

public class Workout
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public List<Exercise> Exercises { get; set; } = new();
    
    // Связь с пользователем
    public int UserId { get; set; }
    public User? User { get; set; }
}