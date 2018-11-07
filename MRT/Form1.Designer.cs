namespace MRT
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.employeesList = new System.Windows.Forms.ComboBox();
            this.add = new System.Windows.Forms.Button();
            this.qualityCircle = new CircularProgressBar.CircularProgressBar();
            this.intimeCircle = new CircularProgressBar.CircularProgressBar();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.addResult = new System.Windows.Forms.Button();
            this.weekNumber = new System.Windows.Forms.Label();
            this.left = new System.Windows.Forms.Button();
            this.right = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.delete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // employeesList
            // 
            this.employeesList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.employeesList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.employeesList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.employeesList.FormattingEnabled = true;
            this.employeesList.Location = new System.Drawing.Point(97, 14);
            this.employeesList.Name = "employeesList";
            this.employeesList.Size = new System.Drawing.Size(209, 21);
            this.employeesList.TabIndex = 0;
            this.employeesList.TextChanged += new System.EventHandler(this.name_TextChanged);
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(330, 12);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(157, 23);
            this.add.TabIndex = 1;
            this.add.Text = "Medewerker toevoegen";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // qualityCircle
            // 
            this.qualityCircle.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.qualityCircle.AnimationSpeed = 500;
            this.qualityCircle.BackColor = System.Drawing.Color.Transparent;
            this.qualityCircle.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold);
            this.qualityCircle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.qualityCircle.InnerColor = System.Drawing.Color.Transparent;
            this.qualityCircle.InnerMargin = 2;
            this.qualityCircle.InnerWidth = -1;
            this.qualityCircle.Location = new System.Drawing.Point(536, 324);
            this.qualityCircle.MarqueeAnimationSpeed = 2000;
            this.qualityCircle.Name = "qualityCircle";
            this.qualityCircle.OuterColor = System.Drawing.Color.Gray;
            this.qualityCircle.OuterMargin = -15;
            this.qualityCircle.OuterWidth = 10;
            this.qualityCircle.ProgressColor = System.Drawing.Color.Black;
            this.qualityCircle.ProgressWidth = 20;
            this.qualityCircle.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.qualityCircle.Size = new System.Drawing.Size(250, 250);
            this.qualityCircle.StartAngle = 270;
            this.qualityCircle.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.qualityCircle.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.qualityCircle.SubscriptText = "";
            this.qualityCircle.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.qualityCircle.SuperscriptMargin = new System.Windows.Forms.Padding(-15, 25, 0, 0);
            this.qualityCircle.SuperscriptText = "%";
            this.qualityCircle.TabIndex = 5;
            this.qualityCircle.Text = "0";
            this.qualityCircle.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.qualityCircle.Value = 68;
            // 
            // intimeCircle
            // 
            this.intimeCircle.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.intimeCircle.AnimationSpeed = 500;
            this.intimeCircle.BackColor = System.Drawing.Color.Transparent;
            this.intimeCircle.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold);
            this.intimeCircle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.intimeCircle.InnerColor = System.Drawing.Color.Transparent;
            this.intimeCircle.InnerMargin = 2;
            this.intimeCircle.InnerWidth = -1;
            this.intimeCircle.Location = new System.Drawing.Point(536, 55);
            this.intimeCircle.MarqueeAnimationSpeed = 2000;
            this.intimeCircle.Name = "intimeCircle";
            this.intimeCircle.OuterColor = System.Drawing.Color.Gray;
            this.intimeCircle.OuterMargin = -15;
            this.intimeCircle.OuterWidth = 10;
            this.intimeCircle.ProgressColor = System.Drawing.Color.Gold;
            this.intimeCircle.ProgressWidth = 20;
            this.intimeCircle.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.intimeCircle.Size = new System.Drawing.Size(250, 250);
            this.intimeCircle.StartAngle = 270;
            this.intimeCircle.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.intimeCircle.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.intimeCircle.SubscriptText = "";
            this.intimeCircle.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.intimeCircle.SuperscriptMargin = new System.Windows.Forms.Padding(-15, 25, 0, 0);
            this.intimeCircle.SuperscriptText = "%";
            this.intimeCircle.TabIndex = 4;
            this.intimeCircle.Text = "0";
            this.intimeCircle.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.intimeCircle.Value = 68;
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "chartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.ItemColumnSpacing = 100;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 55);
            this.chart1.Name = "chart1";
            series1.ChartArea = "chartArea1";
            series1.Color = System.Drawing.Color.Gold;
            series1.EmptyPointStyle.Color = System.Drawing.Color.Red;
            series1.Legend = "Legend1";
            series1.Name = "Op tijd klaar";
            series2.ChartArea = "chartArea1";
            series2.Color = System.Drawing.Color.Black;
            series2.Legend = "Legend1";
            series2.Name = "Kwaliteit";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(518, 548);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            // 
            // addResult
            // 
            this.addResult.Enabled = false;
            this.addResult.Location = new System.Drawing.Point(654, 12);
            this.addResult.Name = "addResult";
            this.addResult.Size = new System.Drawing.Size(131, 23);
            this.addResult.TabIndex = 6;
            this.addResult.Text = "Resultaat invoeren";
            this.addResult.UseVisualStyleBackColor = true;
            this.addResult.Click += new System.EventHandler(this.addResult_Click);
            // 
            // weekNumber
            // 
            this.weekNumber.AutoSize = true;
            this.weekNumber.Location = new System.Drawing.Point(202, 602);
            this.weekNumber.Name = "weekNumber";
            this.weekNumber.Size = new System.Drawing.Size(49, 13);
            this.weekNumber.TabIndex = 7;
            this.weekNumber.Text = "Week xx";
            // 
            // left
            // 
            this.left.BackgroundImage = global::MRT.Properties.Resources.left;
            this.left.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.left.Location = new System.Drawing.Point(147, 589);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(49, 43);
            this.left.TabIndex = 8;
            this.left.UseVisualStyleBackColor = true;
            this.left.Click += new System.EventHandler(this.left_Click);
            // 
            // right
            // 
            this.right.BackgroundImage = global::MRT.Properties.Resources.right;
            this.right.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.right.Location = new System.Drawing.Point(257, 587);
            this.right.Name = "right";
            this.right.Size = new System.Drawing.Size(49, 43);
            this.right.TabIndex = 9;
            this.right.UseVisualStyleBackColor = true;
            this.right.Click += new System.EventHandler(this.right_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Resultaten van";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(588, 618);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "t/m";
            // 
            // dateFrom
            // 
            this.dateFrom.CustomFormat = "";
            this.dateFrom.Enabled = false;
            this.dateFrom.Location = new System.Drawing.Point(410, 612);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(172, 20);
            this.dateFrom.TabIndex = 13;
            this.dateFrom.ValueChanged += new System.EventHandler(this.dateFrom_ValueChanged);
            // 
            // dateTo
            // 
            this.dateTo.CustomFormat = "";
            this.dateTo.Enabled = false;
            this.dateTo.Location = new System.Drawing.Point(617, 612);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(172, 20);
            this.dateTo.TabIndex = 14;
            this.dateTo.ValueChanged += new System.EventHandler(this.dateTo_ValueChanged);
            // 
            // delete
            // 
            this.delete.Enabled = false;
            this.delete.Location = new System.Drawing.Point(493, 12);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(155, 23);
            this.delete.TabIndex = 16;
            this.delete.Text = "Medewerker verwijderen";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 642);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.dateTo);
            this.Controls.Add(this.dateFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.right);
            this.Controls.Add(this.left);
            this.Controls.Add(this.weekNumber);
            this.Controls.Add(this.addResult);
            this.Controls.Add(this.qualityCircle);
            this.Controls.Add(this.intimeCircle);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.add);
            this.Controls.Add(this.employeesList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(813, 681);
            this.MinimumSize = new System.Drawing.Size(813, 681);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MRT";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox employeesList;
        private System.Windows.Forms.Button add;
        private CircularProgressBar.CircularProgressBar qualityCircle;
        private CircularProgressBar.CircularProgressBar intimeCircle;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button addResult;
        private System.Windows.Forms.Label weekNumber;
        private System.Windows.Forms.Button left;
        private System.Windows.Forms.Button right;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.Button delete;
    }
}

