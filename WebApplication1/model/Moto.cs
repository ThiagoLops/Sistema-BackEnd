namespace WebApplication1.model
{
    public class Moto : Automovel
    {
        public Moto()
        {
            QuantRodas = 2;
            TanqueGasolina = 12;
        }

        public int QuantRodas { get; set; }

        public override void Acelerar()
        {
            InjetarCombustivel(2);
        }

        private void InjetarCombustivel(int quantCombustivel)
        {
            base.TanqueGasolina = base.TanqueGasolina - quantCombustivel;
        }

        public override void Abastecer()
        {
            base.TanqueGasolina = 15;
        }

    }
}
