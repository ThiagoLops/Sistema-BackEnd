namespace WebApplication1.model
{
    public class Carro : Automovel
    {
        public Carro()
        {
            QuantRodas = 4;
        }

        public int QuantRodas { get; set; }

        public override void Acelerar()
        {
            InjetarCombustivel(4);
        }

        private void InjetarCombustivel(int quantCombustivel)
        {
            base.TanqueGasolina = base.TanqueGasolina - quantCombustivel;
        }
    }
}
