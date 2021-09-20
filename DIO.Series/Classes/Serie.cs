using System;

namespace DIO.Series
{
    public class Serie : EntidadeBase
    {
        // Artubutos
        private Genero Genero {get; set; }

        private string Titulo {get; set;}

        private string Descricao {get; set;}

        private int Ano {get; set;}

        private bool Excluido {get; set;}

        // Construtor
        public Serie(int Id, Genero genero,string Titulo, string Descricao,int Ano)
        {
            this.Id = Id;
            this.Genero = genero;
            this.Titulo = Titulo;
            this.Descricao = Descricao;
            this.Ano = Ano;
            this.Excluido = false; 
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Genero: " +  this.Genero + "\n";
            retorno += "Titulo: " +  this.Titulo + "\n";
            retorno += "Descricao: " +  this.Descricao + "\n";
            retorno += "Ano: " +  this.Ano + "\n";
            retorno += "Excluido: " + this.Excluido;
            
            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
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