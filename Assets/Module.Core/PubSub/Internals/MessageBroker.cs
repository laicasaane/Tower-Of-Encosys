#if UNITASK || UNITY_6000_0_OR_NEWER

using System;
using Module.Core.Logging;

namespace Module.Core.PubSub.Internals
{
    internal abstract class MessageBroker : IDisposable
    {
        public abstract void Dispose();

        public abstract void Compress(ILogger logger);
    }
}

#endif
