using System;
using System.Collections.Generic;
using System.Text;

namespace Numatic.Apps.CodingChallenges
{

    /// <summary>
    /// Interface for the main application class
    /// </summary>
    public interface IApp : IDisposable
    {

        /// <summary>
        /// The entrypoint to the application
        /// </summary>
        void Run();

    }

}
