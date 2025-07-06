using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Papicalc
{
    internal class UIAnimator
    {
        public System.Windows.Forms.Timer UIAnimatorTimer;
        public AnimationStyle AnimationStyle;
        public AnimationType[] AnimationTypeList;
        public int AnimationFrame;
        public int TotalAnimationFrames;
        public Control Control;
        public Point _StartLoc;
        public Point _EndLoc;
        public Size _StartSize;
        public Size _EndSize;
        public int _CenterStartingXLoc;

        public UIAnimator(AnimationType[] animationTypeList, AnimationStyle animationStyle, int startingFrame, int totalAnimationFrams, Control control, Point startLoc, Point endLoc, Size startSize, Size endSize)
        {
            AnimationTypeList = animationTypeList;
            AnimationStyle = animationStyle;
            AnimationFrame = startingFrame;
            TotalAnimationFrames = totalAnimationFrams;
            Control = control;
            _StartLoc = startLoc;
            _EndLoc = endLoc;
            _StartSize = startSize;
            _EndSize = endSize;
            _CenterStartingXLoc = _StartLoc.X - startSize.Width / 2;

            UIAnimatorTimer = new System.Windows.Forms.Timer
            {
                Interval = 25
            };
            UIAnimatorTimer.Tick += UIAnimatorTimer_Tick;

        }

        private void UIAnimatorTimer_Tick(object? sender, EventArgs e)
        {
            if (AnimationFrame >= TotalAnimationFrames) { UIAnimatorTimer.Stop(); }

            float t = AnimationFrame / (float)TotalAnimationFrames;
            float inverseT = (1 - t);

            float easedT = (float)(0.5 - 0.5 * Math.Cos(t * Math.PI));
            float inverseEasedT = 1 - easedT;

            float modifier;
            float inverseModifier;
            switch (AnimationStyle)
            {
                case AnimationStyle.Ease:
                    modifier = easedT;
                    inverseModifier = inverseEasedT;
                    break;
                case AnimationStyle.Normal:
                    modifier = t;
                    inverseModifier = inverseT;
                    break;
                default:
                    throw new Exception("unexpected animation style");
            }

            if (AnimationTypeList.Contains(AnimationType.SizeTransform))
            {
                Control.Size = new Size((int)(_StartSize.Width * inverseEasedT + _EndSize.Width * easedT), (int)(_StartSize.Height * inverseEasedT + _EndSize.Height * easedT));

                //Control.Location = new Point((int)(_CenterStartingXLoc - (Control.Size.Width / 2)), _StartSize.Height);
            }
            AnimationFrame++;
            return;
        }
    }

}
public enum AnimationType
{
    SizeTransform,
    LocationTransform
}
public enum AnimationStyle
{
    Normal,
    Ease
}



