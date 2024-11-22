using System.ComponentModel;
using System.Data;

namespace ProyectoEval1
{
    public class Hash
    {
        /// <summary>
        /// Esta función recibe un número como un string.
        /// En caso de contener un null o algo que no sea un número, se devolverá una excepción
        /// </summary>
        /// <param name="s">string</param>
        /// <returns>El número en formato "long"</returns>
        /// <exception cref="Exception"></exception>
        public static long StringToLong(string s)
        {
            if (s == null)
                throw new Exception("No puedes introducir un Null.");
            char c;
            long number = 0;
            long mult = 1;

            for (int i = s.Length -1; i >= 0; i--)
            {
                c = s[i];
                if (i == 0 && c == 45)
                {
                    return -number;
                }

                if (!Validators.IsValidNumberInChar(c))
                    throw new Exception("Has introducido un carácter que NO es un número. Vuelve a intentarlo");

                number += Validators.CharToNumber(c) * mult;

                mult *= 10;
                
            }
            return number;
        }




        /// <summary>
        /// Esta función permite obtener los números primos desde el 11 hasta que tengamos 43 elementos.
        /// El motivo de obtener 40 elementos es que el hash máximo son 43 caracteres, es debido a
        /// que nuestro string máximo permitido serán 50 dígitos, y el mínimo serán 8.
        /// Al insertar un string de 8 caracteres, se utilizará como hash el número primo en la posición 0
        /// Si usamos un string de 50 caracteres, se utilizará el hash de la posición 42.
        /// </summary>
        /// <param name="l">lista vacía de int</param>
        /// <returns>la misma lista con 43 números primos diferentes.</returns>
        public static List<int> GetPrimes(List<int> l)
        {
            if (l == null)
                return l;

            for (int i = 11; l.Count < 51; i++)
                if (IsPrime(i))
                    l.Add(i);
            return l;
        }




        /// <summary>
        /// Saber si un número es primo o no
        /// </summary>
        /// <param name="n">INT (Número a analizar)</param>
        /// <returns>BOOL</returns>
        public static bool IsPrime(int n)
        {
            if (n < 2)
                return false;
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }



        /// <summary>
        /// Creación del Hash de un string.
        /// Genera una lista de números primos, y se hashea con un primo de esa lista.
        /// El cálculo de los valores ASCII del string determina la posición de la lista de primos con la cual se generará la operación
        /// </summary>
        /// <param name="s">STRING</param>
        /// <returns>LONG (Hash)</returns>
        public static long HashString(string s)
        {
            if (s == null)
                return long.MaxValue;
           
            List<int> prime = new List<int>();
            prime = GetPrimes(prime);

            long index = s.Length;


            int IntIndex = AdjustIndex(index);

            
            int HashLetter = 0;
            long hash = 1;
            for (int i = 0; i < s.Length; i++)
            {
                HashLetter += s[i] - 0;
                hash = (hash * prime[IntIndex]) + HashLetter;
                
            }
            return hash;
        }


        /// <summary>
        /// Ajusta el índice de "long" a "int", principalmente para evitar un out of range en la lista.
        /// En caso de obtener un número mayor a 50, se harán unos cálculos para elegir otro y devolver un número óptimo.
        /// </summary>
        /// <param name="i">LONG</param>
        /// <returns>INT</returns>
        private static int AdjustIndex(long i)
        {
            long aux = 0;
            if (i >= int.MaxValue)
            {
                aux = i & int.MaxValue;
                return (int)aux;
            }    
            if (i > 50)
                return (int)i % 10;
            return (int)i;
        }
        
    }
}
