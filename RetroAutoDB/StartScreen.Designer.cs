namespace RetroAutoDB
{
    partial class StartScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartScreen));
            this.Admin_btn = new System.Windows.Forms.Button();
            this.user_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Admin_btn
            // 
            this.Admin_btn.BackColor = System.Drawing.Color.White;
            this.Admin_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Admin_btn.Location = new System.Drawing.Point(47, 158);
            this.Admin_btn.Name = "Admin_btn";
            this.Admin_btn.Size = new System.Drawing.Size(190, 39);
            this.Admin_btn.TabIndex = 0;
            this.Admin_btn.Text = "Admin";
            this.Admin_btn.UseVisualStyleBackColor = false;
            this.Admin_btn.Click += new System.EventHandler(this.Admin_btn_Click);
            // 
            // user_btn
            // 
            this.user_btn.BackColor = System.Drawing.Color.White;
            this.user_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_btn.Location = new System.Drawing.Point(47, 203);
            this.user_btn.Name = "user_btn";
            this.user_btn.Size = new System.Drawing.Size(190, 42);
            this.user_btn.TabIndex = 1;
            this.user_btn.Text = "User";
            this.user_btn.UseVisualStyleBackColor = false;
            this.user_btn.Click += new System.EventHandler(this.user_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.user_btn);
            this.Controls.Add(this.Admin_btn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Opacity = 0.9D;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log-in Type";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Admin_btn;
        private System.Windows.Forms.Button user_btn;
    }
}