using System;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent.UI.Elements;

namespace Fargowiltas.Content.UI.Shared.Elements
{
    public class UIHoverTextImageButton : UIImageButton
    {
        public Func<string> Text { get; }

        public UIHoverTextImageButton(Asset<Texture2D> texture, Func<string> text) : base(texture)
        {
            Text = text;
        }

        public UIHoverTextImageButton(Asset<Texture2D> texture, string text) : base(texture)
        {
            Text = () => text;
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);

            if (!IsMouseHovering) return;

            Main.LocalPlayer.mouseInterface = true;
            Main.instance.MouseText(Text());
        }
    }
}