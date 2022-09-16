using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KuralTabanliVarlikIsmiTanimaProgrami
{
    public partial class FormAna : Form
    {
        public FormAna()
        {
            InitializeComponent();
        }

        public static Boolean panelDurum = false;
        public string metin;

        KayitSinif kayitFormAna = new KayitSinif();
        SozlukSinif sozlukFormAna = new SozlukSinif();
        TemelSinif temelFormAna = new TemelSinif();

        private void panelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panelDurum == false)
            {
                panelAna.Visible = true;
                progressBarAna.Visible = true;
                analizEtToolStripMenuItem.Enabled = false;
                kaydetToolStripMenuItem.Enabled = false;
                progressBarAna.Value = 50;
                panelDurum = true;
            }
            else
            {
                panelAna.Visible = false;
                progressBarAna.Visible = false;
                analizEtToolStripMenuItem.Enabled = true;
                kaydetToolStripMenuItem.Enabled = true;
                panelDurum = false;
            }
        }

        private void FormAna_Load(object sender, EventArgs e)
        {
            sozlukFormAna.SozlukleriAl();
        }

        private void FormAna_Resize(object sender, EventArgs e)
        {
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kayitFormAna.Kaydet(richTextBoxAna.Text);
        }

        private void analizEtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            temelFormAna.MetinParcala(richTextBoxAna.Text.ToString());

        }

        //deneme için bu olay var.
        private void metinBolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TemelSinif temel = new TemelSinif();
            temel.MetinParcala(richTextBoxAna.Text);
        }
    }
}
