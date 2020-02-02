using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Catalog_Test
{

    public partial class Form1 : Form
    {
        private List<Catalog_Level> ct = new List<Catalog_Level>();
        ETSGroupEntities db;
        public Form1()
        {
            InitializeComponent();
            db = new ETSGroupEntities();
            db.Catalog_Level.Load();
            ct = db.Catalog_Level.ToList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ct.Where(item => item.Parent_id == null).ToList().ForEach(item => twCatalog.Nodes.Add(new TreeNode() { Text = item.Name, Tag = item }));

            foreach (Catalog_Level catalog_Level in ct.Where(item => item.Parent_id!= null).ToList())
            {
                List<TreeNode> allNodes = twCatalog.Nodes.Cast<TreeNode>().Flatten<TreeNode>(n => n.Nodes.Cast<TreeNode>()).ToList();

                var node = allNodes.SingleOrDefault(item => ((Catalog_Level)item.Tag).id == catalog_Level.Parent_id);
                if (node != null)
                {
                    node.Nodes.Add(new TreeNode() { Text = catalog_Level.Name, Tag = catalog_Level});
                }
            }
        }
    }
}
