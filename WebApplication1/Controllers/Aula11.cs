using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.model;

namespace WebApplication1.Controllers
{
    [Route("api/aula11")]
    [ApiController]
    public class Aula11 : ControllerBase
    {
        [Route("obterAutomovel")]
        [HttpGet]

        public Automovel obterAutomovel()
        {
            var meuAutomovel = new Automovel();

            meuAutomovel.Cor = "Azul";
            meuAutomovel.Marca = "Honda";
            meuAutomovel.Placa = "HDE-9795";
            meuAutomovel.Modelo = "Civic";

            meuAutomovel.Acelerar();

            return meuAutomovel;
        }

        [Route("obterCarro")]
        [HttpGet]

        public Carro obterCarro()
        {
            var meuCarro = new Carro();

            meuCarro.Cor = "Verde";
            meuCarro.Marca = "Fiat";
            meuCarro.Placa = "HDE-0110";
            meuCarro.Modelo = "Uno";

            meuCarro.Acelerar();
            meuCarro.Abastecer();

            return meuCarro;
        }

        [Route("obterMoto")]
        [HttpGet]

        public Moto obterMoto()
        {
            var minhaMoto = new Moto();

            minhaMoto.Cor = "Prata";
            minhaMoto.Marca = "Honda";
            minhaMoto.Placa = "SCX-0112";
            minhaMoto.Modelo = "Titan 150";

            minhaMoto.Acelerar();
            minhaMoto.Abastecer();

            return minhaMoto;
        }
    }
}
