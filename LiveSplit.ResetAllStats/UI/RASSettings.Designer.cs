namespace LiveSplit.ResetAllStats.UI
{
    partial class RASSettings
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.linkStreamDB = new System.Windows.Forms.LinkLabel();
            this.numAppID = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAppID)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblVersion, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(321, 245);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.numAppID);
            this.groupBox1.Controls.Add(this.linkStreamDB);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(315, 88);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reset All Stats";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(3, 94);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(42, 13);
            this.lblVersion.TabIndex = 2;
            this.lblVersion.Text = "Version";
            // 
            // linkStreamDB
            // 
            this.linkStreamDB.Dock = System.Windows.Forms.DockStyle.Top;
            this.linkStreamDB.LinkArea = new System.Windows.Forms.LinkArea(134, 7);
            this.linkStreamDB.Location = new System.Drawing.Point(3, 16);
            this.linkStreamDB.Name = "linkStreamDB";
            this.linkStreamDB.Size = new System.Drawing.Size(309, 49);
            this.linkStreamDB.TabIndex = 3;
            this.linkStreamDB.TabStop = true;
            this.linkStreamDB.Text = "The App ID of the steam game you wish to reset all the stats for, including achie" +
    "vements. You can get the App ID of any steam game on steamdb.";
            this.linkStreamDB.UseCompatibleTextRendering = true;
            // 
            // numAppID
            // 
            this.numAppID.Dock = System.Windows.Forms.DockStyle.Top;
            this.numAppID.Location = new System.Drawing.Point(3, 65);
            this.numAppID.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numAppID.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numAppID.Name = "numAppID";
            this.numAppID.Size = new System.Drawing.Size(309, 20);
            this.numAppID.TabIndex = 4;
            this.numAppID.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // RASSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "RASSettings";
            this.Size = new System.Drawing.Size(321, 245);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numAppID)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.LinkLabel linkStreamDB;
        private System.Windows.Forms.NumericUpDown numAppID;
    }
}
