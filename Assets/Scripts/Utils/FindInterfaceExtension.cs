using UnityEngine;

namespace omochio.Utility
{
    public static class FindInterfaceExtension
    {
        public static T FindObjectOfInterface<T>(this Object _) where T : class
        {
            foreach (var n in Object.FindObjectsOfType<Component>())
            {
                if (n is T component)
                {
                    return component;
                }
            }
            return null;
        }
    }
}