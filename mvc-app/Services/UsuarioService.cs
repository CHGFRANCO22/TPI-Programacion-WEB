using Microsoft.EntityFrameworkCore;
using mvc_app.DTOs;
using mvc_app.Models;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace mvc_app.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AppDbContext _context;

        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> RegistrarUsuarioAsync(UserRegisterDto dto)
        {
            if (dto.Password != dto.ConfirmPassword)
                return false;

            if (await _context.Usuarios.AnyAsync(u => u.Email == dto.Email))
                return false;

            CrearPasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var usuario = new Usuario
            {
                NombreUsuario = dto.NombreUsuario,
                Email = dto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return true;
        }

        private void CrearPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
