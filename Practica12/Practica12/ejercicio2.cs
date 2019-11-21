using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Practica12
{
    class ejercicio2
    {
        static void Main(string[] args)
        {
            Program.Mascota mascota1;
            FileStream fs;
            BinaryFormatter formatter = new BinaryFormatter();
            const string nombreArchivo = "mascota.bin";
            if (File.Exists(nombreArchivo))
            {
                try
                {                    
                    fs = new FileStream(nombreArchivo, FileMode.Open, FileAccess.Read);
                    mascota1 = (Program.Mascota)formatter.Deserialize(fs);
                    fs.Close();
                    Console.WriteLine("Datos de la mascota\n");
                    Console.WriteLine($"Nombre: {mascota1.nombre}");
                    Console.WriteLine($"Especie: {mascota1.especie}");
                    Console.WriteLine($"Raza: {mascota1.raza}");
                    Console.WriteLine($"Sexo: {mascota1.sexo}");
                    Console.WriteLine($"Edad: {mascota1.getEdad()}");
                    Console.WriteLine("Presione <Enter> para salir.");

                }
                catch (Exception)
                {

                    throw;
                }
                Console.ReadKey();
            }
        }
    }
}
