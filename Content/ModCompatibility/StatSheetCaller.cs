using System;
using System.Collections.Generic;
using Fargowiltas.Content.UI.StatSheet;
using Fargowiltas.Core.CrossMod.ModCall;

namespace Fargowiltas.Content.ModCompatibility
{
    public class StatSheetCaller : ModCaller
    {
        public StatSheetCaller()
        {
            CallFunctions.Add("StatSheet", HandleStatSheet);
        }

        private static object HandleStatSheet(List<object> args)
        {
            string option = (string) args[0];
            args.RemoveAt(0);

            return option switch
            {
                "Add" => AddToStatSheet(args),
                _ => null
            };
        }

        private static object AddToStatSheet(IReadOnlyList<object> args)
        {
            StatSheetState.ModCallStats.Add((((Func<string>)args[0]), Convert.ToInt32(args[1])));
            return null;
        }
    }
}