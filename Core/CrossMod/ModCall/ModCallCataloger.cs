using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.ModLoader;

namespace Fargowiltas.Core.CrossMod.ModCall
{
    public class ModCallCataloger : IModCallCataloger
    {
        public Mod Mod { get; }

        public Dictionary<Type, IModCaller> CallersByType { get; }

        public Dictionary<string, Type> CallerTypesByString { get; }

        public ModCallCataloger(Mod mod)
        {
            Mod = mod;

            CallersByType = new Dictionary<Type, IModCaller>();
            CallerTypesByString = new Dictionary<string, Type>();
        }

        public void RegisterHandler<T>() where T : IModCaller, new() => RegisterHandler(new T());

        public void RegisterHandler<T>(T caller) where T : IModCaller => CallersByType.Add(typeof(T), caller);

        public void MapCallersToMessages()
        {
            foreach ((Type type, IModCaller caller) in CallersByType)
            {
                string[] messages = caller.HandledMessages;

                foreach (string s in messages) CallerTypesByString.Add(s, type);
            }
        }

        public object HandleCall(params object[] args)
        {
            ParseArgs(out string message, out List<object> parsedArgs, args);

            return CallersByType[CallerTypesByString[message]].Call(message, parsedArgs);
        }

        public void ParseArgs(out string message, out List<object> parsedArgs, params object[] args)
        {
            if (args[0] is not string s)
                throw new ArgumentException(
                    $"The first parameter of Mod.Call must be a string for all {Mod.Name} calls.");

            message = s;
            parsedArgs = args.ToList();
            parsedArgs.RemoveAt(0);
        }

        public IModCaller GetCaller<T>() => GetCaller(typeof(T));

        public IModCaller GetCaller(Type type) => CallersByType[type];
    }
}