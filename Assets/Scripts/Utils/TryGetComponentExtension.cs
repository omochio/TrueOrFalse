using UnityEngine;

namespace omochio.Utility
{
    public static class TryGetComponentExtension
    {
        public static bool TryGetComponentDebugError<T>(this Component comp, out T outComp)
        {
            if (comp.TryGetComponent(out outComp))
            {
                return true;
            }
            else
            {
                Debug.LogError($"{typeof(T)}がアタッチされていません");
                return false;
            }
        }
    }
}