using WebsitePathfindingApp.Classes.DataStructure;
using WebsitePathfindingApp.Classes.NodeSetUp;

namespace WebsitePathfindingApp.Classes
{
    public class DataStuctureGenorator
    {
        Tree _tree;

        //DECLARE a Node Array called _nodeArray
        private INode[,] _nodeArray;
        //DECLARE a int called _timer
        private int _timer;
        //DECLARE a DepthFirstSearch called _depthFirst
        //private IDepthFirstSearch _depthFirst;
        // DECLARE a int called _goalNodeX
        private int _goalNodeX;
        // DECLARE a int called _goalNodeY
        private int _goalNodeY;
        // DECLARE a int called _startNodeX
        private int _startNodeX;
        // DECLARE a int called _startNodeY
        private int _startNodeY;
        // DECLARE a int called _arrayLength
        private int _arrayLength;
        // DECLARE a int called _arrayHeight
        private int _arrayHeight;

        private DepthFirstSearch _depthFirst;


        public DataStuctureGenorator(int arrayHeight, int arrayLength, string[] nodeInput) 
        {
            _arrayHeight = arrayHeight/ 100;
            _arrayLength = arrayLength/ 100;

            _nodeArray = new Node[_arrayLength, _arrayHeight];

            _tree = new Tree();

            InputHandler handler = new InputHandler(nodeInput);

            _nodeArray = handler.GetNodeArray();

            _startNodeX = handler.StartX;
            //_startNodeY
            _startNodeY = handler.StartY;
            //_goalNodeX
            _goalNodeX = handler.GoalX;
            //_goalNodeY
            _goalNodeY = handler.GoalY;

            //sets GoalNode to the node stored at GoalX and GoalY stored in _fileHandler
            _nodeArray[_goalNodeX, _goalNodeY].GoalNode = true;
            //sets the Root of the tree to the node stored at StartX and StartY stored in _fileHandler
            _tree.Root = _nodeArray[_startNodeX, _startNodeY];

            ArrangeTree();
        }
        public DataStuctureGenorator(int arrayHeight, int arrayLength, int startX, int startY) { }

        private void ArrangeTree()
        {
            // Loops over the arrays length
            for (int x = 0; x < _arrayLength; x++)
            {
                //Loops over the arrays Hight
                for (int y = 0; y < _arrayHeight; y++)
                {
                    //If x +1 is LESS than _arrayLength this is true
                    if (x + 1 < _arrayLength)
                    {
                        // If the current node AND the next node are not walls this is true
                        if (!(_nodeArray[x + 1, y] is Wall) && !(_nodeArray[x, y] is Wall))
                        {
                            //Adds the node to the Neighbours
                            _nodeArray[x, y].Neighbours.Add(_nodeArray[x + 1, y]);
                        }
                    }
                    //If y + 1 LESS than _arrayHeight this is true
                    if (y + 1 < _arrayHeight)
                    {
                        // If the current node AND the next node are not walls this is true
                        if (!(_nodeArray[x, y + 1] is Wall) && !(_nodeArray[x, y] is Wall))
                        {
                            //Adds the node to the Neighbours
                            _nodeArray[x, y].Neighbours.Add(_nodeArray[x, y + 1]);
                        }
                    }
                    //If X - 1 is GREATER than -1 this is true
                    if (x - 1 > -1)
                    {
                        // If the current node AND the next node are not walls this is true
                        if (!(_nodeArray[x - 1, y] is Wall) && !(_nodeArray[x, y] is Wall))
                        {
                            //Adds the node to the Neighbours
                            _nodeArray[x, y].Neighbours.Add(_nodeArray[x - 1, y]);
                        }
                    }
                    //If y - 1 is GREATER than -1 this is true
                    if (y - 1 > -1)
                    {
                        // If the current node AND the next node are not walls this is true
                        if (!(_nodeArray[x, y - 1] is Wall) && !(_nodeArray[x, y] is Wall))
                        {
                            //Adds the node to the Neighbours
                            _nodeArray[x, y].Neighbours.Add(_nodeArray[x, y - 1]);
                        }
                    }
                }
            }
        }

        public IList<INode> getPath()
        {
            //sets GoalNode to the node stored at GoalX and GoalY stored in _fileHandler
            _nodeArray[_goalNodeX, _goalNodeY].GoalNode = true;
            //sets the Root of the tree to the node stored at StartX and StartY stored in _fileHandler
            _tree.Root = _nodeArray[_startNodeX, _startNodeY];
            //INTALISES a new DepthFirstSearch 
            _depthFirst = new DepthFirstSearch();
            _depthFirst.Intialise(_tree);

            //Calls the search Method in _depthFirst Search
            _depthFirst.Search();

            return _depthFirst.Path;
        }
    }
}
