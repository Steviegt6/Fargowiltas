using System;
using System.Security.Cryptography;
using System.Text;
using Terraria.UI;

namespace Fargowiltas.Core.UserInterfaces
{
    public readonly struct UIStateIdentity<TState> : IUIStateIdentity where TState : UIState
    {
        public string TypeName => typeof(TState).FullName;

        public Guid Identity
        {
            get
            {
                using MD5 algorithm = MD5.Create();
                byte[] computedHash = algorithm.ComputeHash(Encoding.Default.GetBytes(TypeName));
                return new Guid(computedHash);
            }
        }
    }
}