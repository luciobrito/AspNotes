using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNotes.Models;
using Microsoft.AspNetCore.Identity;
using static BCrypt.Net.BCrypt;
namespace AspNotes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly AspNotesContext _anCon;

        public UsuarioController (AspNotesContext aspnotContx){
            _anCon = aspnotContx;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            if (_anCon == null) return NotFound();
            return await _anCon.Usuarios.ToListAsync();
        }
        [HttpGet("{id}") ]
        public async Task<ActionResult<Usuario>> GetTeste(int id){
            if(_anCon.Usuarios == null) return NotFound(); 
            var usuario = await _anCon.Usuarios.FindAsync(id);
            if(usuario == null) return NotFound();
            return usuario;
        }

        [HttpPost]
        public ActionResult<Usuario> PostUsuarios(Usuario usuario)
        {
            usuario.senha = HashPassword(usuario.senha);
            
            _anCon.Usuarios.Add(usuario);
            _anCon.SaveChanges();
            return CreatedAtAction(nameof(GetTeste), new {id = usuario.id}, usuario);
        }
    }
}