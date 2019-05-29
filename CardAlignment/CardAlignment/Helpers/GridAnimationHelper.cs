using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Hosting;

namespace CardAlignment.Helpers
{
    public class GridAnimationHelper
    {
        public static void InitializeAnimation(UIElement root, UIElement shadowHost)
        {
            var rootVisual = ElementCompositionPreview.GetElementVisual(root);
            var shadowHostVisual = ElementCompositionPreview.GetElementVisual(shadowHost);
            var compositor = rootVisual.Compositor;

            // Create shadow and add it to the Visual Tree
            var shadow = compositor.CreateDropShadow();
            shadow.Color = Color.FromArgb(255, 75, 75, 80);
            var shadowVisual = compositor.CreateSpriteVisual();
            shadowVisual.Shadow = shadow;
            ElementCompositionPreview.SetElementChildVisual(shadowHost, shadowVisual);

            // Make sure the shadow resizes as its host resizes
            var bindSizeAnimation = compositor.CreateExpressionAnimation("hostVisual.Size");
            bindSizeAnimation.SetReferenceParameter("hostVisual", shadowHostVisual);
            shadowVisual.StartAnimation("Size", bindSizeAnimation);

            // Increase the blurradius as the rectangle is scaled up
            var shadowAnimation = compositor.CreateExpressionAnimation("100 * (source.Scale.X - 1)");
            shadowAnimation.SetReferenceParameter("source", rootVisual);
            shadow.StartAnimation("BlurRadius", shadowAnimation);

            // Create animation to scale up the rectangle
            var pointerEnteredAnimation = compositor.CreateVector3KeyFrameAnimation();
            pointerEnteredAnimation.InsertKeyFrame(1.0f, new Vector3(1.05f));

            // Create animation to scale the rectangle back down
            var pointerExitedAnimation = compositor.CreateVector3KeyFrameAnimation();
            pointerExitedAnimation.InsertKeyFrame(1.0f, new Vector3(1.0f));

            // Play animations on pointer enter and exit
            root.PointerEntered += (sender, args) =>
            {
                rootVisual.CenterPoint = new Vector3(rootVisual.Size / 2, 0);
                rootVisual.StartAnimation("Scale", pointerEnteredAnimation);
            };
            root.GotFocus += (sender, e) =>
            {
                rootVisual.CenterPoint = new Vector3(rootVisual.Size / 2, 0);
                rootVisual.StartAnimation("Scale", pointerEnteredAnimation);
            };


            root.PointerExited += (sender, args) => rootVisual.StartAnimation("Scale", pointerExitedAnimation);
            root.LostFocus += (sender, e) => rootVisual.StartAnimation("Scale", pointerExitedAnimation);
        }
    }
}
