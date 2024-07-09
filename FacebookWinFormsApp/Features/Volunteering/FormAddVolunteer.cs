using System;
using System.Windows.Forms;

namespace BasicFacebookFeatures.Features.Volunteering
{
    public partial class FormAddVolunteer : Form
    {
        private string m_Subject;
        private string m_Location;
        private string m_Phone;
        private DateTime m_StartAvailableDate;
        private DateTime m_EndAvailableDate;
        private readonly AddVolunteerService m_VolunteerService;

        public FormAddVolunteer()
        {
            InitializeComponent();
            m_StartAvailableDate = DateTime.Now;
            m_EndAvailableDate = DateTime.Now;
            m_VolunteerService = new AddVolunteerService();
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
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void buttonAddVolunteer_Click(object sender, EventArgs e)
        {
            if (collectFormData() && validateData())
            {
                var volunteerPerson = new VolunteerPerson()
                {
                    Subject = m_Subject,
                    Location = m_Location,
                    PhoneNumber = m_Phone,
                    StartDate = m_StartAvailableDate,
                    EndDate = m_EndAvailableDate
                };

                m_VolunteerService.SaveVolunteerPerson(volunteerPerson);
                MessageBox.Show("Data Saved Successfully!");
            }
        }

        private bool collectFormData()
        {
            m_Subject = comboBoxSubject.Text;
            m_Location = textBoxLocation.Text;
            m_Phone = textBoxPhone.Text;

            return !string.IsNullOrEmpty(m_Subject) &&
                   !string.IsNullOrEmpty(m_Location) &&
                   !string.IsNullOrEmpty(m_Phone) &&
                   m_StartAvailableDate <= m_EndAvailableDate;
        }

        private bool validateData()
        {
            string errorMessage;
            bool isValid = m_VolunteerService.ValidateData(m_Subject, m_Location, m_StartAvailableDate, m_EndAvailableDate, m_Phone, out errorMessage);

            if (!isValid)
            {
                MessageBox.Show(errorMessage);
            }

            return isValid;
        }
    }
}
