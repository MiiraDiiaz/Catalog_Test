using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Catalog_Test_без_БД
{
    public partial class Form1 : Form
    {
        private List<Catalog_Level> ct = new List<Catalog_Level>();
        public Form1()
        {
            InitializeComponent();
            ct.Add(new Catalog_Level() { id = 1, Parent_id = 0,Name = "VOLVO" });
            ct.Add(new Catalog_Level() { id = 2, Parent_id = 0, Name = "ER" });
            ct.Add(new Catalog_Level() { id = 3, Parent_id = 1, Name = "КПП" });
            ct.Add(new Catalog_Level() { id = 4, Parent_id = 2, Name = "Двигатель" });
            ct.Add(new Catalog_Level() { id = 5, Parent_id = 2, Name = "КПП" });
            ct.Add(new Catalog_Level() { id = 6, Parent_id = 3, Name = "A365" });
            ct.Add(new Catalog_Level() { id = 7, Parent_id = 4, Name = "M4566" });
            ct.Add(new Catalog_Level() { id = 8, Parent_id = 4, Name = "FG4511" });
            ct.Add(new Catalog_Level() { id = 9, Parent_id = 5, Name = "T45459" });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ct.Where(item => item.Parent_id == 0).ToList().ForEach(item => twCatalog.Nodes.Add(new TreeNode() { Text = item.Name, Tag = item }));

            foreach (Catalog_Level catalog_Level in ct.Where(item => item.Parent_id != 0).ToList())
            {
                List<TreeNode> allNodes = twCatalog.Nodes.Cast<TreeNode>().Flatten<TreeNode>(n => n.Nodes.Cast<TreeNode>()).ToList();

                var node = allNodes.SingleOrDefault(item => ((Catalog_Level)item.Tag).id == catalog_Level.Parent_id);
                if (node != null)
                {
                    node.Nodes.Add(new TreeNode() { Text = catalog_Level.Name, Tag = catalog_Level });
                }
            }
        }
    }
}
