using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca
{
    internal class Biblioteca
    {
        private List<Libro> libros;

        private List <Lector> lectores;

        public Biblioteca()
        {
            this.Libros = new List<Libro>();
            this.Lectores = new List<Lector>();
        }

        internal List<Libro> Libros { get => libros; set => libros = value; }
        internal List<Lector> Lectores { get => lectores; set => lectores = value; }


        private Libro buscarLibro(string titulo)
        {
            Libro libroBuscado = null;

            foreach (Libro libro in libros){
                if (libro.Titulo.Equals(titulo)) {

                    libroBuscado = libro;
                }
                else
                {
                    throw new Exception(" No se localizo ningun libro con el titulo " + titulo);
                }
            }

            return libroBuscado;
        }

        public bool verificarLibro(string titulo)
        {
            bool resultado = false;
            foreach(Libro libro in libros)
            {
                if (libro.Titulo.Equals(titulo))
                {
                    resultado = true;
                }
            }

            return resultado;
        }

        public bool agregarLibro(string titulo, string autor, string editorial)
        {
            bool resultado= false;

            Libro libro;

            if(verificarLibro(titulo) == false) {
                libro = new Libro(titulo, autor, editorial);
                libros.Add(libro);
                resultado = true;
            }
            else
            {
                throw new Exception("El libro que quiere agregar ya se encuentra en la biblioteca");
            }

            return resultado;
        }


        public void listarLibro()
        {
            foreach (Libro libro in libros)
            {
                Console.WriteLine(libro.ToString());
            }
        }

        public bool eliminarLibro(string titulo)
        {
            bool resultado = false;
            Libro libro;

         
            if(verificarLibro(titulo)== true)
            {
                libro = buscarLibro(titulo);
            }
            else
            {
                throw new Exception(" No se puede eliminar el libro de titulo " + titulo + " porque no existe en nuestras bases");
            }
            return resultado;
        }

        public Lector buscarLector (int dni)
        {
            Lector lectorBuscado = null;
            foreach (Lector lector in lectores) {
                if(lector.Dni == dni)
                {
                    lectorBuscado = lector;
                }
                else
                {
                    throw new Exception("No existe un lector con el dni " + dni);
                }
            }
            return lectorBuscado;

        }

        public bool verificarLector(int dni)
        {
            bool resultado = false;

            foreach( Lector lector in lectores)
            {
                if (lector.Dni == dni)
                {
                    resultado = true;
                }
            }

            return resultado;
        }

        public bool agregarLector (string nombre, int dni)
        {
            bool resultado = false;
            Lector lector;
            if(verificarLector(dni)== false)
            {
                lector = new Lector(nombre, dni);
                lectores.Add (lector);
                resultado = true;
            }else
            {
                throw new Exception("El usuario con dni " + dni + " ya se encuentra registrado");
            }

            return resultado;
        }

     
    }
}
