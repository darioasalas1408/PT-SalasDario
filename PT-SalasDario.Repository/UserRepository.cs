using Microsoft.EntityFrameworkCore;
using PT_SalasDario.Data;

namespace PT_SalasDario.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext _dbContext;

        public UserRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateUser(Usuario usuario)
        {
            await _dbContext.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Usuario> GetUsers(string nombre, string provincia, string ciudad)
        {
            var listUsers = _dbContext.Usuario.Where(c =>
                                (nombre != null && c.Nombre.Contains(nombre))
                                ||
                                (provincia != null && c.Domicilio.Provincia.Contains(provincia))
                                ||
                                (ciudad != null && c.Domicilio.Ciudad.Contains(ciudad)))
                            .Include(i => i.Domicilio)
                            .AsQueryable();
            return listUsers;
        }

        public async Task<Usuario> GetUser(int id)
        {
            var user = await _dbContext.Usuario.Where(c => c.ID == id)
                            .Include(i => i.Domicilio)
                            .FirstOrDefaultAsync();
            return user;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _dbContext.Usuario.FirstOrDefaultAsync(c => c.ID == id);
            if (user != null)
            {
                _dbContext.Usuario.Remove(user);
                await _dbContext.SaveChangesAsync();
            } 
            return true;
        }

        public async Task PutUser(Usuario usuario)
        {
            _dbContext.Update(usuario);
            await _dbContext.SaveChangesAsync();
        }
    }
}
