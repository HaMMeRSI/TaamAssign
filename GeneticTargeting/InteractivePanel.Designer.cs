namespace TaamAssign
{
    partial class InteractivePanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbScale = new System.Windows.Forms.TrackBar();
            this.pnlView = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.tbScale)).BeginInit();
            this.SuspendLayout();
            // 
            // tbScale
            // 
            this.tbScale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbScale.Location = new System.Drawing.Point(0, 0);
            this.tbScale.Maximum = 100;
            this.tbScale.Minimum = 1;
            this.tbScale.Name = "tbScale";
            this.tbScale.Size = new System.Drawing.Size(186, 56);
            this.tbScale.TabIndex = 0;
            this.tbScale.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbScale.Value = 25;
            this.tbScale.Scroll += new System.EventHandler(this.tbScale_Scroll);
            // 
            // pnlView
            // 
            this.pnlView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlView.Location = new System.Drawing.Point(0, 62);
            this.pnlView.Name = "pnlView";
            this.pnlView.Size = new System.Drawing.Size(189, 127);
            this.pnlView.TabIndex = 1;
            this.pnlView.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlView_Paint);
            this.pnlView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlView_MouseDown);
            this.pnlView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlView_MouseMove);
            this.pnlView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlView_MouseUp);
            // 
            // InteractivePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbScale);
            this.Controls.Add(this.pnlView);
            this.Name = "InteractivePanel";
            this.Size = new System.Drawing.Size(189, 189);
            ((System.ComponentModel.ISupportInitialize)(this.tbScale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar tbScale;
        private System.Windows.Forms.Panel pnlView;
    }
}
