using System;
using System.Collections;
using System.Collections.Generic;

namespace Check_if_two_binary_trees_are_identical
{
    class Program
    {
        class TreeNode
        {
            public int val;
            public TreeNode left, right;
            public TreeNode(int val = 0)
            {
                this.val = val;
                left = right = null;
            }
        }
        static void Main(string[] args)
        {
            TreeNode p = new TreeNode(1);
            p.left = new TreeNode(2);
            p.right = new TreeNode(3);
            p.left.left = new TreeNode(4);
            p.left.right = new TreeNode(5);

            TreeNode q = new TreeNode(1);
            q.left = new TreeNode(2);
            q.right = new TreeNode(3);
            q.left.left = new TreeNode(4);
            q.left.right = new TreeNode(5);
            //q.right.right = new TreeNode(6);

            Console.WriteLine("Using recursive approach!");
            Console.WriteLine(IsSameTree(p, q));
            Console.WriteLine("Using iterative aproach!");
            Console.WriteLine(IsIdenticalIteretive(p, q));
        }

        static bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;
            if (p == null || q == null) return false;

            return (p.val == q.val && IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right));
        }

        static bool IsIdenticalIteretive(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;
            if (p == null || q == null) return false;
            Queue<TreeNode> q1 = new Queue<TreeNode>();
            Queue<TreeNode> q2 = new Queue<TreeNode>();

            q1.Enqueue(p);
            q2.Enqueue(q);
            while (q1.Count > 0 && q2.Count > 0)
            {
                TreeNode n1 = q1.Dequeue();
                TreeNode n2 = q2.Dequeue();

                if (n1.val != n2.val) return false;

                if (n1.left != null && n2.left != null)
                {
                    q1.Enqueue(n1.left);
                    q2.Enqueue(n2.left);
                }
                else if (n1.left != null || n2.left != null) return false;

                if (n1.right != null && n2.right != null)
                {
                    q1.Enqueue(n1.right);
                    q2.Enqueue(n2.right);
                }

                else if (n1.right != null || n2.right != null) return false;
            }

            return true;
        }
    }
}
