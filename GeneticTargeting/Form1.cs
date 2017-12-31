using OptimizationLogics;
using Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaamLogics;

namespace TaamAssign
{
    public partial class Form1 : Form
    {
        public BaseOptimizationLogic<CSingleAssignment> MyOptimizer { get; set; }

        public Form1()
        {
            InitializeComponent();
            this.MyOptimizer = new GeneticLogic<CSingleAssignment>();
            this.InitIPs();
            this.MyOptimizer.Restrategize(() => new CTaamAssignment());
            this.initConfigDelegation();
        }

        public void initConfigDelegation()
        {
            #region Genetic Configuration

            this.numCycles.Value = GlobalConfiguration.GenerationCount;
            this.numCycles.Tag = GlobalConfiguration.GetDelegate("GenerationCount");

            this.tbPopulationSize.Value = GlobalConfiguration.PopulationCount;
            this.tbPopulationSize.Tag = GlobalConfiguration.GetDelegate("PopulationCount");

            this.tbMutationChance.Value = (decimal)GlobalConfiguration.MutationChance;
            this.tbMutationChance.Tag = GlobalConfiguration.GetDelegate("MutationChance");

            this.tbParentChance.Value = (decimal)GlobalConfiguration.ParentChance;
            this.tbParentChance.Tag = GlobalConfiguration.GetDelegate("ParentChance");

            this.cbApplyElitist.CheckState = GlobalConfiguration.ApplyElitist ? CheckState.Checked : CheckState.Unchecked;
            this.cbApplyElitist.Tag = GlobalConfiguration.GetDelegate("ApplyElitist");

            this.cbApplyNaturalSelection.CheckState = GlobalConfiguration.ApplyNaturalSelection ? CheckState.Checked : CheckState.Unchecked;
            this.cbApplyNaturalSelection.Tag = GlobalConfiguration.GetDelegate("ApplyNaturalSelection");

            #endregion

            #region Genetic Configuration

            this.nmInitialTempature.Value = GlobalConfiguration.InitialTempature;
            this.nmInitialTempature.Tag = GlobalConfiguration.GetDelegate("InitialTempature");

            this.nmTempatureDecay.Value = (decimal)GlobalConfiguration.TempatureDecay;
            this.nmTempatureDecay.Tag = GlobalConfiguration.GetDelegate("TempatureDecay");

            this.nmAnnealingInstances.Value = GlobalConfiguration.AnealingInstances;
            this.nmAnnealingInstances.Tag = GlobalConfiguration.GetDelegate("AnealingInstances");

            #endregion

            #region Performances

            this.nmThreadBulkSize.Value = GlobalConfiguration.Performances.ThreadBulkSize;
            this.nmThreadBulkSize.Tag = GlobalConfiguration.GetDelegate("ThreadBulkSize");

            #endregion


            #region Assignment

            this.nmBattalionCount.Value = GlobalConfiguration.Assignemnt.BattalionCount;
            this.nmBattalionCount.Tag = GlobalConfiguration.GetDelegate("BattalionCount");

            this.nmSectorCount.Value = GlobalConfiguration.Assignemnt.SectorCount;
            this.nmSectorCount.Tag = GlobalConfiguration.GetDelegate("SectorCount");

            #endregion
        }

        private async void btnLaunch_Click(object sender, EventArgs e)
        {
            Progress<IDNA<CSingleAssignment>> progress = new Progress<IDNA<CSingleAssignment>>(world => {
                this.ipLog.Refresh();
                this.ipStatusGraph.TransformOrigin.X = -this.MyOptimizer.GetStatusGraph().GetWidth();
                this.ipStatusGraph.TransformOrigin.Y = -this.MyOptimizer.GetStatusGraph().GetHeight();
                this.ipStatusGraph.Refresh();
            });

            this.btnRestrategize.Enabled = false;
            this.btnStart.Enabled = false;
            this.btnLaunchOptimizer.Enabled = false;

            Stopwatch w = Stopwatch.StartNew();
            await this.MyOptimizer.LaunchOptimizer(progress);
            w.Stop();
            Debug.WriteLine(w.ElapsedMilliseconds);

            this.btnRestrategize.Enabled = true;
            this.btnStart.Enabled = true;
            this.btnLaunchOptimizer.Enabled = true;

            this.ipLog.Refresh();
            this.ipStrategy.Refresh();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.btnStart.Text = "Restart!";
            this.btnLaunchOptimizer.Enabled = true;
            this.btnRestrategize.Enabled = true;
            this.MyOptimizer.InitOptimizer(() => new CTaamAssignment());
            this.ipLog.Refresh();
            this.ipStrategy.Refresh();
        }

        private void btnRestrategize_Click(object sender, EventArgs e)
        {
            this.MyOptimizer.Restrategize(() => new CTaamAssignment());
            this.ipLog.Refresh();
            this.ipStrategy.Refresh();
        }

        private void tbConfig_TextChanged(object sender, EventArgs e)
        {
            NumericUpDown tb = (NumericUpDown)sender;
            if (tb.Tag != null)
            {
                ((Action<object>)(tb).Tag)(tb.Value);
            }
        }

        private void cbConfig_TextChanged(object sender, EventArgs e)
        {
            CheckBox tb = (CheckBox)sender;
            if (tb.Tag != null)
            {
                ((Action<object>)(tb).Tag)(tb.CheckState == CheckState.Checked);
            }
        }

        private void OptimizationTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl Tab = (TabControl)sender;
            this.btnStart.Text = "Start!";
            this.btnLaunchOptimizer.Enabled = false;
            this.btnRestrategize.Enabled = false;

            if (Tab.SelectedTab.Name == "Annealing")
            {
                this.MyOptimizer = new AnnealerLogic<CSingleAssignment>();
                GlobalConfiguration.SwitchMutation = true;
            }
            else// if(Tab.SelectedTab.Name == "Genetic")
            {
                this.MyOptimizer = new GeneticLogic<CSingleAssignment>();
                GlobalConfiguration.SwitchMutation = false;
            }

            this.InitIPs();
        }

        private void tmrStatusUpdate_Tick(object sender, EventArgs e)
        {
            if (!this.btnStart.Enabled)
            {
                this.ipLog.Refresh();
                this.ipStatusGraph.TransformOrigin.X = -this.MyOptimizer.GetStatusGraph()?.GetWidth() ?? 0;
                this.ipStatusGraph.TransformOrigin.Y = -this.MyOptimizer.GetStatusGraph()?.GetHeight() ?? 0;
                this.ipStatusGraph.Refresh();
            }
        }

        private void InitIPs()
        {
            this.ipBattalionToSectorSum.DrawFunction = this.MyOptimizer.GetBattalionToSectorSumDrawer();
            this.ipStrategy.DrawFunction = this.MyOptimizer.GetStrategyDrawer();
            this.ipStrategy.UpdateFunction = () => CStrategyPool.ActiveStrategy.Update();

            this.ipStatusGraph.DrawFunction = this.MyOptimizer.GetStatusGraphDrawer();
            this.ipLog.DrawFunction = this.MyOptimizer.GetLoggerDrawer();
        }
    }
}
