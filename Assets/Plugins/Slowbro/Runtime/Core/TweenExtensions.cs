using UnityEngine;
using UnityEngine.UI;

namespace Slowbro
{
    public static class TweenExtensions
    {
        public static Tween<Slider, float> Interpolate(this Slider slider, float end, float duration, EasingType easing)
        {
            return (Tween<Slider, float>)new Tween<Slider, float>((o) => o.value, (o, v) => o.value = v)
                .Initialise(slider).SetStart(slider.value).SetEnd(end).SetDuration(duration).SetInterpolation(new FloatInterpolator(easing)).Run();
        }

        public static Animation Animate(this Image image, Sprite[] sprites, float frameRate)
        {
            return (Animation)new Animation((o) => o.sprite, (o, v) => o.sprite = v)
                .SetSprites(sprites).SetFrameRate(frameRate).SetNumberOfLoops(1).Initialise(image).Run();
        }

        public static Animation Animate(this Image image, Sprite[] sprites, float frameRate, int numberOfLoops)
        {
            return (Animation)new Animation((o) => o.sprite, (o, v) => o.sprite = v)
                .SetSprites(sprites).SetFrameRate(frameRate).SetNumberOfLoops(numberOfLoops).Initialise(image).Run();
        }

        public static Position Translate(this Transform transform, Vector3 end, float duration, Space relativeTo, EasingType easing)
        {
            return (Position)new Position((o) => o.position, (o, v) => o.position = v)
                .Initialise(transform).SetStart(transform.position).SetEnd(end).SetDuration(duration).SetSpace(relativeTo).SetInterpolation(new Vector3Interpolator(easing)).Run();
        }

        public static Position Translate(this Transform transform, Vector3 start, Vector3 end, float duration, Space relativeTo, EasingType easing)
        {
            return (Position)new Position((o) => o.position, (o, v) => o.position = v)
                .Initialise(transform).SetStart(start).SetEnd(end).SetDuration(duration).SetSpace(relativeTo).SetInterpolation(new Vector3Interpolator(easing)).Run();
        }
    }
}