namespace RoboDactics
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonCinématique = new System.Windows.Forms.Button();
            this.buttonDynamique = new System.Windows.Forms.Button();
            this.buttonConfig = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::RoboDactics.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(457, 249);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // buttonCinématique
            // 
            this.buttonCinématique.Location = new System.Drawing.Point(19, 148);
            this.buttonCinématique.Margin = new System.Windows.Forms.Padding(5);
            this.buttonCinématique.Name = "buttonCinématique";
            this.buttonCinématique.Size = new System.Drawing.Size(187, 69);
            this.buttonCinématique.TabIndex = 1;
            this.buttonCinématique.Text = "Cinématique ";
            this.buttonCinématique.UseVisualStyleBackColor = true;
            this.buttonCinématique.Click += new System.EventHandler(this.buttonCinématique_Click);
            // 
            // buttonDynamique
            // 
            this.buttonDynamique.Location = new System.Drawing.Point(251, 148);
            this.buttonDynamique.Margin = new System.Windows.Forms.Padding(5);
            this.buttonDynamique.Name = "buttonDynamique";
            this.buttonDynamique.Size = new System.Drawing.Size(187, 69);
            this.buttonDynamique.TabIndex = 1;
            this.buttonDynamique.Text = "Dynamique";
            this.buttonDynamique.UseVisualStyleBackColor = true;
            this.buttonDynamique.Click += new System.EventHandler(this.buttonDynamique_Click);
            // 
            // buttonConfig
            // 
            this.buttonConfig.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonConfig.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.buttonConfig.FlatAppearance.BorderSize = 0;
            this.buttonConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfig.Image = ((System.Drawing.Image)(resources.GetObject("buttonConfig.Image")));
            this.buttonConfig.Location = new System.Drawing.Point(392, 90);
            this.buttonConfig.Margin = new System.Windows.Forms.Padding(5);
            this.buttonConfig.Name = "buttonConfig";
            this.buttonConfig.Size = new System.Drawing.Size(51, 48);
            this.buttonConfig.TabIndex = 2;
            this.buttonConfig.UseVisualStyleBackColor = false;
            this.buttonConfig.Click += new System.EventHandler(this.buttonConfig_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 249);
            this.Controls.Add(this.buttonConfig);
            this.Controls.Add(this.buttonDynamique);
            this.Controls.Add(this.buttonCinématique);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Robodactics";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonCinématique;
        private System.Windows.Forms.Button buttonDynamique;
        private System.Windows.Forms.Button buttonConfig;
    }
}

