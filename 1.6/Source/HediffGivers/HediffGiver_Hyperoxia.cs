
using RimWorld;
using System.Linq;
using UnityEngine;
using Verse;

namespace VanillaRacesExpandedStarjack
{
    public class HediffGiver_Hyperoxia : HediffGiver
    {


        public override void OnIntervalPassed(Pawn pawn, Hediff cause)
        {
            if (pawn.genes?.HasActiveGene(InternalDefOf.VREStarjack_OxygenSensitivity_Extreme) !=true)
            {
                return;
            }

            bool inVacuum = pawn.Map?.BiomeAt(pawn.Position)?.inVacuum == true;

            HediffDef hediffDef = InternalDefOf.VREStarjack_Hyperoxia;
            Hediff firstHediffOfDef = pawn.health.hediffSet.GetFirstHediffOfDef(hediffDef);
            if (!inVacuum)
            {
                
                HealthUtility.AdjustSeverity(pawn, hediffDef, 0.01f);
                if (pawn.Dead)
                {
                    return;
                }
            }
            if (firstHediffOfDef == null)
            {
                return;
            }
            if (inVacuum)
            {
                
                firstHediffOfDef.Severity -= 0.1f;
            }

        }
    }
}