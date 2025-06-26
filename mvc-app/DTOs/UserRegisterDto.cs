namespace mvc_app.DTOs
{
    public class UserRegisterDto
    {
        public required string NombreUsuario { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string ConfirmPassword { get; set; }
    }
}
