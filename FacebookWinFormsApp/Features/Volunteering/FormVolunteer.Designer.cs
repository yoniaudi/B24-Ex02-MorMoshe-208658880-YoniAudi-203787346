namespace BasicFacebookFeatures.Features.Volunteering
{
    public partial class FormVolunteer
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
            this.buttonFindVolunteer = new System.Windows.Forms.Button();
            this.buttonAddVolunteer = new System.Windows.Forms.Button();
            this.buttonRemoveVolunteer = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonFindVolunteer
            // 
            this.buttonFindVolunteer.Location = new System.Drawing.Point(6, 39);
            this.buttonFindVolunteer.Name = "buttonFindVolunteer";
            this.buttonFindVolunteer.Size = new System.Drawing.Size(114, 23);
            this.buttonFindVolunteer.TabIndex = 20;
            this.buttonFindVolunteer.Text = "Find Volunteer";
            this.buttonFindVolunteer.UseVisualStyleBackColor = true;
            this.buttonFindVolunteer.Click += new System.EventHandler(this.buttonFindVolunteer_Click);
            // 
            // buttonAddVolunteer
            // 
            this.buttonAddVolunteer.Location = new System.Drawing.Point(126, 39);
            this.buttonAddVolunteer.Name = "buttonAddVolunteer";
            this.buttonAddVolunteer.Size = new System.Drawing.Size(118, 23);
            this.buttonAddVolunteer.TabIndex = 30;
            this.buttonAddVolunteer.Text = "Add Volunteer";
            this.buttonAddVolunteer.UseVisualStyleBackColor = true;
            this.buttonAddVolunteer.Click += new System.EventHandler(this.buttonAddVolunteer_Click);
            // 
            // buttonRemoveVolunteer
            // 
            this.buttonRemoveVolunteer.Location = new System.Drawing.Point(250, 39);
            this.buttonRemoveVolunteer.Name = "buttonRemoveVolunteer";
            this.buttonRemoveVolunteer.Size = new System.Drawing.Size(118, 23);
            this.buttonRemoveVolunteer.TabIndex = 40;
            this.buttonRemoveVolunteer.Text = "Remove Volunteer";
            this.buttonRemoveVolunteer.UseVisualStyleBackColor = true;
            this.buttonRemoveVolunteer.Click += new System.EventHandler(this.buttonRemoveVolunteer_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(3, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(202, 13);
            this.labelTitle.TabIndex = 10;
            this.labelTitle.Text = "Help your loved community and voulnteer";
            // 
            // FormVolunteer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(373, 73);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.buttonRemoveVolunteer);
            this.Controls.Add(this.buttonAddVolunteer);
            this.Controls.Add(this.buttonFindVolunteer);
            this.Name = "FormVolunteer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormVolunteer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonFindVolunteer;
        private System.Windows.Forms.Button buttonAddVolunteer;
        private System.Windows.Forms.Button buttonRemoveVolunteer;
        private System.Windows.Forms.Label labelTitle;
    }
}