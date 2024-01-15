using MySql.Data.MySqlClient;
using WebApplication1.Entities;

namespace WebApplication1.Repositories
{
    public class UsuarioRepository
    {
        private string _connectionString;

        public UsuarioRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Inserir(Usuario usuario)
        {
            var cnn = new MySqlConnection(_connectionString);

            var cmd = new MySqlCommand();
            cmd.Connection = cnn;

            cmd.CommandText = @"INSERT INTO usuario(nome, sobrenome, telefone, email, genero, senha, usuarioGuid) 
            VALUES (@Nome, @Sobrenome, @Telefone, @Email, @Genero, @Senha, @UsuarioGuid)";

            cmd.Parameters.AddWithValue("Nome", usuario.Nome);
            cmd.Parameters.AddWithValue("Sobrenome", usuario.Sobrenome);
            cmd.Parameters.AddWithValue("Telefone", usuario.Telefone);
            cmd.Parameters.AddWithValue("Email", usuario.Email);
            cmd.Parameters.AddWithValue("Genero", usuario.Genero);
            cmd.Parameters.AddWithValue("Senha", usuario.Senha);
            cmd.Parameters.AddWithValue("usuarioGuid", usuario.UsuarioGuid);

            cnn.Open();

            var affectedRows = cmd.ExecuteNonQuery();

            cnn.Close();

            return affectedRows;
        }

        public Usuario ObterUsuarioPorEmail(string email)
        {
            Usuario usuario = null;

            MySqlConnection cnn = new MySqlConnection(_connectionString);

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = cnn;

            cmd.CommandText = "SELECT * FROM usuario WHERE email = @email";

            cmd.Parameters.AddWithValue("email", email);

            cnn.Open();

            var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                usuario = new Usuario();
                usuario.Nome = reader["nome"].ToString();
                usuario.Sobrenome = reader["sobrenome"].ToString();
                usuario.Telefone = reader["telefone"].ToString();
                usuario.Genero = reader["genero"].ToString();
                usuario.Email = reader["email"].ToString();
                usuario.Senha = reader["senha"].ToString();

                var usuarioGuid = reader["usuarioGuid"].ToString();
                usuario.UsuarioGuid = new Guid(usuarioGuid);
            }

            cnn.Close();
            return usuario;

        }

        public Usuario ObterPorGuid(Guid usuarioGuid)
        {
            Usuario usuario = null;

            var cnn = new MySqlConnection(_connectionString);
            
            var cmd = new MySqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "SELECT * FROM usuario WHERE usuarioGuid = @UsuarioGuid";

            cmd.Parameters.AddWithValue("usuarioGuid", usuarioGuid);

            cnn.Open();

            var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                usuario = new Usuario();
                usuario.Nome = reader["nome"].ToString();
                usuario.Sobrenome = reader["sobrenome"].ToString();
                usuario.Telefone = reader["telefone"].ToString();
                usuario.Genero = reader["genero"].ToString();
                usuario.Email = reader["email"].ToString();
                usuario.Senha = reader["senha"].ToString();

                var guid = reader["usuarioGuid"].ToString();
                usuario.UsuarioGuid = new Guid(guid);
            }

            cnn.Close();

            return usuario;
        }
    }
}
