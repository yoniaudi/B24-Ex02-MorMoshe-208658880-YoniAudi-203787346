using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace BasicFacebookFeatures.Features.Volunteering
{
    public static class FileOperations
    {
        private static readonly string sr_FileName;

        static FileOperations()
        {
            sr_FileName = Application.ExecutablePath + "volunteers.xml";
        }

        public static void SaveVolunteerPersonToFile(VolunteerPerson i_VoluinteerPerson)
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

            if (File.Exists(sr_FileName))
            {
                using (FileStream stream = new FileStream(sr_FileName, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<VolunteerPerson>));

                    existingVolunteers = (List<VolunteerPerson>)serializer.Deserialize(stream);
                }
            }

            existingVolunteers.Add(volunteerPerson);

            using (FileStream stream = new FileStream(sr_FileName, FileMode.Create))
            {
                XmlSerializer listSerializer = new XmlSerializer(typeof(List<VolunteerPerson>));
                
                listSerializer.Serialize(stream, existingVolunteers);
            }
        }

        public static void SaveToFile(List<VolunteerPerson> i_VoluinteerPerson)
        {
            using (FileStream stream = new FileStream(sr_FileName, FileMode.Create))
            {
                XmlSerializer listSerializer = new XmlSerializer(typeof(List<VolunteerPerson>));
                
                listSerializer.Serialize(stream, i_VoluinteerPerson);
            }
        }

        public static List<VolunteerPerson> LoadFromFile()
        {
            List<VolunteerPerson> volunteerPeople = new List<VolunteerPerson>();

            if (File.Exists(sr_FileName))
            {
                using (FileStream stream = new FileStream(sr_FileName, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<VolunteerPerson>));
                    
                    volunteerPeople = (List<VolunteerPerson>)serializer.Deserialize(stream);
                }
            }

            return volunteerPeople;
        }
    }
}
