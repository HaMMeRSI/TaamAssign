namespace GeneticTargeting
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
            this.pnlView = new System.Windows.Forms.Panel();
            this.tbScale = new System.Windows.Forms.TrackBar();
            this.btnGeneratePopulation = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbScale)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlView
            // 
            this.pnlView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlView.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlView.Location = new System.Drawing.Point(13, 13);
            this.pnlView.Name = "pnlView";
            this.pnlView.Size = new System.Drawing.Size(675, 630);
            this.pnlView.TabIndex = 0;
            this.pnlView.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlView_Paint);
            this.pnlView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlView_MouseDown);
            this.pnlView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlView_MouseMove);
            this.pnlView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlView_MouseUp);
            // 
            // tbScale
            // 
            this.tbScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbScale.Location = new System.Drawing.Point(694, 13);
            this.tbScale.Maximum = 100;
            this.tbScale.Minimum = 1;
            this.tbScale.Name = "tbScale";
            this.tbScale.Size = new System.Drawing.Size(321, 56);
            this.tbScale.TabIndex = 1;
            this.tbScale.TickFrequency = 0;
            this.tbScale.Value = 25;
            this.tbScale.Scroll += new System.EventHandler(this.tbScale_Scroll);
            // 
            // btnGeneratePopulation
            // 
            this.btnGeneratePopulation.Location = new System.Drawing.Point(695, 75);
            this.btnGeneratePopulation.Name = "btnGeneratePopulation";
            this.btnGeneratePopulation.Size = new System.Drawing.Size(320, 68);
            this.btnGeneratePopulation.TabIndex = 2;
            this.btnGeneratePopulation.Text = "Generate Population";
            this.btnGeneratePopulation.UseVisualStyleBackColor = true;
            this.btnGeneratePopulation.Click += new System.EventHandler(this.btnGeneratePopulation_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 655);
            this.Controls.Add(this.btnGeneratePopulation);
            this.Controls.Add(this.tbScale);
            this.Controls.Add(this.pnlView);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.tbScale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlView;
        private System.Windows.Forms.TrackBar tbScale;
        private System.Windows.Forms.Button btnGeneratePopulation;
    }
}

