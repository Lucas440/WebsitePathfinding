using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using WebsitePathfindingApp.Classes.DataStructure;

namespace WebsitePathfindingApp.Classes.NodeSetUp
{
    public class InputHandler
    {
        //DECLARES a int called _goalX
        private int _goalX;
        //DECLARES a int called _goalY
        private int _goalY;
        //DECLARES a int called _startX
        private int _startX;
        //DECLARES a int called _startY
        private int _startY;

        Node[,] _nodeArray;

        /// <summary>
        /// A Property that gets GoalX
        /// </summary>
        public int GoalX { get => _goalX; }
        /// <summary>
        /// A Property that gets GoalY
        /// </summary>
        public int GoalY { get => _goalY; }
        /// <summary>
        /// A Property that gets StartX
        /// </summary>
        public int StartX { get => _startX; }
        /// <summary>
        /// A Property that gets StartY
        /// </summary>
        public int StartY { get => _startY; }

        private string[] _inputArray;

        public InputHandler(string[] inputStringArray)
        {
            _inputArray = inputStringArray;
        }

        public Node[,] GetNodeArray()
        {
            _nodeArray = new Node[10, 5];

            for (int y = 0; y < 5; y++) 
            {
                string inputRow = _inputArray[y];

                for (int x = 0; x < 10; x++)
                {
                    char inputNode = inputRow[x];

                    if (inputNode.ToString().ToUpper() == "S")
                    {
                        //Sets start X and Y to x and y in the loop
                        _startX = x;
                        _startY = y;
                        //Creates a new Node and stores it at x and y 
                        _nodeArray[x, y] = new Node();
                        //Sets the location to 100 times x and y in the loop
                        _nodeArray[x, y].Location = new Vector2(x * 100, y * 100);
                        
                    }
                    //if nodeIndex is G this is true
                    else if (inputNode.ToString().ToUpper() == "G")
                    {
                        //Sets goal X and Y to x and y in the loop
                        _goalX = x;
                        _goalY = y;
                        //Creates a new Node and stores it at x and y 
                        _nodeArray[x, y] = new Node();
                        //Sets the location to 100 times x and y in the loop
                        _nodeArray[x, y].Location = new Vector2(x * 100, y * 100);
                    }
                    //if nodeIndex is W this is true
                    else if (inputNode.ToString().ToUpper() == "W")
                    {
                        //Creates a new Wall and stores it at x and y 
                        _nodeArray[x, y] = new Wall();
                        //Sets the location to 100 times x and y in the loop
                        _nodeArray[x, y].Location = new Vector2(x * 100, y * 100);
                    }
                    else
                    {
                        //Creates a new Node and stores it at x and y 
                        _nodeArray[x, y] = new Node();
                        //Sets the location to 100 times x and y in the loop
                        _nodeArray[x, y].Location = new Vector2(x * 100, y * 100);
                    }
                }
            }

            return _nodeArray;
        }

    }
}
