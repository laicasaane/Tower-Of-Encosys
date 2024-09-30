#if UNITY_ENTITIES

using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Entities;

namespace Module.Core
{
    public static class CoreSystemStateExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static NativeArray<T> CreateNativeArray<T>(ref this SystemState state, int length)
            where T : unmanaged
        {
            return CollectionHelper.CreateNativeArray<T>(
                  length
                , state.WorldUpdateAllocator
                , NativeArrayOptions.ClearMemory
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static NativeArray<T> CreateNativeArrayNotInit<T>(ref this SystemState state, int length)
            where T : unmanaged
        {
            return CollectionHelper.CreateNativeArray<T>(
                  length
                , state.WorldUpdateAllocator
                , NativeArrayOptions.UninitializedMemory
            );
        }
    }
}

#endif
