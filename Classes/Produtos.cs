using System;

namespace classes
{
    public abstract class Produtos 
    {
        public int Id{ get; set; }
        public string Nome{ get; set; }
        public string Descricao{ get; set; }
        public double Preco{ get; set; }
        public string Tipo_animal { get; set; }
        public DateTime Data_validade { get; set; }
        public DateTime Data_cadastro{ get; set; }
    }
}
