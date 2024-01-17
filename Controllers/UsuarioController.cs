using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNotes.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using static BCrypt.Net.BCrypt;
using Microsoft.EntityFrameworkCore.Update.Internal;
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
        public async Task<ActionResult<Usuario>> GetTeste(Guid id){
            if(_anCon.Usuarios == null) return NotFound(); 
            var usuario = await _anCon.Usuarios.FindAsync(id);
            if(usuario == null) return NotFound();
            return usuario;
        }

        [HttpPost]
        public ActionResult<Usuario> PostUsuarios(Usuario usuario)
        {

            usuario.senha = HashPassword(usuario.senha);
            usuario.CreatedAt = DateTimeOffset.UtcNow;
usuario.UpdatedAt = DateTimeOffset.UtcNow;
            _anCon.Usuarios.Add(usuario);
            _anCon.SaveChanges();
            
            return CreatedAtAction(nameof(GetTeste), new {id = usuario.id}, usuario);
        }
        
        [HttpPut("{id}")]
        public ActionResult<Usuario> UpdateUsuario(Guid id, [FromBody]Usuario usuario){
            var usuarioAtualizar = _anCon.Usuarios.Find(id);
            if(usuarioAtualizar == null) return NotFound($"Usuario com id = {id} não encontrado!");
            usuario.senha = HashPassword(usuario.senha);
            usuarioAtualizar.nome = usuario.nome;
            usuarioAtualizar.email = usuario.email;
            usuarioAtualizar.senha = usuario.senha;
            usuarioAtualizar.UpdatedAt = DateTimeOffset.UtcNow;
            _anCon.SaveChanges();
            return CreatedAtAction(nameof(GetTeste), new {id = usuario.id}, usuario);
        }
        [HttpDelete("{id}")]
        public ActionResult<Usuario> DeleteUsuario(Guid id){
            var usuarioDeletar = _anCon.Usuarios.Find(id);
            if(usuarioDeletar == null) return NotFound($"Usuario com id = {id} não encontrado!");
            _anCon.Usuarios.Remove(usuarioDeletar);
            _anCon.SaveChanges();
            return Ok("Usuario deletado com sucesso!");
        }    
    }
}