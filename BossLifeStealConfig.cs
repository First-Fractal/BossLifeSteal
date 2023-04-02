using Terraria;
using Terraria.ID;
using Terraria.Chat;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using Terraria.ModLoader.Config;
using System.ComponentModel;

namespace BossLifeSteal
{
    [Label("$Mods.BossLifeSteal.Config.Label")]
    public class BossLifeStealConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        // Automatically set by tModLoader
        public static BossLifeStealConfig Instance;

        [Header("$Mods.BossLifeSteal.Config.Header.GeneralOptions")]

        [Label("$Mods.BossLifeSteal.Config.LifeStealMulti.Label")]
        [Tooltip("$Mods.BossLifeSteal.Config.LifeStealMulti.Tooltip")]
        [Range(0, 20)]
        //[Increment(10)]
        [Slider]
        [DrawTicks()]
        [DefaultValue(5)]
        public int LifeStealMulti;

        [Label("$Mods.BossLifeSteal.Config.EnableChat.Label")]
        [Tooltip("$Mods.BossLifeSteal.Config.EnableChat.Tooltip")]
        [DefaultValue(false)]
        public bool EnableChat;
    }
}
