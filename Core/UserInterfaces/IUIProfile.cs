using Terraria.UI;

namespace Fargowiltas.Core.UserInterfaces
{
    public interface IUIProfile
    {
        UserInterface UserInterface { get; }

        string InsertionLayer { get; }
    }
}