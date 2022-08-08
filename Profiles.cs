namespace Course
{
    public class ProfilesClass
    {
        public static List<Profile> profiles = new List<Profile>();
        public void CreateProfile(string FirstName, string LastName, string MiddleName, string Foto, string SocialID, string Email, string PhoneNumber)
        {
            Profile profile = new Profile();
            profile.FirstName = FirstName;
            profile.LastName = LastName;
            profile.MiddleName = MiddleName;
            profile.Foto = Foto;
            profile.SocialID = SocialID;
            profile.Email = Email;
            profile.PhoneNumber = PhoneNumber;
            profiles.Add(profile);
        }
        public string WriteAllProfiles()
        {
            string text = "";
            foreach (Profile profile in profiles)
            {
                text += profile.LastName + " " + profile.FirstName + " " + profile.MiddleName + "\n";
                text += profile.Foto + "\n";
                text += profile.SocialID + "\n";
                text += profile.Email + "\n";
                text += profile.PhoneNumber + "\n";
            }
            return text;
        }
        public bool UpdateProfile(int index, Profile profile)
        {
            try
            {
                if (profile.FirstName != null && profile.FirstName != "string")
                {
                    profiles[index].FirstName = profile.FirstName;
                }
                if (profile.LastName != null && profile.LastName != "string")
                {
                    profiles[index].LastName = profile.LastName;
                }
                if (profile.MiddleName != null && profile.MiddleName != "string")
                {
                    profiles[index].MiddleName = profile.MiddleName;
                }
                if (profile.Foto != null && profile.Foto != "string")
                {
                    profiles[index].Foto = profile.Foto;
                }
                if (profile.SocialID != null && profile.SocialID != "string")
                {
                    profiles[index].SocialID = profile.SocialID;
                }
                if (profile.Email != null && profile.Email != "string")
                {
                    profiles[index].Email = profile.Email;
                }
                if (profile.PhoneNumber != null && profile.PhoneNumber != "string")
                {
                    profiles[index].PhoneNumber = profile.PhoneNumber;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteProfile(int index)
        {
            try
            {
                profiles.RemoveAt(index);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
    public class Profile
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Foto { get; set; }
        public string SocialID { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
