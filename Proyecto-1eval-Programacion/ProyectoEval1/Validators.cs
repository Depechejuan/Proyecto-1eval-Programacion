﻿using System.ComponentModel;
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
            if (dni.Length < 10 || dni.Length > 10)
                return false;

            for (int i = 0; i < dni.Length - 1; i++)
            {
                char c;
                c = dni[i];
                if (i <= 7)
                {
                    if (!IsValidNumberInChar(c))
                        return false;
                }

                if (i == 8)
                {
                    if (c != 45)
                        return false;
                }

                if (i == 9)
                {
                    if (!IsValidLetter(c))
                        return false;
                }
            }
            return true;
        }


        /// <summary>
        /// Esta función valida si un carácter es válido para un correo electrónico
        /// Permite todas las letras de la A a la Z en Mayúsculas y minúsculas. Números 0-9, el símbolo "." y el símbolo "@"
        /// </summary>
        /// <param name="c">Char</param>
        /// <returns>bool</returns>
        public static bool IsValidCharEmail(char c)
        {
            if (c == 46)
                return true;
            if (c >= 48 && c <= 57)
                return true;
            if (c >= 64 && c <= 90)
                return true;
            if (c >= 97 && c <= 122)
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
            if (c >= 48 && c <= 57)
                return true;
            return false;
        }

        /// <summary>
        /// Confirma si el caracter que se introduce es mayuscula o minuscula.
        /// </summary>
        /// <param name="c">char</param>
        /// <returns>bool</returns>
        public static bool IsCapitalLetter(char c)
        {
            if (c >= 65 && c <= 90)
                return true;
            return false;
        }


        public static bool IsValidLetter(char c)
        {
            if ((c >= 65 && c <= 90) || (c >= 97 && c <= 122))
                return true;
            return false;
        }

        /// <summary>
        /// Esta función calcula el valor numérico del "char". El char 48 es el número 0.
        /// </summary>
        /// <param name="c">Char</param>
        /// <returns>int</returns>
        public static int CalcCharToNumber(char c)
        {
            return c - 48;
        }


        /// <summary>
        /// Esta función cuenta cuántas @ existen en el string.
        /// </summary>
        /// <param name="email">string</param>
        /// <returns>int</returns>
        private static int CountAt(string email)
        {
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
            if (email == null)
                return false;
            int length = email.Length;

            if (email[0] == '.' || email[email.Length -1] == '.')
                return false;

            if (CountAt(email) != 1)
                return false;

            int IndexOfAt = FindIndexOfAt(email);
            // Se utiliza email.Length - 5
            // Desde el @, al menos debería de contener 2 dígitos del dominio, más 1 dígito de punto,
            // más 2 dígitos del país.
            if (IndexOfAt < 1 || IndexOfAt > email.Length - 5)
                return false;

            int IndexDot = 0;
            bool FindArroba = false;
            bool FindDomain = false;
            for (int i = 0; i < email.Length; i++)
            {
                if (!IsValidCharEmail(email[i]))
                    return false;

                if (i == IndexOfAt)
                {
                    FindArroba = true;
                    continue;
                }

                // Despues de encontrar el @, localizar el punto. Si su distancia es de 1 carácter entre medias, FALSE
                if (FindArroba && !FindDomain)
                {
                    if (i >= IndexOfAt + 2 && email[i] == '.')
                    {
                        FindDomain = true;
                        IndexDot = i;
                    }
                }

                if (FindDomain)
                {
                    if (email.Length - IndexDot > 2) // ¿Comprobar si hay dos puntos seguidos?
                        return true;
                }
            }

            return true;
        }
    }
}
