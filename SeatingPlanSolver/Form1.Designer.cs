namespace SeatingPlanSolver
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
            this.filePicker = new System.Windows.Forms.OpenFileDialog();
            this.btnGetWeightMatrix = new System.Windows.Forms.Button();
            this.btnGetRelationshipMatrix = new System.Windows.Forms.Button();
            this.btnOptimize = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtNumTrials = new System.Windows.Forms.TextBox();
            this.lblNumTrials = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnSaveSeatingPlan = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblProgress = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.chkCalcUtil = new System.Windows.Forms.CheckBox();
            this.btnLoadGuestList = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEvalUtility = new System.Windows.Forms.TextBox();
            this.txtNumHappy = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // filePicker
            // 
            this.filePicker.DefaultExt = "*.csv";
            this.filePicker.FileName = "filePicker";
            // 
            // btnGetWeightMatrix
            // 
            this.btnGetWeightMatrix.Location = new System.Drawing.Point(6, 6);
            this.btnGetWeightMatrix.Name = "btnGetWeightMatrix";
            this.btnGetWeightMatrix.Size = new System.Drawing.Size(101, 23);
            this.btnGetWeightMatrix.TabIndex = 0;
            this.btnGetWeightMatrix.Text = "Get Weight Matrix";
            this.btnGetWeightMatrix.UseVisualStyleBackColor = true;
            this.btnGetWeightMatrix.Click += new System.EventHandler(this.btnGetWeightMatrix_Click);
            // 
            // btnGetRelationshipMatrix
            // 
            this.btnGetRelationshipMatrix.Location = new System.Drawing.Point(6, 35);
            this.btnGetRelationshipMatrix.Name = "btnGetRelationshipMatrix";
            this.btnGetRelationshipMatrix.Size = new System.Drawing.Size(129, 23);
            this.btnGetRelationshipMatrix.TabIndex = 1;
            this.btnGetRelationshipMatrix.Text = "Get Relationship Matrix";
            this.btnGetRelationshipMatrix.UseVisualStyleBackColor = true;
            this.btnGetRelationshipMatrix.Click += new System.EventHandler(this.btnGetRelationshipMatrix_Click);
            // 
            // btnOptimize
            // 
            this.btnOptimize.Location = new System.Drawing.Point(9, 119);
            this.btnOptimize.Name = "btnOptimize";
            this.btnOptimize.Size = new System.Drawing.Size(75, 23);
            this.btnOptimize.TabIndex = 3;
            this.btnOptimize.Text = "Optimize!";
            this.btnOptimize.UseVisualStyleBackColor = true;
            this.btnOptimize.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(9, 148);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(259, 20);
            this.textBox1.TabIndex = 4;
            // 
            // txtNumTrials
            // 
            this.txtNumTrials.Location = new System.Drawing.Point(76, 64);
            this.txtNumTrials.Name = "txtNumTrials";
            this.txtNumTrials.Size = new System.Drawing.Size(190, 20);
            this.txtNumTrials.TabIndex = 5;
            this.txtNumTrials.Text = "120";
            // 
            // lblNumTrials
            // 
            this.lblNumTrials.AutoSize = true;
            this.lblNumTrials.Location = new System.Drawing.Point(6, 67);
            this.lblNumTrials.Name = "lblNumTrials";
            this.lblNumTrials.Size = new System.Drawing.Size(64, 13);
            this.lblNumTrials.TabIndex = 6;
            this.lblNumTrials.Text = "No. of Trials";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "*.csv";
            this.saveFileDialog1.FileName = "SeatingPlan";
            // 
            // btnSaveSeatingPlan
            // 
            this.btnSaveSeatingPlan.Location = new System.Drawing.Point(9, 174);
            this.btnSaveSeatingPlan.Name = "btnSaveSeatingPlan";
            this.btnSaveSeatingPlan.Size = new System.Drawing.Size(75, 39);
            this.btnSaveSeatingPlan.TabIndex = 7;
            this.btnSaveSeatingPlan.Text = "Save Seating Plan";
            this.btnSaveSeatingPlan.UseVisualStyleBackColor = true;
            this.btnSaveSeatingPlan.Click += new System.EventHandler(this.btnSaveSeatingPlan_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(486, 350);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblProgress);
            this.tabPage1.Controls.Add(this.progressBar1);
            this.tabPage1.Controls.Add(this.chkCalcUtil);
            this.tabPage1.Controls.Add(this.btnLoadGuestList);
            this.tabPage1.Controls.Add(this.btnGetWeightMatrix);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.btnSaveSeatingPlan);
            this.tabPage1.Controls.Add(this.btnGetRelationshipMatrix);
            this.tabPage1.Controls.Add(this.txtNumTrials);
            this.tabPage1.Controls.Add(this.btnOptimize);
            this.tabPage1.Controls.Add(this.lblNumTrials);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(478, 324);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.BackColor = System.Drawing.Color.Transparent;
            this.lblProgress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblProgress.ForeColor = System.Drawing.Color.Black;
            this.lblProgress.Location = new System.Drawing.Point(353, 124);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(0, 13);
            this.lblProgress.TabIndex = 11;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(250, 119);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(222, 23);
            this.progressBar1.TabIndex = 10;
            // 
            // chkCalcUtil
            // 
            this.chkCalcUtil.AutoSize = true;
            this.chkCalcUtil.Checked = true;
            this.chkCalcUtil.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCalcUtil.Location = new System.Drawing.Point(90, 123);
            this.chkCalcUtil.Name = "chkCalcUtil";
            this.chkCalcUtil.Size = new System.Drawing.Size(154, 17);
            this.chkCalcUtil.TabIndex = 9;
            this.chkCalcUtil.Text = "Calculate Individual Utilities";
            this.chkCalcUtil.UseVisualStyleBackColor = true;
            // 
            // btnLoadGuestList
            // 
            this.btnLoadGuestList.Location = new System.Drawing.Point(9, 90);
            this.btnLoadGuestList.Name = "btnLoadGuestList";
            this.btnLoadGuestList.Size = new System.Drawing.Size(98, 23);
            this.btnLoadGuestList.TabIndex = 8;
            this.btnLoadGuestList.Text = "Load Guest List";
            this.btnLoadGuestList.UseVisualStyleBackColor = true;
            this.btnLoadGuestList.Click += new System.EventHandler(this.btnLoadGuestList_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(478, 324);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(466, 312);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Evaluate individual utility";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 46);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(454, 260);
            this.dataGridView1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(305, 19);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(155, 20);
            this.textBox2.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(224, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Evaluate!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Individual";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(97, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(478, 324);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtNumHappy);
            this.groupBox2.Controls.Add(this.txtEvalUtility);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Location = new System.Drawing.Point(6, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(476, 315);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Evaluate Plan";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 53);
            this.button2.TabIndex = 0;
            this.button2.Text = "Load and Evaluate plan...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Utility";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Num Happy";
            // 
            // txtEvalUtility
            // 
            this.txtEvalUtility.Location = new System.Drawing.Point(75, 78);
            this.txtEvalUtility.Name = "txtEvalUtility";
            this.txtEvalUtility.Size = new System.Drawing.Size(100, 20);
            this.txtEvalUtility.TabIndex = 3;
            // 
            // txtNumHappy
            // 
            this.txtNumHappy.Location = new System.Drawing.Point(75, 104);
            this.txtNumHappy.Name = "txtNumHappy";
            this.txtNumHappy.Size = new System.Drawing.Size(100, 20);
            this.txtNumHappy.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 374);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog filePicker;
        private System.Windows.Forms.Button btnGetWeightMatrix;
        private System.Windows.Forms.Button btnGetRelationshipMatrix;
        private System.Windows.Forms.Button btnOptimize;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtNumTrials;
        private System.Windows.Forms.Label lblNumTrials;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnSaveSeatingPlan;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnLoadGuestList;
        private System.Windows.Forms.CheckBox chkCalcUtil;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtNumHappy;
        private System.Windows.Forms.TextBox txtEvalUtility;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
    }
}

