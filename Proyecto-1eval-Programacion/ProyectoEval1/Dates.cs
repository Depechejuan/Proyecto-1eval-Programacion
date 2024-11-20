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


        /// <summary>
        /// Esta función separa a varios INT una cadena de texto con un formato determinado 
        /// </summary>
        /// <param name="date">fecha en STRING siguiendo el formato "YYYY/MM/DD - hh:mm:ss"</param>
        /// <returns>int year, int month, int day, int hour, int minute, int second</returns>
        /// <exception cref="Exception"></exception>
        public static (int, int, int, int, int, int) ConvertStringToDate(string date)
        {
            if (date == null)
                return (int.MinValue, int.MinValue, int.MinValue, int.MinValue, int.MinValue, int.MinValue)

            string d = "";

            int year = GetYearFromDateString(date);
            int month = GetMonthFromDateString(date);
            int day = GetDayFromDateString(date);
            int hour = GetHourFromDateString(date);
            int minute = GetMinuteFromDateString(date);
            int second = GetSecondFromDateString(date);

            return (year, month, day, hour, minute, second);
        }

        private static int GetYearFromDateString(string date)
        {
            string YearString = "";
            for (int i = 0; i < date.Length; i++)
            {
                if (date[i] != '/' && Validators.IsValidNumberInChar(date[i]))
                    YearString += date[i];
                else
                    break;
            }

            int year = Utils.StringToInt(YearString);
            if (year < 0 || year > 9999)
                return int.MinValue;
            return year;
        }

        private static int GetMonthFromDateString(string date)
        {
            string MonthDate = "";
            int find = 0;
            for (int i = 0; i < date.Length; i++)
            {
                if (date[i] == '/')
                {
                    find ++;
                }

                if (find > 0 && find < 2 && Validators.IsValidNumberInChar(date[i]))
                {
                    MonthDate += date[i];
                }

                if (find == 2)
                    break;
            }
            int month = Utils.StringToInt(MonthDate);
            if (month < 0 || month > 12)
                return int.MinValue;

            return month;
        }

        private static int GetDayFromDateString(string date)
        {
            string DayDate = "";
            int slash = 0;

            for (int i = 0; i < date.Length; i++)
            {
                if (date[i] == '/')
                {
                    slash++;
                    continue;
                }
                if (slash > 1 && !(Validators.IsValidNumberInChar(date[i])))
                    break;
                if (slash > 1 && slash < 3 && Validators.IsValidNumberInChar(date[i]))
                    DayDate += date[i];
            }
            int day = Utils.StringToInt(DayDate);
            if (day < 0 || day > 31)
                return int.MinValue;

            return day;
        }

        private static int GetHourFromDateString(string date)
        {
            string HourDate = "";
            int count = 0;
            for (int i = 0; i < date.Length; i++)
            {
                if (date[i] == ' ')
                {
                    count++;
                    continue;
                }
                    
                if (count > 1 && Validators.IsValidNumberInChar(date[i]))
                    HourDate += date[i];

                if (date[i] == ':')
                    break;
            }
            
            int hour = Utils.StringToInt(HourDate);
            if (hour < 0 || hour > 23)
                return int.MinValue;

            return hour;
        }

        private static int GetMinuteFromDateString(string date)
        {
            string MinuteDate = "";
            bool find = false;
            for (int i = 0; i < date.Length; i++)
            {
                if (find && date[i] == ':')
                    break;
                if (date[i] == ':')
                    find = true;
                if (find && Validators.IsValidNumberInChar(date[i]))
                    MinuteDate += date[i];
            }
            int minute = Utils.StringToInt(MinuteDate);
            if (minute < 0 || minute > 59)
                return int.MinValue;

            return minute;
        }

        private static int GetSecondFromDateString(string date)
        {
            string SecondDate = "";
            int count = 0;
            for (int i = 0; i < date.Length; i++)
            {
                if (date[i] == ':')
                {
                    count++;
                    continue;
                }

                if (count > 1 && count < 3)
                    SecondDate += date[i];
            }
            int second = Utils.StringToInt(SecondDate);
            if (second < 0 || second > 59)
                return int.MinValue;

            return second;
        }

    }
}
