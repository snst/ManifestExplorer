using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ManifestExplorer
{
    public partial class Form1 : Form
    {
        bool hideBla_ = false;

        public Form1()
        {
            InitializeComponent();
        }

        string[] showVal = { "IPV-6-ADDRESS", "MULTICAST-SD-IP-ADDRESS-REF" };

        bool isInArray(string val, string[] array)
        {
            foreach (string s in array)
            {
                if (s.Equals(val))
                    return true;
            }
            return false;
        }

        private void AddNode(XmlNode inXmlNode, ARNode inTreeNode)
        {
            XmlNode xNode;
            ARNode tNode;
            XmlNodeList nodeList;
            int i;


            {

                //     inTreeNode.Nodes.Add(new TreeNode(inXmlNode.Name));


                // Loop through the XML nodes until the leaf is reached.
                // Add the nodes to the TreeView during the looping process.
                if (inXmlNode.HasChildNodes)
                {

                    nodeList = inXmlNode.ChildNodes;
                    for (i = 0; i <= nodeList.Count - 1; i++)
                    {
                        xNode = inXmlNode.ChildNodes[i];

                        if (xNode.Name == "SHORT-NAME")
                        {
                            inTreeNode.Text += "  (" + xNode.InnerText + ")";
                            inTreeNode.short_name = xNode.InnerText;
                        }
                        else
                        {
                            if (xNode.ChildNodes.Count == 1 && !xNode.InnerXml.StartsWith("<"))
                            {
                                tNode = new ARNode(xNode.Name + " = " + xNode.InnerText);
                                tNode.the_value = xNode.InnerText;
                                inTreeNode.Nodes.Add(tNode);
                            }
                            else
                            {
                                tNode = new ARNode(xNode.Name);
                                // tNode.ForeColor = Color.Red;
                                inTreeNode.Nodes.Add(tNode);
                                AddNode(xNode, tNode);
                            }
                        }
                    }

                }
                else
                {
                    // Here you need to pull the data from the XmlNode based on the
                    // type of node, whether attribute values are required, and so forth.
                    inTreeNode.Text = (inXmlNode.OuterXml).Trim();
                }
            }
        }

        private void loadxml(string filename)
        {
            try
            {
                // SECTION 1. Create a DOM Document and load the XML data into it.
                XmlDocument dom = new XmlDocument();
                dom.Load(filename);

                // SECTION 2. Initialize the TreeView control.
                ARNode tNode = new ARNode(dom.DocumentElement.Name + " (" + filename + ")");
                treeView1.Nodes.Add(tNode);
                //ARNode tNode = new ARNode();
                //tNode = (ARNode) treeView1.Nodes[0];

                // SECTION 3. Populate the TreeView with the DOM nodes.
                AddNode(dom.DocumentElement, tNode);
                treeView1.ExpandAll();
            }
            catch (XmlException xmlEx)
            {
                MessageBox.Show(xmlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clearTree()
        {
            treeView1.Nodes.Clear();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            clearTree();


        }

        void resetNodeColor(ARNode node)
        {
            if (node.short_name != null || node.the_value != null)
                node.ForeColor = Color.Black;
            else
                node.ForeColor = hideBla_ ? Color.White : Color.Black;
        }

        void highlightParentNames(ARNode node, string[] substrings, int i)
        {
            while (node != null && i >= 0)
            {
                if (node.short_name != null)
                {
                    if (node.short_name.Equals(substrings[i]))
                    {
                        node.ForeColor = Color.Green;
                        i--;
                    }
                    else
                    {
                        return;
                    }
                }

                node = (ARNode)node.Parent;
            }
        }

        void highlightNames(ARNode node, string[] substrings)
        {
            resetNodeColor(node);

            if (node.short_name != null)
            {
                if (substrings != null)
                {
                    if (isInArray(node.short_name, substrings))
                        node.ForeColor = Color.Blue;

                    highlightParentNames(node, substrings, substrings.Length - 1);
                }
            }

            foreach (TreeNode child in node.Nodes)
            {
                highlightNames((ARNode)child, substrings);
            }
        }

        string getNodePathName(ARNode node)
        {
            string ret = null;
            while (node != null)
            {
                if (node.short_name != null)
                {
                    if (ret == null)
                        ret = "/" + node.short_name;
                    else
                        ret = "/" + node.short_name + ret;
                }
                node = (ARNode)node.Parent;
            }

            return ret;
        }

        void highlightValue(ARNode node, string val, string path)
        {
            resetNodeColor(node);

            if (node.the_value != null)
            {
                if (val != null && node.the_value.Contains(val))
                    node.ForeColor = Color.Blue;

                if (path != null && node.the_value.Equals(path))
                    node.ForeColor = Color.Green;

            }

            foreach (TreeNode child in node.Nodes)
            {
                highlightValue((ARNode)child, val, path);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ARNode node = (ARNode)e.Node;

            if (node.the_value != null)
            {
                string[] substrings = node.the_value.Split('/');
                foreach (TreeNode n in treeView1.Nodes)
                {
                    highlightNames((ARNode)n, substrings);
                }
            }
            else
            {
                foreach (TreeNode n in treeView1.Nodes)
                {
                    highlightValue((ARNode)n, node.short_name, getNodePathName(node));
                }
            }

        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            if (cbClearOnLoad.Checked)
                clearTree();

            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
                loadxml(openFileDialog1.FileName);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearTree();
        }

        private void loadAllFiles(string dir, bool recursive)
        {
            foreach (string f in Directory.GetFiles(dir))
            {
                if (f.EndsWith(".arxml"))
                {
                    loadxml(f);
                }
            }

            if (recursive)
            {
                foreach (string d in Directory.GetDirectories(dir))
                {
                    loadAllFiles(d, recursive);
                }
            }
        }

        private void btnLoadDir_Click(object sender, EventArgs e)
        {
            if (cbClearOnLoad.Checked)
                clearTree();

            if (DialogResult.OK == folderBrowserDialog1.ShowDialog())
            {
                loadAllFiles(folderBrowserDialog1.SelectedPath, cbRecursive.Checked);
            }
        }

        private void cbHideBla_CheckedChanged(object sender, EventArgs e)
        {
            hideBla_ = cbHideBla.Checked;
        }
    }
}
