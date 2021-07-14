using System;
using Terraria.UI;

namespace Fargowiltas.Core.UserInterfaces
{
    public interface IUIProfile
    {
        UserInterface UserInterface { get; }

        UIState State { get; }

        string InsertionLayer { get; }

        Guid Identifier { get; }
    }
}