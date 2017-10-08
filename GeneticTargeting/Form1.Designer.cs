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
            this.components = new System.ComponentModel.Container();
            Library.Point2D point2D1 = new Library.Point2D();
            Library.Point2D point2D2 = new Library.Point2D();
            this.btnGeneratePopulation = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numCycles = new System.Windows.Forms.NumericUpDown();
            this.lblGenerationCount = new System.Windows.Forms.Label();
            this.lblAverageFitness = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblBestFitness = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTotalImportance = new System.Windows.Forms.Label();
            this.lblBestTotalPrice = new System.Windows.Forms.Label();
            this.lblBestDeadCount = new System.Windows.Forms.Label();
            this.btnRestrategize = new System.Windows.Forms.Button();
            this.tbMutationChance = new System.Windows.Forms.NumericUpDown();
            this.tbPopulationSize = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbcSettings = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbPartialGenomCrossover = new System.Windows.Forms.CheckBox();
            this.cbApplyNaturalSelection = new System.Windows.Forms.CheckBox();
            this.cbApplyElitist = new System.Windows.Forms.CheckBox();
            this.tbParentChance = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tbcGameSubSettings = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.nmImportanceWeight = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.nmPriceWeight = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.nmDeadCountWeight = new System.Windows.Forms.NumericUpDown();
            this.nmGridSize = new System.Windows.Forms.NumericUpDown();
            this.tbEnemyCount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tbFriendlyCount = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.nmMaxAccuracyForShot = new System.Windows.Forms.NumericUpDown();
            this.nmMinAccuracyForShot = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.nmMaxRadius = new System.Windows.Forms.NumericUpDown();
            this.nmMinDamage = new System.Windows.Forms.NumericUpDown();
            this.nmMaxAmmunition = new System.Windows.Forms.NumericUpDown();
            this.nmMinAmmunition = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.nmMinRadius = new System.Windows.Forms.NumericUpDown();
            this.nmMaxDamage = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.nmMaxImportance = new System.Windows.Forms.NumericUpDown();
            this.nmMinImportance = new System.Windows.Forms.NumericUpDown();
            this.nmMaxPricePerShot = new System.Windows.Forms.NumericUpDown();
            this.nmMinPricePerShot = new System.Windows.Forms.NumericUpDown();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ipStrategy = new GeneticTargeting.InteractivePanel();
            this.ipStatus = new GeneticTargeting.InteractivePanel();
            ((System.ComponentModel.ISupportInitialize)(this.numCycles)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMutationChance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPopulationSize)).BeginInit();
            this.tbcSettings.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbParentChance)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tbcGameSubSettings.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmImportanceWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmPriceWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmDeadCountWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmGridSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbEnemyCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFriendlyCount)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmMaxAccuracyForShot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmMinAccuracyForShot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmMaxRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmMinDamage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmMaxAmmunition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmMinAmmunition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmMinRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmMaxDamage)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmMaxImportance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmMinImportance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmMaxPricePerShot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmMinPricePerShot)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGeneratePopulation
            // 
            this.btnGeneratePopulation.Enabled = false;
            this.btnGeneratePopulation.Location = new System.Drawing.Point(117, 35);
            this.btnGeneratePopulation.Margin = new System.Windows.Forms.Padding(4);
            this.btnGeneratePopulation.Name = "btnGeneratePopulation";
            this.btnGeneratePopulation.Size = new System.Drawing.Size(312, 84);
            this.btnGeneratePopulation.TabIndex = 2;
            this.btnGeneratePopulation.Text = "Generate Population";
            this.btnGeneratePopulation.UseVisualStyleBackColor = true;
            this.btnGeneratePopulation.Click += new System.EventHandler(this.btnGeneratePopulation_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number of generations:";
            // 
            // numCycles
            // 
            this.numCycles.Location = new System.Drawing.Point(169, 5);
            this.numCycles.Margin = new System.Windows.Forms.Padding(4);
            this.numCycles.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numCycles.Name = "numCycles";
            this.numCycles.Size = new System.Drawing.Size(260, 22);
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
            this.lblGenerationCount.Location = new System.Drawing.Point(4, 175);
            this.lblGenerationCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGenerationCount.Name = "lblGenerationCount";
            this.lblGenerationCount.Size = new System.Drawing.Size(143, 17);
            this.lblGenerationCount.TabIndex = 5;
            this.lblGenerationCount.Text = "Current generation: 0";
            // 
            // lblAverageFitness
            // 
            this.lblAverageFitness.AutoSize = true;
            this.lblAverageFitness.Location = new System.Drawing.Point(4, 206);
            this.lblAverageFitness.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAverageFitness.Name = "lblAverageFitness";
            this.lblAverageFitness.Size = new System.Drawing.Size(122, 17);
            this.lblAverageFitness.TabIndex = 5;
            this.lblAverageFitness.Text = "Average fitness: 0";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(7, 35);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(102, 84);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start!";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblBestFitness
            // 
            this.lblBestFitness.AutoSize = true;
            this.lblBestFitness.Location = new System.Drawing.Point(4, 241);
            this.lblBestFitness.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBestFitness.Name = "lblBestFitness";
            this.lblBestFitness.Size = new System.Drawing.Size(97, 17);
            this.lblBestFitness.TabIndex = 7;
            this.lblBestFitness.Text = "Best fitness: 0";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lblTotalImportance);
            this.panel1.Controls.Add(this.lblBestTotalPrice);
            this.panel1.Controls.Add(this.lblBestDeadCount);
            this.panel1.Controls.Add(this.btnRestrategize);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblBestFitness);
            this.panel1.Controls.Add(this.lblAverageFitness);
            this.panel1.Controls.Add(this.numCycles);
            this.panel1.Controls.Add(this.lblGenerationCount);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.btnGeneratePopulation);
            this.panel1.Location = new System.Drawing.Point(928, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(433, 426);
            this.panel1.TabIndex = 8;
            // 
            // lblTotalImportance
            // 
            this.lblTotalImportance.AutoSize = true;
            this.lblTotalImportance.Location = new System.Drawing.Point(4, 323);
            this.lblTotalImportance.Name = "lblTotalImportance";
            this.lblTotalImportance.Size = new System.Drawing.Size(157, 17);
            this.lblTotalImportance.TabIndex = 10;
            this.lblTotalImportance.Text = "Best total importance: 0";
            // 
            // lblBestTotalPrice
            // 
            this.lblBestTotalPrice.AutoSize = true;
            this.lblBestTotalPrice.Location = new System.Drawing.Point(4, 297);
            this.lblBestTotalPrice.Name = "lblBestTotalPrice";
            this.lblBestTotalPrice.Size = new System.Drawing.Size(118, 17);
            this.lblBestTotalPrice.TabIndex = 10;
            this.lblBestTotalPrice.Text = "Best total price: 0";
            // 
            // lblBestDeadCount
            // 
            this.lblBestDeadCount.AutoSize = true;
            this.lblBestDeadCount.Location = new System.Drawing.Point(4, 269);
            this.lblBestDeadCount.Name = "lblBestDeadCount";
            this.lblBestDeadCount.Size = new System.Drawing.Size(131, 17);
            this.lblBestDeadCount.TabIndex = 10;
            this.lblBestDeadCount.Text = "Best dead count : 0";
            // 
            // btnRestrategize
            // 
            this.btnRestrategize.Enabled = false;
            this.btnRestrategize.Location = new System.Drawing.Point(7, 126);
            this.btnRestrategize.Name = "btnRestrategize";
            this.btnRestrategize.Size = new System.Drawing.Size(422, 45);
            this.btnRestrategize.TabIndex = 9;
            this.btnRestrategize.Text = "New Formation";
            this.btnRestrategize.UseVisualStyleBackColor = true;
            this.btnRestrategize.Click += new System.EventHandler(this.btnRestrategize_Click);
            // 
            // tbMutationChance
            // 
            this.tbMutationChance.DecimalPlaces = 5;
            this.tbMutationChance.Location = new System.Drawing.Point(169, 42);
            this.tbMutationChance.Name = "tbMutationChance";
            this.tbMutationChance.Size = new System.Drawing.Size(250, 22);
            this.tbMutationChance.TabIndex = 1;
            this.tbMutationChance.TextChanged += new System.EventHandler(this.tbConfig_TextChanged);
            this.tbMutationChance.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // tbPopulationSize
            // 
            this.tbPopulationSize.Location = new System.Drawing.Point(171, 16);
            this.tbPopulationSize.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.tbPopulationSize.Name = "tbPopulationSize";
            this.tbPopulationSize.Size = new System.Drawing.Size(248, 22);
            this.tbPopulationSize.TabIndex = 0;
            this.tbPopulationSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tbPopulationSize.TextChanged += new System.EventHandler(this.tbConfig_TextChanged);
            this.tbPopulationSize.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Mutation chance:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Population size:";
            // 
            // tbcSettings
            // 
            this.tbcSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcSettings.Controls.Add(this.tabPage1);
            this.tbcSettings.Controls.Add(this.tabPage2);
            this.tbcSettings.Location = new System.Drawing.Point(924, 448);
            this.tbcSettings.Name = "tbcSettings";
            this.tbcSettings.SelectedIndex = 0;
            this.tbcSettings.Size = new System.Drawing.Size(433, 343);
            this.tbcSettings.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.cbPartialGenomCrossover);
            this.tabPage1.Controls.Add(this.cbApplyNaturalSelection);
            this.tabPage1.Controls.Add(this.cbApplyElitist);
            this.tabPage1.Controls.Add(this.tbParentChance);
            this.tabPage1.Controls.Add(this.tbMutationChance);
            this.tabPage1.Controls.Add(this.tbPopulationSize);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(425, 314);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Configuration";
            // 
            // cbPartialGenomCrossover
            // 
            this.cbPartialGenomCrossover.AutoSize = true;
            this.cbPartialGenomCrossover.Location = new System.Drawing.Point(169, 155);
            this.cbPartialGenomCrossover.Name = "cbPartialGenomCrossover";
            this.cbPartialGenomCrossover.Size = new System.Drawing.Size(191, 21);
            this.cbPartialGenomCrossover.TabIndex = 4;
            this.cbPartialGenomCrossover.Text = "Partial genome crossover";
            this.cbPartialGenomCrossover.UseVisualStyleBackColor = true;
            this.cbPartialGenomCrossover.CheckedChanged += new System.EventHandler(this.cbConfig_TextChanged);
            // 
            // cbApplyNaturalSelection
            // 
            this.cbApplyNaturalSelection.AutoSize = true;
            this.cbApplyNaturalSelection.Location = new System.Drawing.Point(169, 127);
            this.cbApplyNaturalSelection.Name = "cbApplyNaturalSelection";
            this.cbApplyNaturalSelection.Size = new System.Drawing.Size(173, 21);
            this.cbApplyNaturalSelection.TabIndex = 3;
            this.cbApplyNaturalSelection.Text = "Apply natural selection";
            this.cbApplyNaturalSelection.UseVisualStyleBackColor = true;
            this.cbApplyNaturalSelection.CheckedChanged += new System.EventHandler(this.cbConfig_TextChanged);
            // 
            // cbApplyElitist
            // 
            this.cbApplyElitist.AutoSize = true;
            this.cbApplyElitist.Location = new System.Drawing.Point(169, 99);
            this.cbApplyElitist.Name = "cbApplyElitist";
            this.cbApplyElitist.Size = new System.Drawing.Size(101, 21);
            this.cbApplyElitist.TabIndex = 2;
            this.cbApplyElitist.Text = "Apply elitist";
            this.cbApplyElitist.UseVisualStyleBackColor = true;
            this.cbApplyElitist.CheckedChanged += new System.EventHandler(this.cbConfig_TextChanged);
            // 
            // tbParentChance
            // 
            this.tbParentChance.DecimalPlaces = 5;
            this.tbParentChance.Location = new System.Drawing.Point(169, 70);
            this.tbParentChance.Name = "tbParentChance";
            this.tbParentChance.Size = new System.Drawing.Size(250, 22);
            this.tbParentChance.TabIndex = 1;
            this.tbParentChance.TextChanged += new System.EventHandler(this.tbConfig_TextChanged);
            this.tbParentChance.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(159, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "Choose parent chance: ";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.tbcGameSubSettings);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(425, 314);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Game setting";
            // 
            // tbcGameSubSettings
            // 
            this.tbcGameSubSettings.Controls.Add(this.tabPage5);
            this.tbcGameSubSettings.Controls.Add(this.tabPage3);
            this.tbcGameSubSettings.Controls.Add(this.tabPage4);
            this.tbcGameSubSettings.Location = new System.Drawing.Point(-4, -2);
            this.tbcGameSubSettings.Name = "tbcGameSubSettings";
            this.tbcGameSubSettings.SelectedIndex = 0;
            this.tbcGameSubSettings.Size = new System.Drawing.Size(437, 320);
            this.tbcGameSubSettings.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage5.Controls.Add(this.label11);
            this.tabPage5.Controls.Add(this.nmImportanceWeight);
            this.tabPage5.Controls.Add(this.label15);
            this.tabPage5.Controls.Add(this.nmPriceWeight);
            this.tabPage5.Controls.Add(this.label16);
            this.tabPage5.Controls.Add(this.nmDeadCountWeight);
            this.tabPage5.Controls.Add(this.nmGridSize);
            this.tabPage5.Controls.Add(this.tbEnemyCount);
            this.tabPage5.Controls.Add(this.label2);
            this.tabPage5.Controls.Add(this.label17);
            this.tabPage5.Controls.Add(this.tbFriendlyCount);
            this.tabPage5.Controls.Add(this.label3);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(429, 291);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "General settings";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 151);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(172, 17);
            this.label11.TabIndex = 18;
            this.label11.Text = "Target importance weight:";
            // 
            // nmImportanceWeight
            // 
            this.nmImportanceWeight.DecimalPlaces = 5;
            this.nmImportanceWeight.Location = new System.Drawing.Point(181, 148);
            this.nmImportanceWeight.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nmImportanceWeight.Name = "nmImportanceWeight";
            this.nmImportanceWeight.Size = new System.Drawing.Size(235, 22);
            this.nmImportanceWeight.TabIndex = 19;
            this.nmImportanceWeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmImportanceWeight.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(4, 123);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(92, 17);
            this.label15.TabIndex = 16;
            this.label15.Text = "Price weight: ";
            // 
            // nmPriceWeight
            // 
            this.nmPriceWeight.DecimalPlaces = 5;
            this.nmPriceWeight.Location = new System.Drawing.Point(182, 120);
            this.nmPriceWeight.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nmPriceWeight.Name = "nmPriceWeight";
            this.nmPriceWeight.Size = new System.Drawing.Size(235, 22);
            this.nmPriceWeight.TabIndex = 17;
            this.nmPriceWeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmPriceWeight.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(1, 95);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(133, 17);
            this.label16.TabIndex = 14;
            this.label16.Text = "Dead count weight: ";
            // 
            // nmDeadCountWeight
            // 
            this.nmDeadCountWeight.DecimalPlaces = 5;
            this.nmDeadCountWeight.Location = new System.Drawing.Point(182, 93);
            this.nmDeadCountWeight.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nmDeadCountWeight.Name = "nmDeadCountWeight";
            this.nmDeadCountWeight.Size = new System.Drawing.Size(235, 22);
            this.nmDeadCountWeight.TabIndex = 15;
            this.nmDeadCountWeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmDeadCountWeight.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // nmGridSize
            // 
            this.nmGridSize.Location = new System.Drawing.Point(181, 64);
            this.nmGridSize.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nmGridSize.Name = "nmGridSize";
            this.nmGridSize.Size = new System.Drawing.Size(235, 22);
            this.nmGridSize.TabIndex = 12;
            this.nmGridSize.ValueChanged += new System.EventHandler(this.nmGridSize_ValueChanged);
            // 
            // tbEnemyCount
            // 
            this.tbEnemyCount.Location = new System.Drawing.Point(181, 36);
            this.tbEnemyCount.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.tbEnemyCount.Name = "tbEnemyCount";
            this.tbEnemyCount.Size = new System.Drawing.Size(235, 22);
            this.tbEnemyCount.TabIndex = 12;
            this.tbEnemyCount.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Friendly count:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 67);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(68, 17);
            this.label17.TabIndex = 11;
            this.label17.Text = "Grid size:";
            // 
            // tbFriendlyCount
            // 
            this.tbFriendlyCount.Location = new System.Drawing.Point(181, 10);
            this.tbFriendlyCount.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.tbFriendlyCount.Name = "tbFriendlyCount";
            this.tbFriendlyCount.Size = new System.Drawing.Size(235, 22);
            this.tbFriendlyCount.TabIndex = 13;
            this.tbFriendlyCount.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Enemy count:";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.nmMaxAccuracyForShot);
            this.tabPage3.Controls.Add(this.nmMinAccuracyForShot);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.nmMaxRadius);
            this.tabPage3.Controls.Add(this.nmMinDamage);
            this.tabPage3.Controls.Add(this.nmMaxAmmunition);
            this.tabPage3.Controls.Add(this.nmMinAmmunition);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.nmMinRadius);
            this.tabPage3.Controls.Add(this.nmMaxDamage);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(429, 291);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Dead settings";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 17);
            this.label9.TabIndex = 10;
            this.label9.Text = "Aaccuracy for shot: ";
            // 
            // nmMaxAccuracyForShot
            // 
            this.nmMaxAccuracyForShot.Location = new System.Drawing.Point(339, 93);
            this.nmMaxAccuracyForShot.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nmMaxAccuracyForShot.Name = "nmMaxAccuracyForShot";
            this.nmMaxAccuracyForShot.Size = new System.Drawing.Size(80, 22);
            this.nmMaxAccuracyForShot.TabIndex = 12;
            this.nmMaxAccuracyForShot.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // nmMinAccuracyForShot
            // 
            this.nmMinAccuracyForShot.Location = new System.Drawing.Point(233, 93);
            this.nmMinAccuracyForShot.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nmMinAccuracyForShot.Name = "nmMinAccuracyForShot";
            this.nmMinAccuracyForShot.Size = new System.Drawing.Size(80, 22);
            this.nmMinAccuracyForShot.TabIndex = 11;
            this.nmMinAccuracyForShot.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 17);
            this.label8.TabIndex = 4;
            this.label8.Text = "Damage:";
            // 
            // nmMaxRadius
            // 
            this.nmMaxRadius.Location = new System.Drawing.Point(339, 37);
            this.nmMaxRadius.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nmMaxRadius.Name = "nmMaxRadius";
            this.nmMaxRadius.Size = new System.Drawing.Size(80, 22);
            this.nmMaxRadius.TabIndex = 9;
            this.nmMaxRadius.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // nmMinDamage
            // 
            this.nmMinDamage.DecimalPlaces = 5;
            this.nmMinDamage.Location = new System.Drawing.Point(235, 9);
            this.nmMinDamage.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmMinDamage.Name = "nmMinDamage";
            this.nmMinDamage.Size = new System.Drawing.Size(80, 22);
            this.nmMinDamage.TabIndex = 6;
            this.nmMinDamage.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // nmMaxAmmunition
            // 
            this.nmMaxAmmunition.Location = new System.Drawing.Point(339, 65);
            this.nmMaxAmmunition.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nmMaxAmmunition.Name = "nmMaxAmmunition";
            this.nmMaxAmmunition.Size = new System.Drawing.Size(80, 22);
            this.nmMaxAmmunition.TabIndex = 9;
            this.nmMaxAmmunition.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // nmMinAmmunition
            // 
            this.nmMinAmmunition.Location = new System.Drawing.Point(234, 65);
            this.nmMinAmmunition.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nmMinAmmunition.Name = "nmMinAmmunition";
            this.nmMinAmmunition.Size = new System.Drawing.Size(80, 22);
            this.nmMinAmmunition.TabIndex = 7;
            this.nmMinAmmunition.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Radius:";
            // 
            // nmMinRadius
            // 
            this.nmMinRadius.Location = new System.Drawing.Point(235, 37);
            this.nmMinRadius.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nmMinRadius.Name = "nmMinRadius";
            this.nmMinRadius.Size = new System.Drawing.Size(80, 22);
            this.nmMinRadius.TabIndex = 7;
            this.nmMinRadius.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // nmMaxDamage
            // 
            this.nmMaxDamage.DecimalPlaces = 5;
            this.nmMaxDamage.Location = new System.Drawing.Point(339, 9);
            this.nmMaxDamage.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmMaxDamage.Name = "nmMaxDamage";
            this.nmMaxDamage.Size = new System.Drawing.Size(80, 22);
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
            this.label13.Location = new System.Drawing.Point(6, 67);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(85, 17);
            this.label13.TabIndex = 2;
            this.label13.Text = "Ammunition:";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Controls.Add(this.label14);
            this.tabPage4.Controls.Add(this.nmMaxImportance);
            this.tabPage4.Controls.Add(this.nmMinImportance);
            this.tabPage4.Controls.Add(this.nmMaxPricePerShot);
            this.tabPage4.Controls.Add(this.nmMinPricePerShot);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(429, 291);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Extra settings";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 17);
            this.label7.TabIndex = 2;
            this.label7.Text = "Target importance";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 15);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 17);
            this.label14.TabIndex = 2;
            this.label14.Text = "Price per shot:";
            // 
            // nmMaxImportance
            // 
            this.nmMaxImportance.Location = new System.Drawing.Point(339, 41);
            this.nmMaxImportance.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nmMaxImportance.Name = "nmMaxImportance";
            this.nmMaxImportance.Size = new System.Drawing.Size(80, 22);
            this.nmMaxImportance.TabIndex = 9;
            this.nmMaxImportance.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // nmMinImportance
            // 
            this.nmMinImportance.Location = new System.Drawing.Point(253, 41);
            this.nmMinImportance.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nmMinImportance.Name = "nmMinImportance";
            this.nmMinImportance.Size = new System.Drawing.Size(80, 22);
            this.nmMinImportance.TabIndex = 7;
            this.nmMinImportance.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // nmMaxPricePerShot
            // 
            this.nmMaxPricePerShot.Location = new System.Drawing.Point(339, 13);
            this.nmMaxPricePerShot.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nmMaxPricePerShot.Name = "nmMaxPricePerShot";
            this.nmMaxPricePerShot.Size = new System.Drawing.Size(80, 22);
            this.nmMaxPricePerShot.TabIndex = 9;
            this.nmMaxPricePerShot.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // nmMinPricePerShot
            // 
            this.nmMinPricePerShot.Location = new System.Drawing.Point(253, 13);
            this.nmMinPricePerShot.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nmMinPricePerShot.Name = "nmMinPricePerShot";
            this.nmMinPricePerShot.Size = new System.Drawing.Size(80, 22);
            this.nmMinPricePerShot.TabIndex = 7;
            this.nmMinPricePerShot.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // ipStrategy
            // 
            this.ipStrategy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ipStrategy.DrawFunction = null;
            this.ipStrategy.Location = new System.Drawing.Point(13, 16);
            this.ipStrategy.Name = "ipStrategy";
            this.ipStrategy.ScaleFactor = 25;
            this.ipStrategy.Size = new System.Drawing.Size(455, 778);
            this.ipStrategy.TabIndex = 10;
            point2D1.X = 0D;
            point2D1.Y = 0D;
            this.ipStrategy.TransformOrigin = point2D1;
            this.ipStrategy.UpdateFunction = null;
            // 
            // ipStatus
            // 
            this.ipStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ipStatus.DrawFunction = null;
            this.ipStatus.Location = new System.Drawing.Point(475, 16);
            this.ipStatus.Name = "ipStatus";
            this.ipStatus.ScaleFactor = 25;
            this.ipStatus.Size = new System.Drawing.Size(447, 286);
            this.ipStatus.TabIndex = 11;
            point2D2.X = 0D;
            point2D2.Y = 0D;
            this.ipStatus.TransformOrigin = point2D2;
            this.ipStatus.UpdateFunction = null;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1369, 806);
            this.Controls.Add(this.ipStatus);
            this.Controls.Add(this.ipStrategy);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbcSettings);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numCycles)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMutationChance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPopulationSize)).EndInit();
            this.tbcSettings.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbParentChance)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tbcGameSubSettings.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmImportanceWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmPriceWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmDeadCountWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmGridSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbEnemyCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFriendlyCount)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmMaxAccuracyForShot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmMinAccuracyForShot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmMaxRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmMinDamage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmMaxAmmunition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmMinAmmunition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmMinRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmMaxDamage)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmMaxImportance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmMinImportance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmMaxPricePerShot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmMinPricePerShot)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnGeneratePopulation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numCycles;
        private System.Windows.Forms.Label lblGenerationCount;
        private System.Windows.Forms.Label lblAverageFitness;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblBestFitness;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRestrategize;
        private System.Windows.Forms.NumericUpDown tbMutationChance;
        private System.Windows.Forms.NumericUpDown tbPopulationSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tbcSettings;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.NumericUpDown nmMinDamage;
        private System.Windows.Forms.NumericUpDown nmMinRadius;
        private System.Windows.Forms.NumericUpDown nmMaxDamage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nmMaxRadius;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nmMinAmmunition;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown nmMaxAmmunition;
        private System.Windows.Forms.NumericUpDown tbParentChance;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown tbEnemyCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown tbFriendlyCount;
        private System.Windows.Forms.CheckBox cbApplyElitist;
        private System.Windows.Forms.NumericUpDown nmMinPricePerShot;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown nmMaxPricePerShot;
        private System.Windows.Forms.Label lblBestTotalPrice;
        private System.Windows.Forms.Label lblBestDeadCount;
        private System.Windows.Forms.TabControl tbcGameSubSettings;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.NumericUpDown nmGridSize;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown nmPriceWeight;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown nmDeadCountWeight;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nmMaxAccuracyForShot;
        private System.Windows.Forms.NumericUpDown nmMinAccuracyForShot;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nmMaxImportance;
        private System.Windows.Forms.NumericUpDown nmMinImportance;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown nmImportanceWeight;
        private System.Windows.Forms.Label lblTotalImportance;
        private System.Windows.Forms.CheckBox cbApplyNaturalSelection;
        private System.Windows.Forms.CheckBox cbPartialGenomCrossover;
        private System.Windows.Forms.Timer timer1;
        private InteractivePanel ipStrategy;
        private InteractivePanel ipStatus;
    }
}

