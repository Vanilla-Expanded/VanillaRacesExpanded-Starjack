
using RimWorld;
using Verse;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine.Analytics;

namespace VanillaRacesExpandedStarjack
{

    public class Gene_Randomizer : Gene
    {
       
        public override void PostAdd()
        {
            base.PostAdd();

            List<GeneDef> chosenAstrogenes = StaticCollections.allAstrogenes.OrderBy(x => Rand.Value).Take(2).ToList();
           
            foreach (GeneDef chosenAstrogene in chosenAstrogenes)
            {
                if (!pawn.genes.HasActiveGene(chosenAstrogene))
                {
                    pawn.genes.AddGene(chosenAstrogene, true);
                }
            }

            pawn.genes.RemoveGene(this);

        }

    }
}
