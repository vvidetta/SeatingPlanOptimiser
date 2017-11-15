using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace SeatingPlanSolver
{
    public partial class Form1 : Form
    {
        #region Data Members

        private System.ComponentModel.BackgroundWorker bw = new BackgroundWorker();
        private SeatingPlanOptimizer optimizer = new SeatingPlanOptimizer();

        #endregion

        #region Constructors

        public Form1()
        {
            InitializeComponent();
            bw.WorkerReportsProgress = true;
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
           
            var pos = this.PointToScreen(lblProgress.Location);
            pos = progressBar1.PointToClient(pos);
            label1.Parent = progressBar1;
            label1.Location = pos;
            label1.BackColor = Color.Transparent;
        }

        #endregion

        #region Operations

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Permutation optimalSeatingPlan = (Permutation)e.Result;
            this.textBox1.Text = String.Format("Max Utility: {0}", optimizer.Utility(optimalSeatingPlan));
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
            this.lblProgress.Text = e.ProgressPercentage.ToString() + "%";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnGetWeightMatrix_Click(object sender, EventArgs e)
        {
            var result = filePicker.ShowDialog();
            if (result == DialogResult.OK)
            {
                optimizer.LoadWeightMatrix(filePicker.FileName);
            }
        }

        private void btnGetRelationshipMatrix_Click(object sender, EventArgs e)
        {
            var result = filePicker.ShowDialog();
            if (result == DialogResult.OK)
            {
                optimizer.LoadRelationshipMatrix(filePicker.FileName);
            }
        }

        private void btnGetSeatingPlan_Click(object sender, EventArgs e)
        {
            var result = filePicker.ShowDialog();
            if (result == DialogResult.OK)
            {
                optimizer.LoadSeatingPlan(filePicker.FileName);
            }
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            bw.ReportProgress(0);
            int numTrials = Int32.Parse(txtNumTrials.Text);
            optimizer.Optimize(numTrials);
            e.Result = optimizer.OptimalSeatingPlan;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "Optimizing...";
            bw.RunWorkerAsync();
        }

        private void btnSaveSeatingPlan_Click(object sender, EventArgs e)
        {
            var result = saveFileDialog1.ShowDialog();
            optimizer.SaveSeatingPlan(saveFileDialog1.FileName, chkCalcUtil.Checked);
            this.textBox1.Text = string.Format("SeatingPlan saved in {0}", saveFileDialog1.FileName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string guestName = comboBox1.SelectedItem.ToString();
            double utility = optimizer.CalculateIndividualUtility(guestName);
            textBox2.Text = utility.ToString();
        }

        private void btnLoadGuestList_Click(object sender, EventArgs e)
        {
            var result = filePicker.ShowDialog();
            if (result == DialogResult.OK)
            {
                optimizer.LoadGuestList(filePicker.FileName);
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(optimizer.GuestList.Values.ToArray());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = filePicker.ShowDialog();
            if (result == DialogResult.OK)
            {
                optimizer.LoadAndEvaluatePlan(filePicker.FileName);

                //evaluate
                this.txtEvalUtility.Text = optimizer.OptimalUtility.ToString();
                this.txtNumHappy.Text = optimizer.CountHappyPeople(optimizer.OptimalSeatingPlan).ToString();
            }
        }

        #endregion

        #region Fields
        #endregion
    }
}
