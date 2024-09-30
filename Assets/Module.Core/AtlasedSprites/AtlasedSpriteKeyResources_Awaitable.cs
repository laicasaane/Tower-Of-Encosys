#if !UNITASK && UNITY_6000_0_OR_NEWER

using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

namespace Module.Core.AtlasedSprites
{
    public readonly partial struct AtlasedSpriteKeyResources : ILoadAsync<Sprite>, ITryLoadAsync<Sprite>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public async Awaitable<Sprite> LoadAsync(CancellationToken token = default)
        {
            var result = await TryLoadAsync(token);
            return result.ValueOrDefault();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public async Awaitable<Option<Sprite>> TryLoadAsync(CancellationToken token = default)
        {
            if (string.IsNullOrEmpty(Sprite)) return default;

            var atlasOpt = await Atlas.TryLoadAsync(token);
            return atlasOpt.HasValue ? atlasOpt.Value().TryGetSprite(Sprite) : default;
        }
    }
}

#endif
