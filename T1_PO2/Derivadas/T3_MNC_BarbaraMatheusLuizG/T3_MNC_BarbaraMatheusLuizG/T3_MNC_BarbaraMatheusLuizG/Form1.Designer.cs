namespace T3_MNC_BarbaraMatheusLuizG
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.xbox = new System.Windows.Forms.TextBox();
            this.resultbox = new System.Windows.Forms.TextBox();
            this.xlbl = new System.Windows.Forms.Label();
            this.resultlbl = new System.Windows.Forms.Label();
            this.funcs = new System.Windows.Forms.GroupBox();
            this.sqrt = new System.Windows.Forms.RadioButton();
            this.cotan = new System.Windows.Forms.RadioButton();
            this.asin = new System.Windows.Forms.RadioButton();
            this.acos = new System.Windows.Forms.RadioButton();
            this.atan = new System.Windows.Forms.RadioButton();
            this.sinh = new System.Windows.Forms.RadioButton();
            this.cosh = new System.Windows.Forms.RadioButton();
            this.tanh = new System.Windows.Forms.RadioButton();
            this.cossec = new System.Windows.Forms.RadioButton();
            this.sec = new System.Windows.Forms.RadioButton();
            this.tan = new System.Windows.Forms.RadioButton();
            this.cos = new System.Windows.Forms.RadioButton();
            this.sin = new System.Windows.Forms.RadioButton();
            this.ln = new System.Windows.Forms.RadioButton();
            this.exp = new System.Windows.Forms.RadioButton();
            this.Calc = new System.Windows.Forms.Button();
            this.derivs = new System.Windows.Forms.ComboBox();
            this.derlbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.funcs.SuspendLayout();
            this.SuspendLayout();
            // 
            // xbox
            // 
            this.xbox.Location = new System.Drawing.Point(9, 34);
            this.xbox.Name = "xbox";
            this.xbox.Size = new System.Drawing.Size(100, 20);
            this.xbox.TabIndex = 0;
            // 
            // resultbox
            // 
            this.resultbox.Location = new System.Drawing.Point(9, 73);
            this.resultbox.Name = "resultbox";
            this.resultbox.Size = new System.Drawing.Size(100, 20);
            this.resultbox.TabIndex = 1;
            // 
            // xlbl
            // 
            this.xlbl.AutoSize = true;
            this.xlbl.Location = new System.Drawing.Point(9, 18);
            this.xlbl.Name = "xlbl";
            this.xlbl.Size = new System.Drawing.Size(12, 13);
            this.xlbl.TabIndex = 4;
            this.xlbl.Text = "x";
            // 
            // resultlbl
            // 
            this.resultlbl.AutoSize = true;
            this.resultlbl.Location = new System.Drawing.Point(7, 57);
            this.resultlbl.Name = "resultlbl";
            this.resultlbl.Size = new System.Drawing.Size(55, 13);
            this.resultlbl.TabIndex = 5;
            this.resultlbl.Text = "Resultado";
            // 
            // funcs
            // 
            this.funcs.Controls.Add(this.sqrt);
            this.funcs.Controls.Add(this.cotan);
            this.funcs.Controls.Add(this.asin);
            this.funcs.Controls.Add(this.acos);
            this.funcs.Controls.Add(this.atan);
            this.funcs.Controls.Add(this.sinh);
            this.funcs.Controls.Add(this.cosh);
            this.funcs.Controls.Add(this.tanh);
            this.funcs.Controls.Add(this.cossec);
            this.funcs.Controls.Add(this.sec);
            this.funcs.Controls.Add(this.tan);
            this.funcs.Controls.Add(this.cos);
            this.funcs.Controls.Add(this.sin);
            this.funcs.Controls.Add(this.ln);
            this.funcs.Controls.Add(this.exp);
            this.funcs.Location = new System.Drawing.Point(116, 18);
            this.funcs.Name = "funcs";
            this.funcs.Size = new System.Drawing.Size(210, 182);
            this.funcs.TabIndex = 6;
            this.funcs.TabStop = false;
            this.funcs.Text = "Funções";
            // 
            // sqrt
            // 
            this.sqrt.AutoSize = true;
            this.sqrt.Location = new System.Drawing.Point(153, 19);
            this.sqrt.Name = "sqrt";
            this.sqrt.Size = new System.Drawing.Size(53, 17);
            this.sqrt.TabIndex = 14;
            this.sqrt.Text = "sqrt(x)";
            this.sqrt.UseVisualStyleBackColor = true;
            // 
            // cotan
            // 
            this.cotan.AutoSize = true;
            this.cotan.Location = new System.Drawing.Point(84, 19);
            this.cotan.Name = "cotan";
            this.cotan.Size = new System.Drawing.Size(63, 17);
            this.cotan.TabIndex = 13;
            this.cotan.Text = "cotan(x)";
            this.cotan.UseVisualStyleBackColor = true;
            // 
            // asin
            // 
            this.asin.AutoSize = true;
            this.asin.Location = new System.Drawing.Point(84, 42);
            this.asin.Name = "asin";
            this.asin.Size = new System.Drawing.Size(55, 17);
            this.asin.TabIndex = 12;
            this.asin.Text = "asin(x)";
            this.asin.UseVisualStyleBackColor = true;
            // 
            // acos
            // 
            this.acos.AutoSize = true;
            this.acos.Location = new System.Drawing.Point(84, 65);
            this.acos.Name = "acos";
            this.acos.Size = new System.Drawing.Size(59, 17);
            this.acos.TabIndex = 11;
            this.acos.Text = "acos(x)";
            this.acos.UseVisualStyleBackColor = true;
            // 
            // atan
            // 
            this.atan.AutoSize = true;
            this.atan.Location = new System.Drawing.Point(84, 88);
            this.atan.Name = "atan";
            this.atan.Size = new System.Drawing.Size(57, 17);
            this.atan.TabIndex = 10;
            this.atan.Text = "atan(x)";
            this.atan.UseVisualStyleBackColor = true;
            // 
            // sinh
            // 
            this.sinh.AutoSize = true;
            this.sinh.Location = new System.Drawing.Point(84, 111);
            this.sinh.Name = "sinh";
            this.sinh.Size = new System.Drawing.Size(55, 17);
            this.sinh.TabIndex = 9;
            this.sinh.Text = "sinh(x)";
            this.sinh.UseVisualStyleBackColor = true;
            // 
            // cosh
            // 
            this.cosh.AutoSize = true;
            this.cosh.Location = new System.Drawing.Point(84, 134);
            this.cosh.Name = "cosh";
            this.cosh.Size = new System.Drawing.Size(59, 17);
            this.cosh.TabIndex = 8;
            this.cosh.Text = "cosh(x)";
            this.cosh.UseVisualStyleBackColor = true;
            // 
            // tanh
            // 
            this.tanh.AutoSize = true;
            this.tanh.Location = new System.Drawing.Point(84, 157);
            this.tanh.Name = "tanh";
            this.tanh.Size = new System.Drawing.Size(57, 17);
            this.tanh.TabIndex = 7;
            this.tanh.Text = "tanh(x)";
            this.tanh.UseVisualStyleBackColor = true;
            // 
            // cossec
            // 
            this.cossec.AutoSize = true;
            this.cossec.Location = new System.Drawing.Point(7, 157);
            this.cossec.Name = "cossec";
            this.cossec.Size = new System.Drawing.Size(70, 17);
            this.cossec.TabIndex = 6;
            this.cossec.Text = "cossec(x)";
            this.cossec.UseVisualStyleBackColor = true;
            // 
            // sec
            // 
            this.sec.AutoSize = true;
            this.sec.Location = new System.Drawing.Point(7, 134);
            this.sec.Name = "sec";
            this.sec.Size = new System.Drawing.Size(53, 17);
            this.sec.TabIndex = 5;
            this.sec.Text = "sec(x)";
            this.sec.UseVisualStyleBackColor = true;
            // 
            // tan
            // 
            this.tan.AutoSize = true;
            this.tan.Location = new System.Drawing.Point(7, 111);
            this.tan.Name = "tan";
            this.tan.Size = new System.Drawing.Size(51, 17);
            this.tan.TabIndex = 4;
            this.tan.Text = "tan(x)";
            this.tan.UseVisualStyleBackColor = true;
            // 
            // cos
            // 
            this.cos.AutoSize = true;
            this.cos.Location = new System.Drawing.Point(7, 88);
            this.cos.Name = "cos";
            this.cos.Size = new System.Drawing.Size(53, 17);
            this.cos.TabIndex = 3;
            this.cos.Text = "cos(x)";
            this.cos.UseVisualStyleBackColor = true;
            // 
            // sin
            // 
            this.sin.AutoSize = true;
            this.sin.Location = new System.Drawing.Point(7, 65);
            this.sin.Name = "sin";
            this.sin.Size = new System.Drawing.Size(49, 17);
            this.sin.TabIndex = 2;
            this.sin.Text = "sin(x)";
            this.sin.UseVisualStyleBackColor = true;
            // 
            // ln
            // 
            this.ln.AutoSize = true;
            this.ln.Location = new System.Drawing.Point(7, 42);
            this.ln.Name = "ln";
            this.ln.Size = new System.Drawing.Size(44, 17);
            this.ln.TabIndex = 1;
            this.ln.Text = "ln(x)";
            this.ln.UseVisualStyleBackColor = true;
            // 
            // exp
            // 
            this.exp.AutoSize = true;
            this.exp.Location = new System.Drawing.Point(7, 19);
            this.exp.Name = "exp";
            this.exp.Size = new System.Drawing.Size(53, 17);
            this.exp.TabIndex = 0;
            this.exp.Text = "exp(x)";
            this.exp.UseVisualStyleBackColor = true;
            // 
            // Calc
            // 
            this.Calc.Location = new System.Drawing.Point(10, 151);
            this.Calc.Name = "Calc";
            this.Calc.Size = new System.Drawing.Size(100, 48);
            this.Calc.TabIndex = 7;
            this.Calc.Text = "Calcular";
            this.Calc.UseVisualStyleBackColor = true;
            this.Calc.Click += new System.EventHandler(this.Calc_Click);
            // 
            // derivs
            // 
            this.derivs.FormattingEnabled = true;
            this.derivs.Items.AddRange(new object[] {
            "Primeira",
            "Segunda",
            "Terceira"});
            this.derivs.Location = new System.Drawing.Point(9, 118);
            this.derivs.Name = "derivs";
            this.derivs.Size = new System.Drawing.Size(100, 21);
            this.derivs.TabIndex = 8;
            // 
            // derlbl
            // 
            this.derlbl.AutoSize = true;
            this.derlbl.Location = new System.Drawing.Point(7, 101);
            this.derlbl.Name = "derlbl";
            this.derlbl.Size = new System.Drawing.Size(50, 13);
            this.derlbl.TabIndex = 9;
            this.derlbl.Text = "Derivada";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 202);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Obs: Todos os valores devem ser inseridos utilizando , não .";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 218);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.derlbl);
            this.Controls.Add(this.derivs);
            this.Controls.Add(this.Calc);
            this.Controls.Add(this.funcs);
            this.Controls.Add(this.resultlbl);
            this.Controls.Add(this.xlbl);
            this.Controls.Add(this.resultbox);
            this.Controls.Add(this.xbox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.funcs.ResumeLayout(false);
            this.funcs.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox xbox;
        private System.Windows.Forms.TextBox resultbox;
        private System.Windows.Forms.Label xlbl;
        private System.Windows.Forms.Label resultlbl;
        private System.Windows.Forms.GroupBox funcs;
        private System.Windows.Forms.RadioButton sqrt;
        private System.Windows.Forms.RadioButton cotan;
        private System.Windows.Forms.RadioButton asin;
        private System.Windows.Forms.RadioButton acos;
        private System.Windows.Forms.RadioButton atan;
        private System.Windows.Forms.RadioButton sinh;
        private System.Windows.Forms.RadioButton cosh;
        private System.Windows.Forms.RadioButton tanh;
        private System.Windows.Forms.RadioButton cossec;
        private System.Windows.Forms.RadioButton sec;
        private System.Windows.Forms.RadioButton tan;
        private System.Windows.Forms.RadioButton cos;
        private System.Windows.Forms.RadioButton sin;
        private System.Windows.Forms.RadioButton ln;
        private System.Windows.Forms.RadioButton exp;
        private System.Windows.Forms.Button Calc;
        private System.Windows.Forms.ComboBox derivs;
        private System.Windows.Forms.Label derlbl;
        private System.Windows.Forms.Label label1;
    }
}

