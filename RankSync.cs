using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Network;
using System.Collections;
using System.Collections.Generic;

namespace Server.Items
{
    public class RankSync
    {
        public static void Initialize()
        {
			EventSink.CastSpellRequest += new CastSpellRequestEventHandler( EventSink_CastSpellRequest );
			EventSink.Login += EventSink_Login;
			EventSink.OnItemUse += OnItemUseSink;
			EventSink.Logout += EventSink_LogOut;
			EventSink.Movement += EventSink_Movement;
			EventSink.AggressiveAction += new AggressiveActionEventHandler( EventSink_AggressiveAction );
			
			Mobile.SkillCheckTargetHandler = new SkillCheckTargetHandler( Mobile_SkillCheckTarget );
			Mobile.SkillCheckLocationHandler = new SkillCheckLocationHandler( Mobile_SkillCheckLocation );
			Mobile.SkillCheckDirectLocationHandler = new SkillCheckDirectLocationHandler( Mobile_SkillCheckDirectLocation );
			Mobile.SkillCheckDirectTargetHandler = new SkillCheckDirectTargetHandler( Mobile_SkillCheckDirectTarget );
        }

		public static bool Mobile_SkillCheckDirectTarget( Mobile from, SkillName skillName, object target, double chance )
		{
			Skill skill = from.Skills[skillName];

			if ( skill == null )
				return false;

			RankFeatures.SkillRankGainerTarget(from, skill, skillName);

			return true;
		}
		
		public static bool Mobile_SkillCheckDirectLocation( Mobile from, SkillName skillName, double chance )
		{
			Skill skill = from.Skills[skillName];

			if ( skill == null )
				return false;
			
			RankFeatures.SkillRankGainer(from, skill, skillName);
			
			return true;
		}
		public static bool Mobile_SkillCheckLocation( Mobile from, SkillName skillName, double minSkill, double maxSkill )
		{
			Skill skill = from.Skills[skillName];

			if ( skill == null )
				return false;
			
			RankFeatures.SkillRankGainer(from, skill, skillName);

			return true;
		}
		
		public static bool Mobile_SkillCheckTarget( Mobile from, SkillName skillName, object target, double minSkill, double maxSkill )
		{
			Skill skill = from.Skills[skillName];

			if ( skill == null )
				return false;

			RankFeatures.SkillRankGainerTarget(from, skill, skillName);


			return true;
		}
		private static void EventSink_CastSpellRequest( CastSpellRequestEventArgs e )
		{/* May be used for future  */
			Mobile from = e.Mobile;
			
//			from.SendMessage( "TESTew!" );
			
			Spellbook book = e.Spellbook as Spellbook;
			int spellID = e.SpellID;
		}

		
		public static void EventSink_AggressiveAction( AggressiveActionEventArgs e )
		{
			Mobile aggressor = e.Aggressor;
			Mobile aggressed = e.Aggressed;
			
			if (aggressor is PlayerMobile)
			{
				PlayerMobile pm = aggressor as PlayerMobile;
				BaseWeapon weapon = pm.Weapon as BaseWeapon;
				RankDatabase DB = Server.Items.RankDatabase.GetDB( pm );
				
				if (DB == null)
				{
					return;
				}
				
				RankFeatures.OnHitRankOverRide(pm, aggressed, null);
			}
		}
		
		public static void EventSink_Movement (MovementEventArgs e)
		{
			Mobile m = e.Mobile;

			if (m is PlayerMobile)
			{
				PlayerMobile pm = m as PlayerMobile;
				RankDatabase DB = Server.Items.RankDatabase.GetDB( pm );
				
				if (DB == null)
				{
					return;
				}
				MovementRankExpGain(pm, DB);
			}
		}
		
		public static void EventSink_LogOut (LogoutEventArgs args)
		{
			Mobile m = args.Mobile;

			if (m is PlayerMobile)
			{
				PlayerMobile pm = m as PlayerMobile;
				DeleteRankEscort(pm);
			}
		}
		
