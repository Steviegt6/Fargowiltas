using Fargowiltas.Core.CrossMod.ModCall;

namespace Fargowiltas.Core.CrossMod
{
    public interface ICrossModManager
    {
        IModCallCataloger CallCataloger { get; }
    }
}