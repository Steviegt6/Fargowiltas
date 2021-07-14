using Fargowiltas.Content.UI.Shared.Elements;
using Fargowiltas.Core.Localization;
using Fargowiltas.Core.UserInterfaces;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
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

        private static readonly Asset<Texture2D> IconTexture =
            ModContent.Request<Texture2D>("Fargowiltas/Assets/UI/Icons/StatsButton", AssetRequestMode.ImmediateLoad);

        private static readonly Asset<Texture2D> GlowTexture =
            ModContent.Request<Texture2D>("Fargowiltas/Assets/UI/Icons/StatsButton_MouseOver",
                AssetRequestMode.ImmediateLoad);

        public override void OnActivate()
        {
            base.OnActivate();

            IgnoresMouseInteraction = false;

            // TODO: localization
            Icon = new UIImage(IconTexture);
            Icon.Left.Set(26f, 0f);
            Icon.Top.Set(262f, 0f);
            Append(Icon);

            IconHighlight = new UIHoverTextImageButton(GlowTexture,
                () => LanguageHelper.GetTextValue("StatSheet.StatSheetName"));
            IconHighlight.Left.Set(-2f, 0f);
            IconHighlight.Top.Set(-2f, 0f);
            IconHighlight.SetVisibility(1f, 0f);
            IconHighlight.OnClick += IconHighlight_OnClick;
            Icon.Append(IconHighlight);
        }

        private static void IconHighlight_OnClick(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.playerInventory)
                UIManager.Toggle<StatSheetState>();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Main.playerInventory)
                base.Draw(spriteBatch);
        }
    }
}