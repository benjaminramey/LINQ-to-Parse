﻿#region License

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParseGeoPoint.cs">
// LINQ-to-Parse, a LINQ interface to the Parse.com REST API.
//  
// Copyright (C) 2013 Benjamin Ramey
// 
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
// 
// http://www.gnu.org/licenses/lgpl-2.1-standalone.html
// 
// You can contact me at ben.ramey@gmail.com.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

#endregion

#region Usings

using System;
using System.Linq;
using System.Runtime.Serialization;

#endregion

namespace GoodlyFere.Parse.Model
{
    [DataContract]
    public class ParseGeoPoint
    {
        #region Constructors and Destructors

        public ParseGeoPoint()
        {
            ParseType = "GeoPoint";
        }

        #endregion

        #region Public Properties

        [DataMember(Name = "latitude")]
        public double Latitude { get; set; }

        [DataMember(Name = "longitude")]
        public double Longitude { get; set; }

        [DataMember(Name = "__type")]
        public string ParseType { get; set; }

        #endregion

        #region Public Methods

        public bool NearSphere(double latitude, double longitude)
        {
            throw new NotImplementedException("This method facilitates LINQ NearSphere queries only.");
        }

        #endregion
    }
}