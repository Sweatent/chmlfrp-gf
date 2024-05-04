namespace chmlfrp
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            jindu = new ProgressBar();
            label1 = new Label();
            byte123 = new Label();
            SuspendLayout();
            // 
            // jindu
            // 
            jindu.Location = new Point(98, 124);
            jindu.Name = "jindu";
            jindu.Size = new Size(575, 37);
            jindu.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(98, 58);
            label1.Name = "label1";
            label1.Size = new Size(136, 24);
            label1.TabIndex = 1;
            label1.Text = "正在补全文件：";
            // 
            // byte123
            // 
            byte123.AutoSize = true;
            byte123.Location = new Point(515, 58);
            byte123.Name = "byte123";
            byte123.Size = new Size(63, 24);
            byte123.TabIndex = 2;
            byte123.Text = "label2";
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(765, 215);
            Controls.Add(byte123);
            Controls.Add(label1);
            Controls.Add(jindu);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form3";
            Text = "补全中";
            Load += Form3_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar jindu;
        private Label label1;
        private Label byte123;
    }
}