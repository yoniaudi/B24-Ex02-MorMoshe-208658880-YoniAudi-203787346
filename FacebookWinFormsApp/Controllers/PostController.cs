using FacebookWrapper.ObjectModel;
using System;
using System.Windows.Forms;

namespace BasicFacebookFeatures.Models
{
    public partial class PostController : UserControl
    {
        public string DisplayMember { get { return "Name"; } }
        public object DataSource { get; set; }
        private ProgressBar m_ProgressBar = null;

        public PostController()
        {
            InitializeComponent();
        }

        public PostController(FacebookObjectCollection<Post> i_Posts, ProgressBar i_ProgressBar)
        {
            InitializeComponent();
            m_ProgressBar = i_ProgressBar;
            initializeProgressBar(i_Posts);
            DataSource = filterPostsWithProgress(i_Posts);
        }

        private void initializeProgressBar(FacebookObjectCollection<Post> i_Posts)
        {
            m_ProgressBar.Invoke(new Action(() =>
            {
                m_ProgressBar.Minimum = 1;
                m_ProgressBar.Maximum = i_Posts.Count;
                m_ProgressBar.Value = 1;
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

        internal void ShowSelectedPost(Post i_Post)
        {
            string propValue = getPropertyValue(i_Post, "Message") ?? getPropertyValue(i_Post, "Description");

            labelUserPostAuthor.Text = i_Post.Name != null ? i_Post.Name : "";
            labelUserPostDateCreated.Text = i_Post.CreatedTime.ToString();
            labelUserPostFrom.Text = i_Post.From != null ? i_Post.From.Name : "";
            labelUserPostPlace.Text = i_Post.Place != null ? i_Post.Place.Name : "";
            picturePost.ImageLocation = i_Post.PictureURL;
            labelUserPostMessage.Text = propValue ?? "";
        }

        private string getPropertyValue(object i_Obj, string i_PropertyName)
        {
            return (string)i_Obj.GetType().GetProperty(i_PropertyName)?.GetValue(i_Obj);
        }
    }
}