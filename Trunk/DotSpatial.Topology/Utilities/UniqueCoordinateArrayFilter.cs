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
using DotSpatial.Topology.Geometries;

namespace DotSpatial.Topology.Utilities
{
    /// <summary>
    /// A <c>CoordinateFilter</c> that builds a set of <c>Coordinate</c>s.
    /// The set of coordinates contains no duplicate points.
    /// </summary>
    public class UniqueCoordinateArrayFilter : ICoordinateFilter
    {
        #region Fields

        private readonly List<Coordinate> _list = new List<Coordinate>();

        #endregion

        #region Properties

        /// <summary>
        /// Returns the gathered <see cref="Coordinate"/>s.
        /// </summary>
        public virtual Coordinate[] Coordinates
        {
            get { return _list.ToArray(); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="coord"></param>
        public void Filter(Coordinate coord)
        {
            if (!_list.Contains(coord))
                _list.Add(coord);
        }

        /// <summary>
        /// Convenience method which allows running the filter over an array of <see cref="Coordinate"/>s.
        /// </summary>
        /// <param name="coords">an array of coordinates</param>
        /// <returns>an array of the unique coordinates</returns>
        public static Coordinate[] FilterCoordinates(Coordinate[] coords)
        {
            UniqueCoordinateArrayFilter filter = new UniqueCoordinateArrayFilter();
            for (int i = 0; i < coords.Length; i++)
                filter.Filter(coords[i]);
            return filter.Coordinates;
        }

        #endregion
    }
}