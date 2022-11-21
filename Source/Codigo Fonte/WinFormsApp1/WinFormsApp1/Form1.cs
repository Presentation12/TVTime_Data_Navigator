using System.Xml;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private XmlDocument XmlDoc = new XmlDocument();

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        #region Normal
        
        // Carrega dados para a arvore
        private void load_tree(XmlDocument xml_doc, TreeView tree_view)
        {
            TreeNode root = new TreeNode("Amazon Shows");
            tree_view.Nodes.Clear();
            add_tree_view_model(root,xml_doc.DocumentElement);
        }

        // Adiciona cada nodo á arvore
        private void add_tree_view_model(TreeNode parent_nodes, XmlNode xml_node)
        {
            foreach (XmlNode rows in xml_node.ChildNodes)
            {
                TreeNode new_node = parent_nodes.Nodes.Add(rows.ChildNodes[1].InnerText + ": " + rows.ChildNodes[13].InnerText);
                foreach (XmlNode row in rows)
                {
                    TreeNode new_node2 = new_node.Nodes.Add(row.Name);
                    new_node2.Nodes.Add(row.InnerText);
                }
            }
            treeView1.Nodes.Add(parent_nodes);
        }

        #endregion

        #region Pesquisa

        // Carrega dados para a arvore
        private void load_search_tree(XmlDocument xml_doc, TreeView tree_view)
        {
            TreeNode root = new TreeNode("Amazon Shows");
            tree_view.Nodes.Clear();
            add_search_tree_view_model(root, xml_doc.DocumentElement);
        }

        // Adiciona cada nodo á arvore mas com a condição de titulo igual ao inserido na text box
        private void add_search_tree_view_model(TreeNode parent_nodes, XmlNode xml_node)
        {
            foreach (XmlNode rows in xml_node.ChildNodes)
            {
                if (rows.ChildNodes[1].InnerText.ToLower().Contains(search_box.Text.ToLower()))
                {
                    TreeNode new_node = parent_nodes.Nodes.Add(rows.ChildNodes[1].InnerText + ": " + rows.ChildNodes[13].InnerText);
                    foreach (XmlNode row in rows)
                    {
                        TreeNode new_node2 = new_node.Nodes.Add(row.Name);
                        new_node2.Nodes.Add(row.InnerText);
                    }
                }
            }
            treeView1.Nodes.Add(parent_nodes);
        }
        #endregion

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            XmlDoc.Load(Environment.CurrentDirectory + @"\..\..\..\..\..\..\..\Data\Output\Ficheiros XML Output\Networks\Amazon_Shows.xml");
            load_search_tree(XmlDoc, treeView1);
            treeView1.ExpandAll();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            XmlDoc.Load(Environment.CurrentDirectory + @"\..\..\..\..\..\..\..\Data\Output\Ficheiros XML Output\Networks\Amazon_Shows.xml");
            load_tree(XmlDoc, treeView1);
            treeView1.ExpandAll();
        }
    }
}