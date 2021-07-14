using System;
using System.Security.Cryptography;
using System.Text;
using Terraria.UI;

namespace Fargowiltas.Core.UserInterfaces
{
    public class UIProfile : IUIProfile
    {
        public UserInterface UserInterface { get; }

        public UIState State { get; }

        public string InsertionLayer { get; }

        public Guid Identifier
        {
            get
            {
                using MD5 algorithm = MD5.Create();
                byte[] computerHash = algorithm.ComputeHash(Encoding.Default.GetBytes(State.GetType().FullName ??
                    throw new InvalidOperationException("Could not retrieve state type name.")));
                return new Guid(computerHash);
            }
        }

        public UIProfile(UIState state, string insertionLayer)
        {
            State = state;
            InsertionLayer = insertionLayer;
            UserInterface = new UserInterface();
        }
    }
}