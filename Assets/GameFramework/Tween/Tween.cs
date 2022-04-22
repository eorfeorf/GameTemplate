using UnityEngine;

namespace GameFramework.Tween
{
    public static class Tween
    {
        public static Transform Translate(this Transform transform, Vector3 start, Vector3 end, float t)
        {
            var v = Vector3.Lerp(start, end, t);
            transform.position = v;
            return transform;
        }

        public static Transform Rotate(this Transform transform, Vector3 start, Vector3 end, float t)
        {
            var v = Vector3.Lerp(start, end, t);
            var rot = Quaternion.Euler(v);
            transform.rotation = rot;
            return transform;
        }
        
        public static Transform Scale(this Transform transform, Vector3 start, Vector3 end, float t)
        {
            var v = Vector3.Lerp(start, end, t);
            transform.localScale = v;
            return transform;
        }
    }
}
