using System.Collections.Generic;

namespace Fargowiltas.Core.CrossMod.ModCall
{
    public interface IModCaller
    {
        string[] HandledMessages { get; }

        object Call(string message, List<object> args);
    }
}