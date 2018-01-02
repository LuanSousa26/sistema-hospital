using System;
using System.Text.RegularExpressions;

namespace Util {
    public class Utilidades {

        public string ValidarNome (string Nome) {
            string RNome = "";

            if (Regex.IsMatch (Nome, @"^[a-zA-Z á]*$"))
                RNome = Nome;
            else
                System.Console.WriteLine ("O nome está inválido!\n");

            return RNome;
        }

        /*
          Função para Validar se o E-mail foi digitado corretamente
         */
        public string ValidarEmail (string email) {
            /*
             No código abaixo dizemos que a marcara do e-mail é texto + @ +Texto +. + texto,ou seja,teste@teste.com 
             */
            Regex regex = new Regex(@"(\w+)(@)(\w+)(.)(\w+)");

            //Recebe o parâmetro passado e o valida
            Match match = regex.Match(email);

            // loop para pedir dado caso incorreto
            while (!match.Success) {
                System.Console.WriteLine ("Digite o e-mail Corretamente");
                email = Console.ReadLine ();
                match = regex.Match(email);
            }

            //retorna o e-mail já validado
            return match.Value;
        }

        public string validar_cnpj (string documento) {
            do {
                try {
                    Convert.ToInt64 (documento);
                } catch {
                    System.Console.WriteLine ("Digite o numero do CNPJ novamente, CNPJ invalido.");
                    documento = Console.ReadLine ();
                }
            } while (documento.Length > 14 || documento.Length < 14);
            int[] multiplicador1 = new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            string[] cnpj_char = new string[documento.Length];
            int[] cnpj_char_conv = new int[documento.Length];
            int[] mult_dig1 = new int[12];
            int[] mult_dig2 = new int[13];
            int sum_final = 0;
            int dig1 = 0;
            int dig2 = 0;
            for (var i = 0; i < multiplicador1.Length + 2; i++) {
                cnpj_char[i] = documento.Substring (i, 1);
                cnpj_char_conv[i] = Convert.ToInt32 (cnpj_char[i]);
                //System.Console.WriteLine("{0}", cnpj_char_conv[i]); 
            }

            for (var i = 0; i < 12; i++) {
                mult_dig1[i] = cnpj_char_conv[i] * multiplicador1[i];
                sum_final = sum_final + mult_dig1[i];
            }
            dig1 = sum_final % 11;
            if (dig1 < 2) {
                dig1 = 0;
            } else {
                dig1 = 11 - dig1;
            }
            //System.Console.WriteLine(dig1);
            sum_final = 0;
            for (var i = 0; i < 13; i++) {
                mult_dig2[i] = cnpj_char_conv[i] * multiplicador2[i];
                sum_final = sum_final + mult_dig2[i];
            }
            dig2 = sum_final % 11;
            if (dig2 < 2) {
                dig2 = 0;
            } else {
                dig2 = 11 - dig2;
            }
            //System.Console.WriteLine(dig2);
            if (dig1 == cnpj_char_conv[12] && dig2 == cnpj_char_conv[13]) {
                //System.Console.WriteLine("CPF valido");
                string cnpj_mask = Convert.ToString (cnpj_char_conv[0]) + Convert.ToString (cnpj_char_conv[1]) + "." + Convert.ToString (cnpj_char_conv[2]) + Convert.ToString (cnpj_char_conv[3]) + Convert.ToString (cnpj_char_conv[4]) + "." + Convert.ToString (cnpj_char_conv[5]) + Convert.ToString (cnpj_char_conv[6]) + Convert.ToString (cnpj_char_conv[7]) + "/" + Convert.ToString (cnpj_char_conv[8]) + Convert.ToString (cnpj_char_conv[9]) + Convert.ToString (cnpj_char_conv[10]) + Convert.ToString (cnpj_char_conv[11]) + "." + Convert.ToString (cnpj_char_conv[12]) + Convert.ToString (cnpj_char_conv[13]);
                //System.Console.WriteLine(cnpj_mask);
                return cnpj_mask;
            } else {
                //System.Console.WriteLine("CNPJ invalido");
                return "CNPJ invalido";
            }
        }

        public string validar_cpf (string documento) {
            do {
                try {
                    Convert.ToInt64 (documento);
                } catch {
                    System.Console.WriteLine ("Digite o numero do CPF do cliente novamente, CPF invalido.");
                    documento = Console.ReadLine ();
                }
            } while (documento.Length > 11 || documento.Length < 11);

            string[] cpf_char = new string[documento.Length];
            int[] cpf_char_conv = new int[documento.Length];
            for (var i = 0; i < documento.Length; i++) {
                cpf_char[i] = documento.Substring (i, 1);
                cpf_char_conv[i] = Int32.Parse (cpf_char[i]);
            }
            int[] mult_dig1 = new int[9];
            int mult_sum = 0;
            int e = 10;
            int dig1;
            int dig2;
            for (var i = 0; i < 9; i++) {
                mult_dig1[i] = cpf_char_conv[i] * e;
                mult_sum = mult_sum + mult_dig1[i];
                e--;
            }
            dig1 = mult_sum % 11;
            if (dig1 < 2) {
                dig1 = 0;
            } else {
                dig1 = 11 - dig1;
            }

            int[] mult_dig2 = new int[10];
            mult_sum = 0;
            e = 11;
            for (var i = 0; i < 10; i++) {
                mult_dig2[i] = cpf_char_conv[i] * e;
                mult_sum = mult_sum + mult_dig2[i];
                e--;
            }
            dig2 = mult_sum % 11;
            if (dig2 < 2) {
                dig2 = 0;
            } else {
                dig2 = 11 - dig2;
            }
            if (dig1 == cpf_char_conv[9] && dig2 == cpf_char_conv[10]) {
                //System.Console.WriteLine("CPF valido");
                string cpf_mask = Convert.ToString (cpf_char_conv[0]) + Convert.ToString (cpf_char_conv[1]) + Convert.ToString (cpf_char_conv[2]) + "." + Convert.ToString (cpf_char_conv[3]) + Convert.ToString (cpf_char_conv[4]) + Convert.ToString (cpf_char_conv[5]) + "." + Convert.ToString (cpf_char_conv[6]) + Convert.ToString (cpf_char_conv[7]) + Convert.ToString (cpf_char_conv[8]) + "-" + Convert.ToString (cpf_char_conv[9]) + Convert.ToString (cpf_char_conv[10]);
                //System.Console.WriteLine(cpf_mask);
                return cpf_mask;
            } else {
                //System.Console.WriteLine("CPF invalido");
                return "CPF invalido";
            }
        }

           public string ConsultarDono()
           {
               string[] Leitura=File.ReadAllLines(@"../Repositorio/Dono.csv");
               // a resolver
                foreach(string Dono in Leitura)
                      Console.WriteLine(Dono);
           }
    }
}