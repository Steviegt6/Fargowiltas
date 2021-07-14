using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace Fargowiltas.Content.UI.Shared.Panels
{
    public class UIDragPanel : UIPanel
    {
        public Vector2 Offset { get; protected set; }

        public bool Dragging;
        public UIElement[] ExtraChildren;

        public UIDragPanel()
        {
        }

        public UIDragPanel(params UIElement[] countMeAsChildren)
        {
            ExtraChildren = countMeAsChildren;
        }

        protected virtual void DragStart(Vector2 pos)
        {
            Offset = new Vector2(pos.X - Left.Pixels, pos.Y - Top.Pixels);
            Dragging = true;
        }

        protected virtual void DragEnd(Vector2 pos)
        {
            Dragging = false;

            Left.Set(pos.X - Offset.X, 0f);
            Top.Set(pos.Y - Offset.Y, 0f);

            Recalculate();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (ContainsPoint(Main.MouseScreen)) 
                Main.LocalPlayer.mouseInterface = true;

            switch (Dragging)
            {
                case false when ContainsPoint(Main.MouseScreen) && Main.mouseLeft:
                {
                    bool upperMost = true;

                    if (ExtraChildren != null)
                    {
                        IEnumerable<UIElement> children = Elements.Concat(ExtraChildren);

                        if (children.Any(element => element.ContainsPoint(Main.MouseScreen) && element is not UIPanel))
                            upperMost = false;
                    }

                    if (upperMost)
                        DragStart(Main.MouseScreen);
                    break;
                }

                case true when !Main.mouseLeft:
                    DragEnd(Main.MouseScreen);
                    break;
            }

            if (Dragging)
            {
                Left.Set(Main.mouseX - Offset.X, 0f);
                Top.Set(Main.mouseY - Offset.Y, 0f);
                Recalculate();
            }
            
            Rectangle parentSpace = Parent.GetDimensions().ToRectangle();
            if (GetDimensions().ToRectangle().Intersects(parentSpace)) return;

            Left.Pixels = Utils.Clamp(Left.Pixels, 0, parentSpace.Right - Width.Pixels);
            Top.Pixels = Utils.Clamp(Top.Pixels, 0, parentSpace.Bottom - Height.Pixels);

            Recalculate();
        }
    }
}