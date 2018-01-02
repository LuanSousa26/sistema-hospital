using System;
using System.IO;
using Classes;
using Util;

namespace ProjetoConsole {
    class Program {

        static void Main (string[] args) {
            Dono dn=new Dono();
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
                    System.Console.WriteLine ("            CADASTRO DE DONOS              ");
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
                                 // Se for igual a 11 é CPF
                            if (Documento.Length == 11) {
                                // Função para validar o CPF
                                Documento = Util.validar_cpf (Documento);
                            }
                             else if(Documento.Length==14) 
                             {
                                // Função para validar o CNPJ
                                Documento = Util.validar_cnpj (Documento);
                             }
                             else
                             {
                                 Documento="CPF invalido";
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

                    case "2":
                    dn.Consultar();
                    break;

                    //Cadastro de Animais
                    case "3":
                    string Dono="",NomeAnimal="",Raca="",Tipo="";
                    double Peso=0;
                    int IdadeAnimal=0;

                    System.Console.WriteLine ("-------------------------------------------");
                    System.Console.WriteLine ("            CADASTRO DE ANIMAIS            ");
                    System.Console.WriteLine ("-------------------------------------------");
                    
                    
                    while(Dono=="")
                    {
                    System.Console.WriteLine("\n Favor Digite o Documento CPF ou CNPJ do Dono do Animal:");
                    Dono=Console.ReadLine();
                    Util.ConsultarDono(Dono);
                    }


                    while(NomeAnimal=="")
                    {
                    System.Console.WriteLine("\n Favor Digite o Nome do Animal:");
                    NomeAnimal=Console.ReadLine();
                    
                    //Método para Validar o nome do animal, não pode haver números
                    NomeAnimal=Util.ValidarNome(NomeAnimal);
                    }

                    while(Raca=="")
                    {
                       System.Console.WriteLine("\nFavor Digite a raça do Animal:");
                       Raca=Console.ReadLine();
                        //Método para Validar a raça do animal, não pode haver números
                       Raca=Util.ValidarNome(Raca);
                    }

                    while(Tipo=="")
                    {
                        System.Console.WriteLine("\nFavor Digite o Tipo do Animal:");
                        Tipo=Console.ReadLine();
                        Tipo=Util.ValidarNome(Tipo);
                    }
                     
                    
                    while(Peso.Equals(0))
                    {
                       
                        try
                        {
                           System.Console.WriteLine("\nFavor Digite o Peso do Animal:");
                           Peso=Double.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            System.Console.WriteLine("O peso está em formato inválido");
                        }
                    }
                    
                    while(IdadeAnimal.Equals(0))
                    {
                       try
                       {
                         System.Console.WriteLine("\n Favor Digite a Idade do Animal:");
                         IdadeAnimal=Int32.Parse(Console.ReadLine());
                        }
                       catch 
                       {
                           System.Console.WriteLine("A idade está em um formato Inválido");                         
                       }
                    }

                    break;
            }

        }
    }
}