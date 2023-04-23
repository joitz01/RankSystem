using System;
using Server;
using System.Xml;
using Server.Misc;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Regions;
using System.Collections;
using Server.Engines.Craft;
using System.Collections.Generic;
using Server.Engines.PartySystem;

namespace Server
{
    public class RankLevelHandler
    {
		public static void RankKillInfo(Mobile killer, Mobile killed)
        {
			if (killer is PlayerMobile)
			{
				Mobile pm = (Mobile)killer;
				RankDatabase DBcheck = Server.Items.RankDatabase.GetDB( pm );
				
				if ( DBcheck == null )
				{
					RankDatabase MyDB = new RankDatabase();
					MyDB.CharacterOwner = pm;
					pm.BankBox.DropItem( MyDB );
				}
				RankDatabase DB = Server.Items.RankDatabase.GetDB( pm );
				if (DB == null)
				{
					return;
				}
				
				/* These are extensions from the kill methods */
				RankFeatures.KillTypeCount(pm, DB);
				RankQuestAnimals.Quest_OnKillMethod(pm, killed, DB);
				RankFeatures.PlayerRankUpControl(pm, DB);
				
				/* These are extensions from the kill methods */
				
				Mobile m = (Mobile)killer;
				if (m is PlayerMobile)
				{
					if (DB.Level < 1)
					{
						DB.Level = 1;
					}

					if (DB.ToLevel < 50)
					{
						DB.ToLevel = 50;
					}
				}

				ExpCalculated(pm, killed, DB);
			}
		}
		public static void ExpCalculated (Mobile m, Mobile k, RankDatabase db)
		{
            PlayerMobile pm = null;
            RankLevelHandler lh = new RankLevelHandler();
	
            double orig	= 0;	//Monster Xp

            if (k != null)
			{
                orig = BaseExpCalc(k);
                pm = m as PlayerMobile;
            }

            if (orig > 0)
            {
				pm.SendMessage("You gained " + orig + " exp for the kill!");
				db.Exp	+= (int)orig;

				if (db.Exp >= db.ToLevel)
				{
					if (db.Level < db.MaxLevel)
					{
						DoLevel(pm,db);
					}                   
					else
					{
						pm.SendMessage("You are at max Level!");
						return;
					}
				}
			}
        }

		public static void DoLevel(Mobile klr, RankDatabase db)
		{
            if (db.Exp >= db.ToLevel)
            {
				PlayerMobile pm = klr as PlayerMobile;
				
                db.Exp = 0;
                db.Level += 1;
				
				if (db.Level <= 20)
				{
					db.ToLevel = (int)(db.Level * db.L2to20Multipier);
					db.TotalSkillPoints += db.Below20;
				}
				if (db.Level <= 40)
				{
					db.ToLevel = (int)(db.Level * db.L21to40Multiplier);
					db.TotalSkillPoints += db.Below40;
				}
				if (db.Level <= 60)
				{
					db.ToLevel = (int)(db.Level * db.L41to60Multiplier);
					db.TotalSkillPoints += db.Below60;
				}
				if (db.Level <= 70)
				{
					db.ToLevel = (int)(db.Level * db.L61to70Multiplier);
					db.TotalSkillPoints += db.Below70;
				}
				if (db.Level <= 80)
				{
					db.ToLevel = (int)(db.Level * db.L71to80Multiplier);
					db.TotalSkillPoints += db.Below80;
				}
				if (db.Level <= 90)
				{
					db.ToLevel = (int)(db.Level * db.L81to90Multipier);
					db.TotalSkillPoints += db.Below90;
				}
				if (db.Level <= 100)
				{
					db.ToLevel = (int)(db.Level * db.L91to100Multipier);
					db.TotalSkillPoints += db.Below100;
				}
				if (db.Level <= 110)
				{
					db.ToLevel = (int)(db.Level * db.L101to110Multiplier);
					db.TotalSkillPoints += db.Below110;
				}
				if (db.Level <= 120)
				{
					db.ToLevel = (int)(db.Level * db.L111to120Multiplier);
					db.TotalSkillPoints += db.Below120;
				}
				if (db.Level <= 130)
				{
					db.ToLevel = (int)(db.Level * db.L121to130Multiplier);
					db.TotalSkillPoints += db.Below130;
				}
				if (db.Level <= 140)
				{
					db.ToLevel = (int)(db.Level * db.L131to140Multiplier);
					db.TotalSkillPoints += db.Below140;
				}
				if (db.Level <= 150)
				{
					db.ToLevel = (int)(db.Level * db.L141to150Multiplier);
					db.TotalSkillPoints += db.Below150;
				}
				if (db.Level <= 160)
				{
					db.ToLevel = (int)(db.Level * db.L151to160Multiplier);
					db.TotalSkillPoints += db.Below160;
				}
				if (db.Level <= 170)
				{
					db.ToLevel = (int)(db.Level * db.L161to170Multiplier);
					db.TotalSkillPoints += db.Below170;
				}
				if (db.Level <= 180)
				{
					db.ToLevel = (int)(db.Level * db.L171to180Multiplier);
					db.TotalSkillPoints += db.Below180;
				}
				if (db.Level <= 190)
				{
					db.ToLevel = (int)(db.Level * db.L181to190Multiplier);
					db.TotalSkillPoints += db.Below190;
				}
				if (db.Level <= 200)
				{
					db.ToLevel = (int)(db.Level * db.L191to200Multiplier);
					db.TotalSkillPoints += db.Below200;
				}
				
				int gainstat = StatGain(pm);
				pm.RawStr += gainstat;
				pm.RawDex += gainstat;
				pm.RawInt += gainstat;
				
				if (pm.Hits < pm.HitsMax)
					pm.Hits = pm.HitsMax;

				if (pm.Mana < pm.ManaMax)
					pm.Mana = pm.ManaMax;

				if (pm.Stam < pm.StamMax)
					pm.Stam = pm.StamMax;
			
				pm.PlaySound(0x20F);
				pm.FixedParticles(0x376A, 1, 31, 9961, 1160, 0, EffectLayer.Waist);
				pm.FixedParticles(0x37C4, 1, 31, 9502, 43, 2, EffectLayer.Waist);
				pm.SendMessage( "Your level has increased" );
				db.Exp = 0;
			}
		}
        public static int BaseExpCalc(Mobile kld)
        {
            double amnt;

            if (kld is BaseCreature)
            {
                BaseCreature bc = kld as BaseCreature;

				amnt = bc.HitsMax + bc.RawStatTotal;


            }
            else
            {
                PlayerMobile pm = kld as PlayerMobile;

                amnt = ((pm.Str * pm.Hits) + (pm.Dex * pm.Stam)
                    + (pm.Int * pm.Mana)) / 5;

                if (pm.Skills.Total >= 100)
                    amnt += pm.Skills.Total;
                else
                    amnt += 100;
            }
            
            return (int)amnt / 10;       
        }
		public static int StatGain(Mobile m)
		{
			double amnt;
			
			amnt = m.RawStatTotal / 15;
			
			return (int)amnt; 
		}
	}
}