using UnityEngine;

namespace Slowbro
{
    public enum EasingType
    {
        Linear,
        EaseOutSine,
        EaseInSine,
        EaseOutBounce,
        PingPong
    }

    public readonly struct Easing
    {
        internal static float Resolve(EasingType type, float time)
        {
            switch (type)
            {
                case EasingType.Linear:
                    return Linear(time);

                case EasingType.EaseOutSine:
                    return EaseOutSine(time);

                case EasingType.EaseInSine:
                    return EaseInSine(time);

                case EasingType.EaseOutBounce:
                    return EaseOutBounce(time);

                case EasingType.PingPong:
                    return PingPong(time);

                default:
                    break;
            }

            return time;
        }

        private static float Linear(float time)
        {
            return time;
        }

        private static float EaseOutSine(float time)
        {
            return Mathf.Sin(time * Mathf.PI / 2f);
        }

        private static float EaseInSine(float time)
        {
            return 1f - Mathf.Cos(time * Mathf.PI / 2f);
        }

        private static float EaseOutBounce(float time)
        {
            if (time < (1f / 2.75f))
            {
                return 7.5625f * time * time;
            }
            else if (time < (2f / 2.75f))
            {
                return 7.5625f * (time -= 1.5f / 2.75f) * time + 0.75f;
            }
            else if (time < (2.5f / 2.75f))
            {
                return 7.5625f * (time -= 2.25f / 2.75f) * time + 0.9375f;
            }
            else
            {
                return 7.5625f * (time -= 2.625f / 2.75f) * time + 0.984375f;
            }
        }

        private static float PingPong(float time)
        {
            return Mathf.PingPong(time * 2f, 1f);
        }
    }
}

/*

const n1 = 7.5625;
const d1 = 2.75;

if (x < 1 / d1) {
    return n1 * x * x;
} else if (x < 2 / d1) {
    return n1 * (x -= 1.5 / d1) * x + 0.75;
} else if (x < 2.5 / d1) {
    return n1 * (x -= 2.25 / d1) * x + 0.9375;
} else {
    return n1 * (x -= 2.625 / d1) * x + 0.984375;
}

        public static float EaseOutBounce(float _time)
        {
            if (_time < (1f / 2.75f))
            {
                return 7.5625f * _time * _time;
            }
            else if (_time < (2f / 2.75f))
            {
                return 7.5625f * (_time -= 1.5f / 2.75f) * _time + 0.75f;
            }
            else if (_time < (2.5f / 2.75f))
            {
                return 7.5625f * (_time -= 2.25f / 2.75f) * _time + 0.9375f;
            }
            else
            {
                return 7.5625f * (_time -= 2.625f / 2.75f) * _time + 0.984375f;
            }
        }

 */ 