// Copyright 2018 Stefan Schmidt
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManifestExplorer
{
    public class ARNode : TreeNode
    {
        public ARNode() : base() { }
        public ARNode(string text) : base(text)
        {
            
        }

        public string short_name;
        public string the_value;
    }
}
