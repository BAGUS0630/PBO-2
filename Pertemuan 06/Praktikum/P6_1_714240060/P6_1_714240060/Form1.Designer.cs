namespace P6_1_714240060
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
            this.vbButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.csButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // vbButton
            // 
            this.vbButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vbButton.ForeColor = System.Drawing.Color.ForestGreen;
            this.vbButton.Location = new System.Drawing.Point(113, 128);
            this.vbButton.Name = "vbButton";
            this.vbButton.Size = new System.Drawing.Size(129, 33);
            this.vbButton.TabIndex = 0;
            this.vbButton.Text = "Visual Basic";
            this.vbButton.UseVisualStyleBackColor = true;
            this.vbButton.Click += new System.EventHandler(this.vbButton_Click);
            this.vbButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.vbButton_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(108, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(481, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Which do you think is better, Visual Basic or C#?";
            // 
            // csButton
            // 
            this.csButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.csButton.ForeColor = System.Drawing.Color.Crimson;
            this.csButton.Location = new System.Drawing.Point(497, 128);
            this.csButton.Name = "csButton";
            this.csButton.Size = new System.Drawing.Size(129, 33);
            this.csButton.TabIndex = 0;
            this.csButton.Text = "C#\r\n";
            this.csButton.UseVisualStyleBackColor = true;
            this.csButton.Click += new System.EventHandler(this.csButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.closeButton.Location = new System.Drawing.Point(24, 388);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(129, 33);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(759, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.csButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.vbButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button vbButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button csButton;
        private System.Windows.Forms.Button closeButton;
    }
}

