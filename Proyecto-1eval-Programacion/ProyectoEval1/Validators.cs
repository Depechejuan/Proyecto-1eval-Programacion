using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ProyectoEval1
{
    public class Validators
    {
        /// <summary>
        /// Esta función valida si el fomato de un DNI es el correcto.
        /// Formato deseado: 11111111-B
        /// </summary>
        /// <param name="dni">Insertar DNI</param>
        /// <returns>bool</returns>
        public static bool IsValidDNI(string dni)
        {
            if (dni == null)
                return false;
            if (dni.Length != 10)
                return false;
            if (dni[8] != '-')
                return false;
            if (!IsValidLetter(dni[dni.Length -1]))
                return false;
            char letter = Utils.ToUpper(dni[dni.Length - 1]);

            int DNINumber = 0;
            int mult = 10000000;
            for (int i = 0; i < dni.Length - 1; i++)
            {
                char c = dni[i];
                if (i <= 7)
                {
                    if (!IsValidNumberInChar(c))
                        return false;
                    DNINumber += CharToNumber(c) * mult;
                    mult /= 10;
                }

            }
            return CheckDNI(DNINumber, dni[dni.Length -1]);
        }




        /// <summary>
        /// Esta función comprueba que el número introducido en el DNI y su letra son un DNI real.
        /// </summary>
        /// <param name="dni">INT - Número a operar</param>
        /// <param name="letter">CHAR - Letra del DNI</param>
        /// <returns></returns>
        private static bool CheckDNI(int dni, char letter)
        {
            int module = dni % 23;
            string validLetters = "TRWAGMYFPDXBNJZSQVHLCKE";
            return letter == validLetters[module];
        }



        /// <summary>
        /// Esta función valida si un carácter es válido para un correo electrónico
        /// Permite todas las letras de la A a la Z en Mayúsculas y minúsculas. Números 0-9, el símbolo "." y el símbolo "@"
        /// </summary>
        /// <param name="c">Char</param>
        /// <returns>bool</returns>
        public static bool IsValidCharEmail(char c)
        {
            if (c == '.' || c == '_' || c == '-' || c == '+')
                return true;
            if (c == '@')
                return true;
            if ('0' <= c && c <= '9')
                return true;
            if ('A' <= c && c <= 'Z')
                return true;
            if ('a' <= c && c <= 'z')
                return true;
            return false;
        }




        /// <summary>
        /// Valida si el CHAR es un valor numérico.
        /// </summary>
        /// <param name="c">char</param>
        /// <returns>bool</returns>
        public static bool IsValidNumberInChar(char c)
        {
            return '0' <= c && c <= '9';
        }




        /// <summary>
        /// Confirma si el caracter que se introduce es mayuscula o minuscula.
        /// </summary>
        /// <param name="c">char</param>
        /// <returns>bool</returns>
        public static bool IsCapitalLetter(char c)
        {
            return 'A' <= c && c <= 'Z';
        }

        /// <summary>
        /// Confirma si el caracter que se introduce es válido.
        /// </summary>
        /// <param name="c">char</param>
        /// <returns>bool</returns>
        public static bool IsValidLetter(char c)
        {
            return ('A' <= c && c <= 'Z') || ('a' <= c && c <= 'z');
        }




        /// <summary>
        /// Esta función calcula el valor numérico del "char". El char 48 es el número 0.
        /// </summary>
        /// <param name="c">Char</param>
        /// <returns>int</returns>
        public static int CharToNumber(char c)
        {
            return c - '0';
        }





        /// <summary>
        /// Esta función cuenta cuántas @ existen en el string.
        /// </summary>
        /// <param name="email">string</param>
        /// <returns>int</returns>
        private static int CountAt(string email)
        {
            if (email == null)
                return -1;
            int count = 0;
            for (int i = 0; i < email.Length; i++)
            {
                if (email[i] == '@')
                    count++;
            }
            return count;
        }




        /// <summary>
        /// Esta función busca el carácter '@' en el email, y devuelve su posición
        /// </summary>
        /// <param name="email">string</param>
        /// <returns>int</returns>
        private static int FindIndexOfAt(string email)
        {
            for (int i = 0; i < email.Length; i++)
            {
                if (email[i] == '@')
                    return i;
            }
            return -1;
        }



        /// <summary>
        /// Función para validar email.
        /// Validación == letras@dominio.es
        /// </summary>
        /// <param name="email">string</param>
        /// <returns>bool</returns>
        public static bool IsValidEmail(string email)
        {
            if (email == null || email == "")
                return false;
            int length = email.Length;

            if (email[0] == '.' || email[email.Length -1] == '.')
                return false;

            if (CountAt(email) != 1)
                return false;

            int IndexOfAt = FindIndexOfAt(email);

            if (IndexOfAt == 0 || IndexOfAt == email.Length)
                return false;

            if (IndexOfAt < 1 || email.Length - IndexOfAt <= 5)
                return false;

            if (email[IndexOfAt - 1] == '.' || email[IndexOfAt + 1] == '.')
                return false;


            int IndexDot = 0;
            bool FoundAt = false;
            bool FoundDomain = false;
            for (int i = 0; i < email.Length; i++)
            {
                if (!IsValidCharEmail(email[i]))
                    return false;

                if (i == IndexOfAt)
                {
                    FoundAt = true;
                    continue;
                }

                if (email[i] == '.' && email[i + 1] == '.')
                    return false;

                if (FoundAt && !FoundDomain)
                {
                    if (i >= IndexOfAt + 2 && email[i] == '.')
                    {
                        FoundDomain = true;
                        IndexDot = i;
                        continue;
                    }
                }

                if (FoundDomain)
                {
                    if (email.Length - IndexDot <= 2)
                        return false;
                }
            }

            return true;
        }
    }
}
