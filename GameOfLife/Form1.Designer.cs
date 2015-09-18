namespace GameOfLife
{
    partial class MainForm
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
            this.sbHistory = new System.Windows.Forms.HScrollBar();
            this.SuspendLayout();
            // 
            // sbHistory
            // 
            this.sbHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sbHistory.Location = new System.Drawing.Point(9, 9);
            this.sbHistory.Name = "sbHistory";
            this.sbHistory.Size = new System.Drawing.Size(765, 17);
            this.sbHistory.TabIndex = 0;
            this.sbHistory.ValueChanged += new System.EventHandler(this.sbHistory_ValueChanged);
            this.sbHistory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sbHistory_KeyDown);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 644);
            this.Controls.Add(this.sbHistory);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.Text = "Game Of Life";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.HScrollBar sbHistory;
    }
}

