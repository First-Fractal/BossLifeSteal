﻿using Terraria;
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
        [Range(0, 100)]
        [Slider]
        [DefaultValue(4)]
        public int LifeSteal;

        [Label("$Mods.BossLifeSteal.Config.MinionsLifeSteal.Label")]
        [Tooltip("$Mods.BossLifeSteal.Config.MinionsLifeSteal.Tooltip")]
        [DefaultValue(true)]
        public bool MinionsLifeSteal;

        [Label("$Mods.BossLifeSteal.Config.EnableChat.Label")]
        [Tooltip("$Mods.BossLifeSteal.Config.EnableChat.Tooltip")]
        [DefaultValue(true)]
        public bool EnableChat;
    }
}
