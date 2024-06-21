namespace BasicFacebookFeatures.Models
{
    public partial class ProfileController
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelFirstName = new System.Windows.Forms.Label();
            this.labelUserFirstName = new System.Windows.Forms.Label();
            this.labelLastName = new System.Windows.Forms.Label();
            this.labelUserLastName = new System.Windows.Forms.Label();
            this.labelEmailAddress = new System.Windows.Forms.Label();
            this.labelUserEmailAddress = new System.Windows.Forms.Label();
            this.labelBirthday = new System.Windows.Forms.Label();
            this.labelUserBirthday = new System.Windows.Forms.Label();
            this.labelLocation = new System.Windows.Forms.Label();
            this.labelUserLocation = new System.Windows.Forms.Label();
            this.labelLanguages = new System.Windows.Forms.Label();
            this.labelUserLanguages = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelFirstName
            // 
            this.labelFirstName.AutoSize = true;
            this.labelFirstName.Location = new System.Drawing.Point(3, 9);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(60, 13);
            this.labelFirstName.TabIndex = 0;
            this.labelFirstName.Text = "First Name:";
            // 
            // labelUserFirstName
            // 
            this.labelUserFirstName.AutoSize = true;
            this.labelUserFirstName.Location = new System.Drawing.Point(69, 9);
            this.labelUserFirstName.Name = "labelUserFirstName";
            this.labelUserFirstName.Size = new System.Drawing.Size(82, 13);
            this.labelUserFirstName.TabIndex = 8;
            this.labelUserFirstName.Text = "User First Name";
            // 
            // labelLastName
            // 
            this.labelLastName.AutoSize = true;
            this.labelLastName.Location = new System.Drawing.Point(3, 32);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(61, 13);
            this.labelLastName.TabIndex = 1;
            this.labelLastName.Text = "Last Name:";
            // 
            // labelUserLastName
            // 
            this.labelUserLastName.AutoSize = true;
            this.labelUserLastName.Location = new System.Drawing.Point(69, 32);
            this.labelUserLastName.Name = "labelUserLastName";
            this.labelUserLastName.Size = new System.Drawing.Size(83, 13);
            this.labelUserLastName.TabIndex = 9;
            this.labelUserLastName.Text = "User Last Name";
            // 
            // labelEmailAddress
            // 
            this.labelEmailAddress.AutoSize = true;
            this.labelEmailAddress.Location = new System.Drawing.Point(3, 101);
            this.labelEmailAddress.Name = "labelEmailAddress";
            this.labelEmailAddress.Size = new System.Drawing.Size(35, 13);
            this.labelEmailAddress.TabIndex = 2;
            this.labelEmailAddress.Text = "Email:";
            // 
            // labelUserEmailAddress
            // 
            this.labelUserEmailAddress.AutoSize = true;
            this.labelUserEmailAddress.Location = new System.Drawing.Point(69, 101);
            this.labelUserEmailAddress.Name = "labelUserEmailAddress";
            this.labelUserEmailAddress.Size = new System.Drawing.Size(57, 13);
            this.labelUserEmailAddress.TabIndex = 10;
            this.labelUserEmailAddress.Text = "User Email";
            // 
            // labelBirthday
            // 
            this.labelBirthday.AutoSize = true;
            this.labelBirthday.Location = new System.Drawing.Point(3, 55);
            this.labelBirthday.Name = "labelBirthday";
            this.labelBirthday.Size = new System.Drawing.Size(48, 13);
            this.labelBirthday.TabIndex = 3;
            this.labelBirthday.Text = "Birthday:";
            // 
            // labelUserBirthday
            // 
            this.labelUserBirthday.AutoSize = true;
            this.labelUserBirthday.Location = new System.Drawing.Point(69, 55);
            this.labelUserBirthday.Name = "labelUserBirthday";
            this.labelUserBirthday.Size = new System.Drawing.Size(70, 13);
            this.labelUserBirthday.TabIndex = 11;
            this.labelUserBirthday.Text = "User Birthday";
            // 
            // labelLocation
            // 
            this.labelLocation.AutoSize = true;
            this.labelLocation.Location = new System.Drawing.Point(3, 78);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Size = new System.Drawing.Size(51, 13);
            this.labelLocation.TabIndex = 4;
            this.labelLocation.Text = "Location:";
            // 
            // labelUserLocation
            // 
            this.labelUserLocation.AutoSize = true;
            this.labelUserLocation.Location = new System.Drawing.Point(69, 78);
            this.labelUserLocation.Name = "labelUserLocation";
            this.labelUserLocation.Size = new System.Drawing.Size(73, 13);
            this.labelUserLocation.TabIndex = 12;
            this.labelUserLocation.Text = "User Location";
            // 
            // labelLanguages
            // 
            this.labelLanguages.AutoSize = true;
            this.labelLanguages.Location = new System.Drawing.Point(3, 124);
            this.labelLanguages.Name = "labelLanguages";
            this.labelLanguages.Size = new System.Drawing.Size(63, 13);
            this.labelLanguages.TabIndex = 7;
            this.labelLanguages.Text = "Languages:";
            // 
            // labelUserLanguages
            // 
            this.labelUserLanguages.AutoSize = true;
            this.labelUserLanguages.Location = new System.Drawing.Point(69, 124);
            this.labelUserLanguages.Name = "labelUserLanguages";
            this.labelUserLanguages.Size = new System.Drawing.Size(85, 13);
            this.labelUserLanguages.TabIndex = 14;
            this.labelUserLanguages.Text = "User Languages";
            // 
            // Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelFirstName);
            this.Controls.Add(this.labelUserFirstName);
            this.Controls.Add(this.labelLastName);
            this.Controls.Add(this.labelUserLastName);
            this.Controls.Add(this.labelBirthday);
            this.Controls.Add(this.labelUserBirthday);
            this.Controls.Add(this.labelLocation);
            this.Controls.Add(this.labelUserLocation);
            this.Controls.Add(this.labelEmailAddress);
            this.Controls.Add(this.labelUserEmailAddress);
            this.Controls.Add(this.labelLanguages);
            this.Controls.Add(this.labelUserLanguages);
            this.Name = "Profile";
            this.Size = new System.Drawing.Size(327, 145);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.Label labelUserFirstName;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.Label labelUserLastName;
        private System.Windows.Forms.Label labelEmailAddress;
        private System.Windows.Forms.Label labelUserEmailAddress;
        private System.Windows.Forms.Label labelBirthday;
        private System.Windows.Forms.Label labelUserBirthday;
        private System.Windows.Forms.Label labelLocation;
        private System.Windows.Forms.Label labelUserLocation;
        private System.Windows.Forms.Label labelLanguages;
        private System.Windows.Forms.Label labelUserLanguages;
    }
}
