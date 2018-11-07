namespace MRT
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.label2 = new System.Windows.Forms.Label();
            this.qualityCombo = new System.Windows.Forms.ComboBox();
            this.intimeCheckbox = new System.Windows.Forms.CheckBox();
            this.save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.day = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Kwaliteit";
            // 
            // qualityCombo
            // 
            this.qualityCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.qualityCombo.FormattingEnabled = true;
            this.qualityCombo.Items.AddRange(new object[] {
            "Matig",
            "Voldoende",
            "Goed"});
            this.qualityCombo.Location = new System.Drawing.Point(58, 37);
            this.qualityCombo.Name = "qualityCombo";
            this.qualityCombo.Size = new System.Drawing.Size(214, 21);
            this.qualityCombo.TabIndex = 14;
            // 
            // intimeCheckbox
            // 
            this.intimeCheckbox.AutoSize = true;
            this.intimeCheckbox.Location = new System.Drawing.Point(58, 64);
            this.intimeCheckbox.Name = "intimeCheckbox";
            this.intimeCheckbox.Size = new System.Drawing.Size(82, 17);
            this.intimeCheckbox.TabIndex = 13;
            this.intimeCheckbox.Text = "Op tijd klaar";
            this.intimeCheckbox.UseVisualStyleBackColor = true;
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(58, 86);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(214, 31);
            this.save.TabIndex = 12;
            this.save.Text = "Opslaan";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Dag";
            // 
            // day
            // 
            this.day.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.day.FormattingEnabled = true;
            this.day.Location = new System.Drawing.Point(58, 10);
            this.day.Name = "day";
            this.day.Size = new System.Drawing.Size(214, 21);
            this.day.TabIndex = 17;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 128);
            this.Controls.Add(this.day);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.qualityCombo);
            this.Controls.Add(this.intimeCheckbox);
            this.Controls.Add(this.save);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(300, 167);
            this.MinimumSize = new System.Drawing.Size(300, 167);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resultaat toevoegen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox qualityCombo;
        private System.Windows.Forms.CheckBox intimeCheckbox;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox day;
    }
}