        public static void OnItemUseSink(OnItemUseEventArgs e)
        {
            Item item = e.Item as Item;
			
			if (item.RootParent is PlayerMobile)
			{
				PlayerMobile pm = item.RootParent as PlayerMobile;
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
				
				/* Static Extensions */
				SkillRankPassiveSkillGainItem(pm, item, DB);
				RankFeatures.RankSkillStatCheck(pm, DB);
				/* Static Extensions */
				
				if (item is BaseExplosionPotion)
				{
					DB.Potionexplosionused += 1;
					DB.Potiontotalused += 1;
				}
				if (item is BaseHealPotion)
				{
					DB.Potionhealused += 1;
					DB.Potiontotalused += 1;
				}
				if (item is BasePoisonPotion)
				{
					DB.Potionpoisonedused += 1;
					DB.Potiontotalused += 1;
				}
				if (item is BaseCurePotion)
				{
					DB.Potioncureused += 1;
					DB.Potiontotalused += 1;
				}
				if (item is BaseInstrument)
				{
					DB.Timesinstrumentplayed += 1;
				}
			}
        }		
		public static void RankLevelGain (Mobile killer, Mobile killed)
		{
			RankLevelHandler.RankKillInfo(killer,killed);
		}
		
		public static void SkillRankPassiveSkillGainItem(Mobile from, Item item, RankDatabase DB) 
		{	
			//These Use Items Only
			
			if (from is PlayerMobile)
			{
				PlayerMobile pm = from as PlayerMobile;
				
				if (item is Kindling)
				{
					DB.SkillrankexpCamping += 1;
					return;
				}
				if (item is BaseInstrument)
				{
					DB.SkillrankexpMusicianship += 1;
					return;
				}
			}
		}
		
		public static void EventSink_Login( LoginEventArgs args )
        {
			Mobile m = args.Mobile;

			if (m is PlayerMobile)
			{
				PlayerMobile pm = (PlayerMobile)m;
				RankDatabase DBcheck = Server.Items.RankDatabase.GetDB( pm );
				
				if ( DBcheck == null )
				{
					RankDatabase MyDB = new RankDatabase();
					MyDB.CharacterOwner = pm;
					pm.BankBox.DropItem( MyDB );
				}
				else
				{
					RankFeatures.RankGumpCheckForUskills(pm, DBcheck);
					DeleteRankEscortOnLogin(pm);
				}
			}
		}
		public static void DeleteRankEscort (Mobile m)
		{
			if (m is PlayerMobile)
			{
				PlayerMobile pm = (PlayerMobile)m;
				foreach (Mobile mobile in World.Mobiles.Values)
				{
					if (mobile is RankQuestEscortable && mobile != null)
					{
						BaseCreature bc = mobile as BaseCreature;
						if (bc.ControlMaster == pm)
						{
							RankDatabase DB = Server.Items.RankDatabase.GetDB( pm );
							if (DB != null)
							{
								DB.RankQuestEscort = null;
								DB.Rankquestactive = false;
							}
							bc.Delete();
				//			pm.SendMessage( "Your escort has abandoned you when they noticed you dozed off! you have failed the rank escort quest!" );
							return;
						}
					}
				}
			}
		}
		public static void DeleteRankEscortOnLogin (Mobile m)
		{
			if (m is PlayerMobile)
			{
				PlayerMobile pm = (PlayerMobile)m;
				foreach (Mobile mobile in World.Mobiles.Values)
				{
					if (mobile is RankQuestEscortable && mobile != null)
					{
						BaseCreature bc = mobile as BaseCreature;
						if (bc.ControlMaster == pm)
						{
							RankDatabase DB = Server.Items.RankDatabase.GetDB( pm );
							if (DB != null)
							{
								DB.RankQuestEscort = null;
								DB.Rankquestactive = false;
							}
							bc.Delete();
							pm.SendMessage( "Your escort has abandoned you when they noticed you dozed off! you have failed the rank escort quest!" );
							return;
						}
					}
				}
			}
		}
		public static void MovementRankExpGain (Mobile m, RankDatabase DB)
		{
			if (m.Mana < m.ManaMax - 10)
			{
				if (m.Hunger < 15 ) //only gain points in meditation if hunger is satisfied
				{
					return;
				}
				else
				{
					
					if (Utility.RandomDouble() < 0.10) //Chance for Focus to Gain here in Points
					{
						DB.SkillrankexpMeditation += 1 ;
					}
					
					if (Utility.RandomDouble() < .10) //Chance for Focus to Gain here in Points
					{
						DB.SkillrankexpFocus += 1 ;
					}
				}
			}
			if (m.Stam < m.StamMax - 10)
			{
				if (Utility.RandomDouble() < .10)
				{
					if (m.Hunger < 15 ) //only gain points in Focus if hunger is satisfied
					{
						return;
					}
					else
					{
						DB.SkillrankexpFocus += 1 ;
					}
				}
			}
		}
		
		//Need to import the sync code for item use, also need to setup a readme just in case. 
		//This will allow tracking of items used, such as explosion potions, bandages, etc.
		//This will open up more unique abilities that are not directly skill based. 
    }
}
