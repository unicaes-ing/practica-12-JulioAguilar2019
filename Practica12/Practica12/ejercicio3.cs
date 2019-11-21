using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Practica12
{
    class Ejercicio3
    {
        [Serializable]
      
        public struct alumno
        {            
            public string carnet;
            public string nombre;
            public string carrera;
            private decimal cum;
            public void serCum(decimal cum)
            {
                if (cum > 0)
                {
                    this.cum = cum;
                }
            }
            public decimal getCum()
            {
                return cum;
            }
        }
        
        private static Dictionary<string, alumno> alumno1 = new Dictionary<string, alumno>();
        private static BinaryFormatter formatter = new BinaryFormatter();
        private const string archivo = "alumnos.bin";
        static void Main(string[] args)
        {
            if (File.Exists(archivo))
            {
                leerDiccionario();
            }
            else
            {
                dicionario(alumno1);
            }
            int op;
            do
            {
                Console.Clear();
                Console.WriteLine("Menú principal");
                Console.WriteLine("1. Agregar alumno");
                Console.WriteLine("2. Mostrar alumnos");
                Console.WriteLine("3. Buscar alumno");
                Console.WriteLine("4. Editar alumno");
                Console.WriteLine("5. Eliminar alumno");
                Console.WriteLine("6. Salir");
                op = Convert.ToInt32(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        #region Opccion 1
                        Console.Clear();
                        alumno alumn = new alumno();
                        do
                        {
                            Console.WriteLine("Carnet: ");
                            alumn.carnet = Console.ReadLine();
                            if (alumno1.ContainsKey(alumn.carnet))
                            {
                                Console.WriteLine("Carnet existente en el registro.");
                            }
                        } while (alumno1.ContainsKey(alumn.carnet));
                        Console.WriteLine("Nombre: ");
                        alumn.nombre = Console.ReadLine();
                        Console.WriteLine("Carrera: ");
                        alumn.carrera = Console.ReadLine();
                        Console.WriteLine("CUM: ");
                        alumn.serCum(Convert.ToDecimal(Console.ReadLine()));
                        alumno1.Add(alumn.carnet, alumn);
                        dicionario(alumno1);
                        Console.WriteLine("Datos almacenados Correctamente");
                        Console.WriteLine("\nPresione <ENTER> para continuar.");
                        Console.ReadKey();
                        #endregion
                        break;
                    case 2:
                        #region Opccion 2
                        try
                        {
                            Console.WriteLine("Lista de alumnos");
                            Console.WriteLine("{0, 10} {1,-25} {2,-30} {3,5}", "Carnet: ", "Nombre: ", "Carrera: ", "CUM: ");
                            Console.WriteLine("=========================================================================");
                            leerDiccionario();
                            foreach (KeyValuePair<string, alumno> alumnoG in alumno1)
                            {
                                alumno alumns = alumnoG.Value;
                                Console.WriteLine("{0,10} {1,-25} {2,-30} {3,5}",
                                alumns.carnet, alumns.nombre, alumns.carrera, alumns.getCum());
                            }
                            Console.WriteLine("=========================================================================");
                            Console.WriteLine("\nPresione <ENTER> para continuar.");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            throw;
                        }
                        Console.ReadKey();
                        #endregion
                        break;
                    case 3:
                        #region Opccion 3
                        string buscarcarnet;
                        Console.WriteLine("Ingrese carnet asignado al alumno que desea buscar:");
                        buscarcarnet = Console.ReadLine();
                        if (alumno1.ContainsKey(buscarcarnet))
                        {
                            Console.WriteLine("Datos del alumno");
                            Console.WriteLine("{0, 10} {1,-25} {2,-30} {3,5}", "Carnet: ", "Nombre: ", "Carrera: ", "CUM: ");
                            Console.WriteLine("=========================================================================");
                            leerDiccionario();
                            Console.WriteLine("{0,10} {1,-25} {2,-30} {3,5}",
                                alumno1[buscarcarnet].carnet, alumno1[buscarcarnet].nombre, alumno1[buscarcarnet].carrera, alumno1[buscarcarnet].getCum());
                        }
                        else
                        {
                            Console.WriteLine("El carnet: " + buscarcarnet + " no esta registrado.");
                        }
                        Console.WriteLine("\nPresione <ENTER> para continuar.");
                        Console.ReadKey();
                        #endregion
                        break;
                    case 4:
                        #region Opccion 4
                        string modificado;
                        Console.WriteLine("Ingrese carnet asignado al alumno que desea modificar:");
                        modificado = Console.ReadLine();
                        if (alumno1.ContainsKey(modificado))
                        {

                            alumno1.Remove(modificado);
                            Console.WriteLine("Opcion modificar");
                            Console.WriteLine("Ingrese los nuevos datos del alumno " + modificado + " :");
                            alumno alumnN = new alumno();
                            do
                            {
                                Console.WriteLine("Carnet: ");
                                alumnN.carnet = Console.ReadLine();
                                if (alumno1.ContainsKey(alumnN.carnet))
                                {
                                    Console.WriteLine("Carnet existente en el registro.");
                                }
                            } while (alumno1.ContainsKey(alumnN.carnet));
                            Console.WriteLine("Nombre: ");
                            alumnN.nombre = Console.ReadLine();
                            Console.WriteLine("Carrera: ");
                            alumnN.carrera = Console.ReadLine();
                            Console.WriteLine("CUM: ");
                            alumnN.serCum(Convert.ToDecimal(Console.ReadLine()));
                            alumno1.Add(alumnN.carnet, alumnN);
                            dicionario(alumno1);
                            Console.WriteLine("Datos almacenados Correctamente");
                            Console.WriteLine("\nPresione <ENTER> para continuar.");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("El carnet: " + modificado + " no esta registrado.");
                        }
                        #endregion
                        break;
                    case 5:
                        #region Opccion 5
                        string eliminar;
                        Console.WriteLine("Ingrese carnet asignado al alumno que desea modificar:");
                        eliminar = Console.ReadLine();
                        if (alumno1.ContainsKey(eliminar))
                        {
                            alumno1.Remove(eliminar);
                        }
                        dicionario(alumno1);
                        #endregion
                        break;
                }
            } while (op != 6);
        }
       
        public static bool dicionario(Dictionary<string, alumno> dAlumnos)
        {
            try
            {
                FileStream fs = new FileStream(archivo, FileMode.Create, FileAccess.Write);
                formatter.Serialize(fs, dAlumnos);
                fs.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
       
        public static bool leerDiccionario()
        {
            try
            {
                FileStream fs = new FileStream(archivo, FileMode.Open, FileAccess.Read);
                alumno1 = (Dictionary<string, alumno>)formatter.Deserialize(fs);
                fs.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}