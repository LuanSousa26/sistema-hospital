using classes;
using System.IO;
using System;

namespace Classes
{
    public class Dono : Iacao
    {

        private string Nome;
        private string Documento;
        private int Idade;
        private string Email;
        

        

        public Dono(string Nome,string Documento,int Idade,string Email)
        {
          this.Nome=Nome;
          this.Documento=Documento;
          this.Idade=Idade;
          this.Email=Email;
        }

       public void Cadastrar()
        {
            StreamWriter SalvaDono=new StreamWriter(@"../Repositorio/Dono.csv",true);
            SalvaDono.Write(Nome+";");
            SalvaDono.Write(Documento+";");
            SalvaDono.Write(Idade+";");
            SalvaDono.WriteLine(Email);
            SalvaDono.Close();
        }

     public void Consultar()
        {
            throw new System.NotImplementedException();
        }
    }
}