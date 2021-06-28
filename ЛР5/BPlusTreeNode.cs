using System.Collections.Generic;

namespace ЛР5
{
    public class BPlusTreeNode
    {
        public BPlusTreeNode ParentNode { get; set; }
        public List<int> Data { get; set; }
        public List<BPlusTreeNode> ChildrenNodes { get; set; }
        public BPlusTreeNode(List<int> data)
        {
            Data = data;
        }
    }
}