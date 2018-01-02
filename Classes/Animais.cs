using System;

namespace classes
{
    public class Animais : Iacao
    {
        public int Id{ get; set; }
        public string Nome{ get; set; }
        public string Dono{ get; set; }
        public string Raca{ get;set;  }
        public string Tipo{ get; set; }
        public double Peso{ get; set; }
        public int Idade{ get; set; }
        public DateTime Data_cadastro{ get; set; }
        
        public Animais()
        {
            
        }

        public Animais(int Id, string Nome, string Dono,string Raca, string Tipo, double Peso, int Idade, DateTime Data_cadastro)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Dono = Dono;
            this.Raca=Raca;
            this.Tipo = Tipo;
            this.Peso = Peso;
            this.Idade = Idade;
            this.Data_cadastro = Data_cadastro;
        }

        public void Cadastrar()
        {
            throw new NotImplementedException();
        }

        public void Consultar()
        {
            throw new NotImplementedException();
        }
    }
}

