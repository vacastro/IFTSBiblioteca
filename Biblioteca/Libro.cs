using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca
{
    internal class Libro
    {
        private string titulo;
        private string autor;
        private string editorial;
        private bool prestado;

        public Libro(string titulo, string autor, string editorial)
        {
            this.Titulo = titulo;
            this.Autor = autor;
            this.Editorial = editorial;
            this.Prestado = false;
        }

        public string Titulo { get => titulo; set => titulo = value; }
        public string Autor { get => autor; set => autor = value; }
        public string Editorial { get => editorial; set => editorial = value; }
        public bool Prestado { get => prestado; set => prestado = value; }

        public override string ToString()
        {
            return "Titulo: " + titulo + " Autor: " + autor + " Editorial: " + editorial + " Prestado: " + prestado;
        }
    }
}
