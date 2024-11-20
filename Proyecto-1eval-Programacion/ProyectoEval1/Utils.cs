
using static System.Runtime.InteropServices.JavaScript.JSType;

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

                bool capital = Validators.IsCapitalLetter(c);
                bool symbol = !(Validators.IsValidLetter(c));
                if (symbol)
                {
                    s += (char)(c);
                    continue;
                }
                if (cap)
                {
                    if (capital)
                    {
                        s += (char)(c);
                        continue;
                    }
                    s += (char)(c - 32);
                }
                if (!cap)
                {
                    if (!capital)
                    {
                        s += (char)(c);
                        continue;
                    }
                    s += (char)(c + 32);
                }
            }
            return s;
        }


        public static int StringToInt(string s)
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

                n += Validators.CalcCharToNumber(c) * mult;

                mult *= 10;
            }
            return n;
        }

    }
}
