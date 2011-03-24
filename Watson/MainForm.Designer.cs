namespace Watson
{
    partial class Watson
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Watson));
            this.btnSelectWinner = new System.Windows.Forms.Button();
            this.txtTheWinner = new System.Windows.Forms.TextBox();
            this.imgWatson = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgWatson)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelectWinner
            // 
            this.btnSelectWinner.BackColor = System.Drawing.Color.Green;
            this.btnSelectWinner.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectWinner.ForeColor = System.Drawing.Color.White;
            this.btnSelectWinner.Location = new System.Drawing.Point(226, 402);
            this.btnSelectWinner.Name = "btnSelectWinner";
            this.btnSelectWinner.Size = new System.Drawing.Size(332, 80);
            this.btnSelectWinner.TabIndex = 0;
            this.btnSelectWinner.Text = "Pick a Winner";
            this.btnSelectWinner.UseVisualStyleBackColor = false;
            this.btnSelectWinner.Click += new System.EventHandler(this.btnSelectWinner_Click);
            // 
            // txtTheWinner
            // 
            this.txtTheWinner.BackColor = System.Drawing.Color.Black;
            this.txtTheWinner.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTheWinner.ForeColor = System.Drawing.Color.White;
            this.txtTheWinner.Location = new System.Drawing.Point(12, 12);
            this.txtTheWinner.Multiline = true;
            this.txtTheWinner.Name = "txtTheWinner";
            this.txtTheWinner.Size = new System.Drawing.Size(476, 350);
            this.txtTheWinner.TabIndex = 2;
            this.txtTheWinner.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // imgWatson
            // 
            this.imgWatson.Image = ((System.Drawing.Image)(resources.GetObject("imgWatson.Image")));
            this.imgWatson.Location = new System.Drawing.Point(494, 12);
            this.imgWatson.Name = "imgWatson";
            this.imgWatson.Size = new System.Drawing.Size(284, 350);
            this.imgWatson.TabIndex = 3;
            this.imgWatson.TabStop = false;
            this.imgWatson.Click += new System.EventHandler(this.imgWatson_Click);
            // 
            // Watson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 494);
            this.Controls.Add(this.imgWatson);
            this.Controls.Add(this.txtTheWinner);
            this.Controls.Add(this.btnSelectWinner);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Watson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Watson";
            this.Load += new System.EventHandler(this.Watson_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgWatson)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectWinner;
        private System.Windows.Forms.TextBox txtTheWinner;
        private System.Windows.Forms.PictureBox imgWatson;
    }
}

