using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca
{
    internal class Lector
    {

        private string nombre;
        private int dni;
        private List<Libro> librosPrestados;



        public Lector(string nombre, int dni)
        {
            this.Nombre = nombre;
            this.Dni = dni;
            this.LibrosPrestados = new List<Libro>();
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public int Dni { get => dni; set => dni = value; }
        internal List<Libro> LibrosPrestados { get => librosPrestados; set => librosPrestados = value; }

        public bool contieneLibro(string titulo)
        {
            bool encontrado = false;
            foreach(Libro libro in librosPrestados)
            {
                if(libro.Titulo.Equals(titulo))
                {
                    encontrado = true;
                    break;
                }
            }
            return encontrado;
        }

        public override string ToString()
        {
            string cadena = "";
            if (LibrosPrestados.Count != 0)
            {
                foreach (Libro libro in LibrosPrestados)
                {
                    cadena = cadena + "Nombre: " + nombre + " DNI: " + dni + " Libros Prestados: " + libro.Titulo + "\n";
                }
            }
            else
            {
                cadena = "Nombre: " + nombre + " DNI: " + dni + " Libros Prestados: 0\n";
            }
            return cadena;
        }
    }


}
