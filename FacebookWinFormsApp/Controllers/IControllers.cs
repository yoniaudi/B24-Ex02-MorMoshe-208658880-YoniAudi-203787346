namespace BasicFacebookFeatures
{
    public interface IControllers
    {
        string DisplayMember { get; }
        object DataSource { get; set; }
        void Show(object i_Object);
    }
}
