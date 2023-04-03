using System.Numerics;

namespace WebsitePathfindingApp.Classes.DataStructure
{
    public interface INode
    {
        Vector2 Location { get; set; }
        /// <summary>
        /// A Property used to return and set a boolean called GoalNode
        /// </summary>
        bool GoalNode { get; set; }

        /// <summary>
        /// A Property used to return and get a bool called Visited
        /// </summary>
        bool Visited { get; set; }
        /// <summary>
        /// A Property used to return and get a string called Data
        /// </summary>
        string Data { get; set; }
        /// <summary>
        /// A Property used to return a List Of Nodes Called Neighbours
        /// </summary>
        IList<INode> Neighbours { get; }
        /// <summary>
        /// A Property used to Check if the player visted this node
        /// </summary>
        bool PlayerVisited { get; set; }
    }
}
