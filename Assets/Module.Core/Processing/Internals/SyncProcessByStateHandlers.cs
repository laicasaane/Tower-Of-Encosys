#if UNITASK || UNITY_6000_0_OR_NEWER
#if !(UNITY_EDITOR || DEBUG) || DISABLE_DEBUG
#define __MODULE_CORE_PROCESSING_NO_VALIDATION__
#else
#define __MODULE_CORE_PROCESSING_VALIDATION__
#endif

using System;
using System.Runtime.CompilerServices;

namespace Module.Core.Processing.Internals.Sync
{
    internal sealed class ProcessByStateHandler<TState, TRequest> : IProcessHandler<TRequest>
        where TState : class
    {
        private static readonly TypeId s_typeId;
        private readonly WeakReference<TState> _state;
        private readonly Action<TState, TRequest> _process;

        static ProcessByStateHandler()
        {
            s_typeId = TypeId.Get<Action<TRequest>>();
        }

        public ProcessByStateHandler(TState state, Action<TState, TRequest> process)
        {
            _state = new(state ?? throw new ArgumentNullException(nameof(state)));
            _process = process ?? throw new ArgumentNullException(nameof(process));
        }

        public TypeId Id
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => s_typeId;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Process(TRequest arg)
        {
            if (_state.TryGetTarget(out var state))
            {
                _process(state, arg);
                return;
            }

#if __MODULE_CORE_PROCESSING_VALIDATION__
            StateValidation.ErrorIfStateIsDestroyed<TState>();
#endif
        }
    }

    internal sealed class ProcessByStateHandler<TState, TRequest, TResult> : IProcessHandler<TRequest, TResult>
        where TState : class
    {
        private static readonly TypeId s_typeId;
        private readonly WeakReference<TState> _state;
        private readonly Func<TState, TRequest, TResult> _process;

        static ProcessByStateHandler()
        {
            s_typeId = TypeId.Get<Func<TRequest, TResult>>();
        }

        public ProcessByStateHandler(TState state, Func<TState, TRequest, TResult> process)
        {
            _state = new(state ?? throw new ArgumentNullException(nameof(state)));
            _process = process ?? throw new ArgumentNullException(nameof(process));
        }

        public TypeId Id
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => s_typeId;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TResult Process(TRequest arg)
        {
            if (_state.TryGetTarget(out var state))
            {
                return _process(state, arg);
            }

#if __MODULE_CORE_PROCESSING_VALIDATION__
            StateValidation.ErrorIfStateIsDestroyed<TState>();
#endif

            return default;
        }
    }

#if __MODULE_CORE_PROCESSING_VALIDATION__
    internal static class StateValidation
    {
        public static void ErrorIfStateIsDestroyed<TState>()
        {
            Logging.RuntimeLoggerAPI.LogError($"The state instance of type {typeof(TState)} is not alive anymore.");
        }
    }
#endif
}

#endif
