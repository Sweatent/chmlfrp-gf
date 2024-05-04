namespace chmlfrp_green_fast
{
    partial class main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            textBox1 = new TextBox();
            label1 = new Label();
            linkLabel1 = new LinkLabel();
            button1 = new Button();
            button2 = new Button();
            label2 = new Label();
            rizhi = new TextBox();
            label3 = new Label();
            label4 = new Label();
            buquan = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.AcceptsReturn = true;
            textBox1.AcceptsTab = true;
            textBox1.AllowDrop = true;
            textBox1.Location = new Point(176, 121);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(445, 147);
            textBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(47, 121);
            label1.Name = "label1";
            label1.Size = new Size(90, 24);
            label1.TabIndex = 1;
            label1.Text = "配置文件*";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Microsoft YaHei UI", 8F);
            linkLabel1.Location = new Point(417, 281);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(204, 26);
            linkLabel1.TabIndex = 2;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "点击前往官网获取配置文件";
            linkLabel1.UseCompatibleTextRendering = true;
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // button1
            // 
            button1.Location = new Point(47, 40);
            button1.Name = "button1";
            button1.Size = new Size(200, 34);
            button1.TabIndex = 3;
            button1.Text = "使用方法（一定要看)";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(509, 322);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 4;
            button2.Text = "启动映射";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(47, 370);
            label2.Name = "label2";
            label2.Size = new Size(86, 24);
            label2.TabIndex = 5;
            label2.Text = "日志输出:";
            // 
            // rizhi
            // 
            rizhi.AcceptsReturn = true;
            rizhi.AcceptsTab = true;
            rizhi.AllowDrop = true;
            rizhi.Cursor = Cursors.IBeam;
            rizhi.Location = new Point(176, 370);
            rizhi.Multiline = true;
            rizhi.Name = "rizhi";
            rizhi.ScrollBars = ScrollBars.Vertical;
            rizhi.Size = new Size(445, 234);
            rizhi.TabIndex = 6;
            rizhi.TextChanged += textBox2_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(286, 45);
            label3.Name = "label3";
            label3.Size = new Size(125, 24);
            label3.TabIndex = 7;
            label3.Text = "frp是否完整：";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(396, 45);
            label4.Name = "label4";
            label4.Size = new Size(28, 24);
            label4.TabIndex = 8;
            label4.Text = "否";
            // 
            // buquan
            // 
            buquan.Location = new Point(435, 81);
            buquan.Name = "buquan";
            buquan.Size = new Size(134, 34);
            buquan.TabIndex = 9;
            buquan.Text = "点击补全文件";
            buquan.UseVisualStyleBackColor = true;
            buquan.Click += buquan_Click;
            // 
            // main
            // 
            AcceptButton = button2;
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(673, 638);
            Controls.Add(buquan);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(rizhi);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(linkLabel1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "main";
            Opacity = 0.9D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "chmlfrp-快捷启动器v0.0.1        作者：sweatent";
            FormClosing += Form1_FormClosing;
            Load += main_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private LinkLabel linkLabel1;
        private Button button1;
        private Button button2;
        private Label label2;
        private TextBox rizhi;
        private Label label3;
        private Label label4;
        private Button buquan;
    }
}
