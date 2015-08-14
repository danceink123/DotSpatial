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

using DotSpatial.Topology.Geometries;
using DotSpatial.Topology.Planargraph;

namespace DotSpatial.Topology.Operation.Polygonize
{
    /// <summary>
    /// An edge of a polygonization graph.
    /// </summary>
    public class PolygonizeEdge : Edge
    {
        #region Fields

        private readonly ILineString _line;

        #endregion

        #region Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="line"></param>
        public PolygonizeEdge(ILineString line)
        {
            _line = line;
        }

        #endregion

        #region Properties

        /// <summary>
        ///
        /// </summary>
        public virtual ILineString Line
        {
            get
            {
                return _line;
            }
        }

        #endregion
    }
}