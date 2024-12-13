
namespace ProyectoEval1
{
    internal class Utils
    {
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
            if (s == null || s == "")
                return "No se puede cambiar un string vacío o NULL"; // NUNCA HAGAS ESTO
            string aux = s;
            s = "";
            for (int i = 0; i < aux.Length; i++)
            {
                char c = aux[i];
                bool symbol = !(Validators.IsValidLetter(c));

                if (symbol)
                {
                    s += (char)(c);
                    continue; // NO
                } // ELSE IF

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



        /// <summary>
        /// Función dedicada a convertir un carácter (Letra del abecedario) a minúscula
        /// </summary>
        /// <param name="c">Char</param>
        /// <returns>Char modificado si cumple las condiciones, o el mismo char sin modificar.</returns>
        public static char ToLower(char c)
        {
            if (Validators.IsCapitalLetter(c))
                return (char)(c + 32);
            return c;
        }




        /// <summary>
        /// Función dedicada a convertir un carácter (Letra del abecedario) a mayúscula
        /// </summary>
        /// <param name="c">Char</param>
        /// <returns>Char modificado si cumple las condiciones, o el mismo char sin modificar.</returns>
        public static char ToUpper(char c)
        {
            if (Validators.IsCapitalLetter(c))
                return c;
            return (char)(c - 32);
        }





        /// <summary>
        /// Convierte un String a números INT
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static int StringToInt(string s) // to int
        {
            if (s == null)
                return int.MinValue;

            int n = 0;
            int mult = 1;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                char c = s[i];

                if (!Validators.IsValidNumberInChar(c))
                    return int.MinValue;

                n += Validators.CharToNumber(c) * mult;

                mult *= 10;
            }
            return n;
        }

    }
}
