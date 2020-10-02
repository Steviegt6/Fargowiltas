using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace Fargowiltas.Items.Renewals
{
    public class CorruptRenewal : BaseRenewalItem
    {
        public CorruptRenewal() : base("Corruption Renewal", "Corrupts a large radius", "CorruptNukeProj", ItemID.PurpleSolution)
        {
        }
    }

    public class CorruptRenewalSupreme : BaseRenewalItem
    {
        public CorruptRenewalSupreme() : base("Corruption Renewal Supreme", "Corrupts the entire world", "CorruptNukeSupremeProj", -1, true, "CorruptRenewal")
        {
        }
    }

    public class CrimsonRenewal : BaseRenewalItem
    {
        public CrimsonRenewal() : base("Crimson Renewal", "Crimsons a large radius", "CrimsonNukeProj", ItemID.RedSolution)
        {
        }
    }

    public class CrimsonRenewalSupreme : BaseRenewalItem
    {
        public CrimsonRenewalSupreme() : base("Crimson Renewal Supreme", "Crimsons the entire world", "CrimsonNukeSupremeProj", -1, true, "CrimsonRenewal")
        {
        }
    }

    public class HallowRenewal : BaseRenewalItem
    {
        public HallowRenewal() : base("Hallowed Renewal", "Hallows a large radius", "HallowNukeProj", ItemID.BlueSolution)
        {
        }
    }

    public class HallowRenewalSupreme : BaseRenewalItem
    {
        public HallowRenewalSupreme() : base("Hallowed Renewal Supreme", "Hallows the entire world", "HallowNukeSupremeProj", -1, true, "HallowRenewal")
        {
        }
    }

    public class MushroomRenewal : BaseRenewalItem
    {
        public MushroomRenewal() : base("Mushroom Renewal", "Shroomifies a large radius", "MushroomNukeProj", ItemID.DarkBlueSolution)
        {
        }
    }

    public class MushroomRenewalSupreme : BaseRenewalItem
    {
        public MushroomRenewalSupreme() : base("Mushroom Renewal Supreme", "Shroomifies the entire world", "MushroomNukeSupremeProj", -1, true, "MushroomRenewal")
        {
        }
    }

    public class PurityRenewal : BaseRenewalItem
    {
        public PurityRenewal() : base("Purity Renewal", "Cleanses a large radius", "PurityNukeProj", ItemID.GreenSolution)
        {
        }
    }

    public class PurityRenewalSupreme : BaseRenewalItem
    {
        public PurityRenewalSupreme() : base("Purity Renewal Supreme", "Cleanses the entire world", "PurityNukeSupremeProj", -1, true, "PurityRenewal")
        {
        }
    }
}