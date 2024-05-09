using APIdeCrud.Data;
using APIdeCrud.Models;
using APIdeCrud.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIdeCrud.Repositorios
{
    public class UsuarioRespositorio : IUsuarioRepositorio
    {
        private readonly SistemaTarefasDBContex _dbContext;
        public UsuarioRespositorio(SistemaTarefasDBContex sistemaTarefasDBContex)
        {
            _dbContext = sistemaTarefasDBContex;
        }
        public async Task<UsuarioModel> BuscarPorID(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorID = await BuscarPorID(id);

            if(usuarioPorID == null)
            {
                throw new Exception($"Usuário com o ID: {id} não foi encontrado!");
            }

            usuarioPorID.Nome = usuario.Nome;
            usuarioPorID.Email = usuario.Email;

            _dbContext.Usuarios.Update(usuarioPorID);
            await _dbContext.SaveChangesAsync();

            return usuarioPorID;
        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorID = await BuscarPorID(id);

            if (usuarioPorID == null)
            {
                throw new Exception($"Usuário com o ID: {id} não foi encontrado!");
            }

            _dbContext.Usuarios.Remove(usuarioPorID);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
