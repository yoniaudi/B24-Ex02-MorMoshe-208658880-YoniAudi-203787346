using BasicFacebookFeatures.Models;

namespace BasicFacebookFeatures
{
    public interface IControllers
    {
        string DisplayMember { get; }
        object DataSource { get; set; }
        void LoadData();
        void ShowSelectedItem(object i_Item);
    }
}
