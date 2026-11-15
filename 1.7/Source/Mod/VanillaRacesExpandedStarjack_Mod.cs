using HarmonyLib;
using RimWorld;
using System.Reflection;
using UnityEngine;
using Verse;


namespace VanillaRacesExpandedStarjack
{

    public class VanillaRacesExpandedStarjack_Mod : Mod
    {
        public VanillaRacesExpandedStarjack_Mod(ModContentPack content) : base(content)
        {
            var harmony = new Harmony("com.VanillaRacesExpandedStarjack");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            settings = GetSettings<VanillaRacesExpandedStarjack_Settings>();
        }


        public static VanillaRacesExpandedStarjack_Settings settings;

        
        public override string SettingsCategory() => "VRE - Starjack";

        public override void DoSettingsWindowContents(Rect inRect)
        {
            settings.DoWindowContents(inRect);
        }
    }

}
