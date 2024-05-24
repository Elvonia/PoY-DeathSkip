using HarmonyLib;
using MelonLoader;
using PoY_DeathSkip;

[assembly: MelonInfo(typeof(DeathSkipMod), "Death Skip", "1.0", "Kalico")]
[assembly: MelonGame("TraipseWare", "Peaks of Yore")]

namespace PoY_DeathSkip
{
    public class DeathSkipMod : MelonMod
    {
        [HarmonyPatch(typeof(FallingEvent), "FellToDeath")]
        private static class DeathPatch
        {
            private static bool Prefix()
            {
                if (GameManager.control.permaDeathEnabled || GameManager.control.freesoloEnabled)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
