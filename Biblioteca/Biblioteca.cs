using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
            return resultado;
        }


        public void listarLibros()
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
            if(buscarLibro(titulo) != null)
            {
                libro = buscarLibro(titulo);
                libros.Remove(libro);
                resultado = true;
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
            }
            return resultado;
        }

        public void listarLectores()
        {
            foreach(Lector lector in lectores)
            {
                Console.WriteLine(lector.ToString());
            }
        }

     
        public string prestarLibro(string titulo, int dni)
        {
            Libro libroPrestado = buscarLibro (titulo);
            Lector lectorSolicitante = buscarLector (dni);
            string resultado ="";

            if(libroPrestado != null && libroPrestado.Prestado == false)
            {
                if(lectorSolicitante !=null && lectorSolicitante.LibrosPrestados.Count < 3)
                {
                    libroPrestado.Prestado = true;
                    lectorSolicitante.LibrosPrestados.Add(libroPrestado);
                    resultado = "PRESTAMO EXITOSO";
                }
                else if (lectorSolicitante != null && lectorSolicitante.LibrosPrestados.Count == 3)
                {
                    resultado = " TOPE DE PRESTAMO ALCANZADO";
                }
                else if (lectorSolicitante == null)
                {
                    resultado = "LECTOR INEXISTENTE";
                }
            }
            else if (libroPrestado != null && libroPrestado.Prestado == true)
            {
                resultado = "EL LIBRO NO SE ENCUENTRA DISPONIBLE";
            }
            else if (libroPrestado == null)
            {
                resultado = "LIBRO INEXISTENTE";
            }
            return resultado;
        }

        public string devolverLibro(string titulo, int dni)
        {
            Libro libroDevuelto = buscarLibro(titulo);
            Lector lectorSolicitante = buscarLector(dni);
            string resultado = "";

            if(lectorSolicitante != null && libroDevuelto != null)
            {
                foreach( Libro libro in lectorSolicitante.LibrosPrestados)
                {
                    if(libro.Titulo.Equals(titulo))
                    {
                        resultado = "LIBRO DEVUELTO CON EXITO";
                        libroDevuelto.Prestado = false;
                        lectorSolicitante.LibrosPrestados.Remove(libroDevuelto);
                        break;
                    }
                    else
                    {
                        resultado = "EL LIBRO QUE QUIERE DEVOLVER, NO ESTA SOLICITADO POR EL LECTOR";
                        break;
                    }
                }
            }else if (libroDevuelto== null)
            {
                resultado = "LIBRO INEXISTENTE";
            }else if (lectorSolicitante == null)
            {
                resultado = "LECTOR INEXISTENTE";
            }

            return resultado;
        }

        public void menuPrincipal()
        {
            bool band;
            do
            {
                band = false;
                int i;
                Console.WriteLine("ELIJA UNA OPCION");
                Console.WriteLine("1. Agregar un nuevo libro");
                Console.WriteLine("2. Agregar un nuevo lector");
                Console.WriteLine("3. Buscar libro");
                Console.WriteLine("4. Buscar lector");
                Console.WriteLine("5. Eliminar libro");
                Console.WriteLine("5. Listar libros");
                Console.WriteLine("6. Listar lectores");
                Console.WriteLine("7. Prestar libro");
                Console.WriteLine("8. Devolver libro");
                i = int.Parse(Console.ReadLine());

                switch (i)
                {
                    case 1:
                        Console.WriteLine("Ingrese el titulo del libro que desea agregar");
                        string titulo = Console.ReadLine();
                        Console.WriteLine("Ingrese el autor del libro");
                        string autor = Console.ReadLine();
                        Console.WriteLine("Ingrese la editorial");
                        string editorial = Console.ReadLine();

                        bool agregado= agregarLibro(titulo, autor, editorial);
                        if (agregado)
                        {
                            Console.WriteLine("Libro agregado con exito");
                        }
                        else
                        {
                            Console.WriteLine("No se pudo agregar el libro");
                        }
                        break;
                    case 2:
                        break;
                    default:
                    break;

                }
            } while (band);
        }
    }
}
