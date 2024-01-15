using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.model;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IConfiguration _configuration;
        public UsuarioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Route("login")]
        [HttpPost]
        public LoginResult Login(LoginRequest request)
        {

            var result = new LoginResult();

            if (result == null)
            {
                result.Sucesso = false;
                result.Mensagem = "Parâmetro request veio nulo.";
            }
            else if (request.Email == "")
            {
                result.Sucesso = false;
                result.Mensagem = "E-mail obrigatório.";
            }
            else if (request.Senha == "")
            {
                result.Sucesso = false;
                result.Mensagem = "Senha obrigatória";
            }
            else
            {
                //sucesso

                var connectionString = _configuration.GetConnectionString("programacaoDoZeroDb"); 

                var usuarioService = new UsuarioService(connectionString);

                result = usuarioService.Login(request.Email, request.Senha);
            }

            return result;

        }

        [Route("cadastro")]
        [HttpPost]

        public CadastroResult Cadastro(CadastroRequest request)
        { 

            var result = new CadastroResult();

            if (request == null ||
                string.IsNullOrWhiteSpace(request.Nome) ||
                string.IsNullOrWhiteSpace(request.Sobrenome) ||
                string.IsNullOrWhiteSpace(request.Telefone) ||
                string.IsNullOrWhiteSpace(request.Genero) ||
                string.IsNullOrWhiteSpace(request.Email) ||
                string.IsNullOrWhiteSpace(request.Senha))               
            {

                result.Sucesso = false;
                result.Mensagem = "Todos os campos são obrigatórios";

            } else 
            {
                var connectionString = _configuration.GetConnectionString("programacaoDoZeroDb"); 

                result = new UsuarioService(connectionString).Cadastro(request.Nome, request.Sobrenome, request.Telefone, request.Email, request.Senha, request.Genero);
            }

            return result;
        }

        [Route("recuperarAcesso")]
        [HttpPost]

        public RecuperarAcessoResult RecuperarAcesso(RecuperarAcessoRequest request)
        {
            var result = new RecuperarAcessoResult();

            if (request == null ||  string.IsNullOrEmpty(request.Email))
            {
           
                result.Mensagem = "E-mail obrigatório";

                return result;
            } 
         
            var connectionString = _configuration.GetConnectionString("programacaoDoZeroDb");
            result = new UsuarioService(connectionString).RecuperarAcesso(request.Email);

            return result;

        }

        [Route("obterUsuario")]
        [HttpGet]
        public ObterUsuarioResult ObterUsuario(Guid usuarioGuid)
        {
            var result = new ObterUsuarioResult();

            if (usuarioGuid == null)
            {
                result.Mensagem = "Usuário Guid vazio";
            } else
            {
                var connectionString = _configuration.GetConnectionString("programacaoDoZeroDb");

                var usuario = new UsuarioService(connectionString).ObterUsuario(usuarioGuid);

                if (usuario == null)
                {
                    result.Mensagem = "Usuário não existe";
                }
                else
                {
                    result.Sucesso = true;
                    result.Nome = usuario.Nome;
                }
            }

            return result;
        }
    }
}
