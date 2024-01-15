using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/aula8")]
    [ApiController]
    public class Aula8Controle : ControllerBase
    {
        [Route("olaMundo")]
        [HttpGet]
        public string OlaMundo()
        {
            var mensagem = "Olá mundo via API";

            return mensagem;
        }
        [Route("olaMundoPersonalizado")]
        [HttpGet]
        public string OlaMundoPersonalizado(string nome)
        {
            var mensagem = "Olá " + nome + ". Essa Api lhe deseja boas vindas.";

            return mensagem;
        }

        [Route("somar")]
        [HttpGet]
        public string SomaDeNumeros(int valor1, int valor2)
        {
            var somar = valor1 + valor2;
            var mensagem = "A soma é " + somar;

            return mensagem;
        }

        [Route("media")]
        [HttpGet]

        public string MediaNumeros(int valor1, int valor2)
        {
            var media = (valor1 + valor2) / 2;
            var mensagem = "A média dos numeros é " + media;

            return mensagem;
        }

        [Route("terreno")]
        [HttpGet]

        public string AreaTerreno(float largura, float comprimento, float valor)
        {
            var area = largura * comprimento;
            var precoArea = area * valor;
            var mensagem = "O valor do terreno é " + precoArea;

            return mensagem;
        }

        [Route("troco")]
        [HttpGet]

        public string Troco(float precoProduto, int quantidade, float valorRecebido)
        {
            var totalCompra = precoProduto * quantidade;
            var trocoCliente = valorRecebido - totalCompra;
            string mensagem;

            if(valorRecebido > totalCompra) { 
            
                mensagem = "O total da compra foi " + totalCompra + "$. Com o valor recebido de " + valorRecebido + "$, o troco será de " + trocoCliente + "$.";
            } else
            {
                mensagem = "O valor recebido é inferior ao total da compra.";
            }

            return mensagem;
        }

        [Route("consumo")]
        [HttpGet]

        public string Consumo(float distancia, float totalConsumo)
        {
            var mediaConsumo = distancia / totalConsumo;
            var mensagem = "O consumo médio do veículo é " + mediaConsumo + "Km por litro.";

            return mensagem;
        }

    }
}
