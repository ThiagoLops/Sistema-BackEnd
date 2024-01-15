using WebApplication1.Commom;
using WebApplication1.Entities;
using WebApplication1.model;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public class UsuarioService
    {
        private string _connectionString;
        
        public UsuarioService(string connectionString)
        {
            _connectionString = connectionString;
        }

        
        public  LoginResult Login(string email, string senha)
        {
            var result = new LoginResult();

            var usuarioRepository = new UsuarioRepository(_connectionString);

            var usuario = usuarioRepository.ObterUsuarioPorEmail(email);

            if (usuario != null)
            {
                //usario existe

                if (usuario.Senha == senha)
                {
                    //Login sucesso;
                    result.Sucesso = true;
                    result.usuarioGuid = usuario.UsuarioGuid;
                }
                else
                {
                    //senha invalida

                    result.Sucesso = false;
                    result.Mensagem = "Usúario ou senha inválidos";
                }
            }
            else
            {
                result.Sucesso = false;
                result.Mensagem = "Usuario ou senha inválidos";
            }

            return result;
        }

        public CadastroResult Cadastro(string nome, string sobrenome, string telefone, string email, string senha, string genero)
        {
            var result = new CadastroResult();

            var usuarioRepository = new UsuarioRepository(_connectionString);
            var usuario = usuarioRepository.ObterUsuarioPorEmail(email);
           

            if (usuario != null) 
            {
                //email existe
                result.Sucesso = false;
                result.Mensagem = "Usúario já existe no sistema";

            }
            else
            {
                //usúario não existe
                usuario = new Usuario();

                usuario.Nome = nome;
                usuario.Sobrenome = sobrenome;
                usuario.Email = email;
                usuario.Senha = senha;
                usuario.Telefone = telefone;
                usuario.Genero = genero;
                usuario.UsuarioGuid = Guid.NewGuid();

                var affectedRows = usuarioRepository.Inserir(usuario);

                if (affectedRows > 0)
                {
                    //inseriu com sucesso
                    result.Sucesso = true;
                    result.usuarioGuid = usuario.UsuarioGuid;
                }
                else
                {
                    //erro ao inserir;
                    result.Sucesso = false;
                    result.Mensagem = "Erro ao inserir dados. Preencha novamente";
                }
            }

            return result; 
        }

        public RecuperarAcessoResult RecuperarAcesso(string email)
        {

            var result = new RecuperarAcessoResult();

            var usuarioRepository = new UsuarioRepository(_connectionString);

            var usuario = usuarioRepository.ObterUsuarioPorEmail(email);

            if (usuario == null)
            {
                //não existe
                result.Sucesso = false;
                result.Mensagem = "Usuário não existe";

            }
            else
            {
                //usúario existe
                var emailSender = new EmailSender();

                var assunto = "Programação do Zero - Recuperação de senha";
                var corpo = "Sua senha de acesso é " + usuario.Senha;

                emailSender.Enviar(assunto, corpo, usuario.Email);

                result.Sucesso = true;
            }

            return result;
        }

        public Usuario ObterUsuario(Guid usuarioGuid)
        {
            var usuario = new UsuarioRepository(_connectionString).ObterPorGuid(usuarioGuid);

            return usuario;
        }
    }
}
