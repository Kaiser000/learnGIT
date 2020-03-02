namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.firstNUM = new System.Windows.Forms.TextBox();
            this.lastNUM = new System.Windows.Forms.TextBox();
            this.symbol = new System.Windows.Forms.ComboBox();
            this.c = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // firstNUM
            // 
            this.firstNUM.Location = new System.Drawing.Point(12, 110);
            this.firstNUM.Name = "firstNUM";
            this.firstNUM.Size = new System.Drawing.Size(100, 35);
            this.firstNUM.TabIndex = 0;
            this.firstNUM.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lastNUM
            // 
            this.lastNUM.Location = new System.Drawing.Point(335, 110);
            this.lastNUM.Name = "lastNUM";
            this.lastNUM.Size = new System.Drawing.Size(100, 35);
            this.lastNUM.TabIndex = 1;
            this.lastNUM.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // symbol
            // 
            this.symbol.FormattingEnabled = true;
            this.symbol.Items.AddRange(new object[] {
            "+",
            "-",
            "*",
            "/"});
            this.symbol.Location = new System.Drawing.Point(166, 110);
            this.symbol.Name = "symbol";
            this.symbol.Size = new System.Drawing.Size(101, 32);
            this.symbol.TabIndex = 2;
            this.symbol.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // c
            // 
            this.c.Location = new System.Drawing.Point(494, 85);
            this.c.Name = "c";
            this.c.Size = new System.Drawing.Size(189, 81);
            this.c.TabIndex = 3;
            this.c.Text = "calculate";
            this.c.UseVisualStyleBackColor = true;
            this.c.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(322, 271);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 24);
            this.label1.TabIndex = 4;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.c);
            this.Controls.Add(this.symbol);
            this.Controls.Add(this.lastNUM);
            this.Controls.Add(this.firstNUM);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox firstNUM;
        private System.Windows.Forms.TextBox lastNUM;
        private System.Windows.Forms.ComboBox symbol;
        private System.Windows.Forms.Button c;
        private System.Windows.Forms.Label label1;
    }
}

