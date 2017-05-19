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

        private void button_Click(object sender, EventArgs e)
        {
            var radioChecked = radioButtons.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            switch (radioChecked.Text)
            {
                case "Busca Uniforme":
                    BuscaUniforme buscUni = new BuscaUniforme();
                    buscUni.dados.a = Convert.ToDouble(aTextBox.Text);
                    buscUni.dados.b = Convert.ToDouble(bTextBox.Text);
                    buscUni.dados.delta = Convert.ToDouble(deltaTextBox.Text);
                    buscUni.dados.func = funcTextBox.Text;
                    xotimoTextBox.Text = buscUni.Calcular().ToString();
                    break;
                case "Busca Dicotômica":
                    BuscaDic buscDic = new BuscaDic();
                    buscDic.infos.a = Convert.ToDouble(aDicTextBox.Text);
                    buscDic.infos.b = Convert.ToDouble(bDicTextBox.Text);
                    buscDic.infos.l = Convert.ToDouble(lTextBox.Text);
                    buscDic.infos.e = Convert.ToDouble(episTextBox.Text);
                    buscDic.infos.func = funcDicTextBox.Text;
                    xotimoDicTextBox.Text = buscDic.Calcular().ToString();
                    break;
                case "Seção Áurea":
                    SecAurea secAurea = new SecAurea();
                    secAurea.infos.a = Convert.ToDouble(aAureaTextBox.Text);
                    secAurea.infos.b = Convert.ToDouble(bAureaTextBox.Text);
                    secAurea.infos.l = Convert.ToDouble(lAureaTextBox.Text);
                    secAurea.infos.func = funcAureaTextBox.Text;
                    xotimoAureaTextBox.Text = secAurea.Calcular().ToString();
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
