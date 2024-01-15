namespace WebApplication1.model
{
    public class Automovel
    {
       //construtor;
        public Automovel()
        {
            TanqueGasolina = 40;
        } 

        //atributos e propriedades
        public  string Cor { get; set; }

        public  string Modelo { get; set; }

        public string Marca { get; set; }

        public  string Placa { get; set; }

        public int TanqueGasolina { get; set; }   

        //métodos


        //Liberação para sobre escrever um método;

        public virtual void Acelerar()
        {
            InjetarCombustivel(1);
        }

        public void Freiar()
        {
        }

        private void InjetarCombustivel(int quantidadeInjetada)
        {
            TanqueGasolina = TanqueGasolina - quantidadeInjetada;
        }

        public virtual void Abastecer()
        {
            TanqueGasolina = 60;
        }
    }
}
