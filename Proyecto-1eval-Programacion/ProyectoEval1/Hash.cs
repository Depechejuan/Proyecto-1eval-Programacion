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

                number += Validators.CalcCharToNumber(c) * mult;

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

            for (int i = 11; l.Count < 43; i++)
                if (IsPrime(i))
                    l.Add(i);
            return l;
        }

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


        public static long HashString(string s)
        {
            if (s == null)
                throw new Exception("No se puede hashear un Null");

            if (s.Length < 8 && s.Length > 40)
                throw new Exception("Para hashear necesitas al menos 8 caracteres o menos de 20");

            List<int> prime = new List<int>();
            prime = GetPrimes(prime);

            // Coger, segun el valor del string, una posición de número primo.
            //int IndexPrime = GetIndexPrime(s, prime);

            long index = s.Length;
            int IntIndex = (int)index;

            int HashLetter = 0;
            long hash = 1;
            for (int i = 0; i < s.Length; i++)
            {
                HashLetter += s[i] - 0;
                hash = (hash * prime[IntIndex]) + HashLetter;
                hash %= prime[IntIndex]* prime[IntIndex];
            }
            return hash;
        }


        
    }
}
