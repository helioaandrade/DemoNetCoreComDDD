using System;

namespace InfraTest
{
    public static class Util
    {
        public static int Gerar_Numero_Aleatorio(int min = 500, int max = 3000)
        {
            Random r = new Random();
            var random = r.Next(min, max);

            return random;
        }
    }
}
