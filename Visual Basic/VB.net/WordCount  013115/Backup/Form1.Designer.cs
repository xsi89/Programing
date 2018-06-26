namespace WordCount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnCount = new System.Windows.Forms.Button();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.lblContent = new System.Windows.Forms.Label();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.chkStripTags = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnCount
            // 
            this.btnCount.Location = new System.Drawing.Point(172, 136);
            this.btnCount.Name = "btnCount";
            this.btnCount.Size = new System.Drawing.Size(75, 23);
            this.btnCount.TabIndex = 0;
            this.btnCount.Text = "Count";
            this.btnCount.UseVisualStyleBackColor = true;
            this.btnCount.Click += new System.EventHandler(this.btnCount_Click);
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(98, 176);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(150, 20);
            this.txtCount.TabIndex = 1;
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.Location = new System.Drawing.Point(9, 9);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(73, 13);
            this.lblContent.TabIndex = 2;
            this.lblContent.Text = "Text to count:";
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(12, 25);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtContent.Size = new System.Drawing.Size(236, 105);
            this.txtContent.TabIndex = 3;
            this.txtContent.Text = resources.GetString("txtContent.Text");
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(9, 179);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(83, 13);
            this.lblCount.TabIndex = 4;
            this.lblCount.Text = "Words counted:";
            // 
            // chkStripTags
            // 
            this.chkStripTags.AutoSize = true;
            this.chkStripTags.Location = new System.Drawing.Point(12, 136);
            this.chkStripTags.Name = "chkStripTags";
            this.chkStripTags.Size = new System.Drawing.Size(74, 17);
            this.chkStripTags.TabIndex = 5;
            this.chkStripTags.Text = "Strip Tags";
            this.chkStripTags.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 208);
            this.Controls.Add(this.chkStripTags);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.lblContent);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.btnCount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Word Counter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCount;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.CheckBox chkStripTags;
    }
}

