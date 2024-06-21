namespace BasicFacebookFeatures.Features.Volunteering
{
    public partial class FormRemoveVolunteer
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
            this.listBoxVolunteers = new System.Windows.Forms.ListBox();
            this.labelRemoveVolunteers = new System.Windows.Forms.Label();
            this.labelPhone = new System.Windows.Forms.Label();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.buttonRemoveVolunteer = new System.Windows.Forms.Button();
            this.buttonFindMyVolunteers = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxVolunteers
            // 
            this.listBoxVolunteers.FormattingEnabled = true;
            this.listBoxVolunteers.Location = new System.Drawing.Point(19, 79);
            this.listBoxVolunteers.Name = "listBoxVolunteers";
            this.listBoxVolunteers.Size = new System.Drawing.Size(387, 173);
            this.listBoxVolunteers.TabIndex = 0;
            // 
            // labelRemoveVolunteers
            // 
            this.labelRemoveVolunteers.AutoSize = true;
            this.labelRemoveVolunteers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRemoveVolunteers.Location = new System.Drawing.Point(126, 9);
            this.labelRemoveVolunteers.Name = "labelRemoveVolunteers";
            this.labelRemoveVolunteers.Size = new System.Drawing.Size(173, 20);
            this.labelRemoveVolunteers.TabIndex = 22;
            this.labelRemoveVolunteers.Text = "Remove My Volunteers";
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Location = new System.Drawing.Point(52, 45);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(41, 13);
            this.labelPhone.TabIndex = 23;
            this.labelPhone.Text = "Phone:";
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(100, 42);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(132, 20);
            this.textBoxPhone.TabIndex = 24;
            this.textBoxPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPhone_KeyPress);
            // 
            // buttonRemoveVolunteer
            // 
            this.buttonRemoveVolunteer.Location = new System.Drawing.Point(159, 275);
            this.buttonRemoveVolunteer.Name = "buttonRemoveVolunteer";
            this.buttonRemoveVolunteer.Size = new System.Drawing.Size(114, 48);
            this.buttonRemoveVolunteer.TabIndex = 25;
            this.buttonRemoveVolunteer.Text = "Remove Volunteer";
            this.buttonRemoveVolunteer.UseVisualStyleBackColor = true;
            this.buttonRemoveVolunteer.Click += new System.EventHandler(this.buttonRemoveVolunteer_Click);
            // 
            // buttonFindMyVolunteers
            // 
            this.buttonFindMyVolunteers.Location = new System.Drawing.Point(252, 35);
            this.buttonFindMyVolunteers.Name = "buttonFindMyVolunteers";
            this.buttonFindMyVolunteers.Size = new System.Drawing.Size(110, 33);
            this.buttonFindMyVolunteers.TabIndex = 26;
            this.buttonFindMyVolunteers.Text = "Find My Volunteers";
            this.buttonFindMyVolunteers.UseVisualStyleBackColor = true;
            this.buttonFindMyVolunteers.Click += new System.EventHandler(this.buttonFindMyVolunteers_Click);
            // 
            // FormRemoveVolunteer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(442, 345);
            this.Controls.Add(this.buttonFindMyVolunteers);
            this.Controls.Add(this.buttonRemoveVolunteer);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.labelPhone);
            this.Controls.Add(this.labelRemoveVolunteers);
            this.Controls.Add(this.listBoxVolunteers);
            this.Name = "FormRemoveVolunteer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RemoveVolunteer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxVolunteers;
        private System.Windows.Forms.Label labelRemoveVolunteers;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.Button buttonRemoveVolunteer;
        private System.Windows.Forms.Button buttonFindMyVolunteers;
    }
}