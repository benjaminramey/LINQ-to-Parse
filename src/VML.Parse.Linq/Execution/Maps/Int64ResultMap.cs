﻿// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Int64ResultMap.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>12/19/2013 12:13 PM</created>
//  <updated>01/23/2014 2:32 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;
using Remotion.Linq.Clauses.ResultOperators;
using VML.Parse.Linq.Execution.Handlers;

#endregion

namespace VML.Parse.Linq.Execution.Maps
{
    internal class Int64ResultMap : Map<Int64ResultMap, Type, ScalarResultHandlerMethod<Int64>>
    {
        #region Constructors and Destructors

        public Int64ResultMap()
        {
            Add(typeof(LongCountResultOperator), Int64ResultHandlers.HandleLongCount);
        }

        #endregion
    }
}