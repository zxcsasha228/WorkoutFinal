namespace WorkoutApp.Models;

public class Workout
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public List<Exercise> Exercises { get; set; } = new();
    public int UserId { get; set; }
}