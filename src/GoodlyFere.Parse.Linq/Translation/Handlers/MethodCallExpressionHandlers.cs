﻿#region License

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MethodCallExpressionHandlers.cs">
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
using GoodlyFere.Parse.Linq.Translation.Maps;
using GoodlyFere.Parse.Linq.Translation.ParseQuery;

#endregion

namespace GoodlyFere.Parse.Linq.Translation.Handlers
{
    internal static class MethodCallExpressionHandlers
    {
        #region Methods

        internal static void HandleParseGeoPointMethods(QueryRoot query, MethodCallExpression expression)
        {
            Handle(query, expression, ParseGeoPointMethodHandlersMap.Instance);
        }

        internal static void HandleStringMethods(QueryRoot query, MethodCallExpression expression)
        {
            Handle(query, expression, StringMethodHandlersMap.Instance);
        }

        private static void AddConstraintToQuery(QueryRoot query, IEnumerable<IQueryPiece> operands, ConstraintSet set)
        {
            foreach (var op in operands)
            {
                set.Operators.Add(op);
            }
            query.AddConstraint(set);
        }

        private static void Handle<T>(
            QueryRoot query, MethodCallExpression expression, T map)
            where T : Map<T, string, MethodCallHandlerFactoryMethod>, new()
        {
            string propertyName = MemberNameFinder.Find(expression.Object);
            ConstraintSet set = new ConstraintSet(propertyName);

            if (map.HasValue(expression.Method.Name))
            {
                var method = map.GetValue(expression.Method.Name);
                IList<IQueryPiece> operands = method(query, expression);
                AddConstraintToQuery(query, operands, set);
            }
            else
            {
                throw new Exception(string.Format("Method call not handled! {0}", expression.Method.Name));
            }
        }

        #endregion
    }
}