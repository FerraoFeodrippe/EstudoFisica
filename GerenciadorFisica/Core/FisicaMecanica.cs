using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoFisica.Fisica.Core
{
    public static class FisicaMecanica
    {
        public static float VelocidadeMediaPorEspacoTempo(float espacoFinal, float tempoFinal, float espacoInicial = 0, float tempoInicial = 0)
        {
            return Divisao(espacoFinal - espacoInicial, tempoFinal - tempoInicial);
        }

        public static float AceleracaoMediaPorEspacoTempo(float espacoFinal, float tempoFinal, float espacoInicial = 0, float tempoInicial = 0)
        {
            return Divisao(VelocidadeMediaPorEspacoTempo(espacoFinal, tempoFinal, espacoInicial, tempoInicial), tempoFinal - tempoInicial);
        }

        public static float EspacoPorVelocidadeTempo(float velocidadeFinal, float tempoFinal,
            float velocidadeInicial = 0, float tempoInicial = 0)
        {
            return (velocidadeFinal - velocidadeInicial) * (tempoFinal - tempoInicial);
        }

        public static float VelocidadeFinalPorTorricelli(float aceleracaoMedia, float espacoFinal, 
            float espacoInicial = 0, float velocidadeInicial = 0)
        {
            return (float) Math.Sqrt(Math.Pow(velocidadeInicial, 2) + 2 * aceleracaoMedia * (espacoFinal - espacoInicial));
        }

        private static float Divisao(float n1, float n2)
        {
            if (n2 == 0) return 0;

            return n1 / n2;
        }

    }
}
