using FacebookWrapper.ObjectModel;
using System;
using System.Windows.Forms;

namespace BasicFacebookFeatures.Models
{
    public partial class PostController : UserControl, IControllers
    {
        public string DisplayMember { get { return "Name"; } }
        public object DataSource { get; set; }
        private ProgressBar m_ProgressBar = null;
        private SearchableListBoxController m_SearchableListBox = null;

        public PostController()
        {
            InitializeComponent();
        }

        public PostController(FacebookObjectCollection<Post> i_Posts, SearchableListBoxController i_SearchableListBox, ProgressBar i_ProgressBar)
        {
            InitializeComponent();
            m_ProgressBar = i_ProgressBar;
            m_SearchableListBox = i_SearchableListBox;
            initializeProgressBar(i_Posts);
            DataSource = filterPostsWithProgress(i_Posts);
        }

        private void initializeProgressBar(FacebookObjectCollection<Post> i_Posts)
        {
            m_ProgressBar.Invoke(new Action(() =>
            {
                m_ProgressBar.Minimum = 0;
                m_ProgressBar.Maximum = i_Posts.Count;
                m_ProgressBar.Value = 0;
                m_ProgressBar.Step = 1;
            }));
        }

        private object filterPostsWithProgress(FacebookObjectCollection<Post> i_Posts)
        {
            FacebookObjectCollection<Post> filteredPosts = new FacebookObjectCollection<Post>();

            foreach (Post post in i_Posts)
            {
                if (post.Name != null)
                {
                    filteredPosts.Add(post);
                }

                m_ProgressBar.Invoke(new Action(() => m_ProgressBar.PerformStep()));
            }

            return filteredPosts;
        }

        public void LoadData()
        {
            m_SearchableListBox.Invoke(new Action(() =>
            {
                m_SearchableListBox.DisplayMember = DisplayMember;
                m_SearchableListBox.DataSource = DataSource;
            }));
        }

        public void ShowSelectedItem(object i_Post)
        {
            Post post = i_Post as Post;
            string propValue = getPropertyValue(post, "Message") ?? getPropertyValue(post, "Description");

            labelUserPostAuthor.Text = post.Name != null ? post.Name : "";
            labelUserPostDateCreated.Text = post.CreatedTime.ToString();
            labelUserPostFrom.Text = post.From != null ? post.From.Name : "";
            labelUserPostPlace.Text = post.Place != null ? post.Place.Name : "";
            picturePost.ImageLocation = post.PictureURL;
            labelUserPostMessage.Text = propValue ?? "";
        }

        private string getPropertyValue(object i_Obj, string i_PropertyName)
        {
            return (string)i_Obj.GetType().GetProperty(i_PropertyName)?.GetValue(i_Obj);
        }
    }
}