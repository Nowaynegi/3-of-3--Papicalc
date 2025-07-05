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
        private System.Windows.Forms.Timer operatorAnimationTimer;
        private int animationFrame = 0;
        private int TotalAnimationFrames;
        private Point _StartLoc;
        private Point _EndLoc;
        private Size _StartSize;
        private Size _EndSize;
        private bool animationUp;
        private bool animationLeft;

        public UIAnimator(int totalAnimationFrams, Point startLoc , Point endLoc, Size startSize, Size endSize, bool animationUp, bool animationLeft)
        {

        }

    }


}
