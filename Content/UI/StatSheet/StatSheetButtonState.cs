using Fargowiltas.Content.UI.Shared.Elements;
using Fargowiltas.Core.UserInterfaces;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using ReLogic.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;

namespace Fargowiltas.Content.UI.StatSheet
{
    public class StatSheetButtonState : UIState
    {
        public UIImage Icon;
        public UIHoverTextImageButton IconHighlight;

        public override void OnActivate()
        {
            base.OnActivate();
            // TODO: localization
            Asset<Texture2D> statIcon = ModContent.Request<Texture2D>("Fargowiltas/Assets/UI/Icons/StatsButton");
            Icon = new UIImage(statIcon);
            Icon.Left.Set(26f, 0f);
            Icon.Top.Set(262f, 0f);
            Append(Icon);

            Asset<Texture2D> glow = ModContent.Request<Texture2D>("Fargowiltas/Assets/UI/Icons/StatsButton_MouseOver");
            IconHighlight = new UIHoverTextImageButton(glow, "Stat Sheet");
            IconHighlight.Left.Set( -2f, 0f);
            IconHighlight.Top.Set(-2f, 0f);
            IconHighlight.SetVisibility(1f, 0f);
            IconHighlight.OnClick += IconHighlight_OnClick;
            Icon.Append(IconHighlight);
        }

        private static void IconHighlight_OnClick(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.playerInventory)
                UIManager.Toggle<StatSheetButtonState>();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Main.playerInventory)
                base.Draw(spriteBatch);

            if (IsMouseHovering)
                Main.NewText("cum");
        }
    }
}