namespace ProyectoEval1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Ejercicio 1: Hacer una función que se le pase un string que contiene un número y devuelva un entero (long)");
                Console.WriteLine("Si el string no contiene un número, debe lanzar una excepción.");
                Console.WriteLine(Hash.StringToLong("77"));

                Console.WriteLine("Ejercicio 2: Hacer una función que calcule el hash de un string.");
                Console.WriteLine("Convertir el carácter a su valor numérico (por ejemplo, usando su valor ASCII).");
                Console.WriteLine(Hash.HashString("Javier!"));

                Console.WriteLine("Ejercicio 3: Hacer una función que se le pasa un dni y devuelve si el formato es correcto o no.");
                Console.WriteLine(Validators.IsValidDNI("48620440-G"));

                Console.WriteLine("Ejercicio 4: Hacer una función que se le pase un correo electrónico y devuelva si es correcto o no.");
                Console.WriteLine(Validators.IsValidEmail("dm@dmsd.es"));

                Console.WriteLine("Ejercicio 5: Hacer una función a la que se le pase un string y un booleano. ");
                Console.WriteLine("Esta función devolverá ese string en mayúsculas o minúsculas dependiendo de ese booleano.");
                string s = Utils.ChangeCaptionString("HOla!ñx", false);
                Console.WriteLine(s);

                Console.WriteLine("Ejercicio 6: Hacer una función que dados un año, un mes, un día una hora, unos minutos y unos\r\nsegundos, devuelva un string con este formato:");
                Console.WriteLine("“año/mes/día - hora:minutos:segundos”");
                int year = 1000;
                int month = 7;
                int day = 20;
                int hour = 10;
                int minute = 24;
                int second = 50;
                string FullYear = Dates.ConvertDateToString(year, month, day, hour, minute, second);
                Console.WriteLine(FullYear);
                Console.WriteLine("Ejercicio 7: Hacer una función que, dado un string que representa una fecha, devuelva de una sola vez\r\nel año, el mes, el día, la hora, los minutos y los segundos.");
                (int y, int m, int d, int h, int min, int sec) = Dates.ConvertStringToDate(FullYear);
                Console.WriteLine($"{y}/{m}/{d} - {h}:{min}:{sec}");
            } catch (Exception ex)
            {
                Console.WriteLine($"Ha habido un error: {ex.Message}");
            }




        }
    }
}
