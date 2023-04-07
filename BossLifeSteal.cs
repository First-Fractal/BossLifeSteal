using Terraria;
using Terraria.ID;
using Terraria.Chat;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace BossLifeSteal
{
    public class BossLifeSteal : Mod
    {
        public int[] BossParts = { NPCID.EaterofWorldsHead, NPCID.EaterofWorldsBody, NPCID.EaterofWorldsTail, NPCID.DungeonGuardian, NPCID.SkeletronHand, NPCID.SkeletronHead, NPCID.WallofFleshEye, NPCID.TheDestroyer, NPCID.TheDestroyerBody, NPCID.TheDestroyerTail, NPCID.PrimeCannon, NPCID.PrimeLaser, NPCID.PrimeSaw, NPCID.PrimeVice, NPCID.PlanterasHook, NPCID.PlanterasTentacle, NPCID.GolemFistLeft, NPCID.GolemFistRight, NPCID.GolemHead, NPCID.GolemHeadFree, NPCID.CultistBossClone, NPCID.MoonLordCore, NPCID.MoonLordHand, NPCID.MoonLordHead, NPCID.MoonLordFreeEye };
        public int[] BossMinions = { NPCID.BlueSlime, NPCID.SlimeSpiked, NPCID.ServantofCthulhu, NPCID.VileSpitEaterOfWorlds, NPCID.Creeper, NPCID.Bee, NPCID.BeeSmall,  NPCID.TheHungry, NPCID.TheHungryII, NPCID.QueenSlimeMinionBlue, NPCID.QueenSlimeMinionPink, NPCID.QueenSlimeMinionPurple, NPCID.Probe, NPCID.DetonatingBubble, NPCID.Sharkron, NPCID.Sharkron2, NPCID.AncientLight, NPCID.AncientDoom, NPCID.AncientCultistSquidhead, NPCID.CultistDragonHead, NPCID.CultistDragonBody1, NPCID.CultistDragonBody2, NPCID.CultistDragonBody3, NPCID.CultistDragonBody4,  NPCID.CultistDragonTail};
        public void Talk(string message, Color color)
        {
            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                Main.NewText(message, color);
            }
            else
            {
                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(message), color);
            }
        }

        public void LifeSteal(NPC boss, int damage)
        {
            int heal = damage * BossLifeStealConfig.Instance.LifeStealMulti;
            boss.life += heal;
            if (boss.life > boss.lifeMax)
            {
                boss.life = boss.lifeMax;
            }

            if (BossLifeStealConfig.Instance.EnableChat)
            {
                Talk(boss.FullName + " " + Language.GetTextValue("Mods.BossLifeSteal.Chat.heal") + " " + heal +" HP.", Color.Red);
            }
        }
    }

    public class BossLifeStealNPC : GlobalNPC
    {
        public static BossLifeSteal BLS = new BossLifeSteal();
        public override void ModifyHitPlayer(NPC npc, Player target, ref int damage, ref bool crit)
        {
            if (npc.boss && npc.active)
            {
                BLS.LifeSteal(npc, damage);
            }

            foreach(int part in BLS.BossParts)
            {
                if (part == npc.type && npc.active)
                {
                    BLS.LifeSteal(npc, damage);
                }
            }
            base.ModifyHitPlayer(npc, target, ref damage, ref crit);
        }
    }

    public class BossLifeStealProjectile : GlobalProjectile
    {
        public static BossLifeSteal BLS = new BossLifeSteal();
        public override void OnHitPlayer(Projectile projectile, Player target, int damage, bool crit)
        {
            if (Main.npc[projectile.owner].boss && Main.npc[projectile.owner].active)
            {
                BLS.LifeSteal(Main.npc[projectile.owner], damage);
            }

            foreach (int part in BLS.BossParts)
            {
                if (Main.npc[projectile.owner].type == part && Main.npc[projectile.owner].active)
                {
                    BLS.LifeSteal(Main.npc[projectile.owner], damage);
                }
            }

            base.OnHitPlayer(projectile, target, damage, crit);
        }
    }
}