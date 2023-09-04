using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using RpgApi.Models;
using RpgApi.Data;
using RpgApi.Utils;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly DataContext _context;
        public UsuariosController(DataContext context)
        {
            _context = context;
        }

        private async Task<bool> UsuarioExistente(string username)
        {
            if (await _context.Usuarios.AnyAsync(x => x.Username.ToLower() == username.ToLower()))
            {
                return true;
            }
            return false;
        }

        [HttpPost("GetUser")]
        public async Task<IActionResult> Get(Usuario u)
        {
            try
            {
                Usuario uRetornado = await _context.Usuarios
                    .FirstOrDefaultAsync(x => x.Username == u.Username && u.Email == u.Email);

                if (uRetornado == null)
                    throw new Exception("Usuário não encontrado");

                return Ok(uRetornado);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Usuario> lista = await _context.Usuarios.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> RegistrarUsuario(Usuario user)
        {
            try
            {
                if (await UsuarioExistente(user.Username))
                {
                    throw new System.Exception("Nome de usuário já existe");
                }
                Criptografia.CriarPasswordHash(user.PasswordString, out byte[] hash, out byte[] salt);
                user.PasswordString = string.Empty;
                user.PasswordHash = hash;
                user.PasswordSalt = salt;
                await _context.Usuarios.AddAsync(user);
                await _context.SaveChangesAsync();

                return Ok(user.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Autenticar")]
        public async Task<IActionResult> AutenticarUsuario(Usuario credenciais)
        {
            try
            {
                Usuario usuario = await _context.Usuarios
                    .FirstOrDefaultAsync(x => x.Username.ToLower().Equals(credenciais.Username.ToLower()));
                if (usuario == null)
                {
                    throw new System.Exception("Usuário não encontrado");
                }
                else if (!Criptografia
                .VerificarPasswordHash(credenciais.PasswordString, usuario.PasswordHash, usuario.PasswordSalt))
                {
                    throw new System.Exception("Senha incorreta.");
                }
                else
                {
                     usuario.DataAcesso = DateTime.UtcNow; 
            
                     _context.Entry(usuario).State = EntityState.Modified;
                    await _context.SaveChangesAsync();


                    return Ok(usuario);
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("AlterarSenha")]
public async Task<IActionResult> AlterarSenha(AlterarSenhaModel alterarSenha)
{
    try
    {
        Usuario usuario = await _context.Usuarios
            .FirstOrDefaultAsync(x => x.Username.ToLower().Equals(alterarSenha.Username.ToLower()));

        if (usuario == null)
        {
            throw new System.Exception("Usuário não encontrado");
        }
        else if (!Criptografia.VerificarPasswordHash(alterarSenha.SenhaAtual, usuario.PasswordHash, usuario.PasswordSalt))
        {
            throw new System.Exception("Senha atual incorreta");
        }
        else
        {
            Criptografia.CriarPasswordHash(alterarSenha.NovaSenha, out byte[] hash, out byte[] salt);
            usuario.PasswordHash = hash;
            usuario.PasswordSalt = salt;

            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok("Senha alterada com sucesso");
        }
    }
    catch (System.Exception ex)
    {
        return BadRequest(ex.Message);
    }
}
    }
}