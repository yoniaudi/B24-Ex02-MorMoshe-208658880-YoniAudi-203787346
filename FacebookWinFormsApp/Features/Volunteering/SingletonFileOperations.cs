using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace BasicFacebookFeatures.Features.Volunteering
{
    public sealed class SingletonFileOperations
    {
        private readonly string r_FileName = null;

        private SingletonFileOperations()
        {
            r_FileName = Application.ExecutablePath + "volunteers.xml";
        }

        public void SaveVolunteerPersonToFile(VolunteerPerson i_VoluinteerPerson)
        {
            List<VolunteerPerson> existingVolunteers = new List<VolunteerPerson>();
            VolunteerPerson volunteerPerson = new VolunteerPerson()
            {
                Subject = i_VoluinteerPerson.Subject,
                Location = i_VoluinteerPerson.Location,
                PhoneNumber = i_VoluinteerPerson.PhoneNumber,
                StartDate = i_VoluinteerPerson.StartDate,
                EndDate = i_VoluinteerPerson.EndDate
            };

            if (File.Exists(r_FileName))
            {
                using (FileStream stream = new FileStream(r_FileName, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<VolunteerPerson>));

                    existingVolunteers = (List<VolunteerPerson>)serializer.Deserialize(stream);
                }
            }

            existingVolunteers.Add(volunteerPerson);

            using (FileStream stream = new FileStream(r_FileName, FileMode.Create))
            {
                XmlSerializer listSerializer = new XmlSerializer(typeof(List<VolunteerPerson>));
                
                listSerializer.Serialize(stream, existingVolunteers);
            }
        }

        public void SaveToFile(List<VolunteerPerson> i_VoluinteerPerson)
        {
            using (FileStream stream = new FileStream(r_FileName, FileMode.Create))
            {
                XmlSerializer listSerializer = new XmlSerializer(typeof(List<VolunteerPerson>));
                
                listSerializer.Serialize(stream, i_VoluinteerPerson);
            }
        }

        public List<VolunteerPerson> LoadFromFile()
        {
            List<VolunteerPerson> volunteerPeople = new List<VolunteerPerson>();

            if (File.Exists(r_FileName))
            {
                using (FileStream stream = new FileStream(r_FileName, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<VolunteerPerson>));
                    
                    volunteerPeople = (List<VolunteerPerson>)serializer.Deserialize(stream);
                }
            }

            return volunteerPeople;
        }
    }
}
