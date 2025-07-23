using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using VEF.Genes;
using Verse;



namespace VanillaRacesExpandedStarjack
{

    [HarmonyPatch(typeof(GeneDefGenerator))]
    [HarmonyPatch("ImpliedGeneDefs")]
    public static class VanillaRacesExpandedStarjack_GeneDefGenerator_ImpliedGeneDefs_Patch
    {
        [HarmonyPostfix]
        public static IEnumerable<GeneDef> Postfix(IEnumerable<GeneDef> values)
        {
            if (values.EnumerableNullOrEmpty())
            {
                return values;
            }

            List<GeneDef> resultingList = values.ToList();

            List<GeneDef> validGenes = DefDatabase<GeneDef>.AllDefsListForReading.Where(x => x.biostatCpx <= 2 && x.biostatMet >= -5 && x.biostatMet <= -1 && x.biostatArc == 0 
            && !x.defName.Contains("Randomizer") && !x.defName.Contains("VREA_") && !x.defName.Contains("VREW_Pollution") &&x.prerequisite is null && !InternalDefOf.Starjack.genes.Contains(x)).ToList();
           
            if (!validGenes.NullOrEmpty())
            {
                foreach (var geneDef in validGenes)
                {
                    resultingList.Add(GetAstrogene(geneDef));
                
                }
            }
            return resultingList;

        }

        private static GeneDef GetAstrogene(GeneDef geneDef)
        {
            GeneDef clonedGene = geneDef.Clone() as GeneDef;
            clonedGene.defName = geneDef.defName + "_Astrogene";
            clonedGene.geneClass = typeof(Gene_Astrogene);
            clonedGene.selectionWeight = 0;
            clonedGene.biostatCpx = 0;
            clonedGene.biostatMet = 0;
            clonedGene.modExtensions = clonedGene.modExtensions?.ListFullCopy();

            var existingGeneExtension = clonedGene.GetModExtension<GeneExtension>();

            if (existingGeneExtension != null)
            {
                clonedGene.modExtensions.Remove(existingGeneExtension);
                var clonedGeneExtension = (GeneExtension)existingGeneExtension.Clone();

                clonedGeneExtension.backgroundPathXenogenes = "UI/GeneBackground/GeneBackground_Astrogene";
                clonedGeneExtension.backgroundPathXenogenes = "UI/GeneBackground/GeneBackground_Astrogene";

                clonedGene.modExtensions.Add(clonedGeneExtension);

            }
            else
            {
                clonedGene.modExtensions ??= new List<DefModExtension>();
                clonedGene.modExtensions.Add(new GeneExtension
                {
                    backgroundPathXenogenes = "UI/GeneBackground/GeneBackground_Astrogene",
                    backgroundPathEndogenes = "UI/GeneBackground/GeneBackground_Astrogene"
                });
            }
            clonedGene.canGenerateInGeneSet = false;



            clonedGene.ResolveDefNameHash();
            StaticCollections.allAstrogenes.Add(clonedGene);
           

            return clonedGene;
        }

       
    }

   
}
