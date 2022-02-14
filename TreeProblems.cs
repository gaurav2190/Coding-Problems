using System;

namespace Coding_Problems
{
    public class TreeProblem
    {
        public int MaxDepth(TreeNode root) {
            var value = this.GetNodeDepth(root);
            return value;
        }

        public int GetNodeDepth(TreeNode node)
        {
            if(node == null)
                return 0;
            var depth = Math.Max(GetNodeDepth(node.left), GetNodeDepth(node.right));

            return depth + 1;
        }
    }

public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
          this.val = val;
          this.left = left;
          this.right = right;
       }
    }
}