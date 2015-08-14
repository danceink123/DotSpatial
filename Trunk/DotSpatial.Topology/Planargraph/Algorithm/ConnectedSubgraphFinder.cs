// ********************************************************************************************************
// Product Name: DotSpatial.Topology.dll
// Description:  The basic topology module for the new dotSpatial libraries
// ********************************************************************************************************
// The contents of this file are subject to the Lesser GNU Public License (LGPL)
// you may not use this file except in compliance with the License. You may obtain a copy of the License at
// http://dotspatial.codeplex.com/license  Alternately, you can access an earlier version of this content from
// the Net Topology Suite, which is also protected by the GNU Lesser Public License and the sourcecode
// for the Net Topology Suite can be obtained here: http://sourceforge.net/projects/nts.
//
// Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF
// ANY KIND, either expressed or implied. See the License for the specific language governing rights and
// limitations under the License.
//
// The Original Code is from the Net Topology Suite, which is a C# port of the Java Topology Suite.
//
// The Initial Developer to integrate this code into MapWindow 6.0 is Ted Dunsford.
//
// Contributor(s): (Open source contributors should list themselves and their modifications here).
// |         Name         |    Date    |                              Comment
// |----------------------|------------|------------------------------------------------------------
// |                      |            |
// ********************************************************************************************************

using System.Collections.Generic;

namespace DotSpatial.Topology.Planargraph.Algorithm
{
    /// <summary>
    /// Finds all connected <see cref="Subgraph" />s of a <see cref="PlanarGraph" />.
    /// </summary>
    public class ConnectedSubgraphFinder
    {
        #region Fields

        private readonly PlanarGraph _graph;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectedSubgraphFinder"/> class.
        /// </summary>
        /// <param name="graph">The <see cref="PlanarGraph" />.</param>
        public ConnectedSubgraphFinder(PlanarGraph graph)
        {
            this._graph = graph;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds the argument node and all its out edges to the subgraph.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="nodeStack"></param>
        /// <param name="subgraph"></param>
        private static void AddEdges(Node node, Stack<Node> nodeStack, Subgraph subgraph)
        {
            node.IsVisited = true;
            foreach (DirectedEdge de in node.OutEdges)
            {
                subgraph.Add(de.Edge);
                Node toNode = de.ToNode;
                if (!toNode.IsVisited) 
                    nodeStack.Push(toNode);
            }
        }

        /// <summary>
        /// Adds all nodes and edges reachable from this node to the subgraph.
        /// Uses an explicit stack to avoid a large depth of recursion.
        /// </summary>
        /// <param name="startNode"></param>
        /// <param name="subgraph"></param>
        private void AddReachable(Node startNode, Subgraph subgraph)
        {
            Stack<Node> nodeStack = new Stack<Node>();
            nodeStack.Push(startNode);
            while (nodeStack.Count != 0)
            {
                Node node = nodeStack.Pop();
                AddEdges(node, nodeStack, subgraph);
            }
        }

        private Subgraph FindSubgraph(Node node)
        {
            Subgraph subgraph = new Subgraph(_graph);
            AddReachable(node, subgraph);
            return subgraph;
        }

        public IList<Subgraph> GetConnectedSubgraphs()
        {
            IList<Subgraph> subgraphs = new List<Subgraph>();
            GraphComponent.SetVisited(_graph.GetNodeEnumerator(), false);
            IEnumerator<Edge> ienum = _graph.GetEdgeEnumerator();
            while(ienum.MoveNext())
            {
                Edge e = ienum.Current;
                Node node = e.GetDirEdge(0).FromNode;
                if (!node.IsVisited)
                    subgraphs.Add(FindSubgraph(node));                
            }
            return subgraphs;
        }

        #endregion
    }
}