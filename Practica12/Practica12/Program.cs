using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;using System.IO;

namespace Practica12
{
    class Program
    {      
        static void Main(string[] args)
        {
            Mascota mascota1 = new Mascota();
            const string nombreArchivo = "mascota.bin";
            FileStream fs;
            BinaryFormatter formatter = new BinaryFormatter();

            try
            {
                Console.WriteLine("Nombre: ");
                mascota1.nombre = Console.ReadLine();
                Console.WriteLine("Especie: ");
                mascota1.especie = Console.ReadLine();
                Console.WriteLine("Raza: ");
                mascota1.raza = Console.ReadLine();
                Console.WriteLine("Sexo: ");
                mascota1.sexo = Console.ReadLine();
                Console.WriteLine("Edad: ");
                mascota1.setEdad(Convert.ToInt32(Console.ReadLine()));
                fs = new FileStream(nombreArchivo, FileMode.OpenOrCreate, FileAccess.Write);
                formatter.Serialize(fs, mascota1);
                fs.Close();
                Console.WriteLine("La informacion de la mascota fue almacenada correctamente...");
            }
            catch (Exception)
            {

                throw;
            }
            Console.ReadKey();
        }     
        [Serializable]
        public struct Mascota
        {
            public string nombre;
            public string especie;
            public string raza;
            public string sexo;
            public int edad;
            public void setEdad(int edad)
            {
                if (edad > 0)
                {
                    this.edad = edad;
                }
            }        
           public int getEdad()
            {
                return edad;
            } 
        }

        
    }
}
