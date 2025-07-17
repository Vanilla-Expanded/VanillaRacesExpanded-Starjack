using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;
using RimWorld;
namespace VanillaRacesExpandedStarjack
{
	[DefOf]
	public static class InternalDefOf
	{
		static InternalDefOf()
		{
			DefOfHelper.EnsureInitializedInCtor(typeof(InternalDefOf));
		}

		public static XenotypeDef Starjack;

		public static GeneDef VREStarjack_Cryostasis;
		public static GeneDef VREStarjack_OxygenSensitivity_Extreme;

        public static HediffDef VREStarjack_CryostasisHediff;
		public static HediffDef Hypothermia;
		public static HediffDef VREStarjack_Hyperoxia;


    }
}
