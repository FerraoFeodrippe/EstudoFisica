using EstudoFisica.Modulos.VelocidadeConstante.PontosLineares;
using EstudoFisica.Pontos.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UPrincipal
{
    public partial class UPrincialForm : Form
    {
        private readonly MovimentoSuave _modulo;

        public UPrincialForm()
        {
            InitializeComponent();
            Visor.Image = new Bitmap(Visor.Width, Visor.Height);
            _modulo = new MovimentoSuave(Visor.Image, 1);
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UPrincialForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {

            }
        }

        private void Visor_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && (ModifierKeys & Keys.Control) != Keys.Control)
            {
                _modulo.AdicionarPonto(new Vector2(e.X, e.Y));
                _modulo.Atualizar();
                Visor.Invoke(new Action(() => { Visor.Refresh(); }));
            }
        }

        private void Visor_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left && (ModifierKeys & Keys.Control) == Keys.Control)
            {
                _modulo.AdicionarPonto(new Vector2(e.X, e.Y));
                _modulo.Atualizar();
                Visor.Invoke(new Action(() => { Visor.Refresh(); }));
            }
        }
    }
}
