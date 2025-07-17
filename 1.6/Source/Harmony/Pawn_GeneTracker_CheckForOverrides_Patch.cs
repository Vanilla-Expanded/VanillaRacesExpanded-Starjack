using HarmonyLib;
using RimWorld;
using VEF.Genes;
using Verse;

namespace VanillaRacesExpandedStarjack
{
    [HarmonyPatch(typeof(Pawn_GeneTracker), "CheckForOverrides")]
    public static class VanillaRacesExpandedStarjack_Pawn_GeneTracker_CheckForOverrides_Patch
    {
        public static void Postfix(Pawn_GeneTracker __instance)
        {
            foreach (var gene in __instance.GenesListForReading)
            {
                if (gene is Gene_Astrogene)
                {
                    if (gene.Active) {
                      
                        foreach (var otherGene in __instance.GenesListForReading)
                        {
                            if (otherGene != gene && gene.def.ConflictsWith(otherGene.def))
                            {
                                gene.OverrideBy(null);
                                otherGene.OverrideBy(gene);
                            }
                        }
                    }
                    else {
                       
                        foreach (var otherGene in __instance.GenesListForReading)
                        {
                            if (otherGene != gene && gene.def.ConflictsWith(otherGene.def))
                            {
                                gene.OverrideBy(otherGene);
                                otherGene.OverrideBy(null);
                            }
                        }
                    }



                }
            }
        }
    }
}

