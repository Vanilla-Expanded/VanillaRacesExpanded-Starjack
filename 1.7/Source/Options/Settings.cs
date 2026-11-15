using RimWorld;
using UnityEngine;
using Verse;
using System;


namespace VanillaRacesExpandedStarjack
{


    public class VanillaRacesExpandedStarjack_Settings : ModSettings

    {

        public static int starjackGenesAmount = starjackGenesAmountBase;
        public const int starjackGenesAmountBase = 2;
        public const int maxStarjackGenesAmount = 5;
        public const int minStarjackGenesAmount = 0;

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref starjackGenesAmount, "starjackGenesAmount", starjackGenesAmountBase, true);

        }

        public void DoWindowContents(Rect inRect)
        {
            Listing_Standard ls2 = new Listing_Standard();

            ls2.Begin(inRect);

            var starjackGenesAmountLabel = ls2.LabelPlusButton("VRE_StarjackGenes".Translate() + ": " + starjackGenesAmount, "VRE_StarjackGenesDesc".Translate());
            starjackGenesAmount = (int)Math.Round(ls2.Slider(starjackGenesAmount, minStarjackGenesAmount, maxStarjackGenesAmount), 0);

            if (ls2.Settings_Button("VREStarjack_Reset".Translate(), new Rect(0f, starjackGenesAmountLabel.position.y + 35, 250f, 29f)))
            {
                starjackGenesAmount = starjackGenesAmountBase;
            }



            ls2.End();
        }

    }


}
