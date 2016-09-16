﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VBN_Editor
{
    public partial class VBNRebuilder : Form
    {
        VBN vbn = new VBN();

        public VBNRebuilder()
        {
            InitializeComponent();
        }

        private void buildBoneTree()
        {
            foreach (Bone bone in vbn.bones)
            {
                string name = new String(bone.boneName);
                TreeNode tempNode = new TreeNode(name);
                //tempNode
                treeView1.Nodes.Add(tempNode);
            }
        }

        private void openNUDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename = "";
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Smash 4 Boneset|*.vbn|All files(*.*)|*.*";
            DialogResult result = save.ShowDialog();

            if(result == DialogResult.OK)
            {
                filename = save.FileName;
                vbn.save(filename);
            }
        }

        private void openVBNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename = "";
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Smash 4 Boneset|*.vbn|All files(*.*)|*.*";
            DialogResult result = open.ShowDialog();

            if(result == DialogResult.OK)
            {
                filename = open.FileName;
                vbn = new VBN(filename);
            }
            buildBoneTree();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newForm = new Form2 ();
            newForm.ShowDialog();
        }

    }
}