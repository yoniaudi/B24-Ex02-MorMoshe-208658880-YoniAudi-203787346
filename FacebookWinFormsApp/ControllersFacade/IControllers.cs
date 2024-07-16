using BasicFacebookFeatures.Models;

namespace BasicFacebookFeatures
{
    public interface IControllers
    {
        string DisplayMember { get; }
        object DataSource { get; set; }
        void ShowController();
        void ShowSelectedItem(object i_Item);
    }
}
