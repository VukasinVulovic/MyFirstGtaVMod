namespace WindowsFormsApp1
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
            this.btn_recognize = new System.Windows.Forms.Button();
            this.tb_output = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_recognize
            // 
            this.btn_recognize.BackColor = System.Drawing.Color.Gray;
            this.btn_recognize.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_recognize.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_recognize.Location = new System.Drawing.Point(12, 12);
            this.btn_recognize.Name = "btn_recognize";
            this.btn_recognize.Size = new System.Drawing.Size(411, 86);
            this.btn_recognize.TabIndex = 0;
            this.btn_recognize.Text = "RECOGNIZE";
            this.btn_recognize.UseVisualStyleBackColor = false;
            this.btn_recognize.Click += new System.EventHandler(this.recognizeVoice);
            // 
            // tb_output
            // 
            this.tb_output.BackColor = System.Drawing.SystemColors.Info;
            this.tb_output.CausesValidation = false;
            this.tb_output.Enabled = false;
            this.tb_output.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_output.Location = new System.Drawing.Point(12, 109);
            this.tb_output.Multiline = true;
            this.tb_output.Name = "tb_output";
            this.tb_output.Size = new System.Drawing.Size(411, 172);
            this.tb_output.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(435, 292);
            this.Controls.Add(this.tb_output);
            this.Controls.Add(this.btn_recognize);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_recognize;
        private System.Windows.Forms.TextBox tb_output;
    }
}

