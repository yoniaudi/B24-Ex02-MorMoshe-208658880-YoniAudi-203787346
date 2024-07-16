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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label labelBirthday;
            System.Windows.Forms.Label labelEmail;
            System.Windows.Forms.Label labelFirstName;
            System.Windows.Forms.Label labelLastName;
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dateTimePickerUserBirthday = new System.Windows.Forms.DateTimePicker();
            this.labelUserEmail = new System.Windows.Forms.Label();
            this.labelLanguages = new System.Windows.Forms.Label();
            this.labelUserLanguages = new System.Windows.Forms.Label();
            this.textBoxUserFirstName = new System.Windows.Forms.TextBox();
            this.textBoxUserLastName = new System.Windows.Forms.TextBox();
            labelBirthday = new System.Windows.Forms.Label();
            labelEmail = new System.Windows.Forms.Label();
            labelFirstName = new System.Windows.Forms.Label();
            labelLastName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // labelBirthday
            // 
            labelBirthday.AutoSize = true;
            labelBirthday.Location = new System.Drawing.Point(3, 84);
            labelBirthday.Name = "labelBirthday";
            labelBirthday.Size = new System.Drawing.Size(48, 13);
            labelBirthday.TabIndex = 2;
            labelBirthday.Text = "Birthday:";
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Location = new System.Drawing.Point(3, 59);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new System.Drawing.Size(35, 13);
            labelEmail.TabIndex = 4;
            labelEmail.Text = "Email:";
            // 
            // labelFirstName
            // 
            labelFirstName.AutoSize = true;
            labelFirstName.Location = new System.Drawing.Point(3, 9);
            labelFirstName.Name = "labelFirstName";
            labelFirstName.Size = new System.Drawing.Size(60, 13);
            labelFirstName.TabIndex = 11;
            labelFirstName.Text = "First Name:";
            // 
            // labelLastName
            // 
            labelLastName.AutoSize = true;
            labelLastName.Location = new System.Drawing.Point(3, 34);
            labelLastName.Name = "labelLastName";
            labelLastName.Size = new System.Drawing.Size(61, 13);
            labelLastName.TabIndex = 12;
            labelLastName.Text = "Last Name:";
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(FacebookWrapper.ObjectModel.User);
            // 
            // dateTimePickerUserBirthday
            // 
            this.dateTimePickerUserBirthday.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.userBindingSource, "Birthday", true));
            this.dateTimePickerUserBirthday.Location = new System.Drawing.Point(69, 83);
            this.dateTimePickerUserBirthday.Name = "dateTimePickerUserBirthday";
            this.dateTimePickerUserBirthday.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerUserBirthday.TabIndex = 3;
            // 
            // labelUserEmail
            // 
            this.labelUserEmail.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.userBindingSource, "Email", true));
            this.labelUserEmail.Location = new System.Drawing.Point(69, 61);
            this.labelUserEmail.Name = "labelUserEmail";
            this.labelUserEmail.Size = new System.Drawing.Size(200, 23);
            this.labelUserEmail.TabIndex = 5;
            this.labelUserEmail.Text = "User Email";
            // 
            // labelLanguages
            // 
            this.labelLanguages.AutoSize = true;
            this.labelLanguages.Location = new System.Drawing.Point(3, 109);
            this.labelLanguages.Name = "labelLanguages";
            this.labelLanguages.Size = new System.Drawing.Size(58, 13);
            this.labelLanguages.TabIndex = 10;
            this.labelLanguages.Text = "Language:";
            // 
            // labelUserLanguages
            // 
            this.labelUserLanguages.AutoSize = true;
            this.labelUserLanguages.Location = new System.Drawing.Point(69, 110);
            this.labelUserLanguages.Name = "labelUserLanguages";
            this.labelUserLanguages.Size = new System.Drawing.Size(85, 13);
            this.labelUserLanguages.TabIndex = 11;
            this.labelUserLanguages.Text = "User Languages";
            // 
            // textBoxUserFirstName
            // 
            this.textBoxUserFirstName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.userBindingSource, "FirstName", true));
            this.textBoxUserFirstName.Location = new System.Drawing.Point(70, 6);
            this.textBoxUserFirstName.Name = "textBoxUserFirstName";
            this.textBoxUserFirstName.Size = new System.Drawing.Size(199, 20);
            this.textBoxUserFirstName.TabIndex = 12;
            this.textBoxUserFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxUserFirstName_Validating);
            this.textBoxUserFirstName.Validated += new System.EventHandler(this.textBoxUserFirstName_Validated);
            // 
            // textBoxUserLastName
            // 
            this.textBoxUserLastName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.userBindingSource, "LastName", true));
            this.textBoxUserLastName.Location = new System.Drawing.Point(70, 31);
            this.textBoxUserLastName.Name = "textBoxUserLastName";
            this.textBoxUserLastName.Size = new System.Drawing.Size(199, 20);
            this.textBoxUserLastName.TabIndex = 13;
            this.textBoxUserLastName.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxUserLastName_Validating);
            this.textBoxUserLastName.Validated += new System.EventHandler(this.textBoxUserLastName_Validated);
            // 
            // ProfileController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(labelLastName);
            this.Controls.Add(this.textBoxUserLastName);
            this.Controls.Add(labelFirstName);
            this.Controls.Add(this.textBoxUserFirstName);
            this.Controls.Add(this.labelUserLanguages);
            this.Controls.Add(this.labelLanguages);
            this.Controls.Add(labelBirthday);
            this.Controls.Add(this.dateTimePickerUserBirthday);
            this.Controls.Add(labelEmail);
            this.Controls.Add(this.labelUserEmail);
            this.Name = "ProfileController";
            this.Size = new System.Drawing.Size(276, 132);
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.DateTimePicker dateTimePickerUserBirthday;
        private System.Windows.Forms.Label labelUserEmail;
        private System.Windows.Forms.Label labelLanguages;
        private System.Windows.Forms.Label labelUserLanguages;
        private System.Windows.Forms.TextBox textBoxUserFirstName;
        private System.Windows.Forms.TextBox textBoxUserLastName;
    }
}
