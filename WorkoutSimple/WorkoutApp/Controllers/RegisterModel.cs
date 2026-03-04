using System.ComponentModel.DataAnnotations;

namespace WorkoutApp.Models;

public class RegisterModel
{
    [Required(ErrorMessage = "Email обязателен")]
    [EmailAddress(ErrorMessage = "Неверный формат email")]
    public string Email { get; set; } = "";

    [Required(ErrorMessage = "Пароль обязателен")]
    [MinLength(6, ErrorMessage = "Пароль должен быть не менее 6 символов")]
    public string Password { get; set; } = "";

    [Required(ErrorMessage = "Имя обязательно")]
    public string FirstName { get; set; } = "";

    [Required(ErrorMessage = "Фамилия обязательна")]
    public string LastName { get; set; } = "";
}