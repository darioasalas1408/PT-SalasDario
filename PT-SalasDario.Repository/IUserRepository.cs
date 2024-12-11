using PT_SalasDario.Data;

namespace PT_SalasDario.Repository
{
    public interface IUserRepository
    {
        Task CreateUser(Usuario usuario);
        IQueryable<Usuario> GetUsers(string nombre, string provincia, string ciudad);
        Task<Usuario> GetUser(int id);
        Task<bool> DeleteUser(int id);
        Task PutUser(Usuario usuario);
    }
}
