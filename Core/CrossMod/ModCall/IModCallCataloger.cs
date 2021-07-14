using System;
using System.Collections.Generic;
using Terraria.ModLoader;

namespace Fargowiltas.Core.CrossMod.ModCall
{
    public interface IModCallCataloger
    {
        Mod Mod { get; }

        Dictionary<Type, IModCaller> CallersByType { get; }

        Dictionary<string, Type> CallerTypesByString { get; }

        void RegisterHandler<T>() where T : IModCaller, new();

        void RegisterHandler<T>(T caller) where T : IModCaller;

        void MapCallersToMessages();

        object HandleCall(params object[] args);

        void ParseArgs(out string message, out List<object> parsedArgs, params object[] args);

        IModCaller GetCaller<T>();

        IModCaller GetCaller(Type type);
    }
}