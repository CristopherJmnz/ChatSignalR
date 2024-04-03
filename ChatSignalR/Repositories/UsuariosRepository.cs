using ChatSignalR.Models;

namespace ChatSignalR.Repositories
{
    public class UsuariosRepository
    {
        private List<Usuario> usuarios;
        public UsuariosRepository()
        {
            this.usuarios = new List<Usuario>();
            this.usuarios.Add(new Usuario()
            {
                Email = "cris@gmail.com",
                Password = "123",
                Username = "Cristopher"
            });
            this.usuarios.Add(new Usuario()
            {
                Email = "maria@gmail.com",
                Password = "123",
                Username = "Maria"
            });
        }

        public Usuario Login(string email, string password)
        {
            return this.usuarios
                .FirstOrDefault(x => x.Email == email 
                && x.Password == password);
        }


    }
}
