using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FazendaFront
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btIniciar_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro();
            registro.ShowDialog();
        }
    }
}
