
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
                bool valid = Validators.IsValidLetter(c);
                if (!valid)
                    throw new Exception("Hay un carácter no válido, inserta sólo letras y sin tildes u otros símbolos");

                bool capital = Validators.IsCapitalLetter(c);
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



    }
}
