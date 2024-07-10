using System;
using System.Windows.Forms;

namespace BasicFacebookFeatures.Features.Volunteering
{
    public partial class FormAddVolunteer : Form
    {
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
            if (validateData(out VolunteerPerson volunteerPerson))
            {
                m_VolunteerService.SaveVolunteerPerson(volunteerPerson);
                MessageBox.Show("Data Saved Successfully!");
            }
        }

        private VolunteerPerson collectFormData()
        {
            return new VolunteerPerson()
            {
                Subject = comboBoxSubject.Text,
                Location = textBoxLocation.Text,
                PhoneNumber = textBoxPhone.Text,
                StartDate = m_StartAvailableDate,
                EndDate = m_EndAvailableDate
            };
        }

        private bool validateData(out VolunteerPerson volunteerPerson)
        {
            volunteerPerson = collectFormData();

            string errorMessage;
            bool isValid = m_VolunteerService.ValidateData(volunteerPerson, out errorMessage);

            if (!isValid)
            {
                MessageBox.Show(errorMessage);
            }

            return isValid;
        }
    }
}
