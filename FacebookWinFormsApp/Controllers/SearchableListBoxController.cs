using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BasicFacebookFeatures.Models
{
    public partial class SearchableListBoxController : UserControl
    {
        public event EventHandler SelectedIndexChanged = null;
        public object SelectedItem { get { return listBoxMain.SelectedItem; } }

        public string DisplayMember
        {
            get { return listBoxMain.DisplayMember; }
            set { listBoxMain.DisplayMember = value; }
        }

        public object DataSource
        {
            get { return listBoxMain.DataSource; }
            set { listBoxMain.DataSource = value; }
        }

        public SearchableListBoxController()
        {
            InitializeComponent();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            int foundIdx = -1;

            listBoxMain.Invoke(new Action(() =>
            {
                listBoxMain.ClearSelected();
                foundIdx = listBoxMain.FindString(textBoxSearch.Text);

                if (foundIdx > -1)
                {
                    object item = listBoxMain.Items[foundIdx];
                    string propValue = getPropertyValue(item, "Name") ?? getPropertyValue(item, "Message");

                    if (propValue != null && textBoxSearch.Text.ToLower() == propValue.ToLower())
                    {
                        listBoxMain.SelectedIndex = foundIdx;
                    }
                }

                listBoxMain.TopIndex = foundIdx;
            }));
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            textBoxSearch.Text = "";
            sortListBoxMain();
        }

        private void buttonReverse_Click(object sender, EventArgs e)
        {
            bool isSortReverse = true;

            textBoxSearch.Text = "";
            sortListBoxMain(isSortReverse);
        }

        private void sortListBoxMain(bool i_Reverse = false)
        {
            object[] items = listBoxMain.Items.Cast<object>().ToArray();

            Array.Sort(items, new Comparison<object>((x, y) =>
            {
                string propX = getPropertyValue(x, "Name");
                string propY = getPropertyValue(y, "Name");

                if (propX is null || propY is null)
                {
                    propX = getPropertyValue(x, "Message");
                    propY = getPropertyValue(y, "Message");
                }

                return string.Compare(propX, propY);
            }));

            if (i_Reverse == true)
            {
                Array.Reverse(items);
            }

            listBoxMain.Invoke(new Action(() =>
            {
                listBoxMain.DataSource = null;
                listBoxMain.Items.Clear();
                listBoxMain.DisplayMember = "Name";
                listBoxMain.DataSource = items.ToList();
            }));
        }

        private string getPropertyValue(object i_Obj, string i_PropertyName)
        {
            return (string)i_Obj.GetType().GetProperty(i_PropertyName)?.GetValue(i_Obj);
        }

        private void listBoxMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedIndexChanged?.Invoke(this, EventArgs.Empty);
            //Invoke(new Action(() => SelectedIndexChanged?.Invoke(this, EventArgs.Empty)));
        }
    }
}
