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
            this.cbSingleTargetGenome = new System.Windows.Forms.CheckBox();
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
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.cbFixedStrategy = new System.Windows.Forms.CheckBox();
            this.nmThreadBulkSize = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
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
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmThreadBulkSize)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGeneratePopulation
            // 
            this.btnGeneratePopulation.Enabled = false;
            this.btnGeneratePopulation.Location = new System.Drawing.Point(88, 28);
            this.btnGeneratePopulation.Name = "btnGeneratePopulation";
            this.btnGeneratePopulation.Size = new System.Drawing.Size(234, 68);
            this.btnGeneratePopulation.TabIndex = 2;
            this.btnGeneratePopulation.Text = "Generate Population";
            this.btnGeneratePopulation.UseVisualStyleBackColor = true;
            this.btnGeneratePopulation.Click += new System.EventHandler(this.btnGeneratePopulation_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number of generations:";
            // 
            // numCycles
            // 
            this.numCycles.Location = new System.Drawing.Point(145, 4);
            this.numCycles.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numCycles.Name = "numCycles";
            this.numCycles.Size = new System.Drawing.Size(177, 20);
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
            this.lblGenerationCount.Location = new System.Drawing.Point(3, 142);
            this.lblGenerationCount.Name = "lblGenerationCount";
            this.lblGenerationCount.Size = new System.Drawing.Size(122, 15);
            this.lblGenerationCount.TabIndex = 5;
            this.lblGenerationCount.Text = "Current generation: 0";
            // 
            // lblAverageFitness
            // 
            this.lblAverageFitness.AutoSize = true;
            this.lblAverageFitness.Location = new System.Drawing.Point(3, 167);
            this.lblAverageFitness.Name = "lblAverageFitness";
            this.lblAverageFitness.Size = new System.Drawing.Size(102, 15);
            this.lblAverageFitness.TabIndex = 5;
            this.lblAverageFitness.Text = "Average fitness: 0";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(5, 28);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(76, 68);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start!";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblBestFitness
            // 
            this.lblBestFitness.AutoSize = true;
            this.lblBestFitness.Location = new System.Drawing.Point(3, 196);
            this.lblBestFitness.Name = "lblBestFitness";
            this.lblBestFitness.Size = new System.Drawing.Size(82, 15);
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
            this.panel1.Location = new System.Drawing.Point(855, 13);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(325, 346);
            this.panel1.TabIndex = 8;
            // 
            // lblTotalImportance
            // 
            this.lblTotalImportance.AutoSize = true;
            this.lblTotalImportance.Location = new System.Drawing.Point(3, 262);
            this.lblTotalImportance.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalImportance.Name = "lblTotalImportance";
            this.lblTotalImportance.Size = new System.Drawing.Size(135, 15);
            this.lblTotalImportance.TabIndex = 10;
            this.lblTotalImportance.Text = "Best total importance: 0";
            // 
            // lblBestTotalPrice
            // 
            this.lblBestTotalPrice.AutoSize = true;
            this.lblBestTotalPrice.Location = new System.Drawing.Point(3, 241);
            this.lblBestTotalPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBestTotalPrice.Name = "lblBestTotalPrice";
            this.lblBestTotalPrice.Size = new System.Drawing.Size(100, 15);
            this.lblBestTotalPrice.TabIndex = 10;
            this.lblBestTotalPrice.Text = "Best total price: 0";
            // 
            // lblBestDeadCount
            // 
            this.lblBestDeadCount.AutoSize = true;
            this.lblBestDeadCount.Location = new System.Drawing.Point(3, 219);
            this.lblBestDeadCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBestDeadCount.Name = "lblBestDeadCount";
            this.lblBestDeadCount.Size = new System.Drawing.Size(111, 15);
            this.lblBestDeadCount.TabIndex = 10;
            this.lblBestDeadCount.Text = "Best dead count : 0";
            // 
            // btnRestrategize
            // 
            this.btnRestrategize.Enabled = false;
            this.btnRestrategize.Location = new System.Drawing.Point(5, 102);
            this.btnRestrategize.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRestrategize.Name = "btnRestrategize";
            this.btnRestrategize.Size = new System.Drawing.Size(316, 37);
            this.btnRestrategize.TabIndex = 9;
            this.btnRestrategize.Text = "New Formation";
            this.btnRestrategize.UseVisualStyleBackColor = true;
            this.btnRestrategize.Click += new System.EventHandler(this.btnRestrategize_Click);
            // 
            // tbMutationChance
            // 
            this.tbMutationChance.DecimalPlaces = 5;
            this.tbMutationChance.Location = new System.Drawing.Point(127, 34);
            this.tbMutationChance.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbMutationChance.Name = "tbMutationChance";
            this.tbMutationChance.Size = new System.Drawing.Size(188, 20);
            this.tbMutationChance.TabIndex = 1;
            this.tbMutationChance.TextChanged += new System.EventHandler(this.tbConfig_TextChanged);
            this.tbMutationChance.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // tbPopulationSize
            // 
            this.tbPopulationSize.Location = new System.Drawing.Point(128, 13);
            this.tbPopulationSize.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbPopulationSize.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.tbPopulationSize.Name = "tbPopulationSize";
            this.tbPopulationSize.Size = new System.Drawing.Size(186, 20);
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
            this.label5.Location = new System.Drawing.Point(4, 36);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Mutation chance:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 13);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Population size:";
            // 
            // tbcSettings
            // 
            this.tbcSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcSettings.Controls.Add(this.tabPage1);
            this.tbcSettings.Controls.Add(this.tabPage2);
            this.tbcSettings.Controls.Add(this.tabPage6);
            this.tbcSettings.Location = new System.Drawing.Point(852, 364);
            this.tbcSettings.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbcSettings.Name = "tbcSettings";
            this.tbcSettings.SelectedIndex = 0;
            this.tbcSettings.Size = new System.Drawing.Size(325, 391);
            this.tbcSettings.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.cbSingleTargetGenome);
            this.tabPage1.Controls.Add(this.cbPartialGenomCrossover);
            this.tabPage1.Controls.Add(this.cbApplyNaturalSelection);
            this.tabPage1.Controls.Add(this.cbApplyElitist);
            this.tabPage1.Controls.Add(this.tbParentChance);
            this.tabPage1.Controls.Add(this.tbMutationChance);
            this.tabPage1.Controls.Add(this.tbPopulationSize);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Size = new System.Drawing.Size(317, 365);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Configuration";
            // 
            // cbSingleTargetGenome
            // 
            this.cbSingleTargetGenome.AutoSize = true;
            this.cbSingleTargetGenome.Location = new System.Drawing.Point(127, 149);
            this.cbSingleTargetGenome.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbSingleTargetGenome.Name = "cbSingleTargetGenome";
            this.cbSingleTargetGenome.Size = new System.Drawing.Size(147, 19);
            this.cbSingleTargetGenome.TabIndex = 5;
            this.cbSingleTargetGenome.Text = "Single target genome";
            this.cbSingleTargetGenome.UseVisualStyleBackColor = true;
            this.cbSingleTargetGenome.CheckedChanged += new System.EventHandler(this.cbConfig_TextChanged);
            // 
            // cbPartialGenomCrossover
            // 
            this.cbPartialGenomCrossover.AutoSize = true;
            this.cbPartialGenomCrossover.Location = new System.Drawing.Point(127, 126);
            this.cbPartialGenomCrossover.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbPartialGenomCrossover.Name = "cbPartialGenomCrossover";
            this.cbPartialGenomCrossover.Size = new System.Drawing.Size(168, 19);
            this.cbPartialGenomCrossover.TabIndex = 4;
            this.cbPartialGenomCrossover.Text = "Partial genome crossover";
            this.cbPartialGenomCrossover.UseVisualStyleBackColor = true;
            this.cbPartialGenomCrossover.CheckedChanged += new System.EventHandler(this.cbConfig_TextChanged);
            // 
            // cbApplyNaturalSelection
            // 
            this.cbApplyNaturalSelection.AutoSize = true;
            this.cbApplyNaturalSelection.Location = new System.Drawing.Point(127, 103);
            this.cbApplyNaturalSelection.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbApplyNaturalSelection.Name = "cbApplyNaturalSelection";
            this.cbApplyNaturalSelection.Size = new System.Drawing.Size(151, 19);
            this.cbApplyNaturalSelection.TabIndex = 3;
            this.cbApplyNaturalSelection.Text = "Apply natural selection";
            this.cbApplyNaturalSelection.UseVisualStyleBackColor = true;
            this.cbApplyNaturalSelection.CheckedChanged += new System.EventHandler(this.cbConfig_TextChanged);
            // 
            // cbApplyElitist
            // 
            this.cbApplyElitist.AutoSize = true;
            this.cbApplyElitist.Location = new System.Drawing.Point(127, 80);
            this.cbApplyElitist.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbApplyElitist.Name = "cbApplyElitist";
            this.cbApplyElitist.Size = new System.Drawing.Size(89, 19);
            this.cbApplyElitist.TabIndex = 2;
            this.cbApplyElitist.Text = "Apply elitist";
            this.cbApplyElitist.UseVisualStyleBackColor = true;
            this.cbApplyElitist.CheckedChanged += new System.EventHandler(this.cbConfig_TextChanged);
            // 
            // tbParentChance
            // 
            this.tbParentChance.DecimalPlaces = 5;
            this.tbParentChance.Location = new System.Drawing.Point(127, 57);
            this.tbParentChance.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbParentChance.Name = "tbParentChance";
            this.tbParentChance.Size = new System.Drawing.Size(188, 20);
            this.tbParentChance.TabIndex = 1;
            this.tbParentChance.TextChanged += new System.EventHandler(this.tbConfig_TextChanged);
            this.tbParentChance.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 58);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(136, 15);
            this.label10.TabIndex = 0;
            this.label10.Text = "Choose parent chance: ";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.tbcGameSubSettings);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Size = new System.Drawing.Size(317, 253);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Game setting";
            // 
            // tbcGameSubSettings
            // 
            this.tbcGameSubSettings.Controls.Add(this.tabPage5);
            this.tbcGameSubSettings.Controls.Add(this.tabPage3);
            this.tbcGameSubSettings.Controls.Add(this.tabPage4);
            this.tbcGameSubSettings.Location = new System.Drawing.Point(-3, -2);
            this.tbcGameSubSettings.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbcGameSubSettings.Name = "tbcGameSubSettings";
            this.tbcGameSubSettings.SelectedIndex = 0;
            this.tbcGameSubSettings.Size = new System.Drawing.Size(328, 260);
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
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(320, 234);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "General settings";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(2, 123);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(149, 15);
            this.label11.TabIndex = 18;
            this.label11.Text = "Target importance weight:";
            // 
            // nmImportanceWeight
            // 
            this.nmImportanceWeight.DecimalPlaces = 5;
            this.nmImportanceWeight.Location = new System.Drawing.Point(136, 120);
            this.nmImportanceWeight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nmImportanceWeight.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nmImportanceWeight.Name = "nmImportanceWeight";
            this.nmImportanceWeight.Size = new System.Drawing.Size(176, 20);
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
            this.label15.Location = new System.Drawing.Point(3, 100);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 15);
            this.label15.TabIndex = 16;
            this.label15.Text = "Price weight: ";
            // 
            // nmPriceWeight
            // 
            this.nmPriceWeight.DecimalPlaces = 5;
            this.nmPriceWeight.Location = new System.Drawing.Point(136, 98);
            this.nmPriceWeight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nmPriceWeight.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nmPriceWeight.Name = "nmPriceWeight";
            this.nmPriceWeight.Size = new System.Drawing.Size(176, 20);
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
            this.label16.Location = new System.Drawing.Point(1, 77);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(115, 15);
            this.label16.TabIndex = 14;
            this.label16.Text = "Dead count weight: ";
            // 
            // nmDeadCountWeight
            // 
            this.nmDeadCountWeight.DecimalPlaces = 5;
            this.nmDeadCountWeight.Location = new System.Drawing.Point(136, 76);
            this.nmDeadCountWeight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nmDeadCountWeight.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nmDeadCountWeight.Name = "nmDeadCountWeight";
            this.nmDeadCountWeight.Size = new System.Drawing.Size(176, 20);
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
            this.nmGridSize.Location = new System.Drawing.Point(136, 52);
            this.nmGridSize.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nmGridSize.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nmGridSize.Name = "nmGridSize";
            this.nmGridSize.Size = new System.Drawing.Size(176, 20);
            this.nmGridSize.TabIndex = 12;
            this.nmGridSize.ValueChanged += new System.EventHandler(this.nmGridSize_ValueChanged);
            // 
            // tbEnemyCount
            // 
            this.tbEnemyCount.Location = new System.Drawing.Point(136, 29);
            this.tbEnemyCount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbEnemyCount.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.tbEnemyCount.Name = "tbEnemyCount";
            this.tbEnemyCount.Size = new System.Drawing.Size(176, 20);
            this.tbEnemyCount.TabIndex = 12;
            this.tbEnemyCount.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Friendly count:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(2, 54);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(58, 15);
            this.label17.TabIndex = 11;
            this.label17.Text = "Grid size:";
            // 
            // tbFriendlyCount
            // 
            this.tbFriendlyCount.Location = new System.Drawing.Point(136, 8);
            this.tbFriendlyCount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbFriendlyCount.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.tbFriendlyCount.Name = "tbFriendlyCount";
            this.tbFriendlyCount.Size = new System.Drawing.Size(176, 20);
            this.tbFriendlyCount.TabIndex = 13;
            this.tbFriendlyCount.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 32);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 15);
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
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage3.Size = new System.Drawing.Size(320, 234);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Dead settings";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 77);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 15);
            this.label9.TabIndex = 10;
            this.label9.Text = "Aaccuracy for shot: ";
            // 
            // nmMaxAccuracyForShot
            // 
            this.nmMaxAccuracyForShot.Location = new System.Drawing.Point(254, 76);
            this.nmMaxAccuracyForShot.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nmMaxAccuracyForShot.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nmMaxAccuracyForShot.Name = "nmMaxAccuracyForShot";
            this.nmMaxAccuracyForShot.Size = new System.Drawing.Size(60, 20);
            this.nmMaxAccuracyForShot.TabIndex = 12;
            this.nmMaxAccuracyForShot.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // nmMinAccuracyForShot
            // 
            this.nmMinAccuracyForShot.Location = new System.Drawing.Point(175, 76);
            this.nmMinAccuracyForShot.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nmMinAccuracyForShot.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nmMinAccuracyForShot.Name = "nmMinAccuracyForShot";
            this.nmMinAccuracyForShot.Size = new System.Drawing.Size(60, 20);
            this.nmMinAccuracyForShot.TabIndex = 11;
            this.nmMinAccuracyForShot.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 9);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 15);
            this.label8.TabIndex = 4;
            this.label8.Text = "Damage:";
            // 
            // nmMaxRadius
            // 
            this.nmMaxRadius.Location = new System.Drawing.Point(254, 30);
            this.nmMaxRadius.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nmMaxRadius.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nmMaxRadius.Name = "nmMaxRadius";
            this.nmMaxRadius.Size = new System.Drawing.Size(60, 20);
            this.nmMaxRadius.TabIndex = 9;
            this.nmMaxRadius.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // nmMinDamage
            // 
            this.nmMinDamage.DecimalPlaces = 5;
            this.nmMinDamage.Location = new System.Drawing.Point(176, 7);
            this.nmMinDamage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nmMinDamage.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmMinDamage.Name = "nmMinDamage";
            this.nmMinDamage.Size = new System.Drawing.Size(60, 20);
            this.nmMinDamage.TabIndex = 6;
            this.nmMinDamage.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // nmMaxAmmunition
            // 
            this.nmMaxAmmunition.Location = new System.Drawing.Point(254, 53);
            this.nmMaxAmmunition.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nmMaxAmmunition.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nmMaxAmmunition.Name = "nmMaxAmmunition";
            this.nmMaxAmmunition.Size = new System.Drawing.Size(60, 20);
            this.nmMaxAmmunition.TabIndex = 9;
            this.nmMaxAmmunition.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // nmMinAmmunition
            // 
            this.nmMinAmmunition.Location = new System.Drawing.Point(176, 53);
            this.nmMinAmmunition.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nmMinAmmunition.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nmMinAmmunition.Name = "nmMinAmmunition";
            this.nmMinAmmunition.Size = new System.Drawing.Size(60, 20);
            this.nmMinAmmunition.TabIndex = 7;
            this.nmMinAmmunition.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 32);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Radius:";
            // 
            // nmMinRadius
            // 
            this.nmMinRadius.Location = new System.Drawing.Point(176, 30);
            this.nmMinRadius.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nmMinRadius.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nmMinRadius.Name = "nmMinRadius";
            this.nmMinRadius.Size = new System.Drawing.Size(60, 20);
            this.nmMinRadius.TabIndex = 7;
            this.nmMinRadius.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // nmMaxDamage
            // 
            this.nmMaxDamage.DecimalPlaces = 5;
            this.nmMaxDamage.Location = new System.Drawing.Point(254, 7);
            this.nmMaxDamage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nmMaxDamage.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmMaxDamage.Name = "nmMaxDamage";
            this.nmMaxDamage.Size = new System.Drawing.Size(60, 20);
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
            this.label13.Location = new System.Drawing.Point(4, 54);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 15);
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
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage4.Size = new System.Drawing.Size(320, 234);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Extra settings";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 35);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "Target importance";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(4, 12);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(85, 15);
            this.label14.TabIndex = 2;
            this.label14.Text = "Price per shot:";
            // 
            // nmMaxImportance
            // 
            this.nmMaxImportance.Location = new System.Drawing.Point(254, 33);
            this.nmMaxImportance.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nmMaxImportance.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nmMaxImportance.Name = "nmMaxImportance";
            this.nmMaxImportance.Size = new System.Drawing.Size(60, 20);
            this.nmMaxImportance.TabIndex = 9;
            this.nmMaxImportance.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // nmMinImportance
            // 
            this.nmMinImportance.Location = new System.Drawing.Point(190, 33);
            this.nmMinImportance.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nmMinImportance.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nmMinImportance.Name = "nmMinImportance";
            this.nmMinImportance.Size = new System.Drawing.Size(60, 20);
            this.nmMinImportance.TabIndex = 7;
            this.nmMinImportance.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // nmMaxPricePerShot
            // 
            this.nmMaxPricePerShot.Location = new System.Drawing.Point(254, 11);
            this.nmMaxPricePerShot.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nmMaxPricePerShot.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nmMaxPricePerShot.Name = "nmMaxPricePerShot";
            this.nmMaxPricePerShot.Size = new System.Drawing.Size(60, 20);
            this.nmMaxPricePerShot.TabIndex = 9;
            this.nmMaxPricePerShot.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // nmMinPricePerShot
            // 
            this.nmMinPricePerShot.Location = new System.Drawing.Point(190, 11);
            this.nmMinPricePerShot.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nmMinPricePerShot.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nmMinPricePerShot.Name = "nmMinPricePerShot";
            this.nmMinPricePerShot.Size = new System.Drawing.Size(60, 20);
            this.nmMinPricePerShot.TabIndex = 7;
            this.nmMinPricePerShot.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage6.Controls.Add(this.cbFixedStrategy);
            this.tabPage6.Controls.Add(this.nmThreadBulkSize);
            this.tabPage6.Controls.Add(this.label12);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(317, 253);
            this.tabPage6.TabIndex = 2;
            this.tabPage6.Text = "Performance";
            // 
            // cbFixedStrategy
            // 
            this.cbFixedStrategy.AutoSize = true;
            this.cbFixedStrategy.Location = new System.Drawing.Point(127, 36);
            this.cbFixedStrategy.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbFixedStrategy.Name = "cbFixedStrategy";
            this.cbFixedStrategy.Size = new System.Drawing.Size(104, 19);
            this.cbFixedStrategy.TabIndex = 6;
            this.cbFixedStrategy.Text = "Fixed strategy";
            this.cbFixedStrategy.UseVisualStyleBackColor = true;
            this.cbFixedStrategy.CheckedChanged += new System.EventHandler(this.cbConfig_TextChanged);
            // 
            // nmThreadBulkSize
            // 
            this.nmThreadBulkSize.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nmThreadBulkSize.Location = new System.Drawing.Point(127, 13);
            this.nmThreadBulkSize.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nmThreadBulkSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nmThreadBulkSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmThreadBulkSize.Name = "nmThreadBulkSize";
            this.nmThreadBulkSize.Size = new System.Drawing.Size(186, 20);
            this.nmThreadBulkSize.TabIndex = 1;
            this.nmThreadBulkSize.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nmThreadBulkSize.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 13);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 15);
            this.label12.TabIndex = 2;
            this.label12.Text = "Thread bulk size:";
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
            this.ipStrategy.Location = new System.Drawing.Point(10, 13);
            this.ipStrategy.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ipStrategy.Name = "ipStrategy";
            this.ipStrategy.ScaleFactor = 25;
            this.ipStrategy.Size = new System.Drawing.Size(500, 744);
            this.ipStrategy.TabIndex = 10;
            this.ipStrategy.TransformOrigin = point2D1;
            this.ipStrategy.UpdateFunction = null;
            // 
            // ipStatus
            // 
            this.ipStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ipStatus.DrawFunction = null;
            this.ipStatus.Location = new System.Drawing.Point(515, 13);
            this.ipStatus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ipStatus.Name = "ipStatus";
            this.ipStatus.ScaleFactor = 25;
            this.ipStatus.Size = new System.Drawing.Size(335, 232);
            this.ipStatus.TabIndex = 11;
            this.ipStatus.TransformOrigin = point2D2;
            this.ipStatus.UpdateFunction = null;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 767);
            this.Controls.Add(this.ipStatus);
            this.Controls.Add(this.ipStrategy);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbcSettings);
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
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmThreadBulkSize)).EndInit();
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
        private System.Windows.Forms.CheckBox cbSingleTargetGenome;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.NumericUpDown nmThreadBulkSize;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox cbFixedStrategy;
    }
}

