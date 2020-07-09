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
        private Action _updateAction;
        private int _pixelSize;

        private readonly object __lock;

        public GerenciadorGrafico(Bitmap imagem, Action updateAction, Color? corAtual = null , Color? corTransparente = null)
        {
            _imagem = imagem;
            _updateAction = updateAction;
            _corAtual = corAtual == null ? Color.WhiteSmoke : corAtual.Value;
            _corTransparente = corTransparente == null ? Color.Black : corTransparente.Value;
            //_imagem.MakeTransparent(_corTransparente);
            _pixelSize = 1;

            __lock = new object();
        }

        public void MudarCorAtual(Color cor)
        {
            _corAtual = cor;
        }

        public void MudarCorTransparente(Color cor)
        {
            _corTransparente = cor;
        }

        public void Update()
        {
            _updateAction.Invoke();
        }


        public void DesenharLinha(Vector2 p1, Vector2 p2, Color? cor = null)
        {

            Graphics g = Graphics.FromImage(_imagem);
            Brush brush = new SolidBrush((cor == null ? _corAtual : cor.Value));
            Pen pen = new Pen(brush);
            g.DrawLine(pen, p1.X, p1.Y, p2.X, p2.Y);
            g.Save();
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

        public void DesenharCirculo(Vector2 ponto, int radius, Color? cor = null)
        {
            Graphics g = Graphics.FromImage(_imagem);
            Brush brush = new SolidBrush((cor == null ? _corAtual : cor.Value));
            Pen pen = new Pen(brush);
            g.DrawEllipse(pen, ponto.X, ponto.Y, radius, radius);
            g.FillEllipse(brush, ponto.X, ponto.Y, radius, radius);
            g.Save();
        }

        public void RemoverCirculo(Vector2 ponto, int radius)
        {
            Color cor = _corTransparente;
            Graphics g = Graphics.FromImage(_imagem);
            Brush brush = new SolidBrush(cor);
            Pen pen = new Pen(brush);
            g.DrawEllipse(pen, ponto.X, ponto.Y, radius, radius);
            g.FillEllipse(brush, ponto.X, ponto.Y, radius, radius);
        //    g.Clear(_corTransparente);
            g.Save();
        }


    }
}
