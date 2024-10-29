namespace Islamic_App
{
    partial class fmPrayerAdkar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmPrayerAdkar));
            this.tbAdkars = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbAdkars
            // 
            this.tbAdkars.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tbAdkars.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbAdkars.ForeColor = System.Drawing.Color.Black;
            this.tbAdkars.Location = new System.Drawing.Point(12, 64);
            this.tbAdkars.Multiline = true;
            this.tbAdkars.Name = "tbAdkars";
            this.tbAdkars.ReadOnly = true;
            this.tbAdkars.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbAdkars.Size = new System.Drawing.Size(811, 485);
            this.tbAdkars.TabIndex = 9;
            this.tbAdkars.TabStop = false;
            // 
            // fmPrayerAdkar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(836, 599);
            this.Controls.Add(this.tbAdkars);
            this.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "fmPrayerAdkar";
            this.Load += new System.EventHandler(this.fmPrayerAdkar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbAdkars;
    }
}