using Terraria.UI;

namespace Fargowiltas.Core.UserInterfaces
{
    public class UIProfile : IUIProfile
    {
        public UserInterface UserInterface { get; }

        public string InsertionLayer { get; }

        public UIProfile(UserInterface userInterface, string insertionLayer)
        {
            UserInterface = userInterface;
            InsertionLayer = insertionLayer;
        }
    }
}