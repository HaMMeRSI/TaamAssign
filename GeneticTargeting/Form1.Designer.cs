namespace TaamAssign
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
            Library.Point2D point2D3 = new Library.Point2D();
            this.btnGeneratePopulation = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numCycles = new System.Windows.Forms.NumericUpDown();
            this.lblGenerationCount = new System.Windows.Forms.Label();
            this.lblAverageFitness = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblBestFitness = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.cbFixedStrategy = new System.Windows.Forms.CheckBox();
            this.nmThreadBulkSize = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ipBattalionToSectorSum = new TaamAssign.InteractivePanel();
            this.ipStatus = new TaamAssign.InteractivePanel();
            this.ipStrategy = new TaamAssign.InteractivePanel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.nmBattalionCount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nmSectorCount = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.cbSwitchMutation = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numCycles)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMutationChance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPopulationSize)).BeginInit();
            this.tbcSettings.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbParentChance)).BeginInit();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmThreadBulkSize)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmBattalionCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmSectorCount)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGeneratePopulation
            // 
            this.btnGeneratePopulation.Enabled = false;
            this.btnGeneratePopulation.Location = new System.Drawing.Point(104, 28);
            this.btnGeneratePopulation.Name = "btnGeneratePopulation";
            this.btnGeneratePopulation.Size = new System.Drawing.Size(238, 68);
            this.btnGeneratePopulation.TabIndex = 2;
            this.btnGeneratePopulation.Text = "Generate Population";
            this.btnGeneratePopulation.UseVisualStyleBackColor = true;
            this.btnGeneratePopulation.Click += new System.EventHandler(this.btnGeneratePopulation_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number of generations:";
            // 
            // numCycles
            // 
            this.numCycles.Location = new System.Drawing.Point(140, 5);
            this.numCycles.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numCycles.Name = "numCycles";
            this.numCycles.Size = new System.Drawing.Size(201, 20);
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
            this.btnStart.Location = new System.Drawing.Point(6, 28);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(92, 68);
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
            this.panel1.Controls.Add(this.btnRestrategize);
            this.panel1.Controls.Add(this.lblBestFitness);
            this.panel1.Controls.Add(this.lblAverageFitness);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblGenerationCount);
            this.panel1.Controls.Add(this.btnGeneratePopulation);
            this.panel1.Controls.Add(this.numCycles);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Location = new System.Drawing.Point(882, 13);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(346, 292);
            this.panel1.TabIndex = 8;
            // 
            // btnRestrategize
            // 
            this.btnRestrategize.Enabled = false;
            this.btnRestrategize.Location = new System.Drawing.Point(6, 103);
            this.btnRestrategize.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRestrategize.Name = "btnRestrategize";
            this.btnRestrategize.Size = new System.Drawing.Size(336, 37);
            this.btnRestrategize.TabIndex = 9;
            this.btnRestrategize.Text = "New Formation";
            this.btnRestrategize.UseVisualStyleBackColor = true;
            this.btnRestrategize.Click += new System.EventHandler(this.btnRestrategize_Click);
            // 
            // tbMutationChance
            // 
            this.tbMutationChance.DecimalPlaces = 5;
            this.tbMutationChance.Location = new System.Drawing.Point(140, 34);
            this.tbMutationChance.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbMutationChance.Name = "tbMutationChance";
            this.tbMutationChance.Size = new System.Drawing.Size(194, 20);
            this.tbMutationChance.TabIndex = 1;
            this.tbMutationChance.TextChanged += new System.EventHandler(this.tbConfig_TextChanged);
            this.tbMutationChance.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // tbPopulationSize
            // 
            this.tbPopulationSize.Location = new System.Drawing.Point(141, 13);
            this.tbPopulationSize.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbPopulationSize.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.tbPopulationSize.Name = "tbPopulationSize";
            this.tbPopulationSize.Size = new System.Drawing.Size(192, 20);
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
            this.tbcSettings.Location = new System.Drawing.Point(882, 309);
            this.tbcSettings.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbcSettings.Name = "tbcSettings";
            this.tbcSettings.SelectedIndex = 0;
            this.tbcSettings.Size = new System.Drawing.Size(346, 399);
            this.tbcSettings.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.cbSwitchMutation);
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
            this.tabPage1.Size = new System.Drawing.Size(338, 373);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Configuration";
            // 
            // cbPartialGenomCrossover
            // 
            this.cbPartialGenomCrossover.AutoSize = true;
            this.cbPartialGenomCrossover.Location = new System.Drawing.Point(140, 128);
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
            this.cbApplyNaturalSelection.Location = new System.Drawing.Point(140, 105);
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
            this.cbApplyElitist.Location = new System.Drawing.Point(140, 82);
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
            this.tbParentChance.Location = new System.Drawing.Point(140, 57);
            this.tbParentChance.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbParentChance.Name = "tbParentChance";
            this.tbParentChance.Size = new System.Drawing.Size(194, 20);
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
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage6.Controls.Add(this.cbFixedStrategy);
            this.tabPage6.Controls.Add(this.nmThreadBulkSize);
            this.tabPage6.Controls.Add(this.label12);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(338, 373);
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
            this.nmThreadBulkSize.Size = new System.Drawing.Size(204, 20);
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
            // ipBattalionToSectorSum
            // 
            this.ipBattalionToSectorSum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ipBattalionToSectorSum.DrawFunction = null;
            this.ipBattalionToSectorSum.Location = new System.Drawing.Point(570, 210);
            this.ipBattalionToSectorSum.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ipBattalionToSectorSum.Name = "ipBattalionToSectorSum";
            this.ipBattalionToSectorSum.ScaleFactor = 25;
            this.ipBattalionToSectorSum.Size = new System.Drawing.Size(308, 498);
            this.ipBattalionToSectorSum.TabIndex = 11;
            this.ipBattalionToSectorSum.TransformOrigin = point2D1;
            this.ipBattalionToSectorSum.UpdateFunction = null;
            // 
            // ipStatus
            // 
            this.ipStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ipStatus.DrawFunction = null;
            this.ipStatus.Location = new System.Drawing.Point(572, 13);
            this.ipStatus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ipStatus.Name = "ipStatus";
            this.ipStatus.ScaleFactor = 25;
            this.ipStatus.Size = new System.Drawing.Size(308, 193);
            this.ipStatus.TabIndex = 11;
            this.ipStatus.TransformOrigin = point2D2;
            this.ipStatus.UpdateFunction = null;
            // 
            // ipStrategy
            // 
            this.ipStrategy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ipStrategy.DrawFunction = null;
            this.ipStrategy.Location = new System.Drawing.Point(9, 13);
            this.ipStrategy.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ipStrategy.Name = "ipStrategy";
            this.ipStrategy.ScaleFactor = 25;
            this.ipStrategy.Size = new System.Drawing.Size(557, 695);
            this.ipStrategy.TabIndex = 10;
            this.ipStrategy.TransformOrigin = point2D3;
            this.ipStrategy.UpdateFunction = null;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tabControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(338, 373);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "Assignment";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(6, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(326, 361);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.nmSectorCount);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.nmBattalionCount);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(318, 335);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Structure";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // nmBattalionCount
            // 
            this.nmBattalionCount.Location = new System.Drawing.Point(121, 5);
            this.nmBattalionCount.Margin = new System.Windows.Forms.Padding(2);
            this.nmBattalionCount.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nmBattalionCount.Name = "nmBattalionCount";
            this.nmBattalionCount.Size = new System.Drawing.Size(192, 20);
            this.nmBattalionCount.TabIndex = 1;
            this.nmBattalionCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmBattalionCount.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Battalion Count:";
            // 
            // nmSectorCount
            // 
            this.nmSectorCount.Location = new System.Drawing.Point(121, 30);
            this.nmSectorCount.Margin = new System.Windows.Forms.Padding(2);
            this.nmSectorCount.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nmSectorCount.Name = "nmSectorCount";
            this.nmSectorCount.Size = new System.Drawing.Size(192, 20);
            this.nmSectorCount.TabIndex = 3;
            this.nmSectorCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmSectorCount.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 32);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Serctor Count:";
            // 
            // cbSwitchMutation
            // 
            this.cbSwitchMutation.AutoSize = true;
            this.cbSwitchMutation.Location = new System.Drawing.Point(140, 151);
            this.cbSwitchMutation.Margin = new System.Windows.Forms.Padding(2);
            this.cbSwitchMutation.Name = "cbSwitchMutation";
            this.cbSwitchMutation.Size = new System.Drawing.Size(116, 19);
            this.cbSwitchMutation.TabIndex = 5;
            this.cbSwitchMutation.Text = "Switch mutation";
            this.cbSwitchMutation.UseVisualStyleBackColor = true;
            this.cbSwitchMutation.CheckedChanged += new System.EventHandler(this.cbConfig_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1235, 717);
            this.Controls.Add(this.ipBattalionToSectorSum);
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
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmThreadBulkSize)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmBattalionCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmSectorCount)).EndInit();
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
        private System.Windows.Forms.NumericUpDown tbParentChance;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox cbApplyElitist;
        private System.Windows.Forms.CheckBox cbApplyNaturalSelection;
        private System.Windows.Forms.CheckBox cbPartialGenomCrossover;
        private System.Windows.Forms.Timer timer1;
        private InteractivePanel ipStrategy;
        private InteractivePanel ipStatus;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.NumericUpDown nmThreadBulkSize;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox cbFixedStrategy;
        private InteractivePanel ipBattalionToSectorSum;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.NumericUpDown nmSectorCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nmBattalionCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbSwitchMutation;
    }
}

