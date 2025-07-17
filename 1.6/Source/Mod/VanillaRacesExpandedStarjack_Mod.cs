using HarmonyLib;
using RimWorld;
using System.Reflection;
using Verse;


namespace VanillaRacesExpandedStarjack
{

    public class VanillaRacesExpandedStarjack_Mod : Mod
    {
        public VanillaRacesExpandedStarjack_Mod(ModContentPack content) : base(content)
        {
            var harmony = new Harmony("com.VanillaRacesExpandedStarjack");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }

}
