using System;

namespace DIO.Carros
{
    public class Carro : EntidadeBase
    {
        //Atributos
        private Cor Cor { get; set; }
        private string Marca { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }

        private bool Excluido {get; set;}

        //Métodos

        public Carro(int id, Cor cor, string marca, string descricao, int ano)
        {
            this.Id = id;
            this.Cor = cor;
            this.Marca = marca;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Cor: " + this.Marca + Environment.NewLine;
            retorno += "Marca: " + this.Cor + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de fábricação: " + this.Ano + Environment.NewLine;
            retorno += "Excluido:" + this.Excluido;
            return retorno;
        }
        public string retornaMarca()
        {
            return this.Marca;
        }
        public int retornaId()
        {
            return this.Id;
        }

         public bool retornaExcluido()
        {
            return this.Excluido;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}