using UnityEngine;

namespace Slowbro
{
    public interface IInterpolator<T>
    {
        public T Interpolate(T a, T b, float t);
    }

    public struct FloatInterpolator : IInterpolator<float>
    {
        internal readonly EasingType easing;

        internal FloatInterpolator(EasingType easing)
        {
            this.easing = easing;
        }

        public float Interpolate(float a, float b, float t)
        {
            return Mathf.LerpUnclamped(a, b, Easing.Resolve(easing, t));
        }
    }

    public struct IntInterpolator : IInterpolator<float>
    {
        internal readonly EasingType easing;

        internal IntInterpolator(EasingType easing)
        {
            this.easing = easing;
        }

        public float Interpolate(float a, float b, float t)
        {
            return Mathf.RoundToInt(Mathf.LerpUnclamped(a, b, Easing.Resolve(easing, t)));
        }
    }

    public struct Vector3Interpolator : IInterpolator<Vector3>
    {
        internal readonly EasingType easing;

        internal Vector3Interpolator(EasingType easing)
        {
            this.easing = easing;
        }

        public Vector3 Interpolate(Vector3 a, Vector3 b, float t)
        {
            return new Vector3(Mathf.LerpUnclamped(a.x, b.x, Easing.Resolve(easing, t)),
                Mathf.LerpUnclamped(a.y, b.y, Easing.Resolve(easing, t)), Mathf.LerpUnclamped(a.z, b.z, Easing.Resolve(easing, t)));
        }
    }

    public struct Vector3IntInterpolator : IInterpolator<Vector3>
    {
        internal readonly EasingType easing;

        internal Vector3IntInterpolator(EasingType easing)
        {
            this.easing = easing;
        }

        public Vector3 Interpolate(Vector3 a, Vector3 b, float t)
        {
            return new Vector3(Mathf.RoundToInt(Mathf.LerpUnclamped(a.x, b.x, Easing.Resolve(easing, t))),
                Mathf.RoundToInt(Mathf.LerpUnclamped(a.y, b.y, Easing.Resolve(easing, t))), Mathf.RoundToInt(Mathf.LerpUnclamped(a.z, b.z, Easing.Resolve(easing, t))));
        }
    }

    public struct BezierInterpolator : IInterpolator<Vector3>
    {
        internal readonly float height;

        internal BezierInterpolator(float height)
        {
            this.height = height;
        }

        public Vector3 Interpolate(Vector3 a, Vector3 b, float t)
        {
            var c = a + (b - a) / 2f + Vector3.up * height;

            var ac = Vector3.LerpUnclamped(a, c, t);
            var cb = Vector3.LerpUnclamped(c, b, t);

            return Vector3.LerpUnclamped(ac, cb, t);
        }
    }
}

/*

    public struct RotationInterpolator : IInterpolator<Vector2>
    {
        private float frequency;
        private float angle;
        private float radius;

        private float loops;

        public RotationInterpolator(float _frequency, float _loops)
        {
            frequency = _frequency;
            loops = _loops;

            angle = 0f;
            radius = 2f;
        }

        public Vector2 Interpolate(Vector2 _startValue, Vector2 _endValue, float _time)
        {
            angle -= (2f * Mathf.PI / frequency * Time.deltaTime) * loops;

            return _startValue + new Vector2(Mathf.Sin(angle) * _endValue.x, Mathf.Cos(angle) * _endValue.y) * radius;
        }
    }

 */ 