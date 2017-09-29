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
            this.label1 = new System.Windows.Forms.Label();
            this.numCycles = new System.Windows.Forms.NumericUpDown();
            this.lblGenerationCount = new System.Windows.Forms.Label();
            this.lblAverageFitness = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblBestFitness = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRestrategize = new System.Windows.Forms.Button();
            this.lblAmmo = new System.Windows.Forms.Label();
            this.tbMutationChance = new System.Windows.Forms.NumericUpDown();
            this.tbPopulationSize = new System.Windows.Forms.NumericUpDown();
            this.tbEnemyCount = new System.Windows.Forms.NumericUpDown();
            this.tbFriendlyCount = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.nmMinDamage = new System.Windows.Forms.NumericUpDown();
            this.nmMinAmmunition = new System.Windows.Forms.NumericUpDown();
            this.nmMinRadius = new System.Windows.Forms.NumericUpDown();
            this.nmMaxDamage = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nmMaxAmmunition = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.nmMaxRadius = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tbScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCycles)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMutationChance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPopulationSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbEnemyCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFriendlyCount)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmMinDamage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmMinAmmunition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmMinRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmMaxDamage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmMaxAmmunition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmMaxRadius)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlView
            // 
            this.pnlView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlView.BackColor = System.Drawing.Color.Silver;
            this.pnlView.Location = new System.Drawing.Point(17, 16);
            this.pnlView.Margin = new System.Windows.Forms.Padding(4);
            this.pnlView.Name = "pnlView";
            this.pnlView.Size = new System.Drawing.Size(900, 775);
            this.pnlView.TabIndex = 0;
            this.pnlView.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlView_Paint);
            this.pnlView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlView_MouseDown);
            this.pnlView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlView_MouseMove);
            this.pnlView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlView_MouseUp);
            // 
            // tbScale
            // 
            this.tbScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbScale.Location = new System.Drawing.Point(1, 4);
            this.tbScale.Margin = new System.Windows.Forms.Padding(4);
            this.tbScale.Maximum = 100;
            this.tbScale.Minimum = 1;
            this.tbScale.Name = "tbScale";
            this.tbScale.Size = new System.Drawing.Size(428, 56);
            this.tbScale.TabIndex = 1;
            this.tbScale.TickFrequency = 0;
            this.tbScale.Value = 25;
            this.tbScale.Scroll += new System.EventHandler(this.tbScale_Scroll);
            // 
            // btnGeneratePopulation
            // 
            this.btnGeneratePopulation.Location = new System.Drawing.Point(84, 85);
            this.btnGeneratePopulation.Margin = new System.Windows.Forms.Padding(4);
            this.btnGeneratePopulation.Name = "btnGeneratePopulation";
            this.btnGeneratePopulation.Size = new System.Drawing.Size(345, 84);
            this.btnGeneratePopulation.TabIndex = 2;
            this.btnGeneratePopulation.Text = "Generate Population";
            this.btnGeneratePopulation.UseVisualStyleBackColor = true;
            this.btnGeneratePopulation.Click += new System.EventHandler(this.btnGeneratePopulation_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number of generations:";
            // 
            // numCycles
            // 
            this.numCycles.Location = new System.Drawing.Point(193, 62);
            this.numCycles.Margin = new System.Windows.Forms.Padding(4);
            this.numCycles.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numCycles.Name = "numCycles";
            this.numCycles.Size = new System.Drawing.Size(236, 22);
            this.numCycles.TabIndex = 4;
            this.numCycles.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblGenerationCount
            // 
            this.lblGenerationCount.AutoSize = true;
            this.lblGenerationCount.Location = new System.Drawing.Point(4, 225);
            this.lblGenerationCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGenerationCount.Name = "lblGenerationCount";
            this.lblGenerationCount.Size = new System.Drawing.Size(143, 17);
            this.lblGenerationCount.TabIndex = 5;
            this.lblGenerationCount.Text = "Current generation: 0";
            // 
            // lblAverageFitness
            // 
            this.lblAverageFitness.AutoSize = true;
            this.lblAverageFitness.Location = new System.Drawing.Point(4, 256);
            this.lblAverageFitness.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAverageFitness.Name = "lblAverageFitness";
            this.lblAverageFitness.Size = new System.Drawing.Size(122, 17);
            this.lblAverageFitness.TabIndex = 5;
            this.lblAverageFitness.Text = "Average fitness: 0";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(4, 85);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(69, 84);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start!";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblBestFitness
            // 
            this.lblBestFitness.AutoSize = true;
            this.lblBestFitness.Location = new System.Drawing.Point(4, 291);
            this.lblBestFitness.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBestFitness.Name = "lblBestFitness";
            this.lblBestFitness.Size = new System.Drawing.Size(97, 17);
            this.lblBestFitness.TabIndex = 7;
            this.lblBestFitness.Text = "Best fitness: 0";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnRestrategize);
            this.panel1.Controls.Add(this.lblAmmo);
            this.panel1.Controls.Add(this.lblBestFitness);
            this.panel1.Controls.Add(this.btnGeneratePopulation);
            this.panel1.Controls.Add(this.tbScale);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblGenerationCount);
            this.panel1.Controls.Add(this.numCycles);
            this.panel1.Controls.Add(this.lblAverageFitness);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Location = new System.Drawing.Point(924, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(433, 426);
            this.panel1.TabIndex = 8;
            // 
            // btnRestrategize
            // 
            this.btnRestrategize.Location = new System.Drawing.Point(3, 177);
            this.btnRestrategize.Name = "btnRestrategize";
            this.btnRestrategize.Size = new System.Drawing.Size(426, 45);
            this.btnRestrategize.TabIndex = 9;
            this.btnRestrategize.Text = "New Formation";
            this.btnRestrategize.UseVisualStyleBackColor = true;
            this.btnRestrategize.Click += new System.EventHandler(this.btnRestrategize_Click);
            // 
            // lblAmmo
            // 
            this.lblAmmo.AutoSize = true;
            this.lblAmmo.Location = new System.Drawing.Point(4, 321);
            this.lblAmmo.Name = "lblAmmo";
            this.lblAmmo.Size = new System.Drawing.Size(124, 17);
            this.lblAmmo.TabIndex = 8;
            this.lblAmmo.Text = "Total ammunition: ";
            // 
            // tbMutationChance
            // 
            this.tbMutationChance.DecimalPlaces = 5;
            this.tbMutationChance.Location = new System.Drawing.Point(169, 86);
            this.tbMutationChance.Name = "tbMutationChance";
            this.tbMutationChance.Size = new System.Drawing.Size(256, 22);
            this.tbMutationChance.TabIndex = 1;
            this.tbMutationChance.TextChanged += new System.EventHandler(this.tbConfig_TextChanged);
            this.tbMutationChance.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // tbPopulationSize
            // 
            this.tbPopulationSize.Location = new System.Drawing.Point(169, 58);
            this.tbPopulationSize.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.tbPopulationSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tbPopulationSize.Name = "tbPopulationSize";
            this.tbPopulationSize.Size = new System.Drawing.Size(256, 22);
            this.tbPopulationSize.TabIndex = 1;
            this.tbPopulationSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tbPopulationSize.TextChanged += new System.EventHandler(this.tbConfig_TextChanged);
            this.tbPopulationSize.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // tbEnemyCount
            // 
            this.tbEnemyCount.Location = new System.Drawing.Point(169, 32);
            this.tbEnemyCount.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.tbEnemyCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tbEnemyCount.Name = "tbEnemyCount";
            this.tbEnemyCount.Size = new System.Drawing.Size(256, 22);
            this.tbEnemyCount.TabIndex = 1;
            this.tbEnemyCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tbEnemyCount.TextChanged += new System.EventHandler(this.tbConfig_TextChanged);
            this.tbEnemyCount.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // tbFriendlyCount
            // 
            this.tbFriendlyCount.Location = new System.Drawing.Point(169, 6);
            this.tbFriendlyCount.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.tbFriendlyCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tbFriendlyCount.Name = "tbFriendlyCount";
            this.tbFriendlyCount.Size = new System.Drawing.Size(256, 22);
            this.tbFriendlyCount.TabIndex = 1;
            this.tbFriendlyCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tbFriendlyCount.TextChanged += new System.EventHandler(this.tbConfig_TextChanged);
            this.tbFriendlyCount.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Mutation chance:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Population size:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Enemy count:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Friendly count:";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(924, 448);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(433, 343);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.tbMutationChance);
            this.tabPage1.Controls.Add(this.tbEnemyCount);
            this.tabPage1.Controls.Add(this.tbPopulationSize);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.tbFriendlyCount);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(425, 314);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Configuration";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.nmMinDamage);
            this.tabPage2.Controls.Add(this.nmMinAmmunition);
            this.tabPage2.Controls.Add(this.nmMinRadius);
            this.tabPage2.Controls.Add(this.nmMaxDamage);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.nmMaxAmmunition);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.nmMaxRadius);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(425, 314);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Game setting";
            // 
            // nmMinDamage
            // 
            this.nmMinDamage.DecimalPlaces = 5;
            this.nmMinDamage.Location = new System.Drawing.Point(168, 32);
            this.nmMinDamage.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmMinDamage.Name = "nmMinDamage";
            this.nmMinDamage.Size = new System.Drawing.Size(256, 22);
            this.nmMinDamage.TabIndex = 6;
            this.nmMinDamage.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // nmMinAmmunition
            // 
            this.nmMinAmmunition.Location = new System.Drawing.Point(169, 139);
            this.nmMinAmmunition.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nmMinAmmunition.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmMinAmmunition.Name = "nmMinAmmunition";
            this.nmMinAmmunition.Size = new System.Drawing.Size(256, 22);
            this.nmMinAmmunition.TabIndex = 7;
            this.nmMinAmmunition.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmMinAmmunition.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // nmMinRadius
            // 
            this.nmMinRadius.Location = new System.Drawing.Point(168, 86);
            this.nmMinRadius.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nmMinRadius.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmMinRadius.Name = "nmMinRadius";
            this.nmMinRadius.Size = new System.Drawing.Size(256, 22);
            this.nmMinRadius.TabIndex = 7;
            this.nmMinRadius.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmMinRadius.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // nmMaxDamage
            // 
            this.nmMaxDamage.DecimalPlaces = 5;
            this.nmMaxDamage.Location = new System.Drawing.Point(168, 4);
            this.nmMaxDamage.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmMaxDamage.Name = "nmMaxDamage";
            this.nmMaxDamage.Size = new System.Drawing.Size(256, 22);
            this.nmMaxDamage.TabIndex = 8;
            this.nmMaxDamage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmMaxDamage.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 116);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(113, 17);
            this.label13.TabIndex = 2;
            this.label13.Text = "Max ammunition:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 142);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 17);
            this.label12.TabIndex = 3;
            this.label12.Text = "Min ammunition:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Max radius:";
            // 
            // nmMaxAmmunition
            // 
            this.nmMaxAmmunition.Location = new System.Drawing.Point(169, 113);
            this.nmMaxAmmunition.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nmMaxAmmunition.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmMaxAmmunition.Name = "nmMaxAmmunition";
            this.nmMaxAmmunition.Size = new System.Drawing.Size(256, 22);
            this.nmMaxAmmunition.TabIndex = 9;
            this.nmMaxAmmunition.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmMaxAmmunition.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "Min radius:";
            // 
            // nmMaxRadius
            // 
            this.nmMaxRadius.Location = new System.Drawing.Point(168, 60);
            this.nmMaxRadius.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nmMaxRadius.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmMaxRadius.Name = "nmMaxRadius";
            this.nmMaxRadius.Size = new System.Drawing.Size(256, 22);
            this.nmMaxRadius.TabIndex = 9;
            this.nmMaxRadius.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmMaxRadius.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 17);
            this.label8.TabIndex = 4;
            this.label8.Text = "Max damage:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 17);
            this.label9.TabIndex = 5;
            this.label9.Text = "Min damage:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1369, 806);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlView);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.tbScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCycles)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMutationChance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPopulationSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbEnemyCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFriendlyCount)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmMinDamage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmMinAmmunition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmMinRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmMaxDamage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmMaxAmmunition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmMaxRadius)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlView;
        private System.Windows.Forms.TrackBar tbScale;
        private System.Windows.Forms.Button btnGeneratePopulation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numCycles;
        private System.Windows.Forms.Label lblGenerationCount;
        private System.Windows.Forms.Label lblAverageFitness;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblBestFitness;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblAmmo;
        private System.Windows.Forms.Button btnRestrategize;
        private System.Windows.Forms.NumericUpDown tbMutationChance;
        private System.Windows.Forms.NumericUpDown tbPopulationSize;
        private System.Windows.Forms.NumericUpDown tbEnemyCount;
        private System.Windows.Forms.NumericUpDown tbFriendlyCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.NumericUpDown nmMinDamage;
        private System.Windows.Forms.NumericUpDown nmMinRadius;
        private System.Windows.Forms.NumericUpDown nmMaxDamage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nmMaxRadius;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nmMinAmmunition;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown nmMaxAmmunition;
    }
}

