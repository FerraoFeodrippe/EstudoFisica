using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstudoFisica.Pontos.Core;
using EstudoFisica.Fisica.Core;
using System.Numerics;
using System.Drawing;
using EstudoFisica.Graficos.Core;

namespace EstudoFisica.Modulos.VelocidadeConstante.PontosLineares
{
    public class MovimentoSuave
    {
        private readonly GerenciadorPontos _gerenciador;
        private int _delay;
        private GerenciadorGrafico _grafico;

        private readonly object __lock;

        public MovimentoSuave(Image image, int delay = 100)
        {
            _delay = delay;
            __lock = new object();
            _gerenciador = new GerenciadorPontos();

            _grafico = new GerenciadorGrafico((Bitmap) image);
        }

        public void AdicionarPonto(Vector2 ponto)
        {
            lock(__lock)
            { 
                _gerenciador.AdicionarPonto(ponto);
            }
            
        }

        public void RemoverPonto(Vector2 ponto)
        {
            lock (__lock)
            {
                _gerenciador.RemoverPonto(ponto);
            }
        }

        public void LimparPontos()
        {
            lock (__lock)
            {
                _gerenciador.LimparPontos();
            }
        }

        public void Start()
        {
        }

        public void Atualizar()
        {
            Desenhar();
        }

        public void Desenhar()
        {
            IList<Vector2> pontos;

            lock (__lock)
            {
                pontos = _gerenciador.PontosAtuais();
                _grafico.DesenharLinhas(pontos.ToArray());
            }

        }

    }
}
