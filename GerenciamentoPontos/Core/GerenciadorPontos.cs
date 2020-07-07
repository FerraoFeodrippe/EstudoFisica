using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EstudoFisica.Pontos.Core
{
    public class GerenciadorPontos
    {
        private int _conjuntoAtual;
        private IList<Vector2> _pontosAtuais;
        private readonly IDictionary<int, IList<Vector2>> _conjuntoPontos;

        public GerenciadorPontos()
        {
            _conjuntoAtual = 0;
            _conjuntoPontos = new Dictionary<int, IList<Vector2>>();
            MudarConjunto(_conjuntoAtual);
        }

        public int ConjuntoAtual { get { return _conjuntoAtual; } private set { } }

        public IEnumerable<int> ConjuntosAtuais()
        { 
            foreach(var conjunto in _conjuntoPontos)
            {
                yield return conjunto.Key;
            }
        }

        public IEnumerable<IList<Vector2>> TodosPontos()
        {
            foreach (var conjunto in _conjuntoPontos)
            {
                yield return new List<Vector2>(conjunto.Value);
            }
        }

        public IList<Vector2> PontosAtuais()
        {
            return new List<Vector2>(_pontosAtuais);
        }

        public void MudarConjunto(int conjunto)
        {
            _conjuntoAtual = conjunto;

            if (_conjuntoPontos.ContainsKey(_conjuntoAtual))
            {
                _pontosAtuais = _conjuntoPontos[_conjuntoAtual];
            }
            else
            {
                _pontosAtuais = new List<Vector2>();
            }

        }

        public void AdicionarPonto(Vector2 ponto)
        {
            _pontosAtuais.Add(ponto);

            if (!_conjuntoPontos.ContainsKey(_conjuntoAtual))
            {
                _conjuntoPontos[_conjuntoAtual] = _pontosAtuais;
            }
        }

        public void AdicionarPontos(IEnumerable<Vector2> pontos)
        {
            foreach (Vector2 ponto in pontos)
            {
                AdicionarPonto(ponto);
            }
        }

        public void RemoverPonto(Vector2 ponto)
        {
            _pontosAtuais.Remove(ponto);

            if (_conjuntoPontos.ContainsKey(_conjuntoAtual) && !_pontosAtuais.Any())
            {
                _conjuntoPontos.Remove(_conjuntoAtual);
            }
        }

        public void RemoverPontos(IEnumerable<Vector2> pontos)
        {
            foreach (Vector2 ponto in pontos)
            {
                RemoverPonto(ponto);
            }
        }

        public void LimparPontos()
        {
            _pontosAtuais.Clear();

            if (_conjuntoPontos.ContainsKey(_conjuntoAtual))
            {
                _conjuntoPontos.Remove(_conjuntoAtual);
            }
        }

        public float DistanciaTotalConjuntoPontos(int conjunto)
        {
            float distancia = 0;

            if (_conjuntoPontos.ContainsKey(conjunto) && _conjuntoPontos[conjunto].Count > 1)
            {
                var pontos = _conjuntoPontos[conjunto];

                Vector2 p1 = _pontosAtuais.First();

                for (int i = 1; i < _pontosAtuais.Count; i++)
                {
                    Vector2 p2 = pontos[i];

                    distancia += DistanciaPontos(p1, p2);

                    p1 = p2;
                }
            }
            return distancia;
        }

        public float DistanciaMediaConjuntoPontos(int conjunto)
        {
            float media = 0;

            if (_conjuntoPontos.ContainsKey(conjunto) && _conjuntoPontos[conjunto].Count > 1)
            {
                media = DistanciaTotalConjuntoPontos(conjunto) / _conjuntoPontos[conjunto].Count;
            }

            return media;
        }

        public float DistanciaPontos(Vector2 p1, Vector2 p2)
        {
            return Vector2.Distance(p1, p2);
        }
    }
}
