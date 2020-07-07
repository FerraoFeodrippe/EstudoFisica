using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EstudoFisica.Graficos.Core
{
    public class GerenciadorGrafico
    {
        private readonly Bitmap _imagem;
        private Color _corAtual;
        private Color _corTransparente;
        private Action<Region> _updateAction;
        private Region _region;

        private int _pixelSize;

        public GerenciadorGrafico(Bitmap imagem, Action<Region> updateAction, Color? corAtual = null , Color? corTransparente = null)
        {
            _imagem = imagem;
            _updateAction = updateAction;
            _region = new Region();
            _corAtual = corAtual == null ? Color.WhiteSmoke : corAtual.Value;
            _corTransparente = corTransparente == null ? Color.Black : corTransparente.Value;
            _imagem.MakeTransparent(_corTransparente);

            _pixelSize = 1;
        }

        public void MudarCorAtual(Color cor)
        {
            _corAtual = cor;
        }

        public void MudarCorTransparente(Color cor)
        {
            _corTransparente = cor;
        }

        public void DesenharPixel(Vector2 p, Color? cor = null)
        {
            DesenharPixel((int) p.X, (int) p.Y, cor);
        }

        public void DesenharPixel(int x, int y, Color? cor = null)
        {
            if (x >= 0 && y >=0 && x < _imagem.Width && y < _imagem.Height)
            {
                _imagem.SetPixel(x, y, cor == null? _corAtual : cor.Value);
                _region.Union(new Region(new Rectangle(x, y, 1, 1) ));
            }

        }
        public void Update()
        {
            _updateAction.Invoke(_region);
        }

        public void RemoverPixel(Vector2 p)
        {
            RemoverPixel((int)p.X, (int)p.Y);
        }

        public void RemoverPixel(int x, int y)
        {
            DesenharPixel(x, y, _corTransparente);
        }

        public void DesenharLinha(Vector2 p1, Vector2 p2, Color? cor = null)
        {
            DesenharLinha((int)p1.X, (int)p1.Y, (int)p2.X, (int)p2.Y, cor);
        }

        public void DesenharLinha(int x1, int y1, int x2, int y2, Color? cor = null)
        {
            if (x2 == x1 && y2 == y1) return;


            int x, y;

            int minX = Math.Min(x1, x2);
            int maxX = Math.Max(x1, x2);

            int minY = Math.Min(y1, y2);
            int maxY = Math.Max(y1, y2);

            float a = (x2 - x1) != 0 ? (y2 - y1)*1f / (x2 - x1)*1f : 0f;

            if (maxY - minY > maxX - minX)
            {
                for (y = minY; y <= maxY; y++)
                {
                    if (a != 0)
                    {
                        x = (int) ((y - y1)/a + x1);
                    }
                    else
                    {
                        x = x1;
                    }
                    
                    DesenharPixel(x, y, cor);
                }
            }
            else
            {
                for (x = minX; x <= maxX; x++)
                {
                    y = (int)((x - x1) * a + y1);

                    DesenharPixel(x, y, cor);
                }
            }

        }

        public void DesenharLinhas(Vector2[] pontos, Color? cor = null)
        {
            if (pontos.Length > 1)
            {
                Vector2 p1;
                Vector2 p2;

                for (int i= 1; i < pontos.Length; i++)
                {
                    p1 = pontos[i-1];
                    p2 = pontos[i];

                    DesenharLinha(p1, p2, cor);
                }

            }
        }

    }
}
