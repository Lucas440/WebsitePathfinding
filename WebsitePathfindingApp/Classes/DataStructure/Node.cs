using System.Numerics;

namespace WebsitePathfindingApp.Classes.DataStructure
{
    public class Node : INode
    {
        /// <summary>
        /// A Property used to Check if the player visted this node
        /// </summary>
        public bool PlayerVisited { get; set; }

        //DECLARE a Vector2 called _location
        private Vector2 _location;
        /// <summary>
        /// A Property used to return and set a Vector2 called Location
        /// </summary>
        public Vector2 Location { get => _location; set { _location = value; } }
        /// <summary>
        /// A Property used to return and set a boolean called GoalNode
        /// </summary>
        public bool GoalNode { get; set; }

        //DECLARE a string called _data
        protected string _data;
        //DECALRE a List of Nodes called _neighbours
        protected IList<INode> _neighbours;
        /// <summary>
        /// A Property used to return and get a string called Data
        /// </summary>
        public string Data { get => _data; set { _data = value; } }
        /// <summary>
        /// A Property used to return a List Of Nodes Called Neighbours
        /// </summary>
        public IList<INode> Neighbours { get => _neighbours; }
        /// <summary>
        /// A Property used to return and get a bool called Visited
        /// </summary>
        public bool Visited { get; set; }
        /// <summary>
        /// The defualt constructor for node
        /// </summary>
        public Node()
        {
            //INTIALISES _neighbours
            _neighbours = new List<INode>();
        }
        /// <summary>
        /// The recommended constructor for node
        /// </summary>
        /// <param name="pData">The Data that is stored within the node</param>
        public Node(string pData) { }
        /// <summary>
        /// A Contructor which definines the nodes neighbous
        /// </summary>
        /// <param name="pData">The Data that is stored within the node</param>
        /// <param name="pNeigbours">The Neighbours of the node</param>
        public Node(string pData, IList<INode> pNeigbours)
        {
            //Sets _data to pData
            _data = pData;
            //Sets _neighbours to pNeighbours
            _neighbours = pNeigbours;
            //Sets Visited to false
            Visited = false;

        }
    }
}
