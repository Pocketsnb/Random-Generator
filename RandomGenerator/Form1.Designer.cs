namespace RandomGenerator
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
            this.buttonRandom = new System.Windows.Forms.Button();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.comboBoxGenerators = new System.Windows.Forms.ComboBox();
            this.labelGenerator = new System.Windows.Forms.Label();
            this.groupBoxTreasure = new System.Windows.Forms.GroupBox();
            this.radioButtonTreasureIndividual = new System.Windows.Forms.RadioButton();
            this.radioButtonTreasureHoard = new System.Windows.Forms.RadioButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.comboBoxTreasureLevelRange = new System.Windows.Forms.ComboBox();
            this.labelTreasureLevelRange = new System.Windows.Forms.Label();
            this.labelTreasureType = new System.Windows.Forms.Label();
            this.groupBoxTreasure.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonRandom
            // 
            this.buttonRandom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRandom.Location = new System.Drawing.Point(405, 297);
            this.buttonRandom.Name = "buttonRandom";
            this.buttonRandom.Size = new System.Drawing.Size(75, 23);
            this.buttonRandom.TabIndex = 1;
            this.buttonRandom.Text = "Random";
            this.buttonRandom.UseVisualStyleBackColor = true;
            this.buttonRandom.Click += new System.EventHandler(this.buttonRandom_Click);
            // 
            // textBoxResult
            // 
            this.textBoxResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxResult.Location = new System.Drawing.Point(139, 12);
            this.textBoxResult.Multiline = true;
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.Size = new System.Drawing.Size(341, 279);
            this.textBoxResult.TabIndex = 2;
            // 
            // comboBoxGenerators
            // 
            this.comboBoxGenerators.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGenerators.FormattingEnabled = true;
            this.comboBoxGenerators.Items.AddRange(new object[] {
            "Building",
            "Dungeon",
            "NPC",
            "Settlement",
            "Tavern Name",
            "Treasure"});
            this.comboBoxGenerators.Location = new System.Drawing.Point(12, 28);
            this.comboBoxGenerators.Name = "comboBoxGenerators";
            this.comboBoxGenerators.Size = new System.Drawing.Size(121, 21);
            this.comboBoxGenerators.Sorted = true;
            this.comboBoxGenerators.TabIndex = 8;
            this.comboBoxGenerators.SelectedIndexChanged += new System.EventHandler(this.comboBoxGenerators_SelectedIndexChanged);
            this.comboBoxGenerators.SelectedIndex = 0;
            // 
            // labelGenerator
            // 
            this.labelGenerator.AutoSize = true;
            this.labelGenerator.Location = new System.Drawing.Point(12, 12);
            this.labelGenerator.Name = "labelGenerator";
            this.labelGenerator.Size = new System.Drawing.Size(54, 13);
            this.labelGenerator.TabIndex = 9;
            this.labelGenerator.Text = "Generator";
            // 
            // groupBoxTreasure
            // 
            this.groupBoxTreasure.Controls.Add(this.labelTreasureType);
            this.groupBoxTreasure.Controls.Add(this.labelTreasureLevelRange);
            this.groupBoxTreasure.Controls.Add(this.comboBoxTreasureLevelRange);
            this.groupBoxTreasure.Controls.Add(this.radioButtonTreasureHoard);
            this.groupBoxTreasure.Controls.Add(this.radioButtonTreasureIndividual);
            this.groupBoxTreasure.Location = new System.Drawing.Point(15, 56);
            this.groupBoxTreasure.Name = "groupBoxTreasure";
            this.groupBoxTreasure.Size = new System.Drawing.Size(118, 235);
            this.groupBoxTreasure.TabIndex = 10;
            this.groupBoxTreasure.TabStop = false;
            this.groupBoxTreasure.Text = "Treasure Features";
            this.groupBoxTreasure.Visible = false;
            // 
            // radioButtonTreasureIndividual
            // 
            this.radioButtonTreasureIndividual.AutoSize = true;
            this.radioButtonTreasureIndividual.Checked = true;
            this.radioButtonTreasureIndividual.Location = new System.Drawing.Point(10, 36);
            this.radioButtonTreasureIndividual.Name = "radioButtonTreasureIndividual";
            this.radioButtonTreasureIndividual.Size = new System.Drawing.Size(70, 17);
            this.radioButtonTreasureIndividual.TabIndex = 0;
            this.radioButtonTreasureIndividual.TabStop = true;
            this.radioButtonTreasureIndividual.Text = "Individual";
            this.radioButtonTreasureIndividual.UseVisualStyleBackColor = true;
            // 
            // radioButtonTreasureHoard
            // 
            this.radioButtonTreasureHoard.AutoSize = true;
            this.radioButtonTreasureHoard.Location = new System.Drawing.Point(10, 59);
            this.radioButtonTreasureHoard.Name = "radioButtonTreasureHoard";
            this.radioButtonTreasureHoard.Size = new System.Drawing.Size(54, 17);
            this.radioButtonTreasureHoard.TabIndex = 1;
            this.radioButtonTreasureHoard.TabStop = true;
            this.radioButtonTreasureHoard.Text = "Hoard";
            this.radioButtonTreasureHoard.UseVisualStyleBackColor = true;
            // 
            // comboBoxTreasureLevelRange
            // 
            this.comboBoxTreasureLevelRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTreasureLevelRange.FormattingEnabled = true;
            this.comboBoxTreasureLevelRange.Items.AddRange(new object[] {
            "0-4",
            "5-10",
            "11-16",
            "17+"});
            this.comboBoxTreasureLevelRange.Location = new System.Drawing.Point(10, 95);
            this.comboBoxTreasureLevelRange.Name = "comboBoxTreasureLevelRange";
            this.comboBoxTreasureLevelRange.Size = new System.Drawing.Size(102, 21);
            this.comboBoxTreasureLevelRange.TabIndex = 2;
            this.comboBoxTreasureLevelRange.SelectedIndex = 0;
            // 
            // labelTreasureLevelRange
            // 
            this.labelTreasureLevelRange.AutoSize = true;
            this.labelTreasureLevelRange.Location = new System.Drawing.Point(6, 79);
            this.labelTreasureLevelRange.Name = "labelTreasureLevelRange";
            this.labelTreasureLevelRange.Size = new System.Drawing.Size(68, 13);
            this.labelTreasureLevelRange.TabIndex = 3;
            this.labelTreasureLevelRange.Text = "Level Range";
            // 
            // labelTreasureType
            // 
            this.labelTreasureType.AutoSize = true;
            this.labelTreasureType.Location = new System.Drawing.Point(7, 20);
            this.labelTreasureType.Name = "labelTreasureType";
            this.labelTreasureType.Size = new System.Drawing.Size(31, 13);
            this.labelTreasureType.TabIndex = 4;
            this.labelTreasureType.Text = "Type";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 332);
            this.Controls.Add(this.groupBoxTreasure);
            this.Controls.Add(this.labelGenerator);
            this.Controls.Add(this.comboBoxGenerators);
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.buttonRandom);
            this.Name = "Form1";
            this.Text = "Random Generator";
            this.groupBoxTreasure.ResumeLayout(false);
            this.groupBoxTreasure.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonRandom;
        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.ComboBox comboBoxGenerators;
        private System.Windows.Forms.Label labelGenerator;
        private System.Windows.Forms.GroupBox groupBoxTreasure;
        private System.Windows.Forms.Label labelTreasureType;
        private System.Windows.Forms.Label labelTreasureLevelRange;
        private System.Windows.Forms.ComboBox comboBoxTreasureLevelRange;
        private System.Windows.Forms.RadioButton radioButtonTreasureHoard;
        private System.Windows.Forms.RadioButton radioButtonTreasureIndividual;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

