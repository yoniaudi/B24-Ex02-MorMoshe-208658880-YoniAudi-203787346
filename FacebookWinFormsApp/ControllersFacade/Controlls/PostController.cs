using FacebookWrapper.ObjectModel;
using System;
using System.Windows.Forms;

namespace BasicFacebookFeatures.Models
{
    public partial class PostController : UserControl, IController
    {
        public string DisplayMember { get { return "Name"; } }
        public object DataSource { get; set; }
        private ProgressBar m_ProgressBar = null;
        private SearchableListBoxController m_SearchableListBox = null;

        public PostController()
        {
            InitializeComponent();
        }

        public PostController(User i_LoggedInUser, SearchableListBoxController i_SearchableListBox, ProgressBar i_ProgressBar)
        {
            InitializeComponent();
            m_ProgressBar = i_ProgressBar;
            m_SearchableListBox = i_SearchableListBox;
            initializeProgressBar(i_LoggedInUser.Posts);
            DataSource = filterPostsWithProgress(i_LoggedInUser.Posts);
        }

        private void initializeProgressBar(FacebookObjectCollection<Post> i_Posts)
        {
            m_ProgressBar.Invoke(new Action(() => m_ProgressBar.Maximum += i_Posts.Count));
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

        public void LoadDataToListBox()
        {
            if (m_SearchableListBox != null)
            {
                m_SearchableListBox.Invoke(new Action(() =>
                {
                    m_SearchableListBox.DisplayMember = DisplayMember;
                    m_SearchableListBox.DataSource = DataSource;
                }));
            }
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