using System;
using System.Text.RegularExpressions;

namespace Util
{
    public class Utilidades
    {
        
         
         public string ValidarNome(string Nome)
         {
            string RNome="";

            if(Regex.IsMatch(Nome,@"^[a-zA-Z á]*$"))
             RNome=Nome;
             else
             System.Console.WriteLine("O nome está inválido!\n");

             return RNome;
         }

        /*
          Função para Validar se o E-mail foi digitado corretamente
         */
         public string ValidarEmail(string email)
        {
            /*
             No código abaixo dizemos que a marcara do e-mail é texto + @ +Texto +. + texto,ou seja,teste@teste.com 
             */
            Regex regex = new Regex(@"(\w+)(@)(\w+)(.)(\w+)");
            
            //Recebe o parâmetro passado e o valida
            Match match = regex.Match(email);

            // loop para pedir dado caso incorreto
            while (!match.Success)
            {
                System.Console.WriteLine("Digite o e-mail Corretamente");
                email = Console.ReadLine();
                match = regex.Match(email);
            }

            //retorna o e-mail já validado
            return match.Value;
        }
    }
}
