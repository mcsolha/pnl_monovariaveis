using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T1_PO2
{
    public partial class FormPrinc : Form
    {
        //new DadosEventData() { Type = this.GetType().Name }
        string[] lastDataPath = new string[6];

        event EventHandler<Type> FinishWriting;

        void OnFinishWriting(Type type)
        {
            FinishWriting?.Invoke(this, type);
        }

        public void WriteFile(string log, Type type)
        {
            string actualPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            
            var @switch = new Dictionary<Type, Action>()
                {
                    {typeof(BuscaUniforme),() => actualPath = lastDataPath[0] = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\" + type.Name + "_" + DateTime.Now.ToString(@"MM\_dd\_yyyy_h\_mm_ss") + ".txt" },
                    {typeof(BuscaDic),() => actualPath = lastDataPath[1] = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\" + type.Name + "_" + DateTime.Now.ToString(@"MM\_dd\_yyyy_h\_mm_ss") + ".txt" },
                    {typeof(SecAurea),() => actualPath = lastDataPath[2] = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\" + type.Name + "_" + DateTime.Now.ToString(@"MM\_dd\_yyyy_h\_mm_ss") + ".txt" },
                    {typeof(Fibonacci),() => actualPath = lastDataPath[3] = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\" + type.Name + "_" + DateTime.Now.ToString(@"MM\_dd\_yyyy_h\_mm_ss") + ".txt" },
                    {typeof(Bissecao),() => actualPath = lastDataPath[4] = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\" + type.Name + "_" + DateTime.Now.ToString(@"MM\_dd\_yyyy_h\_mm_ss") + ".txt" },
                    {typeof(Newton),() => actualPath = lastDataPath[5] = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\" + type.Name + "_" + DateTime.Now.ToString(@"MM\_dd\_yyyy_h\_mm_ss") + ".txt" },
                };
            @switch[type]();
            actualPath.Replace(@"\\", @"\");
            lastArchieve.Text = "Último arquivo: " + Path.GetFileName(actualPath);
            using (StreamWriter file = new StreamWriter(@actualPath, false, Encoding.ASCII))
            {
                file.WriteLine(log);
            }
            OnFinishWriting(type);            
        }

        public FormPrinc()
        {
            InitializeComponent();
            this.Name = "FormPrinc";
            FinishWriting += (sender, e) => 
            {
                var @switch = new Dictionary<Type, Action>()
                {
                    {typeof(BuscaUniforme),() => logButtonUni.Enabled = true },
                    {typeof(BuscaDic),() => logButtonDic.Enabled = true },
                    {typeof(SecAurea),() => logButtonSec.Enabled = true },
                    {typeof(Fibonacci),() => logButtonFib.Enabled = true },
                    {typeof(Bissecao),() => logButtonBiss.Enabled = true },
                    {typeof(Newton),() => logButtonNew.Enabled = true },
                };

                @switch[e]();
            };
            lastArchieve.Text = "Último arquivo: Nenhum";
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

        private void log_Click(object sender, EventArgs e)
        {
            switch (((Button) sender).Name)
            {
                case "logButtonUni":
                    Process.Start(lastDataPath[0]);
                    break;
                case "logButtonDic":
                    Process.Start(lastDataPath[1]);
                    break;
                case "logButtonSec":
                    Process.Start(lastDataPath[2]);
                    break;
                case "logButtonFib":
                    Process.Start(lastDataPath[3]);
                    break;
                case "logButtonBiss":
                    Process.Start(lastDataPath[4]);
                    break;
                case "logButtonNew":
                    Process.Start(lastDataPath[5]);
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
                    buscUni.FinishCalculating += FinishCalculating;
                    buscUni.dados.a = Convert.ToDouble(aTextBox.Text);
                    buscUni.dados.b = Convert.ToDouble(bTextBox.Text);
                    buscUni.dados.delta = Convert.ToDouble(deltaTextBox.Text);
                    buscUni.dados.func = funcTextBox.Text;
                    xotimoTextBox.Text = buscUni.Calcular().ToString();
                    break;
                case "Busca Dicotômica":
                    BuscaDic buscDic = new BuscaDic();
                    buscDic.FinishCalculating += FinishCalculating;
                    buscDic.infos.a = Convert.ToDouble(aDicTextBox.Text);
                    buscDic.infos.b = Convert.ToDouble(bDicTextBox.Text);
                    buscDic.infos.l = Convert.ToDouble(lTextBox.Text);
                    buscDic.infos.e = Convert.ToDouble(episTextBox.Text);
                    buscDic.infos.func = funcDicTextBox.Text;
                    xotimoDicTextBox.Text = buscDic.Calcular().ToString();
                    break;
                case "Seção Áurea":
                    SecAurea secAurea = new SecAurea();
                    secAurea.FinishCalculating += FinishCalculating;
                    secAurea.infos.a = Convert.ToDouble(aAureaTextBox.Text);
                    secAurea.infos.b = Convert.ToDouble(bAureaTextBox.Text);
                    secAurea.infos.l = Convert.ToDouble(lAureaTextBox.Text);
                    secAurea.infos.func = funcAureaTextBox.Text;
                    xotimoAureaTextBox.Text = secAurea.Calcular().ToString();
                    break;
                case "Busca de Fibonacci":
                    Fibonacci fib = new Fibonacci();
                    fib.FinishCalculating += FinishCalculating;
                    fib.infos.a = Convert.ToDouble(aFibTextBox.Text);
                    fib.infos.b = Convert.ToDouble(bFibTextBox.Text);
                    fib.infos.l = Convert.ToDouble(lFibTextBox.Text);
                    fib.infos.func = funcFibTextBox.Text;
                    xotimoFib.Text = fib.Calcular().ToString();
                    break;
                case "Bisseção":
                    Bissecao biss = new Bissecao();
                    biss.FinishCalculating += FinishCalculating;
                    biss.infos.a = Convert.ToDouble(aBissecTextBox.Text);
                    biss.infos.b = Convert.ToDouble(bBissecTextBox.Text);
                    biss.infos.l = Convert.ToDouble(lBissecTextBox.Text);
                    biss.infos.func = funcBissecTextBox.Text;
                    xotimoBissecTextBox.Text = biss.Calcular().ToString();
                    break;
                case "Newton":
                    Newton newt = new Newton();
                    newt.FinishCalculating += FinishCalculating;
                    newt.infos.a = Convert.ToDouble(aNewTextBox.Text);
                    newt.infos.b = Convert.ToDouble(bNewTextBox.Text);
                    newt.infos.e = Convert.ToDouble(episNewTextBox.Text);
                    newt.infos.func = funcNewTextBox.Text;
                    xotimoNewTextBox.Text = newt.Calcular().ToString();
                    break;
                default:
                    break;
            }
        }

        private void FinishCalculating(object sender, DadosEventData e)
        {
            WriteFile(e.Log, e.Type);
        }

        private void lastArchieve_Click(object sender, EventArgs e)
        {
            string retira = "Último arquivo: ";
            int index = lastArchieve.Text.IndexOf(retira);
            string cleanPath = (index < 0)
                ? lastArchieve.Text
                : lastArchieve.Text.Remove(index, retira.Length);
            if(cleanPath != "Nenhum")
                Process.Start(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\" + cleanPath);
        }
    }
}
