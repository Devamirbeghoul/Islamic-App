namespace Islamic_App
{
    partial class fmMorningAdkars
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmMorningAdkars));
            this.tbAdkars = new System.Windows.Forms.TextBox();
            this.btn2 = new Guna.UI2.WinForms.Guna2Button();
            this.btn1 = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // tbAdkars
            // 
            this.tbAdkars.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tbAdkars.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbAdkars.ForeColor = System.Drawing.Color.Black;
            this.tbAdkars.Location = new System.Drawing.Point(12, 100);
            this.tbAdkars.Multiline = true;
            this.tbAdkars.Name = "tbAdkars";
            this.tbAdkars.ReadOnly = true;
            this.tbAdkars.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbAdkars.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbAdkars.Size = new System.Drawing.Size(811, 485);
            this.tbAdkars.TabIndex = 11;
            // 
            // btn2
            // 
            this.btn2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn2.BorderRadius = 25;
            this.btn2.BorderThickness = 2;
            this.btn2.CheckedState.Parent = this.btn2;
            this.btn2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn2.CustomImages.Parent = this.btn2;
            this.btn2.FillColor = System.Drawing.Color.Transparent;
            this.btn2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn2.HoverState.Parent = this.btn2;
            this.btn2.Location = new System.Drawing.Point(12, 14);
            this.btn2.Name = "btn2";
            this.btn2.ShadowDecoration.Parent = this.btn2;
            this.btn2.Size = new System.Drawing.Size(257, 57);
            this.btn2.TabIndex = 10;
            this.btn2.Text = "من السنة النبوية";
            this.btn2.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn1
            // 
            this.btn1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn1.BorderRadius = 25;
            this.btn1.BorderThickness = 2;
            this.btn1.CheckedState.Parent = this.btn1;
            this.btn1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn1.CustomImages.Parent = this.btn1;
            this.btn1.FillColor = System.Drawing.Color.Transparent;
            this.btn1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn1.HoverState.Parent = this.btn1;
            this.btn1.Location = new System.Drawing.Point(567, 14);
            this.btn1.Name = "btn1";
            this.btn1.ShadowDecoration.Parent = this.btn1;
            this.btn1.Size = new System.Drawing.Size(257, 57);
            this.btn1.TabIndex = 9;
            this.btn1.Text = "من القرأن الكريم";
            this.btn1.Click += new System.EventHandler(this.btn_Click);
            // 
            // fmMorningAdkars
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(836, 599);
            this.Controls.Add(this.tbAdkars);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "fmMorningAdkars";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbAdkars;
        private Guna.UI2.WinForms.Guna2Button btn2;
        private Guna.UI2.WinForms.Guna2Button btn1;
    }
}