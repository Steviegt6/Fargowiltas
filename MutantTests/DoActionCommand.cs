using System;
using Terraria.ModLoader;

namespace MutantTests
{
    public class DoActionCommand : ModCommand
    {
        public override void Action(CommandCaller caller, string input, string[] args) => DoAction?.Invoke(input, args);

        public override string Command { get; }

        public override CommandType Type => CommandType.Chat;

        public virtual Action<string, string[]> DoAction { get; }

        public DoActionCommand(string command, Action<string, string[]> action)
        {
            Command = command;
            DoAction = action;
        }
    }
}