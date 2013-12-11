﻿#region License

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParseQueryExecutor.cs">
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
using GoodlyFere.Parse.Interfaces;
using GoodlyFere.Parse.Linq.Generation;
using Remotion.Linq;

#endregion

namespace GoodlyFere.Parse.Linq
{
    public class ParseQueryExecutor : IQueryExecutor
    {
        #region Constants and Fields

        private IParseApiSettingsProvider _settingsProvider;

        #endregion

        #region Constructors and Destructors

        public ParseQueryExecutor(IParseApiSettingsProvider settingsProvider)
        {
            _settingsProvider = settingsProvider;
        }

        #endregion

        #region Public Methods

        public IEnumerable<T> ExecuteCollection<T>(QueryModel queryModel)
        {
            string queryString = TranslationVisitor.Translate(queryModel);
            IList<T> query = ParseContext.API.Query<T>(queryString);

            return query.ToList();
        }

        public T ExecuteScalar<T>(QueryModel queryModel)
        {
            throw new NotImplementedException();
        }

        public T ExecuteSingle<T>(QueryModel queryModel, bool returnDefaultWhenEmpty)
        {
            string queryString = TranslationVisitor.Translate(queryModel);
            queryString += "&limit=1";

            IList<T> query = ParseContext.API.Query<T>(queryString);

            if (returnDefaultWhenEmpty)
            {
                return query.FirstOrDefault();
            }

            return query.First();
        }

        #endregion
    }
}