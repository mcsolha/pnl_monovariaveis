using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T1_PO2
{
    public partial class FormPrinc : Form
    {
        public FormPrinc()
        {
            InitializeComponent();
        }

        private void metodoChange_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GroupBox item in painelPrin.Panel2.Controls)
            {
                item.Visible = false;
            }
            var radioChecked = radioButtons.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            switch (radioChecked.Text)
            {
                case "Busca Uniforme":
                    buscaUniItens.Visible = true;
                    break;
                case "Busca Dicotômica":
                    buscaDicItens.Visible = true;
                    break;
                case "Seção Áurea":
                    secAureaItens.Visible = true;
                    break;
                case "Busca de Fibonacci":
                    fibItens.Visible = true;
                    break;
                case "Bisseção":
                    bissecItens.Visible = true;
                    break;
                case "Newton":
                    newItens.Visible = true;
                    break;
                default:
                    break;
            }
        }
    }
}
