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

        public bool agregarLibro(string titulo, string autor, string editorial)
        {
            bool resultado= false;

            Libro libro = buscarLibro(titulo);

            if(libro == null) {
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
            Libro libro = buscarLibro(titulo);
            if( libro != null)
            {
                if (libro.Prestado == false)
                {
                    libros.Remove(libro);
                    resultado = true;
                }
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

        public bool agregarLector (string nombre, int dni)
        {
            bool resultado = false;
            Lector lector = buscarLector(dni);
            if(lector == null)
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
                if(lectorSolicitante.contieneLibro(libroDevuelto.Titulo))
                {
                    resultado = "LIBRO DEVUELTO CON EXITO";
                    libroDevuelto.Prestado = false;
                    lectorSolicitante.LibrosPrestados.Remove(libroDevuelto);
                }
                else
                {
                    resultado = "EL LIBRO QUE QUIERE DEVOLVER, NO ESTA SOLICITADO POR EL LECTOR";
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
            bool band, agregado, eliminado;
            string titulo, autor, editorial, nombre;
            int dni;

            do
            {
                band = true;
                int i;
                Console.WriteLine("\nELIJA UNA OPCION");
                Console.WriteLine("1. Agregar un nuevo libro");
                Console.WriteLine("2. Agregar un nuevo lector");
                Console.WriteLine("3. Buscar libro");
                Console.WriteLine("4. Buscar lector");
                Console.WriteLine("5. Eliminar libro");
                Console.WriteLine("6. Listar libros");
                Console.WriteLine("7. Listar lectores");
                Console.WriteLine("8. Prestar libro");
                Console.WriteLine("9. Devolver libro");
                Console.WriteLine("10. Finalizar Ejecución");
                Console.Write("\nIngrese Opcion: ");
                i = int.Parse(Console.ReadLine());

                switch (i)
                {
                    case 1:
                        Console.Write("Ingrese el titulo del libro que desea agregar: ");
                        titulo = Console.ReadLine();
                        Console.Write("Ingrese el autor del libro: ");
                        autor = Console.ReadLine();
                        Console.Write("Ingrese la editorial: ");
                        editorial = Console.ReadLine();

                        agregado = agregarLibro(titulo, autor, editorial);
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
                        Console.Write("Ingrese el nombre del Lector: ");
                        nombre = Console.ReadLine();
                        Console.Write("Ingrese el dni del Lector: ");
                        dni = int.Parse(Console.ReadLine());

                        agregado = agregarLector(nombre, dni);
                        if (agregado)
                        {
                            Console.WriteLine("Lector agregado con exito");
                        }
                        else
                        {
                            Console.WriteLine("No se pudo agregar el lector");
                        }
                        break;

                    case 3:
                        Console.Write("Ingrese el titulo del libro a buscar: ");
                        titulo = Console.ReadLine();
                        Libro libro = buscarLibro(titulo);
                        if(libro == null)
                        {
                            Console.WriteLine("El libro no existe");
                        }
                        else
                        {
                            Console.WriteLine(libro.ToString());
                        }
                        
                        break;

                    case 4:
                        Console.Write("Ingrese el dni del lector a buscar: ");
                        dni = int.Parse(Console.ReadLine());
                        Lector lector = buscarLector(dni);
                        if (lector == null)
                        {
                            Console.WriteLine("El lector no existe");
                        }
                        else
                        {
                            Console.WriteLine(lector.ToString());
                        }
                        
                        break;

                    case 5:
                        Console.Write("Ingrese el titulo del libro a eliminar: ");
                        titulo = Console.ReadLine();
                        eliminado = eliminarLibro(titulo);
                        if (eliminado)
                        {
                            Console.WriteLine("Libro eliminado con exito");
                        }
                        else
                        {
                            Console.WriteLine("No se pudo eliminar el libro. El libro no existe o está prestado y deberá ser devuelto primero.");
                        }
                        break;

                    case 6:
                        listarLibros();
                        break;

                    case 7:
                        listarLectores();
                        break;

                    case 8:
                        Console.Write("Ingrese el titulo del libro a prestar: ");
                        titulo = Console.ReadLine();
                        Console.Write("Ingrese el dni del lector que toma el libro prestado: ");
                        dni = int.Parse(Console.ReadLine());
                        Console.WriteLine(prestarLibro(titulo, dni));
                        break;

                    case 9:
                        Console.Write("Ingrese el titulo del libro a devolver: ");
                        titulo = Console.ReadLine();
                        Console.Write("Ingrese el dni del lector que devuelve el libro: ");
                        dni = int.Parse(Console.ReadLine());
                        Console.WriteLine(devolverLibro(titulo, dni));
                        break;

                    case 10:
                        band = false;
                        break;

                    default:
                        Console.WriteLine("Opcion no válida");
                        break;

                }
            } while (band);
        }
    }
}
