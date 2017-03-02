﻿#region Copyright & Licence
// This software is licensed under the MIT License
// 
// 
// Copyright (C) 2012-15, Rob Levine
// 
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy 
// of this software and associated documentation files (the "Software"), 
// to deal in the Software without restriction, including without limitation 
// the rights to use, copy, modify, merge, publish, distribute, sublicense, 
// and/or sell copies of the Software, and to permit persons to whom the 
// Software is furnished to do so, subject to the following conditions:
// 
// 
// The above copyright notice and this permission notice shall be included in 
// all copies or substantial portions of the Software.
// 
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS 
// IN THE SOFTWARE.
// 
// [Source code: https://github.com/alekseysshubin/UnityNLogExtension]
#endregion

using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.ObjectBuilder;
using UnityNLogExtension.CreationStackTracker;

namespace UnityNLogExtension.CreationStackReporter
{
    /// <summary>
    /// </summary>
    public class CreationStackReporterExtension : UnityContainerExtension
    {
        #region Methods

        /// <summary>
        /// </summary>
        protected override void Initialize()
        {
            Context.Strategies.AddNew<CreationStackTrackerStrategy>(UnityBuildStage.TypeMapping);
            Context.Strategies.AddNew<UnityObjectCreationStackReporterStrategy>(UnityBuildStage.TypeMapping);
        }

        #endregion
    }
}