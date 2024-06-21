using System;
using System.Windows.Forms;

namespace BasicFacebookFeatures.Features.Volunteering
{
    public partial class FormAddVolunteer : Form
    {
        string m_Subject = null;
        string m_Location = null;
        string m_Phone = null;
        DateTime m_StartAvailableDate;
        DateTime m_EndAvailableDate;

        public FormAddVolunteer()
        {
            InitializeComponent();
            m_StartAvailableDate = DateTime.Now;
            m_EndAvailableDate = DateTime.Now;
        }

        private void dateTimePickerStartDate_ValueChanged(object sender, EventArgs e)
        {
            m_StartAvailableDate = dateTimePickerStartDate.Value;
        }

        private void dateTimePickerEndDate_ValueChanged(object sender, EventArgs e)
        {
            m_EndAvailableDate = dateTimePickerEndDate.Value;
        }

        private void textBoxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void buttonAddVolunteer_Click(object sender, EventArgs e)
        {
            VolunteerPerson volunteerPerson = null;

            if (checkDataValidation())
            {
                volunteerPerson = new VolunteerPerson()
                {
                    Subject = m_Subject,
                    Location = m_Location,
                    PhoneNumber = m_Phone,
                    StartDate = m_StartAvailableDate,
                    EndDate = m_EndAvailableDate
                };

                FileOperations.SaveVolunteerPersonToFile(volunteerPerson);
                MessageBox.Show("Data Saved Successfully!");
            }
            else
            {
                MessageBox.Show("Saved Failed!");
            }
        }

        private bool checkDataValidation()
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(comboBoxSubject.Text) == false)
            {
                m_Subject = comboBoxSubject.Text;
            }
            else
            {
                isValid = false;
                MessageBox.Show("Choose subject");
            }

            if (string.IsNullOrEmpty(textBoxLocation.Text) == false)
            {
                m_Location = textBoxLocation.Text;
            }
            else
            {
                isValid = false;
                MessageBox.Show("Choose location");
            }

            if (String.IsNullOrEmpty(m_StartAvailableDate.ToString()) ||
                String.IsNullOrEmpty(m_EndAvailableDate.ToString()) ||
                m_StartAvailableDate > m_EndAvailableDate)
            {
                isValid = false;
                MessageBox.Show("Invalid dates");
            }

            if (String.IsNullOrEmpty(textBoxPhone.Text) == false)
            {
                m_Phone = textBoxPhone.Text;
            }
            else
            {
                isValid = false;
                MessageBox.Show("Enter phone number");
            }

            return isValid;
        }
    }
}
