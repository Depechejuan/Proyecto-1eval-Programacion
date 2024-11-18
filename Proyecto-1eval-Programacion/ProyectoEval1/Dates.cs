namespace ProyectoEval1
{
    internal class Dates
    {
        /// <summary>
        /// Esta función calcula si un año es bisiesto o no. 
        /// Los años bisiestos deben cumplir estos 3 requisitos:
        /// 1.- Ser divisibles entre 4
        /// 2.- No ser divisibles entre 100
        /// 3.- Ser divisibles entre 400
        /// </summary>
        /// <param name="year">Año (previamente controlado)</param>
        /// <returns>bool</returns>
        private static bool IsLeapYear(int year)
        {
            if (year % 4 == 0)
            {
                if (year % 100 == 0 && year % 400 == 0)
                    return true;
                if (year % 100 == 0)
                    return false;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Esta función confirma si la fecha introducida es válida o no, revisando que los datos introducidos estén en los valores esperados.
        /// Además, añade comprobaciones a los meses de 29/30/31 días, años bisiestos etc.
        /// </summary>
        /// <param name="year">año(0-9999)</param>
        /// <param name="month">mes(1-12)</param>
        /// <param name="day">dia(1-31)</param>
        /// <param name="hour">hora(0-23)</param>
        /// <param name="minute">minuto(0-59)</param>
        /// <param name="second">segundo (0-59)</param>
        /// <returns>bool</returns>
        private static bool IsValidDate(int year, int month, int day, int hour, int minute, int second)
        {
            if (year < 0 || year > 9999)
                return false;
            if (month < 1 || month > 12)
                return false;
            if (day < 1 || day > 31)
                return false;
            if (hour < 0 || hour > 23)
                return false;
            if (minute < 0 || minute > 59)
                return false;
            if (second < 0 || second > 59)
                return false;
            if (month == 2 && day > 29)
                return false;

            if ((month == 2 || month == 4 || month == 6 || month == 9 || month == 11) && day > 30)
                return false;

            if (month == 2 && day == 29)
            {
                if (!IsLeapYear(year))
                    return false;
            }

            return true;
        }
        /// <summary>
        /// Convierte una fecha a un string
        /// </summary>
        /// <param name="year">año(0-9999)</param>
        /// <param name="month">mes(1-12)</param>
        /// <param name="day">dia(1-31)</param>
        /// <param name="hour">hora(0-23)</param>
        /// <param name="minute">minuto(0-59)</param>
        /// <param name="second">segundo (0-59)</param>
        /// <returns>string</returns>
        public static string ConvertDateToString(int year, int month, int day, int hour, int minute, int second)
        {
            if (!IsValidDate(year, month, day, hour, minute, second))
                return "El formato de fecha introducido no es correcto. Revisa si los valores introducidos son correctos, y si podría existir la fecha introducida";
            return $"{year}/{month}/{day} - {hour}:{minute}:{second}";
        }
    }
}
