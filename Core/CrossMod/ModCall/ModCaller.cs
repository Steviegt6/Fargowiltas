using System;
using System.Collections.Generic;
using System.Linq;

namespace Fargowiltas.Core.CrossMod.ModCall
{
    public abstract class ModCaller : IModCaller
    {
        public Dictionary<string, Func<List<object>, object>> CallFunctions = new();

        public virtual string[] HandledMessages => CallFunctions.Keys.ToArray();

        public virtual object Call(string message, List<object> args) => CallFunctions[message](args);
    }
}