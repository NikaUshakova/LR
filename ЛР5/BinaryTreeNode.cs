namespace ЛР5
{
    public class BinaryTreeNode
    {
        public int Data {get; set;}
        public BinaryTreeNode LeftNode {get; set;}
        public BinaryTreeNode RightNode {get; set;}
        public BinaryTreeNode ParentNode {get; set;}
        public BinaryTreeNode(int data)
        {
            Data = data;
        }

        public Side? NodeSide => ParentNode == null
            ? (Side?)null
            : ParentNode.LeftNode == this
                ? Side.left
                : Side.right;

    }
}