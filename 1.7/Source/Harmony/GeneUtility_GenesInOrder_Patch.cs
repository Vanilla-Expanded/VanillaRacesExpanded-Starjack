using HarmonyLib;
using RimWorld;
using Verse;
using System.Collections.Generic;
using System.Linq;
using VEF.Genes;

namespace VanillaRacesExpandedStarjack
{
    [HarmonyPatch(typeof(GeneUtility), "GenesInOrder", MethodType.Getter)]
    public static class VanillaRacesExpandedStarjack_GeneUtility_GenesInOrder_Patch
    {
        [HarmonyPriority(int.MinValue)]
        public static void Postfix(ref List<GeneDef> __result)
        {
            var window = Find.WindowStack.WindowOfType<GeneCreationDialogBase>();
            if (window != null)
            {
                __result = __result.Where(x => x.geneClass != typeof(Gene_Astrogene)).ToList();
            }
        }
    }
}

