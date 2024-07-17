namespace BasicFacebookFeatures
{
    public interface IController
    {
        string DisplayMember { get; }
        object DataSource { get; set; }
        void LoadDataToListBox();
        void ShowSelectedItem(object i_Item);
    }
}
