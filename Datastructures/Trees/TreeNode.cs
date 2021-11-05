using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorsEmail.Datastructures
{
    public class TreeNode
    {
        private TreeNode root { get; set; }
        public char letter { get; set; }
        public TreeNode left { get; set; }
        public TreeNode right { get; set; }
        public TreeNode(char _letter, TreeNode _left, TreeNode _right)
        {
            letter = _letter;
            left = _left ;
            right = _right;
        }

        
    }
}
