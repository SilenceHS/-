using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void setNode(string path, TreeNode prenode)
        {
            string[] son;
            try
            {
                son = Directory.GetDirectories(path);
            }
            catch (Exception)
            {
                prenode.Nodes.Add("拒绝sb110访问");
                return;
            }
            for (int i = 0; i < son.Length; i++)
            {
                string truename = Path.GetFileNameWithoutExtension(son[i]);
                TreeNode newnode = new TreeNode(truename);
                prenode.Nodes.Add(newnode);
                setNode(son[i], newnode);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();//清除所有的结点
            if (Directory.Exists(textBox1.Text))
            {
                treeView1.Nodes.Add(textBox1.Text);
                setNode(textBox1.Text, treeView1.Nodes[0]);
            }
            else
                MessageBox.Show("找不到路径！");
        }

    }
}
