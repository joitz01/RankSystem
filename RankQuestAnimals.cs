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
    public class RankQuestAnimals
    {
		public static void Quest_OnKillMethod (Mobile from, Mobile killed, RankDatabase DB)
		{/* Subjugation Section */
			if (killed is BaseCreature && DB.Rankquestactive == true)
			{
				BaseCreature bc = (BaseCreature)killed;
				
				Container m_pack = from.Backpack;
				
				
				if (bc.Name == DB.Rankquestcreaturenameone)
				{
					int SetKillTotal = Quest_SetKillTotal(from, DB);
					if (DB.Rankquestobjectiveone >= SetKillTotal)
					{
						return;
					}
					else
					{
						DB.Rankquestobjectiveone += 1;
						int goldgiven = bc.HitsMax * 20;
						if (m_pack != null)
							m_pack.DropItem(new Gold(goldgiven));
					}
				}
				if(bc.Name == DB.Rankquestcreaturenametwo)
				{
					int SetKillTotal = Quest_SetKillTotal(from, DB);
					if (DB.Rankquestobjectivetwo >= SetKillTotal)
					{
						return;
					}
					else
					{
						DB.Rankquestobjectivetwo += 1;
						int goldgiven = bc.HitsMax * 20;
						if (m_pack != null)
							m_pack.DropItem(new Gold(goldgiven));
					}
				}
				if (bc.Name == DB.Rankquestcreaturenamethree)
				{
					int SetKillTotal = Quest_SetKillTotal(from, DB);
					if (DB.Rankquestobjectivethree >= SetKillTotal)
					{
						return;
					}
					else
					{
						DB.Rankquestobjectivethree += 1;
						int goldgiven = bc.HitsMax * 20;
						if (m_pack != null)
							m_pack.DropItem(new Gold(goldgiven));
					}
				}
				if (bc.Name == DB.Rankquestcreaturenamefour)
				{
					int SetKillTotal = Quest_SetKillTotal(from, DB);
					if (DB.Rankquestobjectivefour >= SetKillTotal)
					{
						return;
					}
					else
					{
						DB.Rankquestobjectivefour += 1;
						int goldgiven = bc.HitsMax * 20;
						if (m_pack != null)
							m_pack.DropItem(new Gold(goldgiven));
					}
				}
				
				int SetKillTotalz = Quest_SetKillTotal(from, DB);
				if (DB.Rankquestobjectivefour >= SetKillTotalz &&
					DB.Rankquestobjectivethree >= SetKillTotalz &&
					DB.Rankquestobjectivetwo >= SetKillTotalz &&
					DB.Rankquestobjectiveone >= SetKillTotalz)
					{
						Quest_Subjugation_Complete(from, DB);
						int goldgivenfinish = SetKillTotalz * 30;
						BankBox m_bank = from.BankBox;
						if (m_bank != null)
							m_bank.DropItem(new Gold(goldgivenfinish));
					}
			}
		}
		public static int Quest_SetKillTotal (Mobile m, RankDatabase DB)
		{
			PlayerMobile pm = m as PlayerMobile;
			
			int killtotal = 0;
			int totalpmstats = pm.RawStr + pm.RawDex + pm.RawInt + pm.HitsMax + pm.ManaMax + pm.StamMax;
			int finalkillpoints = totalpmstats / 19;
			
			
			if(DB.PlayerRankLevel == "F")
			{
				int ranklevelaugment = 5;
				
				killtotal = finalkillpoints + ranklevelaugment;
			}
			else if(DB.PlayerRankLevel == "E")
			{
				int ranklevelaugment = 15;
				killtotal = finalkillpoints + ranklevelaugment;
			}
			else if(DB.PlayerRankLevel == "D")
			{
				int ranklevelaugment = 25;
				killtotal = finalkillpoints + ranklevelaugment;
			}
			else if(DB.PlayerRankLevel == "C")
			{
				int ranklevelaugment = 30;
				killtotal = finalkillpoints + ranklevelaugment;
			}
			else if(DB.PlayerRankLevel == "B")
			{
				int ranklevelaugment = 40;
				killtotal = finalkillpoints + ranklevelaugment;
			}
			else if(DB.PlayerRankLevel == "A")
			{
				int ranklevelaugment = 55;
				killtotal = finalkillpoints + ranklevelaugment;
			}
			else if(DB.PlayerRankLevel == "S")
			{
				int ranklevelaugment = 180;
				killtotal = finalkillpoints + ranklevelaugment;
			}
			return (int)killtotal;
		}
		
		public static void Quest_Subjugation_Complete (Mobile from, RankDatabase DB)
		{
			DB.Rankquestactive = false;
			DB.Rankquesttype = null;

			DB.Rankquestobjectiveone = 0;
			DB.Rankquestobjectivetwo = 0;
			DB.Rankquestobjectivethree = 0;
			DB.Rankquestobjectivefour = 0;
			
			/* Not Used 
			DB.Rankquestobjectivefive = 0;
			DB.Rankquestobjectivesix = 0;
			DB.Rankquestobjectiveseven = 0;
			DB.Rankquestobjectiveeight = 0;
			DB.Rankquestobjectivenine = 0;
			DB.Rankquestobjectiveten = 0;
			/* Not Used */
			
			DB.Rankquestcreaturenameone = null;
			DB.Rankquestcreaturenametwo = null;
			DB.Rankquestcreaturenamethree = null;
			DB.Rankquestcreaturenamefour = null;
			
			/* Not Used 
			DB.Rankquestcreaturenamefive = null;
			DB.Rankquestcreaturenamesix = null;
			DB.Rankquestcreaturenameseven = null;
			DB.Rankquestcreaturenameeight = null;
			DB.Rankquestcreaturenamenine = null;
			DB.Rankquestcreaturenameten = null;
			/* Not Used */
			
			RankFeatures.RankQuestCompletedTotal(from, DB);
			DB.SubjugationCompleted += 1;
			RankFeatures.PlayerRankUpControl(from, DB);
			
			from.SendMessage("You have completed your ranked quest!");
		}
		public static void Quest_Gathering_Complete (Mobile from, RankDatabase DB)
		{
			DB.Rankquestactive = false;
			DB.Rankquesttype = null;
			
			DB.Rankquestobjectiveone = 0;
			DB.Rankquestobjectivetwo = 0;
			DB.Rankquestobjectivethree = 0;
			DB.Rankquestobjectivefour = 0;
			
			/* Not Used 
			DB.Rankquestobjectivefive = 0;
			DB.Rankquestobjectivesix = 0;
			DB.Rankquestobjectiveseven = 0;
			DB.Rankquestobjectiveeight = 0;
			DB.Rankquestobjectivenine = 0;
			DB.Rankquestobjectiveten = 0;
			/* Not Used */
			
			DB.Rankquestcreaturenameone = null;
			DB.Rankquestcreaturenametwo = null;
			DB.Rankquestcreaturenamethree = null;
			DB.Rankquestcreaturenamefour = null;
			
			/* Not Used 
			DB.Rankquestcreaturenamefive = null;
			DB.Rankquestcreaturenamesix = null;
			DB.Rankquestcreaturenameseven = null;
			DB.Rankquestcreaturenameeight = null;
			DB.Rankquestcreaturenamenine = null;
			DB.Rankquestcreaturenameten = null;
			/* Not Used */
			
			GatheringPouchQuest gatherpouch = from.Backpack.FindItemByType(typeof(GatheringPouchQuest), false) as GatheringPouchQuest;
			if (gatherpouch != null)
			{
				gatherpouch.Delete();
			}
			DB.GatheringCompleted += 1;
			RankFeatures.RankQuestCompletedTotal(from, DB);
			RankFeatures.PlayerRankUpControl(from, DB);
			from.SendMessage("You have completed your ranked quest!");
		}
	}
}