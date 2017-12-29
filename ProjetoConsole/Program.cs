using System;
using System.IO;
using Classes;
using Util;

namespace ProjetoConsole {
    class Program {

        static void Main (string[] args) {
            Utilidades Util = new Utilidades ();

            string Operacao = "";

            while (Operacao != "1" && Operacao != "2" && Operacao != "3" && Operacao != "4") {
                System.Console.WriteLine ("-------------------------------------------");
                System.Console.WriteLine ("                 PETSHOP                   ");
                System.Console.WriteLine ("-------------------------------------------");
                System.Console.WriteLine ("Escolha uma Opção:\n1 - Para Cadastro de Donos\n2 - Pesquisa de Donos\n3 - Cadastro de Animais\n4 -Pesquisa de Animais ");
                Operacao = Console.ReadLine ();
            }
            switch (Operacao) {
                case "1":
                    string Nome = "", Documento = "", Email = "";
                    int Idade;
                    System.Console.WriteLine ("-------------------------------------------");
                    System.Console.WriteLine ("            CADASTRO DE DONO              ");
                    System.Console.WriteLine ("-------------------------------------------");

                    while (Nome == "") {
                        System.Console.WriteLine ("\nFavor digite o Nome do Dono:");
                        Nome = Console.ReadLine ();

                        //Valida se o nome é válido(Nao possui números)
                        Nome = Util.ValidarNome (Nome);

                    }

                    while (Documento == "") {
                        do {
                            System.Console.WriteLine ("\nFavor digite o Documento do Dono:");
                            Documento = Console.ReadLine ();
                            if (Documento.Length == 11) {
                                Documento = Util.validar_cpf (Documento);
                            } else {
                                Documento = Util.validar_cnpj (Documento);
                            }
                        } while (Documento == "CNPJ invalido" || Documento == "CPF invalido");

                    }

                    Idade:
                        try {
                            System.Console.WriteLine ("\nFavor digite a Idade do Dono:");
                            Idade = Int32.Parse (Console.ReadLine ());
                        }
                    catch {
                        goto Idade;
                    }

                    while (Email == "") {
                        System.Console.WriteLine ("\nFavor digite o E-mail do Dono:");
                        Email = Console.ReadLine ();
                        //Valida se o E-mail está válido
                        Util.ValidarEmail (Email);
                    }
                    //Cria o Objeto NovoDono e o instância com o construtor pré criado na classe Dono
                    Dono NovoDono = new Dono (Nome, Documento, Idade, Email);
                    //Método para Salvar o Dono
                    NovoDono.Cadastrar ();

                    break;

            }

        }
    }
}