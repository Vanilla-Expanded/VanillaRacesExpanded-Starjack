
using RimWorld;
using Verse;
using Verse.AI;

namespace VanillaRacesExpandedStarjack
{
    public class CompAbilitySpaceOnly : AbilityComp
    {
        public override bool GizmoDisabled(out string reason)
        {
            if (this.parent.pawn.Position!=IntVec3.Invalid && this.parent.pawn.Map?.BiomeAt(this.parent.pawn.Position)?.inVacuum != true)
            {
                reason = "VRE_AbilityOnlyInSpace".Translate();
                return true;
            }
            return base.GizmoDisabled(out reason);
        }

       
    }
}