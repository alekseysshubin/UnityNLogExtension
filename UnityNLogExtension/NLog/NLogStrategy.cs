#region Copyright & Licence
// This software is licensed under the MIT License
// 
// 
// Original UnityLog4NetExtension copyright (C) 2012-15, Rob Levine
// NLog adaptation copyright (c) 2017, Aleksey Shubin
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

using Microsoft.Practices.ObjectBuilder2;
using NLog;
using UnityNLogExtension.CreationStackTracker;

namespace UnityNLogExtension.NLog
{
    /// <summary>
    /// </summary>
    public class NLogStrategy<TLogger> : BuilderStrategy where TLogger : ILogger
    {
        #region Public Methods and Operators

        /// <summary>
        /// </summary>
        /// <param name="context">
        /// </param>
        public override void PreBuildUp(IBuilderContext context)
        {
            var policy = context.Policies.Get<ICreationStackTrackerPolicy>(buildKey: null, localOnly: true);

            if (typeof(ILogger).IsAssignableFrom(policy.TypeStack.Peek(0)))
            {
                context.Existing = LogManager.GetLogger(
                    policy.TypeStack.Count >= 2 ? policy.TypeStack.Peek(1).FullName : "", 
                    typeof(TLogger));
            }

            base.PreBuildUp(context);
        }

        #endregion
    }
}