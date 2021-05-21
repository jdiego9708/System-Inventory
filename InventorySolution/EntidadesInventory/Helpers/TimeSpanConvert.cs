namespace EntidadesInventory.Helpers
{
    using System;
    using System.Linq;

    public class TimeSpanConvert
    {
        public static TimeSpan StringToTimeSpan(string hora)
        {
            TimeSpan tiempo;

            if (hora.Contains("."))
            {
                int index = hora.IndexOf(".");
                if (index > 0)
                {
                    string horaeditada = hora.Substring(0, index);
                    hora = horaeditada;
                }
            }

            int[] partes = hora.Split(new char[] { ':' }).Select(x => Convert.ToInt32(x)).ToArray();
            if (partes.Length == 2)
            {
                tiempo = new TimeSpan(partes[0], partes[1], 0);
            }
            else
            {
                tiempo = new TimeSpan(partes[0], partes[1], partes[2]);
            }
            return tiempo;
        }

        public static string TimeSpanToString(TimeSpan hora, string format)
        {
            string tiempo;
            DateTime date = new DateTime().Add(hora);
            tiempo = date.ToString(format);

            return tiempo;
        }
    }
}
