﻿#region License

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringMethodHandlers.cs">
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
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using GoodlyFere.Parse.Linq.Translation.ExpressionVisitors;
using GoodlyFere.Parse.Linq.Translation.ParseQuery;

#endregion

namespace GoodlyFere.Parse.Linq.Translation.Handlers
{
    internal static class ParseGeoPointMethodHandlers
    {
        #region Methods

        internal static IList<IQueryPiece> HandleNearSphere(QueryRoot query, MethodCallExpression expression)
        {
            object latitude = ConstantValueFinder.Find(expression.Arguments[0]);
            object longitude = ConstantValueFinder.Find(expression.Arguments[1]);

            SubConstraintSet set = new SubConstraintSet("$nearSphere");
            set.Operators.Add(new BasicQueryPiece("__type", "GeoPoint"));
            set.Operators.Add(new BasicQueryPiece("latitude", latitude));
            set.Operators.Add(new BasicQueryPiece("longitude", longitude));

            return new List<IQueryPiece> { set };
        }

        #endregion
    }
}