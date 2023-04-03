using System.Diagnostics;
using System.Xml.Linq;
using WebsitePathfindingApp.Classes.DataStructure;

namespace WebsitePathfindingApp.Classes
{
    public class DepthFirstSearch
    {
        //DECLARE a BinaryTree called _binaryTree
        private Tree _binaryTree;
        //DECLARE a Queue of nodes called _nodes
        Queue<INode> _nodes;
        //DECLARE a stack of nodes called _pathStack
        Stack<INode> _pathStack;
        //DECLARE a dictionary With nodes as a key and Nodes as data called _cameFrom
        IDictionary<INode, INode> _cameFrom;
        //DECLARE a List of Nodes called _path
        IList<INode> _path;
        /// <summary>
        /// A Property that gets a List of Nodes called path
        /// </summary>
        public IList<INode> Path { get => _path; }
        /// <summary>
        /// Intalises the DepthFirstSearch Class
        /// </summary>
        /// <param name="pData">The data of the class</param>
        /// <param name="pBinaryTree">The Tree that will be searched</param>
        public void Intialise(Tree pBinaryTree)
        {
            //INTALISE Variables
            //_binaryTree
            _binaryTree = pBinaryTree;
            //_nodes
            _nodes = new Queue<INode>();
            //_pathStack
            _pathStack = new Stack<INode>();
            //_cameFrom
            _cameFrom = new Dictionary<INode, INode>();
            //_path
            _path = new List<INode>();
            //enqueues the Root of _binaryTree
            _nodes.Enqueue(_binaryTree.Root);
            //pushes the root of _binaryTree
            _pathStack.Push(_binaryTree.Root);


        }
        /// <summary>
        /// A Method used to search a binary tree
        /// </summary>
        public void Search()
        {
            //While _nodes are not empty this will loop
            while (_nodes.Count != 0)
            {
                //If the item in the queue has been visited this is true
                if (_nodes.Peek().Visited)
                {
                    //Dequeues the queue
                    _nodes.Dequeue();
                }
                else
                {
                    //Writes to the dbugger whats being peeked at
                    Debug.WriteLine("Peeked at : " + _nodes.Peek().Data);
                    //IF the current node Has Neighbours this is true
                    if (_nodes.Peek().Neighbours != null)
                    {
                        //pushes the current node onto the pathStack
                        _pathStack.Push(_nodes.Peek());
                        //sets visited to true
                        _nodes.Peek().Visited = true;
                        //Loops over each node in the current nodes neighbours
                        foreach (INode n in _nodes.Peek().Neighbours)
                        {
                            //adds the node to the queue
                            _nodes.Enqueue(n);
                            //If the current node is not in the dictionary this is true
                            if (!_cameFrom.ContainsKey(n))
                            {
                                //Adds the node as a key and the current node as data
                                _cameFrom.Add(n, _nodes.Peek());
                            }
                        }
                        //If the Current node is the Goal Node
                        if (_nodes.Peek().GoalNode)
                        {
                            //Stopps the while loop
                            break;
                        }
                    }
                }
            }
            //Trys the following
            try
            {
                //DECLARE a new node Current
                INode Current = _nodes.Peek();
                //While Current is not the Root of _binaryTree this loops
                while (true)
                {
                    //Adds curret to _path
                    _path.Add(Current);
                    //Current is set to the data with the key Current
                    Current = _cameFrom[Current];
                    //If current is the Root this is true
                    if (Current == _binaryTree.Root)
                    {
                        //Adds curret to _path
                        _path.Add(Current);
                        //breaks out of the loop
                        break;
                    }
                }
            }
            //Catches PathNotFoundExeceptions
            catch (Exception e)
            {
                //Throws a new Exception
                throw new Exception("Could Not Find A Path");
            }

        }
    }
}
