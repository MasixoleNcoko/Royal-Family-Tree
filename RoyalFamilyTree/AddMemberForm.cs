using System;
using System.Windows.Forms;

namespace RoyalFamilyTree
{
    public partial class AddMemberForm : Form
    {
        private TextBox txtName;
        private DateTimePicker dtpBirth;
        private CheckBox chkAlive;
        private TextBox txtTitle;
        private TextBox txtParent;
        private Button btnAdd;
        private Button btnCancel;

        public string ParentName => txtParent.Text;
        public RoyalFamilyMember NewMember { get; private set; }

        public AddMemberForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Size = new Size(400, 300);
            this.Text = "Add Royal Family Member";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            Label lblName = new Label() { Text = "Name:", Location = new Point(20, 20), Size = new Size(80, 20) };
            txtName = new TextBox() { Location = new Point(100, 20), Size = new Size(200, 20) };
            this.Controls.AddRange(new Control[] { lblName, txtName });

            Label lblBirth = new Label() { Text = "Date of Birth:", Location = new Point(20, 50), Size = new Size(80, 20) };
            dtpBirth = new DateTimePicker() { Location = new Point(100, 50), Size = new Size(200, 20) };
            this.Controls.AddRange(new Control[] { lblBirth, dtpBirth });

            Label lblAlive = new Label() { Text = "Alive:", Location = new Point(20, 80), Size = new Size(80, 20) };
            chkAlive = new CheckBox() { Location = new Point(100, 80), Checked = true, Size = new Size(20, 20) };
            this.Controls.AddRange(new Control[] { lblAlive, chkAlive });

            Label lblTitle = new Label() { Text = "Title:", Location = new Point(20, 110), Size = new Size(80, 20) };
            txtTitle = new TextBox() { Location = new Point(100, 110), Size = new Size(200, 20) };
            this.Controls.AddRange(new Control[] { lblTitle, txtTitle });

            Label lblParent = new Label() { Text = "Parent Name:", Location = new Point(20, 140), Size = new Size(80, 20) };
            txtParent = new TextBox() { Location = new Point(100, 140), Size = new Size(200, 20) };
            this.Controls.AddRange(new Control[] { lblParent, txtParent });

            // Buttons
            btnAdd = new Button()
            {
                Text = "Add Member",
                Location = new Point(100, 180),
                Size = new Size(90, 30),
                BackColor = Color.LightGreen
            };
            btnAdd.Click += BtnAdd_Click;

            btnCancel = new Button()
            {
                Text = "Cancel",
                Location = new Point(200, 180),
                Size = new Size(90, 30),
                BackColor = Color.LightCoral
            };
            btnCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            this.Controls.AddRange(new Control[] { btnAdd, btnCancel });
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter a name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtParent.Text))
            {
                MessageBox.Show("Please enter a parent name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            NewMember = new RoyalFamilyMember(
                txtName.Text,
                dtpBirth.Value,
                chkAlive.Checked,
                txtTitle.Text
            );

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}