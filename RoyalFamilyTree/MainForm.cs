using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RoyalFamilyTree
{
    public partial class MainForm : Form
    {
        private FamilyTreeNode root;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnAddMember;
        private Panel treePanel;
        private Label lblResult;
        private VScrollBar vScrollBar;

        public MainForm()
        {
            InitializeComponent();
            InitializeRoyalFamilyTree();
            DisplayFamilyTree();
        }

        private void InitializeComponent()
        {
            this.Size = new Size(1200, 800);
            this.Text = "Royal Family Tree - House of Windsor";
            this.BackColor = Color.White;

            // Search
            Label lblSearch = new Label()
            {
                Text = "Search Family Member:",
                Location = new Point(20, 20),
                Size = new Size(150, 20),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            this.Controls.Add(lblSearch);

            txtSearch = new TextBox()
            {
                Location = new Point(180, 20),
                Size = new Size(200, 20),
                Font = new Font("Arial", 10)
            };
            this.Controls.Add(txtSearch);

            btnSearch = new Button()
            {
                Text = "Search",
                Location = new Point(390, 20),
                Size = new Size(80, 25),
                BackColor = Color.LightBlue,
                Font = new Font("Arial", 9, FontStyle.Bold)
            };
            btnSearch.Click += BtnSearch_Click;
            this.Controls.Add(btnSearch);

            btnAddMember = new Button()
            {
                Text = "Add Family Member",
                Location = new Point(480, 20),
                Size = new Size(150, 25),
                BackColor = Color.LightGreen,
                Font = new Font("Arial", 9, FontStyle.Bold)
            };
            btnAddMember.Click += BtnAddMember_Click;
            this.Controls.Add(btnAddMember);

            // Results
            lblResult = new Label()
            {
                Location = new Point(20, 60),
                Size = new Size(800, 30),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.DarkBlue
            };
            this.Controls.Add(lblResult);

            // Tree display
            treePanel = new Panel()
            {
                Location = new Point(20, 100),
                Size = new Size(1100, 650),
                AutoScroll = true,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(treePanel);

            vScrollBar = new VScrollBar()
            {
                Location = new Point(1120, 100),
                Size = new Size(20, 650),
                Maximum = 1000
            };
            vScrollBar.Scroll += VScrollBar_Scroll;
            this.Controls.Add(vScrollBar);
        }

        private void InitializeRoyalFamilyTree()
        {
            var charles = new RoyalFamilyMember("Charles III", new DateTime(1948, 11, 14), true, "King");
            root = new FamilyTreeNode(charles);

            var william = new RoyalFamilyMember("William", new DateTime(1982, 6, 21), true, "Prince of Wales");
            var harry = new RoyalFamilyMember("Harry", new DateTime(1984, 9, 15), true, "Duke of Sussex");
            var anne = new RoyalFamilyMember("Anne", new DateTime(1950, 8, 15), true, "Princess Royal");
            var andrew = new RoyalFamilyMember("Andrew", new DateTime(1960, 2, 19), true, "Duke of York");
            var edward = new RoyalFamilyMember("Edward", new DateTime(1964, 3, 10), true, "Duke of Edinburgh");

            root.AddChild(new FamilyTreeNode(william));
            root.AddChild(new FamilyTreeNode(harry));
            root.AddChild(new FamilyTreeNode(anne));
            root.AddChild(new FamilyTreeNode(andrew));
            root.AddChild(new FamilyTreeNode(edward));

            var george = new RoyalFamilyMember("George", new DateTime(2013, 7, 22), true, "Prince");
            var charlotte = new RoyalFamilyMember("Charlotte", new DateTime(2015, 5, 2), true, "Princess");
            var louis = new RoyalFamilyMember("Louis", new DateTime(2018, 4, 23), true, "Prince");

            var williamNode = root.Children[0];
            williamNode.AddChild(new FamilyTreeNode(george));
            williamNode.AddChild(new FamilyTreeNode(charlotte));
            williamNode.AddChild(new FamilyTreeNode(louis));

            var archie = new RoyalFamilyMember("Archie", new DateTime(2019, 5, 6), true, "Prince");
            var lilibet = new RoyalFamilyMember("Lilibet", new DateTime(2021, 6, 4), true, "Princess");

            var harryNode = root.Children[1];
            harryNode.AddChild(new FamilyTreeNode(archie));
            harryNode.AddChild(new FamilyTreeNode(lilibet));

            var peter = new RoyalFamilyMember("Peter", new DateTime(1977, 11, 15), true, "Phillips");
            var zara = new RoyalFamilyMember("Zara", new DateTime(1981, 5, 15), true, "Tindall");

            var anneNode = root.Children[2];
            anneNode.AddChild(new FamilyTreeNode(peter));
            anneNode.AddChild(new FamilyTreeNode(zara));

            var savannah = new RoyalFamilyMember("Savannah", new DateTime(2010, 12, 29), true, "");
            var isla = new RoyalFamilyMember("Isla", new DateTime(2012, 3, 29), true, "");

            var peterNode = anneNode.Children[0];
            peterNode.AddChild(new FamilyTreeNode(savannah));
            peterNode.AddChild(new FamilyTreeNode(isla));

            var mia = new RoyalFamilyMember("Mia", new DateTime(2014, 1, 17), true, "");
            var lena = new RoyalFamilyMember("Lena", new DateTime(2018, 6, 18), true, "");
            var lucas = new RoyalFamilyMember("Lucas", new DateTime(2021, 3, 21), true, "");

            var zaraNode = anneNode.Children[1];
            zaraNode.AddChild(new FamilyTreeNode(mia));
            zaraNode.AddChild(new FamilyTreeNode(lena));
            zaraNode.AddChild(new FamilyTreeNode(lucas));

            var beatrice = new RoyalFamilyMember("Beatrice", new DateTime(1988, 8, 8), true, "Princess");
            var eugenie = new RoyalFamilyMember("Eugenie", new DateTime(1990, 3, 23), true, "Princess");

            var andrewNode = root.Children[3];
            andrewNode.AddChild(new FamilyTreeNode(beatrice));
            andrewNode.AddChild(new FamilyTreeNode(eugenie));

            var sienna = new RoyalFamilyMember("Sienna", new DateTime(2021, 9, 18), true, "");
            var beatriceNode = andrewNode.Children[0];
            beatriceNode.AddChild(new FamilyTreeNode(sienna));

            var august = new RoyalFamilyMember("August", new DateTime(2021, 2, 9), true, "");
            var eugenieNode = andrewNode.Children[1];
            eugenieNode.AddChild(new FamilyTreeNode(august));

            var louise = new RoyalFamilyMember("Louise", new DateTime(2003, 11, 8), true, "Lady");
            var james = new RoyalFamilyMember("James", new DateTime(2007, 12, 17), true, "Earl of Wessex");

            var edwardNode = root.Children[4];
            edwardNode.AddChild(new FamilyTreeNode(louise));
            edwardNode.AddChild(new FamilyTreeNode(james));
        }

        private void DisplayFamilyTree()
        {
            treePanel.Controls.Clear();
            DrawNode(root, 50, 50, 200);
        }

        private void DrawNode(FamilyTreeNode node, int x, int y, int horizontalSpacing)
        {
            Panel memberPanel = new Panel()
            {
                Location = new Point(x, y),
                Size = new Size(180, 60),
                BackColor = node.Member.Name.Contains("Charles") ? Color.Gold : Color.LightBlue,
                BorderStyle = BorderStyle.FixedSingle,
                Tag = node
            };

            Label nameLabel = new Label()
            {
                Text = node.Member.ToString(),
                Location = new Point(5, 5),
                Size = new Size(170, 50),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 8, FontStyle.Bold),
                ForeColor = Color.DarkBlue
            };
            memberPanel.Controls.Add(nameLabel);

            memberPanel.MouseEnter += (s, e) => { memberPanel.BackColor = Color.Yellow; };
            memberPanel.MouseLeave += (s, e) =>
            {
                memberPanel.BackColor = node.Member.Name.Contains("Charles") ? Color.Gold : Color.LightBlue;
            };

            treePanel.Controls.Add(memberPanel);

            if (node.Children.Count > 0)
            {
                int childY = y + 100;
                int childX = x - ((node.Children.Count - 1) * horizontalSpacing) / 2;

                using (Graphics g = treePanel.CreateGraphics())
                {
                    Pen pen = new Pen(Color.Black, 2);
                    foreach (var child in node.Children)
                    {
                        int childCenterX = childX + 90;
                        int childCenterY = childY + 30;
                        int parentCenterX = x + 90;
                        int parentCenterY = y + 60;

                        g.DrawLine(pen, parentCenterX, parentCenterY + 30, parentCenterX, parentCenterY + 40);
                        g.DrawLine(pen, parentCenterX, parentCenterY + 40, childCenterX, childCenterY - 10);
                        g.DrawLine(pen, childCenterX, childCenterY - 10, childCenterX, childCenterY);

                        DrawNode(child, childX, childY, horizontalSpacing / 2);
                        childX += horizontalSpacing;
                    }
                }
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string searchName = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(searchName))
            {
                MessageBox.Show("Please enter a name to search.", "Search Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = FindMemberAndPosition(root, searchName, 1);
            if (result.node != null)
            {
                lblResult.Text = $"Found: {result.node.Member.ToString()} - Position in line: {result.position}";
                HighlightMember(result.node);
            }
            else
            {
                lblResult.Text = $"Member '{searchName}' not found in the royal family tree.";
            }
        }

        private (FamilyTreeNode node, int position) FindMemberAndPosition(FamilyTreeNode currentNode, string searchName, int currentPosition)
        {
            if (currentNode.Member.Name.IndexOf(searchName, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return (currentNode, currentPosition);
            }

            int position = currentPosition;
            foreach (var child in currentNode.Children)
            {
                var result = FindMemberAndPosition(child, searchName, position);
                if (result.node != null)
                {
                    return result;
                }
                position++;
            }

            return (null, -1);
        }

        private void HighlightMember(FamilyTreeNode node)
        {
            foreach (Control control in treePanel.Controls)
            {
                if (control is Panel panel && panel.Tag is FamilyTreeNode treeNode)
                {
                    panel.BackColor = treeNode == node ? Color.Red :
                        (treeNode.Member.Name.Contains("Charles") ? Color.Gold : Color.LightBlue);
                }
            }
        }

        private void BtnAddMember_Click(object sender, EventArgs e)
        {
            using (var addForm = new AddMemberForm())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    var parentName = addForm.ParentName;
                    var newMember = addForm.NewMember;

                    var parentNode = FindParentNode(root, parentName);
                    if (parentNode != null)
                    {
                        parentNode.AddChild(new FamilyTreeNode(newMember));
                        DisplayFamilyTree();
                        lblResult.Text = $"Successfully added {newMember.Name} to the family tree.";
                    }
                    else
                    {
                        MessageBox.Show($"Parent '{parentName}' not found.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private FamilyTreeNode FindParentNode(FamilyTreeNode currentNode, string parentName)
        {
            if (currentNode.Member.Name.Equals(parentName, StringComparison.OrdinalIgnoreCase))
            {
                return currentNode;
            }

            foreach (var child in currentNode.Children)
            {
                var result = FindParentNode(child, parentName);
                if (result != null)
                {
                    return result;
                }
            }

            return null;
        }

        private void VScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            treePanel.AutoScrollPosition = new Point(0, e.NewValue);
        }
    }
}