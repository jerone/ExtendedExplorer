namespace ExtendedExplorer
{
    partial class TaskDialog
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
            this.picSystemIcon = new System.Windows.Forms.PictureBox();
            this.lMsg = new System.Windows.Forms.Label();
            this.btnNo = new CommandLink();
            this.btnYes = new CommandLink();
            ((System.ComponentModel.ISupportInitialize)(this.picSystemIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // picSystemIcon
            // 
            this.picSystemIcon.Location = new System.Drawing.Point(21, 19);
            this.picSystemIcon.Name = "picSystemIcon";
            this.picSystemIcon.Size = new System.Drawing.Size(36, 36);
            this.picSystemIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picSystemIcon.TabIndex = 0;
            this.picSystemIcon.TabStop = false;
            // 
            // lMsg
            // 
            this.lMsg.AutoSize = true;
            this.lMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lMsg.Location = new System.Drawing.Point(76, 12);
            this.lMsg.Name = "lMsg";
            this.lMsg.Size = new System.Drawing.Size(100, 25);
            this.lMsg.TabIndex = 0;
            this.lMsg.Text = "Message";
            // 
            // btnNo
            // 
            this.btnNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNo.DescriptionText = "No Message";
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnNo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNo.HeaderText = "No";
            this.btnNo.Image = global::ExtendedExplorer.Properties.Resources.delete;
            this.btnNo.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.btnNo.Location = new System.Drawing.Point(32, 138);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(244, 50);
            this.btnNo.TabIndex = 1;
            // 
            // btnYes
            // 
            this.btnYes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYes.DescriptionText = "Yes Message";
            this.btnYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnYes.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYes.HeaderText = "Yes";
            this.btnYes.Image = global::ExtendedExplorer.Properties.Resources.check;
            this.btnYes.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.btnYes.Location = new System.Drawing.Point(32, 82);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(244, 50);
            this.btnYes.TabIndex = 2;
            // 
            // YesNoDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 210);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.lMsg);
            this.Controls.Add(this.picSystemIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "YesNoDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.picSystemIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picSystemIcon;
        private System.Windows.Forms.Label lMsg;
        private CommandLink btnYes;
        private CommandLink btnNo;
    }
}