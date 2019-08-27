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
            Library.Point2D point2D25 = new Library.Point2D();
            Library.Point2D point2D26 = new Library.Point2D();
            Library.Point2D point2D27 = new Library.Point2D();
            Library.Point2D point2D28 = new Library.Point2D();
            Library.Point2D point2D29 = new Library.Point2D();
            Library.Point2D point2D30 = new Library.Point2D();
            this.btnLaunchOptimizer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numCycles = new System.Windows.Forms.NumericUpDown();
            this.btnStart = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbMutationChance = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbPopulationSize = new System.Windows.Forms.NumericUpDown();
            this.tbParentChance = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cbApplyNaturalSelection = new System.Windows.Forms.CheckBox();
            this.cbApplyElitist = new System.Windows.Forms.CheckBox();
            this.btnRestrategize = new System.Windows.Forms.Button();
            this.tbcSettings = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.nmSectorCount = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nmBattalionCount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.cbFixedStrategy = new System.Windows.Forms.CheckBox();
            this.nmThreadBulkSize = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.OptimizationTab = new System.Windows.Forms.TabControl();
            this.Genetic = new System.Windows.Forms.TabPage();
            this.Annealing = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nmTempatureDecay = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.nmAnnealingInstances = new System.Windows.Forms.NumericUpDown();
            this.nmInitialTempature = new System.Windows.Forms.NumericUpDown();
            this.Swarm = new System.Windows.Forms.TabPage();
            this.ipStrategy = new TaamAssign.InteractivePanel();
            this.ipBattalionToSectorSum = new TaamAssign.InteractivePanel();
            this.ipLog = new TaamAssign.InteractivePanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ipStatusGraph = new TaamAssign.InteractivePanel();
            this.tmrStatusUpdate = new System.Windows.Forms.Timer(this.components);
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.ipBattalionReservations = new TaamAssign.InteractivePanel();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.ipBattalionPotentialCount = new TaamAssign.InteractivePanel();
            ((System.ComponentModel.ISupportInitialize)(this.numCycles)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMutationChance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPopulationSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbParentChance)).BeginInit();
            this.tbcSettings.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmSectorCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmBattalionCount)).BeginInit();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmThreadBulkSize)).BeginInit();
            this.OptimizationTab.SuspendLayout();
            this.Genetic.SuspendLayout();
            this.Annealing.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmTempatureDecay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmAnnealingInstances)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmInitialTempature)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLaunchOptimizer
            // 
            this.btnLaunchOptimizer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLaunchOptimizer.Enabled = false;
            this.btnLaunchOptimizer.Location = new System.Drawing.Point(234, 4);
            this.btnLaunchOptimizer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLaunchOptimizer.Name = "btnLaunchOptimizer";
            this.btnLaunchOptimizer.Size = new System.Drawing.Size(223, 58);
            this.btnLaunchOptimizer.TabIndex = 2;
            this.btnLaunchOptimizer.Text = "Launch Optimizer";
            this.btnLaunchOptimizer.UseVisualStyleBackColor = true;
            this.btnLaunchOptimizer.Click += new System.EventHandler(this.btnLaunch_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number of generations:";
            // 
            // numCycles
            // 
            this.numCycles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numCycles.Location = new System.Drawing.Point(232, 4);
            this.numCycles.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numCycles.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numCycles.Name = "numCycles";
            this.numCycles.Size = new System.Drawing.Size(220, 22);
            this.numCycles.TabIndex = 4;
            this.numCycles.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCycles.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(4, 4);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(222, 58);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start!";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.cbApplyNaturalSelection);
            this.panel1.Controls.Add(this.cbApplyElitist);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(456, 229);
            this.panel1.TabIndex = 8;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.numCycles, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbMutationChance, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbPopulationSize, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbParentChance, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(456, 229);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // tbMutationChance
            // 
            this.tbMutationChance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMutationChance.DecimalPlaces = 5;
            this.tbMutationChance.Location = new System.Drawing.Point(231, 32);
            this.tbMutationChance.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbMutationChance.Name = "tbMutationChance";
            this.tbMutationChance.Size = new System.Drawing.Size(222, 22);
            this.tbMutationChance.TabIndex = 1;
            this.tbMutationChance.TextChanged += new System.EventHandler(this.tbConfig_TextChanged);
            this.tbMutationChance.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(222, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Mutation chance:";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(222, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "Choose parent chance: ";
            // 
            // tbPopulationSize
            // 
            this.tbPopulationSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPopulationSize.Location = new System.Drawing.Point(231, 58);
            this.tbPopulationSize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbPopulationSize.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.tbPopulationSize.Name = "tbPopulationSize";
            this.tbPopulationSize.Size = new System.Drawing.Size(222, 22);
            this.tbPopulationSize.TabIndex = 0;
            this.tbPopulationSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tbPopulationSize.TextChanged += new System.EventHandler(this.tbConfig_TextChanged);
            this.tbPopulationSize.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // tbParentChance
            // 
            this.tbParentChance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbParentChance.DecimalPlaces = 5;
            this.tbParentChance.Location = new System.Drawing.Point(231, 84);
            this.tbParentChance.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbParentChance.Name = "tbParentChance";
            this.tbParentChance.Size = new System.Drawing.Size(222, 22);
            this.tbParentChance.TabIndex = 1;
            this.tbParentChance.TextChanged += new System.EventHandler(this.tbConfig_TextChanged);
            this.tbParentChance.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(222, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Population size:";
            // 
            // cbApplyNaturalSelection
            // 
            this.cbApplyNaturalSelection.AutoSize = true;
            this.cbApplyNaturalSelection.Location = new System.Drawing.Point(185, 433);
            this.cbApplyNaturalSelection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.cbApplyElitist.Location = new System.Drawing.Point(8, 433);
            this.cbApplyElitist.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbApplyElitist.Name = "cbApplyElitist";
            this.cbApplyElitist.Size = new System.Drawing.Size(101, 21);
            this.cbApplyElitist.TabIndex = 2;
            this.cbApplyElitist.Text = "Apply elitist";
            this.cbApplyElitist.UseVisualStyleBackColor = true;
            this.cbApplyElitist.CheckedChanged += new System.EventHandler(this.cbConfig_TextChanged);
            // 
            // btnRestrategize
            // 
            this.btnRestrategize.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.btnRestrategize, 2);
            this.btnRestrategize.Enabled = false;
            this.btnRestrategize.Location = new System.Drawing.Point(3, 68);
            this.btnRestrategize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRestrategize.Name = "btnRestrategize";
            this.btnRestrategize.Size = new System.Drawing.Size(455, 63);
            this.btnRestrategize.TabIndex = 9;
            this.btnRestrategize.Text = "New Formation";
            this.btnRestrategize.UseVisualStyleBackColor = true;
            this.btnRestrategize.Click += new System.EventHandler(this.btnRestrategize_Click);
            // 
            // tbcSettings
            // 
            this.tbcSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcSettings.Controls.Add(this.tabPage2);
            this.tbcSettings.Controls.Add(this.tabPage6);
            this.tbcSettings.Location = new System.Drawing.Point(1176, 674);
            this.tbcSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbcSettings.Name = "tbcSettings";
            this.tbcSettings.SelectedIndex = 0;
            this.tbcSettings.Size = new System.Drawing.Size(467, 197);
            this.tbcSettings.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.tabControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(459, 168);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "Assignment";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(8, 7);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(435, 150);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.nmSectorCount);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.nmBattalionCount);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage3.Size = new System.Drawing.Size(427, 121);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Structure";
            // 
            // nmSectorCount
            // 
            this.nmSectorCount.Location = new System.Drawing.Point(161, 37);
            this.nmSectorCount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nmSectorCount.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nmSectorCount.Name = "nmSectorCount";
            this.nmSectorCount.Size = new System.Drawing.Size(256, 22);
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
            this.label3.Location = new System.Drawing.Point(7, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Serctor Count:";
            // 
            // nmBattalionCount
            // 
            this.nmBattalionCount.Location = new System.Drawing.Point(161, 6);
            this.nmBattalionCount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nmBattalionCount.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nmBattalionCount.Name = "nmBattalionCount";
            this.nmBattalionCount.Size = new System.Drawing.Size(256, 22);
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
            this.label2.Location = new System.Drawing.Point(7, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Battalion Count:";
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage6.Controls.Add(this.cbFixedStrategy);
            this.tabPage6.Controls.Add(this.nmThreadBulkSize);
            this.tabPage6.Controls.Add(this.label12);
            this.tabPage6.Location = new System.Drawing.Point(4, 25);
            this.tabPage6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(459, 168);
            this.tabPage6.TabIndex = 2;
            this.tabPage6.Text = "Performance";
            // 
            // cbFixedStrategy
            // 
            this.cbFixedStrategy.AutoSize = true;
            this.cbFixedStrategy.Location = new System.Drawing.Point(169, 44);
            this.cbFixedStrategy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbFixedStrategy.Name = "cbFixedStrategy";
            this.cbFixedStrategy.Size = new System.Drawing.Size(118, 21);
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
            this.nmThreadBulkSize.Location = new System.Drawing.Point(169, 16);
            this.nmThreadBulkSize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.nmThreadBulkSize.Size = new System.Drawing.Size(272, 22);
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
            this.label12.Location = new System.Drawing.Point(4, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(117, 17);
            this.label12.TabIndex = 2;
            this.label12.Text = "Thread bulk size:";
            // 
            // OptimizationTab
            // 
            this.OptimizationTab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OptimizationTab.Controls.Add(this.Genetic);
            this.OptimizationTab.Controls.Add(this.Annealing);
            this.OptimizationTab.Controls.Add(this.Swarm);
            this.OptimizationTab.Location = new System.Drawing.Point(1176, 155);
            this.OptimizationTab.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.OptimizationTab.Name = "OptimizationTab";
            this.OptimizationTab.SelectedIndex = 0;
            this.OptimizationTab.Size = new System.Drawing.Size(472, 266);
            this.OptimizationTab.TabIndex = 12;
            this.OptimizationTab.SelectedIndexChanged += new System.EventHandler(this.OptimizationTab_SelectedIndexChanged);
            // 
            // Genetic
            // 
            this.Genetic.Controls.Add(this.panel1);
            this.Genetic.Location = new System.Drawing.Point(4, 25);
            this.Genetic.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Genetic.Name = "Genetic";
            this.Genetic.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Genetic.Size = new System.Drawing.Size(464, 237);
            this.Genetic.TabIndex = 0;
            this.Genetic.Text = "Genetic";
            this.Genetic.UseVisualStyleBackColor = true;
            // 
            // Annealing
            // 
            this.Annealing.BackColor = System.Drawing.SystemColors.Control;
            this.Annealing.Controls.Add(this.tableLayoutPanel3);
            this.Annealing.Location = new System.Drawing.Point(4, 25);
            this.Annealing.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Annealing.Name = "Annealing";
            this.Annealing.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Annealing.Size = new System.Drawing.Size(464, 237);
            this.Annealing.TabIndex = 1;
            this.Annealing.Text = "Annealing";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.nmTempatureDecay, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label8, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.nmAnnealingInstances, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.nmInitialTempature, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(456, 229);
            this.tableLayoutPanel3.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 6);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(220, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Initial tempature:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 36);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(220, 17);
            this.label7.TabIndex = 1;
            this.label7.Text = "Tempature decay:";
            // 
            // nmTempatureDecay
            // 
            this.nmTempatureDecay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nmTempatureDecay.DecimalPlaces = 10;
            this.nmTempatureDecay.Location = new System.Drawing.Point(232, 34);
            this.nmTempatureDecay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nmTempatureDecay.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmTempatureDecay.Name = "nmTempatureDecay";
            this.nmTempatureDecay.Size = new System.Drawing.Size(220, 22);
            this.nmTempatureDecay.TabIndex = 2;
            this.nmTempatureDecay.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 66);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(220, 17);
            this.label8.TabIndex = 1;
            this.label8.Text = "Instances:";
            // 
            // nmAnnealingInstances
            // 
            this.nmAnnealingInstances.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nmAnnealingInstances.Location = new System.Drawing.Point(232, 64);
            this.nmAnnealingInstances.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nmAnnealingInstances.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nmAnnealingInstances.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmAnnealingInstances.Name = "nmAnnealingInstances";
            this.nmAnnealingInstances.Size = new System.Drawing.Size(220, 22);
            this.nmAnnealingInstances.TabIndex = 2;
            this.nmAnnealingInstances.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmAnnealingInstances.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // nmInitialTempature
            // 
            this.nmInitialTempature.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nmInitialTempature.Location = new System.Drawing.Point(232, 4);
            this.nmInitialTempature.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nmInitialTempature.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nmInitialTempature.Name = "nmInitialTempature";
            this.nmInitialTempature.Size = new System.Drawing.Size(220, 22);
            this.nmInitialTempature.TabIndex = 2;
            this.nmInitialTempature.ValueChanged += new System.EventHandler(this.tbConfig_TextChanged);
            // 
            // Swarm
            // 
            this.Swarm.BackColor = System.Drawing.SystemColors.Control;
            this.Swarm.Location = new System.Drawing.Point(4, 25);
            this.Swarm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Swarm.Name = "Swarm";
            this.Swarm.Size = new System.Drawing.Size(464, 237);
            this.Swarm.TabIndex = 2;
            this.Swarm.Text = "Swarm";
            // 
            // ipStrategy
            // 
            this.ipStrategy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ipStrategy.CenterDraw = false;
            this.ipStrategy.DrawFunction = null;
            this.ipStrategy.Location = new System.Drawing.Point(15, 14);
            this.ipStrategy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ipStrategy.Name = "ipStrategy";
            this.ipStrategy.ScaleFactor = 25;
            this.ipStrategy.Size = new System.Drawing.Size(740, 858);
            this.ipStrategy.TabIndex = 13;
            this.ipStrategy.TransformOrigin = point2D25;
            this.ipStrategy.UpdateFunction = null;
            // 
            // ipBattalionToSectorSum
            // 
            this.ipBattalionToSectorSum.CenterDraw = false;
            this.ipBattalionToSectorSum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ipBattalionToSectorSum.DrawFunction = null;
            this.ipBattalionToSectorSum.Location = new System.Drawing.Point(4, 4);
            this.ipBattalionToSectorSum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ipBattalionToSectorSum.Name = "ipBattalionToSectorSum";
            this.ipBattalionToSectorSum.ScaleFactor = 25;
            this.ipBattalionToSectorSum.Size = new System.Drawing.Size(399, 581);
            this.ipBattalionToSectorSum.TabIndex = 15;
            this.ipBattalionToSectorSum.TransformOrigin = point2D26;
            this.ipBattalionToSectorSum.UpdateFunction = null;
            // 
            // ipLog
            // 
            this.ipLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ipLog.CenterDraw = false;
            this.ipLog.DrawFunction = null;
            this.ipLog.Location = new System.Drawing.Point(1177, 427);
            this.ipLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ipLog.Name = "ipLog";
            this.ipLog.ScaleFactor = 25;
            this.ipLog.Size = new System.Drawing.Size(465, 242);
            this.ipLog.TabIndex = 16;
            this.ipLog.TransformOrigin = point2D27;
            this.ipLog.UpdateFunction = null;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnStart, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnLaunchOptimizer, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnRestrategize, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1181, 15);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(461, 133);
            this.tableLayoutPanel2.TabIndex = 17;
            // 
            // ipStatusGraph
            // 
            this.ipStatusGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ipStatusGraph.CenterDraw = true;
            this.ipStatusGraph.DrawFunction = null;
            this.ipStatusGraph.Location = new System.Drawing.Point(760, 14);
            this.ipStatusGraph.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ipStatusGraph.Name = "ipStatusGraph";
            this.ipStatusGraph.ScaleFactor = 25;
            this.ipStatusGraph.Size = new System.Drawing.Size(409, 238);
            this.ipStatusGraph.TabIndex = 18;
            this.ipStatusGraph.TransformOrigin = point2D28;
            this.ipStatusGraph.UpdateFunction = null;
            // 
            // tmrStatusUpdate
            // 
            this.tmrStatusUpdate.Enabled = true;
            this.tmrStatusUpdate.Interval = 50;
            this.tmrStatusUpdate.Tick += new System.EventHandler(this.tmrStatusUpdate_Tick);
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage1);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Location = new System.Drawing.Point(763, 258);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(415, 618);
            this.tabControl2.TabIndex = 19;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ipBattalionToSectorSum);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(407, 589);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Destrebution";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.ipBattalionReservations);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage4.Size = new System.Drawing.Size(407, 589);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Reservations";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // ipBattalionReservations
            // 
            this.ipBattalionReservations.CenterDraw = false;
            this.ipBattalionReservations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ipBattalionReservations.DrawFunction = null;
            this.ipBattalionReservations.Location = new System.Drawing.Point(4, 4);
            this.ipBattalionReservations.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ipBattalionReservations.Name = "ipBattalionReservations";
            this.ipBattalionReservations.ScaleFactor = 25;
            this.ipBattalionReservations.Size = new System.Drawing.Size(399, 581);
            this.ipBattalionReservations.TabIndex = 0;
            this.ipBattalionReservations.TransformOrigin = point2D29;
            this.ipBattalionReservations.UpdateFunction = null;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.ipBattalionPotentialCount);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage5.Size = new System.Drawing.Size(407, 589);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "Potential";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // ipBattalionPotentialCount
            // 
            this.ipBattalionPotentialCount.CenterDraw = false;
            this.ipBattalionPotentialCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ipBattalionPotentialCount.DrawFunction = null;
            this.ipBattalionPotentialCount.Location = new System.Drawing.Point(4, 4);
            this.ipBattalionPotentialCount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ipBattalionPotentialCount.Name = "ipBattalionPotentialCount";
            this.ipBattalionPotentialCount.ScaleFactor = 25;
            this.ipBattalionPotentialCount.Size = new System.Drawing.Size(399, 581);
            this.ipBattalionPotentialCount.TabIndex = 16;
            this.ipBattalionPotentialCount.TransformOrigin = point2D30;
            this.ipBattalionPotentialCount.UpdateFunction = null;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1647, 882);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.ipStatusGraph);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.ipLog);
            this.Controls.Add(this.ipStrategy);
            this.Controls.Add(this.OptimizationTab);
            this.Controls.Add(this.tbcSettings);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numCycles)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMutationChance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPopulationSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbParentChance)).EndInit();
            this.tbcSettings.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmSectorCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmBattalionCount)).EndInit();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmThreadBulkSize)).EndInit();
            this.OptimizationTab.ResumeLayout(false);
            this.Genetic.ResumeLayout(false);
            this.Annealing.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmTempatureDecay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmAnnealingInstances)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmInitialTempature)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnLaunchOptimizer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numCycles;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRestrategize;
        private System.Windows.Forms.NumericUpDown tbMutationChance;
        private System.Windows.Forms.NumericUpDown tbPopulationSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tbcSettings;
        private System.Windows.Forms.NumericUpDown tbParentChance;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox cbApplyElitist;
        private System.Windows.Forms.CheckBox cbApplyNaturalSelection;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.NumericUpDown nmThreadBulkSize;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox cbFixedStrategy;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.NumericUpDown nmSectorCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nmBattalionCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl OptimizationTab;
        private System.Windows.Forms.TabPage Genetic;
        private System.Windows.Forms.TabPage Annealing;
        private System.Windows.Forms.TabPage Swarm;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private InteractivePanel ipStrategy;
        private InteractivePanel ipBattalionToSectorSum;
        private InteractivePanel ipLog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private InteractivePanel ipStatusGraph;
        private System.Windows.Forms.Timer tmrStatusUpdate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nmInitialTempature;
        private System.Windows.Forms.NumericUpDown nmTempatureDecay;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nmAnnealingInstances;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage4;
        private InteractivePanel ipBattalionReservations;
        private System.Windows.Forms.TabPage tabPage5;
        private InteractivePanel ipBattalionPotentialCount;
    }
}

