
namespace ProyectoEval1
{
    internal class Utils
    {
        public static void PrintList(List<int> list)
        {

            if (list == null)
                Console.WriteLine("La lista está vacía");
            for (int i = 0; i < list.Count -1; i++)
            {
                Console.WriteLine(list[i]);
            }
            Console.WriteLine(list.Count);
        }


        /// <summary>
        /// Esta función cambia las letras de un string a todo mayúsculas o todo minúsculas.
        /// Si insertas en el slot del Booleano un "FALSE", todo el texto será en minúsculas
        /// Si insertas en el slot del Booleano un "TRUE", todo el texto será en mayúsculas.
        /// </summary>
        /// <param name="s">string / bool</param>
        /// <returns>Devuelve el mismo string modificado</returns>
        /// <exception cref="Exception">string null == exception // Un carácter no válido (Sólo letras sin tildes u otros simbolos) == exception</exception>

        public static string ChangeCaptionString(string s, bool cap)
        {
            if (s == null)
                throw new Exception("No puedes pasar un string vacío");
            string aux = s;
            s = "";
            for (int i = 0; i < aux.Length; i++)
            {
                char c = aux[i];
                bool symbol = !(Validators.IsValidLetter(c));

                // hacer un toLower propio!!!!

                if (symbol)
                {
                    s += (char)(c);
                    continue;
                }

                if (cap)
                {
                    s += ToUpper(c);
                }
                if (!cap)
                {
                    s += ToLower(c);
                }
            }
            return s;
        }

        public static char ToLower(char c)
        {
            if (Validators.IsCapitalLetter(c))
                return (char)(c + 32);
            return c;
        }

        public static char ToUpper(char c)
        {
            if (Validators.IsCapitalLetter(c))
                return c;
            return (char)(c - 32);
        }

        public static int StringToInt(string s) // to int
        {
            if (s == null)
                throw new Exception("No puedes introducir un Null.");

            int n = 0;
            int mult = 1;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                char c = s[i];

                if (!Validators.IsValidNumberInChar(c))
                    throw new Exception("Has introducido un carácter que NO es un número. Vuelve a intentarlo");

                n += Validators.CalcCharToNumber(c) * mult; // CharToNumber

                mult *= 10;
            }
            return n;
        }

    }
}
