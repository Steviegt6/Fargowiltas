using System;

namespace Fargowiltas.Core.UserInterfaces
{
    public interface IUIStateIdentity
    {
        string TypeName { get; }

        Guid Identity { get; }
    }
}