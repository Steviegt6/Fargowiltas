using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent.UI.Elements;

namespace Fargowiltas.Content.UI.Shared.Elements
{
    public class UIHoverTextImageButton : UIImageButton
    {
        public string Text { get; }

        public UIHoverTextImageButton(Asset<Texture2D> texture, string text) : base(texture)
        {
            Text = text;
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            if (IsMouseHovering)
            {
                Main.LocalPlayer.mouseInterface = true;
                Main.hoverItemName = Text;
            }

            base.DrawSelf(spriteBatch);
        }
    }
}