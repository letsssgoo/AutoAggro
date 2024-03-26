namespace AutoAggro
{
    partial class AutoAggro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoAggro));
            this.timerStopAttack = new System.Windows.Forms.Timer(this.components);
            this.darkLabel8 = new DarkUI.Controls.DarkLabel();
            this.txtMapName = new DarkUI.Controls.DarkLabel();
            this.cbAutoAggro = new DarkUI.Controls.DarkCheckBox();
            this.txtAggroText = new DarkUI.Controls.DarkLabel();
            this.darkLabel9 = new DarkUI.Controls.DarkLabel();
            this.darkLabel10 = new DarkUI.Controls.DarkLabel();
            this.numAggroDelay = new DarkUI.Controls.DarkNumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numAggroDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // darkLabel8
            // 
            this.darkLabel8.AutoSize = true;
            this.darkLabel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel8.Location = new System.Drawing.Point(23, 20);
            this.darkLabel8.Name = "darkLabel8";
            this.darkLabel8.Size = new System.Drawing.Size(57, 25);
            this.darkLabel8.TabIndex = 40;
            this.darkLabel8.Text = "Map:";
            // 
            // txtMapName
            // 
            this.txtMapName.AutoSize = true;
            this.txtMapName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMapName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtMapName.Location = new System.Drawing.Point(86, 20);
            this.txtMapName.Name = "txtMapName";
            this.txtMapName.Size = new System.Drawing.Size(34, 25);
            this.txtMapName.TabIndex = 41;
            this.txtMapName.Text = "aa";
            // 
            // cbAutoAggro
            // 
            this.cbAutoAggro.AutoSize = true;
            this.cbAutoAggro.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAutoAggro.Location = new System.Drawing.Point(22, 81);
            this.cbAutoAggro.Name = "cbAutoAggro";
            this.cbAutoAggro.Size = new System.Drawing.Size(197, 26);
            this.cbAutoAggro.TabIndex = 30;
            this.cbAutoAggro.Text = "Enable Auto Aggro";
            this.cbAutoAggro.CheckedChanged += new System.EventHandler(this.cbAutoAggro_CheckedChanged);
            // 
            // txtAggroText
            // 
            this.txtAggroText.AutoSize = true;
            this.txtAggroText.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAggroText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtAggroText.Location = new System.Drawing.Point(25, 121);
            this.txtAggroText.Name = "txtAggroText";
            this.txtAggroText.Size = new System.Drawing.Size(19, 13);
            this.txtAggroText.TabIndex = 42;
            this.txtAggroText.Text = "aa";
            // 
            // darkLabel9
            // 
            this.darkLabel9.AutoSize = true;
            this.darkLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel9.Location = new System.Drawing.Point(162, 56);
            this.darkLabel9.Name = "darkLabel9";
            this.darkLabel9.Size = new System.Drawing.Size(20, 13);
            this.darkLabel9.TabIndex = 45;
            this.darkLabel9.Text = "ms";
            // 
            // darkLabel10
            // 
            this.darkLabel10.AutoSize = true;
            this.darkLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel10.Location = new System.Drawing.Point(25, 54);
            this.darkLabel10.Name = "darkLabel10";
            this.darkLabel10.Size = new System.Drawing.Size(68, 13);
            this.darkLabel10.TabIndex = 44;
            this.darkLabel10.Text = "Aggro Delay:";
            // 
            // numAggroDelay
            // 
            this.numAggroDelay.IncrementAlternate = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.numAggroDelay.Location = new System.Drawing.Point(99, 52);
            this.numAggroDelay.LoopValues = false;
            this.numAggroDelay.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.numAggroDelay.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numAggroDelay.Name = "numAggroDelay";
            this.numAggroDelay.Size = new System.Drawing.Size(60, 20);
            this.numAggroDelay.TabIndex = 43;
            this.numAggroDelay.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // AutoAggro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 150);
            this.Controls.Add(this.darkLabel9);
            this.Controls.Add(this.darkLabel10);
            this.Controls.Add(this.numAggroDelay);
            this.Controls.Add(this.txtAggroText);
            this.Controls.Add(this.cbAutoAggro);
            this.Controls.Add(this.txtMapName);
            this.Controls.Add(this.darkLabel8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AutoAggro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Auto Aggro";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numAggroDelay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timerStopAttack;
        private DarkUI.Controls.DarkLabel darkLabel8;
        private DarkUI.Controls.DarkLabel txtMapName;
        public DarkUI.Controls.DarkCheckBox cbAutoAggro;
        private DarkUI.Controls.DarkLabel txtAggroText;
        private DarkUI.Controls.DarkLabel darkLabel9;
        private DarkUI.Controls.DarkLabel darkLabel10;
        private DarkUI.Controls.DarkNumericUpDown numAggroDelay;
    }
}