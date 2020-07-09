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
using EstudoFisica.Fisica;

namespace EstudoFisica.Modulos.VelocidadeConstante.PontosLineares
{
    public class MovimentoSuave
    {
        private readonly GerenciadorPontos _gerenciador;
        private int _delay;
        private GerenciadorGrafico _grafico;
        private int _conjuntoCaminho;
        private int _conjuntoObjeto;
        private int _raioObjeto;
        private int _pontoAtual;
        private Vector2 _posicaoObjetoAnterior;
        private Vector2 _posicaoObjetoAtual;
        private int _unidadeAtual;

        private readonly object __lock;

        public MovimentoSuave(Image image, Action updateAction, int delay = 100)
        {
            _conjuntoCaminho = 0;
            _conjuntoObjeto = 1;
            _raioObjeto = 10;
            _pontoAtual = -1;
            _unidadeAtual = 5;
            _posicaoObjetoAtual = Vector2.Zero;
            _posicaoObjetoAnterior = Vector2.Zero;
            _delay = delay;
            __lock = new object();
            _gerenciador = new GerenciadorPontos();
            
            _grafico = new GerenciadorGrafico((Bitmap) image, updateAction);
        }

        public void AdicionarPonto(Vector2 ponto)
        {
            lock(__lock)
            {
                Console.WriteLine(ponto);
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
            Task.Run(ProximaPosicao);

        }

        private async void ProximaPosicao()
        {
            IList<Vector2> pontos;

            lock (__lock)
            {
               pontos = _gerenciador.PontosAtuais();
            }

            if (_pontoAtual == -1 && pontos.Any())
            {
                _pontoAtual = 0;
                _posicaoObjetoAtual = pontos[0];
            }

            while (pontos.Count > _pontoAtual)
            {
                lock (__lock)
                {
                    if (pontos.Count > 1)
                    {
                        MoverObjeto();
                    }
                }
                    await Task.Delay(_delay);
            }

            _grafico.RemoverCirculo(_posicaoObjetoAnterior, _raioObjeto);
            _grafico.RemoverCirculo(_posicaoObjetoAtual, _raioObjeto);
            Desenhar();

            _posicaoObjetoAtual = Vector2.Zero;
            _posicaoObjetoAnterior = _posicaoObjetoAtual;
            _pontoAtual = -1;
        }

        private void MoverObjeto()
        {

            lock (__lock)
            {

                var pontos = _gerenciador.PontosAtuais();

                if (pontos.Count > _pontoAtual)
                {

                    var pontoAtual = pontos[_pontoAtual];
                    _posicaoObjetoAnterior = _posicaoObjetoAtual;

                    if (pontos.Count > _pontoAtual + 1)
                    {
                        var proximoPonto = pontos[_pontoAtual + 1];

                        var dif = proximoPonto - pontoAtual;

                        var fator = Math.Abs(dif.X) >= Math.Abs(dif.Y ) ? 
                            ((proximoPonto.X - pontoAtual.X) >= 0 ? 1 : -1) : ((proximoPonto.Y - pontoAtual.Y)  >= 0 ? 1 : -1);

                        var a = dif.X != 0 ? (dif.Y/dif.X) : 0;

                        var p = Math.Abs(dif.X) >= Math.Abs(dif.Y) ?
                            CalculaFx(_posicaoObjetoAtual.X + _unidadeAtual * fator, pontoAtual.X, pontoAtual.Y, a):
                            CalculaFy(_posicaoObjetoAtual.Y + _unidadeAtual * fator, pontoAtual.Y, pontoAtual.X, a);

                        _posicaoObjetoAtual = p;

                        Console.WriteLine(p);

                        if (Math.Abs(dif.X) >= Math.Abs(dif.Y)  && (_posicaoObjetoAtual.X >= proximoPonto.X && fator > 0 || _posicaoObjetoAtual.X <= proximoPonto.X && fator < 0))
                        {
                            _pontoAtual++;
                        }

                        if (Math.Abs(dif.X) < Math.Abs(dif.Y) && (_posicaoObjetoAtual.Y >= proximoPonto.Y && fator > 0 || _posicaoObjetoAtual.Y <= proximoPonto.Y && fator < 0))
                        {
                            _pontoAtual++;
                        }

                        if (_posicaoObjetoAnterior != _posicaoObjetoAtual)
                        {
                            _grafico.RemoverCirculo(_posicaoObjetoAnterior, _raioObjeto);
                            Desenhar();
                        }

                        _grafico.DesenharCirculo(_posicaoObjetoAtual, _raioObjeto, Color.BlueViolet);
                        _grafico.Update();
                    }
                    else
                    {
                        _posicaoObjetoAtual = pontoAtual;
                        _pontoAtual++;
                    }


                }
            }
        }

        private Vector2 CalculaFx(float x, float x1, float y1, float a)
        {
            return new Vector2(x, (x - x1) * a + y1);
        }

        private Vector2 CalculaFy(float y, float y1, float x1, float a)
        {
            if (a == 0) return new Vector2(x1, y);
            return new Vector2((y - y1) / a + x1, y);
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
                DesenharCaminho(pontos);
                _grafico.Update();
            }

        }

        private void DesenharCaminho(IList<Vector2> pontos)
        {
            _grafico.DesenharLinhas(pontos.ToArray());
        }
    }
}
