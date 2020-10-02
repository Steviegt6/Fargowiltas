using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace Fargowiltas.Projectiles
{
    public class CorruptNukeProj : RenewalBaseProj
    {
        public CorruptNukeProj() : base("CorruptRenewal", ProjectileID.CorruptSpray, 1, false)
        {
        }
    }

    public class CorruptNukeSupremeProj : RenewalBaseProj
    {
        public CorruptNukeSupremeProj() : base("CorruptRenewalSupreme", ProjectileID.CorruptSpray, 1, true)
        {
        }
    }

    public class CrimsonNukeProj : RenewalBaseProj
    {
        public CrimsonNukeProj() : base("CrimsonRenewal", ProjectileID.CrimsonSpray, 4, false)
        {
        }
    }

    public class CrimsonNukeSupremeProj : RenewalBaseProj
    {
        public CrimsonNukeSupremeProj() : base("CrimsonRenewalSupreme", ProjectileID.CrimsonSpray, 4, true)
        {
        }
    }

    public class HallowNukeProj : RenewalBaseProj
    {
        public HallowNukeProj() : base("HallowRenewal", ProjectileID.HallowSpray, 2, false)
        {
        }
    }

    public class HallowNukeSupremeProj : RenewalBaseProj
    {
        public HallowNukeSupremeProj() : base("HallowRenewalSupreme", ProjectileID.HallowSpray, 2, true)
        {
        }
    }

    public class MushroomNukeProj : RenewalBaseProj
    {
        public MushroomNukeProj() : base("MushroomRenewal", ProjectileID.MushroomSpray, 3, false)
        {
        }
    }

    public class MushroomNukeSupremeProj : RenewalBaseProj
    {
        public MushroomNukeSupremeProj() : base("MushroomRenewalSupreme", ProjectileID.MushroomSpray, 3, true)
        {
        }
    }

    public class PurityNukeProj : RenewalBaseProj
    {
        public PurityNukeProj() : base("PurityRenewal", ProjectileID.PureSpray, 0, false)
        {
        }
    }

    public class PurityNukeSupremeProj : RenewalBaseProj
    {
        public PurityNukeSupremeProj() : base("PurityRenewalSupreme", ProjectileID.PureSpray, 0, true)
        {
        }
    }
}