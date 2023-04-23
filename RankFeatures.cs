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

using Server.Spells;
using Server.Spells.First;
using Server.Spells.Ninjitsu;
using Server.Spells.Bushido;
using Server.Spells.Necromancy;
using Server.Spells.Chivalry;

namespace Server
{
    public class RankFeatures
    {	
		public static void PlayerRankUpControl (Mobile m, RankDatabase DB)
		{
			if (DB == null)
			{
				return;
			}
			
			int subjugation = DB.SubjugationCompleted;
			int gathering = DB.GatheringCompleted;
			int escorts = DB.EscortCompleted;
			
			if(DB.PlayerRankLevel == "S")
			{
				if (subjugation >= 200&&
					gathering	>= 200&&
					escorts		>= 200)
					{
						subjugation = 0;
						gathering = 0;
						escorts = 0;
						DB.PlayerRankLevel = "SS Adventurer";
					} //Need to expand here, after becoming SS Adventure, easier more profitable rank quest should be available. 
			}
			if(DB.PlayerRankLevel == "A")
			{
				if (subjugation >= 160&&
					gathering	>= 160&&
					escorts		>= 160)
					{
						subjugation = 0;
						gathering = 0;
						escorts = 0;
						DB.PlayerRankLevel = "S";
					}
			}
			if(DB.PlayerRankLevel == "B")
			{
				if (subjugation >= 120&&
					gathering	>= 120&&
					escorts		>= 120)
					{
						subjugation = 0;
						gathering = 0;
						escorts = 0;
						DB.PlayerRankLevel = "A";
					}
			}
			if(DB.PlayerRankLevel == "C")
			{
				if (subjugation >= 80&&
					gathering	>= 80&&
					escorts		>= 80)
					{
						subjugation = 0;
						gathering = 0;
						escorts = 0;
						DB.PlayerRankLevel = "B";
					}
			}
			if(DB.PlayerRankLevel == "D")
			{
				if (subjugation >= 65&&
					gathering	>= 65&&
					escorts		>= 65)
					{
						subjugation = 0;
						gathering = 0;
						escorts = 0;
						DB.PlayerRankLevel = "C";
					}
			}
			if(DB.PlayerRankLevel == "E")
			{
				if (subjugation >= 55&
					gathering	>= 55&&
					escorts		>= 55)
					{
						subjugation = 0;
						gathering = 0;
						escorts = 0;
						DB.PlayerRankLevel = "D";
					}
			}
			if(DB.PlayerRankLevel == "F")
			{
				if (subjugation >= 30&&
					gathering	>= 30&&
					escorts		>= 30)
					{
						subjugation = 0;
						gathering = 0;
						escorts = 0;
						DB.PlayerRankLevel = "E";
					}
			}
		}
		
		public static void RankQuestCompletedTotal (Mobile m, RankDatabase DB)
		{
			if(DB.PlayerRankLevel == "S")
			{
				DB.sRankQuestCompleted += 1;
			}
			if(DB.PlayerRankLevel == "A")
			{
				DB.aRankQuestCompleted += 1;
			}
			if(DB.PlayerRankLevel == "B")
			{
				DB.bRankQuestCompleted += 1;
			}
			if(DB.PlayerRankLevel == "C")
			{
				DB.cRankQuestCompleted += 1;
			}
			if(DB.PlayerRankLevel == "D")
			{
				DB.dRankQuestCompleted += 1;
			}
			if(DB.PlayerRankLevel == "E")
			{
				DB.eRankQuestCompleted += 1;
			}
			if(DB.PlayerRankLevel == "F")
			{
				DB.fRankQuestCompleted += 1;
			}
		}

		public static void RankSkillStatCheck (Mobile from, RankDatabase DB)
		{
			int RankF = 5000;
			int RankE = 7000;
			int RankD = 9000;
			int RankC = 12000;
			int RankB = 14000;
			int RankA = 16000;
			int RankS = 20000;
			
			int scap = 120;
			int acap = 117;
			int bcap = 112;
			int ccap = 108;
			int dcap = 105;
			int ecap = 101;
			
			if (DB.SkillrankexpAlchemy > RankF)
			{
				Skill skill = from.Skills[SkillName.Alchemy];

				int skillvalue = DB.SkillrankexpAlchemy;
				
				SkillName skillName = skill.SkillName;
				
				if (DB.RankAlchemy == "F") {DB.RankAlchemy = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankAlchemy == "E") {DB.RankAlchemy = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankAlchemy == "D") {DB.RankAlchemy = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankAlchemy == "C") {DB.RankAlchemy = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankAlchemy == "B") {DB.RankAlchemy = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankAlchemy == "A") {DB.RankAlchemy = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpBlacksmith > RankF)
			{
				Skill skill = from.Skills[SkillName.Blacksmith];
				int skillvalue = DB.SkillrankexpBlacksmith;
				SkillName skillName = skill.SkillName;
				if (DB.RankBlacksmith == "F") {DB.RankBlacksmith = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankBlacksmith == "E") {DB.RankBlacksmith = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankBlacksmith == "D") {DB.RankBlacksmith = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankBlacksmith == "C") {DB.RankBlacksmith = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankBlacksmith == "B") {DB.RankBlacksmith = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankBlacksmith == "A") {DB.RankBlacksmith = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpCartography > RankF)
			{
				Skill skill = from.Skills[SkillName.Cartography];
				int skillvalue = DB.SkillrankexpCartography;
				SkillName skillName = skill.SkillName;
				if (DB.RankCartography == "F") {DB.RankCartography = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankCartography == "E") {DB.RankCartography = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankCartography == "D") {DB.RankCartography = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankCartography == "C") {DB.RankCartography = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankCartography == "B") {DB.RankCartography = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankCartography == "A") {DB.RankCartography = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpCarpentry > RankF)
			{
				Skill skill = from.Skills[SkillName.Carpentry];
				int skillvalue = DB.SkillrankexpCarpentry;
				SkillName skillName = skill.SkillName;
				if (DB.RankCarpentry == "F") {DB.RankCarpentry = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankCarpentry == "E") {DB.RankCarpentry = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankCarpentry == "D") {DB.RankCarpentry = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankCarpentry == "C") {DB.RankCarpentry = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankCarpentry == "B") {DB.RankCarpentry = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankCarpentry == "A") {DB.RankCarpentry = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpCooking > RankF)
			{
				Skill skill = from.Skills[SkillName.Cooking];
				int skillvalue = DB.SkillrankexpCooking;
				SkillName skillName = skill.SkillName;
				if (DB.RankCooking == "F") {DB.RankCooking = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankCooking == "E") {DB.RankCooking = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankCooking == "D") {DB.RankCooking = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankCooking == "C") {DB.RankCooking = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankCooking == "B") {DB.RankCooking = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankCooking == "A") {DB.RankCooking = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpFletching > RankF)
			{
				Skill skill = from.Skills[SkillName.Fletching];
				int skillvalue = DB.SkillrankexpFletching;
				SkillName skillName = skill.SkillName;
				if (DB.RankFletching == "F") {DB.RankFletching = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankFletching == "E") {DB.RankFletching = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankFletching == "D") {DB.RankFletching = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankFletching == "C") {DB.RankFletching = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankFletching == "B") {DB.RankFletching = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankFletching == "A") {DB.RankFletching = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpInscribe > RankF)
			{
				Skill skill = from.Skills[SkillName.Inscribe];
				int skillvalue = DB.SkillrankexpInscribe;
				SkillName skillName = skill.SkillName;
				if (DB.RankInscribe == "F") {DB.RankInscribe = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankInscribe == "E") {DB.RankInscribe = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankInscribe == "D") {DB.RankInscribe = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankInscribe == "C") {DB.RankInscribe = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankInscribe == "B") {DB.RankInscribe = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankInscribe == "A") {DB.RankInscribe = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpTailoring > RankF)
			{
				Skill skill = from.Skills[SkillName.Tailoring];
				int skillvalue = DB.SkillrankexpTailoring;
				SkillName skillName = skill.SkillName;
				if (DB.RankTailoring == "F") {DB.RankTailoring = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankTailoring == "E") {DB.RankTailoring = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankTailoring == "D") {DB.RankTailoring = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankTailoring == "C") {DB.RankTailoring = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankTailoring == "B") {DB.RankTailoring = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankTailoring == "A") {DB.RankTailoring = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpTinkering > RankF)
			{
				Skill skill = from.Skills[SkillName.Tinkering];
				int skillvalue = DB.SkillrankexpTinkering;
				SkillName skillName = skill.SkillName;
				if (DB.RankTinkering == "F") {DB.RankTinkering = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankTinkering == "E") {DB.RankTinkering = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankTinkering == "D") {DB.RankTinkering = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankTinkering == "C") {DB.RankTinkering = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankTinkering == "B") {DB.RankTinkering = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankTinkering == "A") {DB.RankTinkering = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpDiscordance > RankF)
			{
				Skill skill = from.Skills[SkillName.Discordance];
				int skillvalue = DB.SkillrankexpDiscordance;
				SkillName skillName = skill.SkillName;
				if (DB.RankDiscordance == "F") {DB.RankDiscordance = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankDiscordance == "E") {DB.RankDiscordance = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankDiscordance == "D") {DB.RankDiscordance = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankDiscordance == "C") {DB.RankDiscordance = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankDiscordance == "B") {DB.RankDiscordance = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankDiscordance == "A") {DB.RankDiscordance = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpMusicianship > RankF)
			{
				Skill skill = from.Skills[SkillName.Musicianship];
				int skillvalue = DB.SkillrankexpMusicianship;
				SkillName skillName = skill.SkillName;
				if (DB.RankMusicianship == "F") {DB.RankMusicianship = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankMusicianship == "E") {DB.RankMusicianship = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankMusicianship == "D") {DB.RankMusicianship = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankMusicianship == "C") {DB.RankMusicianship = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankMusicianship == "B") {DB.RankMusicianship = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankMusicianship == "A") {DB.RankMusicianship = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpPeacemaking > RankF)
			{
				Skill skill = from.Skills[SkillName.Peacemaking];
				int skillvalue = DB.SkillrankexpPeacemaking;
				SkillName skillName = skill.SkillName;
				if (DB.RankPeacemaking == "F") {DB.RankPeacemaking = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankPeacemaking == "E") {DB.RankPeacemaking = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankPeacemaking == "D") {DB.RankPeacemaking = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankPeacemaking == "C") {DB.RankPeacemaking = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankPeacemaking == "B") {DB.RankPeacemaking = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankPeacemaking == "A") {DB.RankPeacemaking = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpProvocation > RankF)
			{
				Skill skill = from.Skills[SkillName.Provocation];
				int skillvalue = DB.SkillrankexpProvocation;
				SkillName skillName = skill.SkillName;
				if (DB.RankProvocation == "F") {DB.RankProvocation = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankProvocation == "E") {DB.RankProvocation = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankProvocation == "D") {DB.RankProvocation = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankProvocation == "C") {DB.RankProvocation = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankProvocation == "B") {DB.RankProvocation = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankProvocation == "A") {DB.RankProvocation = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpChivalry > RankF)
			{
				Skill skill = from.Skills[SkillName.Chivalry];
				int skillvalue = DB.SkillrankexpChivalry;
				SkillName skillName = skill.SkillName;
				if (DB.RankChivalry == "F") {DB.RankChivalry = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankChivalry == "E") {DB.RankChivalry = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankChivalry == "D") {DB.RankChivalry = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankChivalry == "C") {DB.RankChivalry = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankChivalry == "B") {DB.RankChivalry = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankChivalry == "A") {DB.RankChivalry = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpEvalInt > RankF)
			{
				Skill skill = from.Skills[SkillName.EvalInt];
				int skillvalue = DB.SkillrankexpEvalInt;
				SkillName skillName = skill.SkillName;
				if (DB.RankEvalInt == "F") {DB.RankEvalInt = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankEvalInt == "E") {DB.RankEvalInt = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankEvalInt == "D") {DB.RankEvalInt = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankEvalInt == "C") {DB.RankEvalInt = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankEvalInt == "B") {DB.RankEvalInt = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankEvalInt == "A") {DB.RankEvalInt = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpMagery > RankF)
			{
				Skill skill = from.Skills[SkillName.Magery];
				int skillvalue = DB.SkillrankexpMagery;
				SkillName skillName = skill.SkillName;
				if (DB.RankMagery == "F") {DB.RankMagery = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankMagery == "E") {DB.RankMagery = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankMagery == "D") {DB.RankMagery = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankMagery == "C") {DB.RankMagery = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankMagery == "B") {DB.RankMagery = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankMagery == "A") {DB.RankMagery = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpMagicResist > RankF)
			{
				Skill skill = from.Skills[SkillName.MagicResist];
				int skillvalue = DB.SkillrankexpMagicResist;
				SkillName skillName = skill.SkillName;
				if (DB.RankMagicResist == "F") {DB.RankMagicResist = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankMagicResist == "E") {DB.RankMagicResist = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankMagicResist == "D") {DB.RankMagicResist = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankMagicResist == "C") {DB.RankMagicResist = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankMagicResist == "B") {DB.RankMagicResist = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankMagicResist == "A") {DB.RankMagicResist = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpMeditation > RankF)
			{
				Skill skill = from.Skills[SkillName.Meditation];
				int skillvalue = DB.SkillrankexpMeditation;
				SkillName skillName = skill.SkillName;
				if (DB.RankMeditation == "F") {DB.RankMeditation = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankMeditation == "E") {DB.RankMeditation = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankMeditation == "D") {DB.RankMeditation = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankMeditation == "C") {DB.RankMeditation = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankMeditation == "B") {DB.RankMeditation = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankMeditation == "A") {DB.RankMeditation = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpNecromancy > RankF)
			{
				Skill skill = from.Skills[SkillName.Necromancy];
				int skillvalue = DB.SkillrankexpNecromancy;
				SkillName skillName = skill.SkillName;
				if (DB.RankNecromancy == "F") {DB.RankNecromancy = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankNecromancy == "E") {DB.RankNecromancy = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankNecromancy == "D") {DB.RankNecromancy = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankNecromancy == "C") {DB.RankNecromancy = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankNecromancy == "B") {DB.RankNecromancy = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankNecromancy == "A") {DB.RankNecromancy = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpSpiritSpeak > RankF)
			{
				Skill skill = from.Skills[SkillName.SpiritSpeak];
				int skillvalue = DB.SkillrankexpSpiritSpeak;
				SkillName skillName = skill.SkillName;
				if (DB.RankSpiritSpeak == "F") {DB.RankSpiritSpeak = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankSpiritSpeak == "E") {DB.RankSpiritSpeak = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankSpiritSpeak == "D") {DB.RankSpiritSpeak = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankSpiritSpeak == "C") {DB.RankSpiritSpeak = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankSpiritSpeak == "B") {DB.RankSpiritSpeak = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankSpiritSpeak == "A") {DB.RankSpiritSpeak = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpNinjitsu > RankF)
			{
				Skill skill = from.Skills[SkillName.Ninjitsu];
				int skillvalue = DB.SkillrankexpNinjitsu;
				SkillName skillName = skill.SkillName;
				if (DB.RankNinjitsu == "F") {DB.RankNinjitsu = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankNinjitsu == "E") {DB.RankNinjitsu = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankNinjitsu == "D") {DB.RankNinjitsu = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankNinjitsu == "C") {DB.RankNinjitsu = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankNinjitsu == "B") {DB.RankNinjitsu = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankNinjitsu == "A") {DB.RankNinjitsu = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpBushido > RankF)
			{
				Skill skill = from.Skills[SkillName.Bushido];
				int skillvalue = DB.SkillrankexpBushido;
				SkillName skillName = skill.SkillName;
				if (DB.RankBushido == "F") {DB.RankBushido = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankBushido == "E") {DB.RankBushido = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankBushido == "D") {DB.RankBushido = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankBushido == "C") {DB.RankBushido = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankBushido == "B") {DB.RankBushido = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankBushido == "A") {DB.RankBushido = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpSpellweaving > RankF)
			{
				Skill skill = from.Skills[SkillName.Spellweaving];
				int skillvalue = DB.SkillrankexpSpellweaving;
				SkillName skillName = skill.SkillName;
				if (DB.RankSpellweaving == "F") {DB.RankSpellweaving = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankSpellweaving == "E") {DB.RankSpellweaving = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankSpellweaving == "D") {DB.RankSpellweaving = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankSpellweaving == "C") {DB.RankSpellweaving = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankSpellweaving == "B") {DB.RankSpellweaving = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankSpellweaving == "A") {DB.RankSpellweaving = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpCamping > RankF)
			{
				Skill skill = from.Skills[SkillName.Camping];
				int skillvalue = DB.SkillrankexpCamping;
				SkillName skillName = skill.SkillName;
				if (DB.RankCamping == "F") {DB.RankCamping = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankCamping == "E") {DB.RankCamping = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankCamping == "D") {DB.RankCamping = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankCamping == "C") {DB.RankCamping = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankCamping == "B") {DB.RankCamping = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankCamping == "A") {DB.RankCamping = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpFishing > RankF)
			{
				Skill skill = from.Skills[SkillName.Fishing];
				int skillvalue = DB.SkillrankexpFishing;
				SkillName skillName = skill.SkillName;
				if (DB.RankFishing == "F") {DB.RankFishing = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankFishing == "E") {DB.RankFishing = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankFishing == "D") {DB.RankFishing = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankFishing == "C") {DB.RankFishing = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankFishing == "B") {DB.RankFishing = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankFishing == "A") {DB.RankFishing = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpFocus > RankF)
			{
				Skill skill = from.Skills[SkillName.Focus];
				int skillvalue = DB.SkillrankexpFocus;
				SkillName skillName = skill.SkillName;
				if (DB.RankFocus == "F") {DB.RankFocus = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankFocus == "E") {DB.RankFocus = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankFocus == "D") {DB.RankFocus = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankFocus == "C") {DB.RankFocus = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankFocus == "B") {DB.RankFocus = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankFocus == "A") {DB.RankFocus = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpHealing > RankF)
			{
				Skill skill = from.Skills[SkillName.Healing];
				int skillvalue = DB.SkillrankexpHealing;
				SkillName skillName = skill.SkillName;
				if (DB.RankHealing == "F") {DB.RankHealing = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankHealing == "E") {DB.RankHealing = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankHealing == "D") {DB.RankHealing = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankHealing == "C") {DB.RankHealing = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankHealing == "B") {DB.RankHealing = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankHealing == "A") {DB.RankHealing = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpHerding > RankF)
			{
				Skill skill = from.Skills[SkillName.Herding];
				int skillvalue = DB.SkillrankexpHerding;
				SkillName skillName = skill.SkillName;
				if (DB.RankHerding == "F") {DB.RankHerding = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankHerding == "E") {DB.RankHerding = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankHerding == "D") {DB.RankHerding = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankHerding == "C") {DB.RankHerding = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankHerding == "B") {DB.RankHerding = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankHerding == "A") {DB.RankHerding = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpLockpicking > RankF)
			{
				Skill skill = from.Skills[SkillName.Lockpicking];
				int skillvalue = DB.SkillrankexpLockpicking;
				SkillName skillName = skill.SkillName;
				if (DB.RankLockpicking == "F") {DB.RankLockpicking = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankLockpicking == "E") {DB.RankLockpicking = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankLockpicking == "D") {DB.RankLockpicking = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankLockpicking == "C") {DB.RankLockpicking = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankLockpicking == "B") {DB.RankLockpicking = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankLockpicking == "A") {DB.RankLockpicking = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpLumberjacking > RankF)
			{
				Skill skill = from.Skills[SkillName.Lumberjacking];
				int skillvalue = DB.SkillrankexpLumberjacking;
				SkillName skillName = skill.SkillName;
				if (DB.RankLumberjacking == "F") {DB.RankLumberjacking = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankLumberjacking == "E") {DB.RankLumberjacking = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankLumberjacking == "D") {DB.RankLumberjacking = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankLumberjacking == "C") {DB.RankLumberjacking = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankLumberjacking == "B") {DB.RankLumberjacking = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankLumberjacking == "A") {DB.RankLumberjacking = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpMining > RankF)
			{
				Skill skill = from.Skills[SkillName.Mining];
				int skillvalue = DB.SkillrankexpMining;
				SkillName skillName = skill.SkillName;
				if (DB.RankMining == "F") {DB.RankMining = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankMining == "E") {DB.RankMining = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankMining == "D") {DB.RankMining = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankMining == "C") {DB.RankMining = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankMining == "B") {DB.RankMining = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankMining == "A") {DB.RankMining = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpSnooping > RankF)
			{
				Skill skill = from.Skills[SkillName.Snooping];
				int skillvalue = DB.SkillrankexpSnooping;
				SkillName skillName = skill.SkillName;
				if (DB.RankSnooping == "F") {DB.RankSnooping = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankSnooping == "E") {DB.RankSnooping = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankSnooping == "D") {DB.RankSnooping = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankSnooping == "C") {DB.RankSnooping = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankSnooping == "B") {DB.RankSnooping = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankSnooping == "A") {DB.RankSnooping = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpVeterinary > RankF)
			{
				Skill skill = from.Skills[SkillName.Veterinary];
				int skillvalue = DB.SkillrankexpVeterinary;
				SkillName skillName = skill.SkillName;
				if (DB.RankVeterinary == "F") {DB.RankVeterinary = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankVeterinary == "E") {DB.RankVeterinary = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankVeterinary == "D") {DB.RankVeterinary = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankVeterinary == "C") {DB.RankVeterinary = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankVeterinary == "B") {DB.RankVeterinary = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankVeterinary == "A") {DB.RankVeterinary = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpArchery > RankF)
			{
				Skill skill = from.Skills[SkillName.Archery];
				int skillvalue = DB.SkillrankexpArchery;
				SkillName skillName = skill.SkillName;
				if (DB.RankArchery == "F") {DB.RankArchery = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankArchery == "E") {DB.RankArchery = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankArchery == "D") {DB.RankArchery = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankArchery == "C") {DB.RankArchery = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankArchery == "B") {DB.RankArchery = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankArchery == "A") {DB.RankArchery = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpFencing > RankF)
			{
				Skill skill = from.Skills[SkillName.Fencing];
				int skillvalue = DB.SkillrankexpFencing;
				SkillName skillName = skill.SkillName;
				if (DB.RankFencing == "F") {DB.RankFencing = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankFencing == "E") {DB.RankFencing = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankFencing == "D") {DB.RankFencing = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankFencing == "C") {DB.RankFencing = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankFencing == "B") {DB.RankFencing = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankFencing == "A") {DB.RankFencing = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpMacing > RankF)
			{
				Skill skill = from.Skills[SkillName.Macing];
				int skillvalue = DB.SkillrankexpMacing;
				SkillName skillName = skill.SkillName;
				if (DB.RankMacing == "F") {DB.RankMacing = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankMacing == "E") {DB.RankMacing = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankMacing == "D") {DB.RankMacing = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankMacing == "C") {DB.RankMacing = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankMacing == "B") {DB.RankMacing = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankMacing == "A") {DB.RankMacing = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpParry > RankF)
			{
				Skill skill = from.Skills[SkillName.Parry];
				int skillvalue = DB.SkillrankexpParry;
				SkillName skillName = skill.SkillName;
				if (DB.RankParry == "F") {DB.RankParry = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankParry == "E") {DB.RankParry = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankParry == "D") {DB.RankParry = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankParry == "C") {DB.RankParry = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankParry == "B") {DB.RankParry = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankParry == "A") {DB.RankParry = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpSwords > RankF)
			{
				Skill skill = from.Skills[SkillName.Swords];
				int skillvalue = DB.SkillrankexpSwords;
				SkillName skillName = skill.SkillName;
				if (DB.RankSwords == "F") {DB.RankSwords = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankSwords == "E") {DB.RankSwords = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankSwords == "D") {DB.RankSwords = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankSwords == "C") {DB.RankSwords = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankSwords == "B") {DB.RankSwords = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankSwords == "A") {DB.RankSwords = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpTactics > RankF)
			{
				Skill skill = from.Skills[SkillName.Tactics];
				int skillvalue = DB.SkillrankexpTactics;
				SkillName skillName = skill.SkillName;
				if (DB.RankTactics == "F") {DB.RankTactics = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankTactics == "E") {DB.RankTactics = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankTactics == "D") {DB.RankTactics = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankTactics == "C") {DB.RankTactics = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankTactics == "B") {DB.RankTactics = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankTactics == "A") {DB.RankTactics = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpWrestling > RankF)
			{
				Skill skill = from.Skills[SkillName.Wrestling];
				int skillvalue = DB.SkillrankexpWrestling;
				SkillName skillName = skill.SkillName;
				if (DB.RankWrestling == "F") {DB.RankWrestling = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankWrestling == "E") {DB.RankWrestling = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankWrestling == "D") {DB.RankWrestling = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankWrestling == "C") {DB.RankWrestling = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankWrestling == "B") {DB.RankWrestling = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankWrestling == "A") {DB.RankWrestling = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpAnimalTaming > RankF)
			{
				Skill skill = from.Skills[SkillName.AnimalTaming];
				int skillvalue = DB.SkillrankexpAnimalTaming;
				SkillName skillName = skill.SkillName;
				if (DB.RankAnimalTaming == "F") {DB.RankAnimalTaming = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankAnimalTaming == "E") {DB.RankAnimalTaming = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankAnimalTaming == "D") {DB.RankAnimalTaming = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankAnimalTaming == "C") {DB.RankAnimalTaming = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankAnimalTaming == "B") {DB.RankAnimalTaming = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankAnimalTaming == "A") {DB.RankAnimalTaming = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpBegging > RankF)
			{
				Skill skill = from.Skills[SkillName.Begging];
				int skillvalue = DB.SkillrankexpBegging;
				SkillName skillName = skill.SkillName;
				if (DB.RankBegging == "F") {DB.RankBegging = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankBegging == "E") {DB.RankBegging = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankBegging == "D") {DB.RankBegging = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankBegging == "C") {DB.RankBegging = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankBegging == "B") {DB.RankBegging = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankBegging == "A") {DB.RankBegging = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpDetectHidden > RankF)
			{
				Skill skill = from.Skills[SkillName.DetectHidden];
				int skillvalue = DB.SkillrankexpDetectHidden;
				SkillName skillName = skill.SkillName;
				if (DB.RankDetectHidden == "F") {DB.RankDetectHidden = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankDetectHidden == "E") {DB.RankDetectHidden = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankDetectHidden == "D") {DB.RankDetectHidden = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankDetectHidden == "C") {DB.RankDetectHidden = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankDetectHidden == "B") {DB.RankDetectHidden = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankDetectHidden == "A") {DB.RankDetectHidden = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpHiding > RankF)
			{
				Skill skill = from.Skills[SkillName.Hiding];
				int skillvalue = DB.SkillrankexpHiding;
				SkillName skillName = skill.SkillName;
				if (DB.RankHiding == "F") {DB.RankHiding = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankHiding == "E") {DB.RankHiding = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankHiding == "D") {DB.RankHiding = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankHiding == "C") {DB.RankHiding = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankHiding == "B") {DB.RankHiding = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankHiding == "A") {DB.RankHiding = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpRemoveTrap > RankF)
			{
				Skill skill = from.Skills[SkillName.RemoveTrap];
				int skillvalue = DB.SkillrankexpRemoveTrap;
				SkillName skillName = skill.SkillName;
				if (DB.RankRemoveTrap == "F") {DB.RankRemoveTrap = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankRemoveTrap == "E") {DB.RankRemoveTrap = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankRemoveTrap == "D") {DB.RankRemoveTrap = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankRemoveTrap == "C") {DB.RankRemoveTrap = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankRemoveTrap == "B") {DB.RankRemoveTrap = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankRemoveTrap == "A") {DB.RankRemoveTrap = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpPoisoning > RankF)
			{
				Skill skill = from.Skills[SkillName.Poisoning];
				int skillvalue = DB.SkillrankexpPoisoning;
				SkillName skillName = skill.SkillName;
				if (DB.RankPoisoning == "F") {DB.RankPoisoning = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankPoisoning == "E") {DB.RankPoisoning = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankPoisoning == "D") {DB.RankPoisoning = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankPoisoning == "C") {DB.RankPoisoning = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankPoisoning == "B") {DB.RankPoisoning = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankPoisoning == "A") {DB.RankPoisoning = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpStealing > RankF)
			{
				Skill skill = from.Skills[SkillName.Stealing];
				int skillvalue = DB.SkillrankexpStealing;
				SkillName skillName = skill.SkillName;
				if (DB.RankStealing == "F") {DB.RankStealing = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankStealing == "E") {DB.RankStealing = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankStealing == "D") {DB.RankStealing = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankStealing == "C") {DB.RankStealing = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankStealing == "B") {DB.RankStealing = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankStealing == "A") {DB.RankStealing = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpStealth > RankF)
			{
				Skill skill = from.Skills[SkillName.Stealth];
				int skillvalue = DB.SkillrankexpStealth;
				SkillName skillName = skill.SkillName;
				if (DB.RankStealth == "F") {DB.RankStealth = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankStealth == "E") {DB.RankStealth = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankStealth == "D") {DB.RankStealth = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankStealth == "C") {DB.RankStealth = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankStealth == "B") {DB.RankStealth = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankStealth == "A") {DB.RankStealth = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpTracking > RankF)
			{
				Skill skill = from.Skills[SkillName.Tracking];
				int skillvalue = DB.SkillrankexpTracking;
				SkillName skillName = skill.SkillName;
				if (DB.RankTracking == "F") {DB.RankTracking = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankTracking == "E") {DB.RankTracking = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankTracking == "D") {DB.RankTracking = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankTracking == "C") {DB.RankTracking = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankTracking == "B") {DB.RankTracking = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankTracking == "A") {DB.RankTracking = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpAnatomy > RankF)
			{
				Skill skill = from.Skills[SkillName.Anatomy];
				int skillvalue = DB.SkillrankexpAnatomy;
				SkillName skillName = skill.SkillName;
				if (DB.RankAnatomy == "F") {DB.RankAnatomy = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankAnatomy == "E") {DB.RankAnatomy = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankAnatomy == "D") {DB.RankAnatomy = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankAnatomy == "C") {DB.RankAnatomy = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankAnatomy == "B") {DB.RankAnatomy = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankAnatomy == "A") {DB.RankAnatomy = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpAnimalLore > RankF)
			{
				Skill skill = from.Skills[SkillName.AnimalLore];
				int skillvalue = DB.SkillrankexpAnimalLore;
				SkillName skillName = skill.SkillName;
				if (DB.RankAnimalLore == "F") {DB.RankAnimalLore = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankAnimalLore == "E") {DB.RankAnimalLore = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankAnimalLore == "D") {DB.RankAnimalLore = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankAnimalLore == "C") {DB.RankAnimalLore = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankAnimalLore == "B") {DB.RankAnimalLore = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankAnimalLore == "A") {DB.RankAnimalLore = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpArmsLore > RankF)
			{
				Skill skill = from.Skills[SkillName.ArmsLore];
				int skillvalue = DB.SkillrankexpArmsLore;
				SkillName skillName = skill.SkillName;
				if (DB.RankArmsLore == "F") {DB.RankArmsLore = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankArmsLore == "E") {DB.RankArmsLore = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankArmsLore == "D") {DB.RankArmsLore = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankArmsLore == "C") {DB.RankArmsLore = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankArmsLore == "B") {DB.RankArmsLore = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankArmsLore == "A") {DB.RankArmsLore = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpForensics > RankF)
			{
				Skill skill = from.Skills[SkillName.Forensics];
				int skillvalue = DB.SkillrankexpForensics;
				SkillName skillName = skill.SkillName;
				if (DB.RankForensics == "F") {DB.RankForensics = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankForensics == "E") {DB.RankForensics = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankForensics == "D") {DB.RankForensics = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankForensics == "C") {DB.RankForensics = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankForensics == "B") {DB.RankForensics = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankForensics == "A") {DB.RankForensics = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpItemID > RankF)
			{
				Skill skill = from.Skills[SkillName.ItemID];
				int skillvalue = DB.SkillrankexpItemID;
				SkillName skillName = skill.SkillName;
				if (DB.RankItemID == "F") {DB.RankItemID = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankItemID == "E") {DB.RankItemID = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankItemID == "D") {DB.RankItemID = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankItemID == "C") {DB.RankItemID = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankItemID == "B") {DB.RankItemID = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankItemID == "A") {DB.RankItemID = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpTasteID > RankF)
			{
				Skill skill = from.Skills[SkillName.TasteID];
				int skillvalue = DB.SkillrankexpTasteID;
				SkillName skillName = skill.SkillName;
				if (DB.RankTasteID == "F") {DB.RankTasteID = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankTasteID == "E") {DB.RankTasteID = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankTasteID == "D") {DB.RankTasteID = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankTasteID == "C") {DB.RankTasteID = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankTasteID == "B") {DB.RankTasteID = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankTasteID == "A") {DB.RankTasteID = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpThrowing > RankF)
			{
				Skill skill = from.Skills[SkillName.Throwing];
				int skillvalue = DB.SkillrankexpThrowing;
				SkillName skillName = skill.SkillName;
				if (DB.RankThrowing == "F") {DB.RankThrowing = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankThrowing == "E") {DB.RankThrowing = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankThrowing == "D") {DB.RankThrowing = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankThrowing == "C") {DB.RankThrowing = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankThrowing == "B") {DB.RankThrowing = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankThrowing == "A") {DB.RankThrowing = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpImbueing > RankF)
			{
				Skill skill = from.Skills[SkillName.Imbuing];
				int skillvalue = DB.SkillrankexpImbueing;
				SkillName skillName = skill.SkillName;
				if (DB.RankImbueing == "F") {DB.RankImbueing = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankImbueing == "E") {DB.RankImbueing = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankImbueing == "D") {DB.RankImbueing = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankImbueing == "C") {DB.RankImbueing = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankImbueing == "B") {DB.RankImbueing = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankImbueing == "A") {DB.RankImbueing = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpMysticism > RankF)
			{
				Skill skill = from.Skills[SkillName.Mysticism];
				int skillvalue = DB.SkillrankexpMysticism;
				SkillName skillName = skill.SkillName;
				if (DB.RankMysticism == "F") {DB.RankMysticism = "E"; skill.Cap = ecap; from.SendMessage("You have ranked up {0}", skillName);}
				if (skillvalue > RankE)
				{
					if (DB.RankMysticism == "E") {DB.RankMysticism = "D"; skill.Cap = dcap; from.SendMessage("You have ranked up {0}", skillName);}
					if (skillvalue > RankD)
					{
						if (DB.RankMysticism == "D") {DB.RankMysticism = "C"; skill.Cap = ccap; from.SendMessage("You have ranked up {0}", skillName);}
						if (skillvalue > RankC)
						{
							if (DB.RankMysticism == "C") {DB.RankMysticism = "B"; skill.Cap = bcap; from.SendMessage("You have ranked up {0}", skillName);}
							if (skillvalue > RankB)
							{
								if (DB.RankMysticism == "B") {DB.RankMysticism = "A"; skill.Cap = acap; from.SendMessage("You have ranked up {0}", skillName);}
								if (skillvalue > RankA)
								{
									if (DB.RankMysticism == "A") {DB.RankMysticism = "S"; skill.Cap = scap; from.SendMessage("You have ranked up {0}", skillName);}
									if (skillvalue > RankS)
									{
									}
								}
							}
						}
					}
				}
			}
		}
		
		public static void RankGumpCheckForUskills (Mobile from, RankDatabase DB)
		{
			/* Smithes Eyes */
			if (DB.RankBlacksmith == "S" && DB.RankArmsLore == "S")
			{
				if (DB.USkill_smitheseyes == false)
				{
					DB.USkill_smitheseyes = true;
					from.SendMessage( "You have activated the Unique Skill Smithes Eyes!" );
				}
			}
		}
		public static void DisplayPropsOverride (Mobile from, Item item)
		{
			RankDatabase DB = Server.Items.RankDatabase.GetDB( from );
			
			if (from.AccessLevel >= AccessLevel.GameMaster)
			{
				from.Send(item.PropertyList);
			}
			else
			{
				if (DB.USkill_smitheseyes == true)
				{
					from.Send(item.PropertyList);
				}
				else
				{
					if ( item.RootParent == null || item.RootParent == from || item.Parent is Container || DB != null & DB.USkill_smitheseyes == true)
					{
						from.Send(item.PropertyList);
					}
				}
			}
		}
		public static void DoorOpenPoints (Mobile from)
		{
			RankDatabase DB = Server.Items.RankDatabase.GetDB( from );
			if (DB != null && from is PlayerMobile)
			{
				DB.DoorsOpened += 1;
			}
		}
		public static void OnHitRankOverRide (Mobile attacker, Mobile defender, Item item)
		{
			//SanityCheck
			PlayerMobile pm = (PlayerMobile)attacker;
			RankDatabase db = Server.Items.RankDatabase.GetDB( pm );
			if (db == null)
				return;
			
			BaseWeapon weapon = attacker.Weapon as BaseWeapon;
			BaseArmor armor = attacker.ShieldArmor as BaseArmor;

			if (armor != null)
			{
				db.SkillrankexpParry += 1;
			}

			if(weapon.Skill == SkillName.Swords)
			{
				int randomnumber = Utility.Random(1, 17);
				db.SkillrankexpSwords += randomnumber;
				OnHitTacticsExtension(pm, defender, db);
				OnHitAnatomyExtension(pm, defender, db);
				OnHitFocusExtension(pm, defender, db);

			}
			if(weapon.Skill == SkillName.Fencing)
			{
				int randomnumber = Utility.Random(1, 17);
				db.SkillrankexpFencing += randomnumber;
				OnHitTacticsExtension(pm, defender, db);
				OnHitAnatomyExtension(pm, defender, db);
				OnHitFocusExtension(pm, defender, db);

			}
			if(weapon.Skill == SkillName.Macing)
			{
				int randomnumber = Utility.Random(1, 17);
				db.SkillrankexpMacing += randomnumber;
				OnHitTacticsExtension(pm, defender, db);
				OnHitAnatomyExtension(pm, defender, db);
				OnHitFocusExtension(pm, defender, db);

			}
			if(weapon.Skill == SkillName.Wrestling)
			{
				int randomnumber = Utility.Random(1, 17);
				db.SkillrankexpWrestling += randomnumber;
				OnHitTacticsExtension(pm, defender, db);
				OnHitAnatomyExtension(pm, defender, db);
				OnHitFocusExtension(pm, defender, db);

			}
			if(weapon.Skill == SkillName.Archery)
			{
				int randomnumber = Utility.Random(1, 17);
				db.SkillrankexpArchery += randomnumber;
				OnHitTacticsExtension(pm, defender, db);
				OnHitAnatomyExtension(pm, defender, db);
				OnHitFocusExtension(pm, defender, db);

			}
		}
		public static void OnHitFocusExtension (Mobile atacker, Mobile defender,RankDatabase db )
		{
			int randomnumber = Utility.Random(1, 17);
			var skillname = SkillName.Focus;
			db.SkillrankexpFocus += randomnumber;

		}
		public static void OnHitTacticsExtension (Mobile atacker, Mobile defender,RankDatabase db )
		{
			int randomnumber = Utility.Random(1, 17);
			var skillname = SkillName.Tactics;
			db.SkillrankexpTactics += randomnumber;

		}
		public static void OnHitAnatomyExtension (Mobile atacker, Mobile defender,RankDatabase db )
		{
			int randomnumber = Utility.Random(1, 17);
			var skillname = SkillName.Anatomy;
			db.SkillrankexpAnatomy += randomnumber;
		}
		public static void KillTypeCount(Mobile killer, RankDatabase db)
        {
			BaseWeapon weapon = killer.Weapon as BaseWeapon;

			if(weapon.Skill == SkillName.Swords)
			{
				db.TotalKillsWithSwords += 1;
			}
			if(weapon.Skill == SkillName.Fencing)
			{
				db.TotalKillsWithFencing += 1;
			}
			if(weapon.Skill == SkillName.Macing)
			{
				db.TotalKillswithMacing += 1;
			}
			if(weapon.Skill == SkillName.Wrestling)
			{
				db.TotalKillsWithHands += 1;
			}
			if(weapon.Skill == SkillName.Archery)
			{
				db.TotalKillsWithArchery += 1;
			}
		}
		
		public static void SkillRankGainer(Mobile from, Skill skill, SkillName skillName) 
		{
			RankDatabase DB = Server.Items.RankDatabase.GetDB( from );
			
			
			if (DB == null)
				return;
			
			if (from is PlayerMobile)
			{
				PlayerMobile pm = from as PlayerMobile;

				if (skillName == SkillName.Magery)
				{
					int randomnumber = Utility.Random(1, 17);
					DB.SkillrankexpMagery += 1 + randomnumber; 
					return;
				}
				else if (skillName == SkillName.Chivalry)
				{
					int randomnumber = Utility.Random(1, 17);
					DB.SkillrankexpChivalry += 1 + randomnumber; 
					return;
				}
				else if (skillName == SkillName.Necromancy)
				{
					int randomnumber = Utility.Random(1, 17);
					DB.SkillrankexpNecromancy += 1 + randomnumber;  
					return;
				}
				else if (skillName == SkillName.Ninjitsu)
				{
					int randomnumber = Utility.Random(1, 17);
					DB.SkillrankexpNinjitsu += 1 + randomnumber; 
					return;
				}
				else if (skillName == SkillName.Bushido)
				{
					int randomnumber = Utility.Random(1, 17);
					DB.SkillrankexpBushido += 1 + randomnumber;
					return;
				}
				else if (skill == from.Skills.Fishing)
				{
					int randomnumber = Utility.Random(1, 17);
					DB.SkillrankexpFishing += 1 + randomnumber;
					return;
				}
				else if (skill == from.Skills.Hiding)
				{
					int randomnumber = Utility.Random(1, 17);
					DB.SkillrankexpHiding += 1 + randomnumber;
					return;
				}
				else if (skill == from.Skills.SpiritSpeak)
				{
					int randomnumber = Utility.Random(1, 17);
					DB.SkillrankexpSpiritSpeak += 1 + randomnumber;
					return;
				}
				else if (skill == from.Skills.Meditation)
				{
					int randomnumber = Utility.Random(1, 2);
					DB.SkillrankexpMeditation += 1 + randomnumber;
					return;
				}
				else if (skill == from.Skills.Healing)
				{
					int randomnumber = Utility.Random(1, 17);
					DB.SkillrankexpHealing += 1 + randomnumber;
					return;
				}
				else if (skill == from.Skills.Stealth)
				{
					int randomnumber = Utility.Random(1, 17);
					DB.SkillrankexpStealth += 1 + randomnumber;
					return;
				}
				else if (skill == from.Skills.Veterinary)
				{
					int randomnumber = Utility.Random(1, 17);
					DB.SkillrankexpVeterinary += 1 + randomnumber;
					return;
				}
				else if (skill == from.Skills.Tracking)
				{
					int randomnumber = Utility.Random(1, 17);
					DB.SkillrankexpTracking += 1 + randomnumber;
					return;
				}
				else if (skill == from.Skills.Lumberjacking)
				{
					int randomnumber = Utility.Random(1, 17);
					DB.SkillrankexpLumberjacking += 1 + randomnumber;
					return;
				}
				else if (skill == from.Skills.Mining)
				{
					int randomnumber = Utility.Random(1, 17);
					DB.SkillrankexpMining += 1 + randomnumber;
					return;
				}
			}
		}
		public static void SkillRankGainerTarget(Mobile from, Skill skill, SkillName skillName) 
		{
			RankDatabase DB = Server.Items.RankDatabase.GetDB( from );
			
			
			if (DB == null)
				return;
			
			else if (skill == from.Skills.Provocation)
			{
				int randomnumber = Utility.Random(1, 17);
				DB.SkillrankexpProvocation += 1 + randomnumber;
				return;
			}
			else if (skill == from.Skills.Peacemaking)
			{
				int randomnumber = Utility.Random(1, 17);
				DB.SkillrankexpPeacemaking += 1 + randomnumber;
				return;
			}
			else if (skill == from.Skills.Discordance)
			{
				int randomnumber = Utility.Random(1, 17);
				DB.SkillrankexpDiscordance += 1 + randomnumber;
				return;
			}
			else if (skill == from.Skills.EvalInt)
			{
				int randomnumber = Utility.Random(1, 17);
				DB.SkillrankexpEvalInt += 1 + randomnumber;
				return;
			}
			else if (skill == from.Skills.AnimalTaming)
			{
				int randomnumber = Utility.Random(1, 17);
				DB.SkillrankexpAnimalTaming += 1 + randomnumber;
				return;
			}
			else if (skill == from.Skills.Anatomy)
			{
				int randomnumber = Utility.Random(1, 17);
				DB.SkillrankexpAnatomy += 1 + randomnumber;
				return;
			}
			else if (skill == from.Skills.AnimalLore)
			{
				int randomnumber = Utility.Random(1, 17);
				DB.SkillrankexpAnimalLore += 1 + randomnumber;
				return;
			}
			else if (skill == from.Skills.ArmsLore)
			{
				int randomnumber = Utility.Random(1, 17);
				DB.SkillrankexpArmsLore += 1 + randomnumber;
				return;
			}
			else if (skill == from.Skills.ItemID)
			{
				int randomnumber = Utility.Random(1, 17);
				DB.SkillrankexpItemID += 1 + randomnumber;
				return;
			}
			else if (skill == from.Skills.TasteID)
			{
				int randomnumber = Utility.Random(1, 17);
				DB.SkillrankexpTasteID += 1 + randomnumber;
				return;
			}
			else if (skill == from.Skills.DetectHidden)
			{
				int randomnumber = Utility.Random(1, 17);
				DB.SkillrankexpDetectHidden += 1 + randomnumber;
				return;
			}
			else if (skill == from.Skills.RemoveTrap)
			{
				int randomnumber = Utility.Random(1, 17);
				DB.SkillrankexpRemoveTrap += 1 + randomnumber;
				return;
			}
			else if (skill == from.Skills.Poisoning)
			{
				int randomnumber = Utility.Random(1, 17);
				DB.SkillrankexpPoisoning += 1 + randomnumber;
				return;
			}
			else if (skill == from.Skills.Forensics)
			{
				int randomnumber = Utility.Random(1, 17);
				DB.SkillrankexpForensics += 1 + randomnumber;
				return;
			}
			else if (skill == from.Skills.Begging)
			{
				int randomnumber = Utility.Random(1, 17);
				DB.SkillrankexpBegging += 1 + randomnumber;
				return;
			}
			else if (skill == from.Skills.Herding)
			{
				int randomnumber = Utility.Random(1, 17);
				DB.SkillrankexpHerding += 1 + randomnumber;
				return;
			}
			else if (skill == from.Skills.Lockpicking)
			{
				int randomnumber = Utility.Random(1, 17);
				DB.SkillrankexpLockpicking += 1 + randomnumber;
				return;
			}
			else if (skill == from.Skills.Snooping)
			{
				int randomnumber = Utility.Random(1, 17);
				DB.SkillrankexpSnooping += 1 + randomnumber;
				return;
			}
		}
		
		public static void CraftSystemExp (Mobile m , Item item, CraftSystem craftSystem)
		{
			PlayerMobile pm = m as PlayerMobile;
			RankDatabase DB = Server.Items.RankDatabase.GetDB( pm );
			
			if (DB == null)
				return;
			
			if (craftSystem is DefBlacksmithy)
			{
				int randomnumber = Utility.Random(1, 17);
				DB.SkillrankexpBlacksmith += 1 + randomnumber;
			}
			if (craftSystem is DefMasonry)
			{
				int randomnumber = Utility.Random(1, 17);
				DB.SkillrankexpBlacksmith += 1 + randomnumber;
			}
			if (craftSystem is DefTailoring)
			{
				int randomnumber = Utility.Random(1, 17);
				DB.SkillrankexpTailoring += 1 + randomnumber;
			}
			if (craftSystem is DefAlchemy)
			{
				int randomnumber = Utility.Random(1, 17);
				DB.SkillrankexpAlchemy += 1 + randomnumber;
			}
			if (craftSystem is DefBowFletching)
			{
				int randomnumber = Utility.Random(1, 17);
				DB.SkillrankexpFletching += 1 + randomnumber;
			}
			if (craftSystem is DefCarpentry)
			{
				int randomnumber = Utility.Random(1, 17);
				DB.SkillrankexpCarpentry += 1 + randomnumber;
			}
			if (craftSystem is DefCartography)
			{
				int randomnumber = Utility.Random(1, 17);
				DB.SkillrankexpCartography += 1 + randomnumber;
			}
			if (craftSystem is DefCooking)
			{
				int randomnumber = Utility.Random(1, 17);
				DB.SkillrankexpCooking += 1 + randomnumber;
			}
			if (craftSystem is DefGlassblowing)
			{
				int randomnumber = Utility.Random(1, 17);
				DB.SkillrankexpBlacksmith += 1 + randomnumber;
			}
			if (craftSystem is DefInscription)
			{
				int randomnumber = Utility.Random(1, 17);
				DB.SkillrankexpInscribe += 1 + randomnumber;
			}
			if (craftSystem is DefShelves)
			{
				int randomnumber = Utility.Random(1, 17);
				DB.SkillrankexpCarpentry += 1 + randomnumber;
			}
			if (craftSystem is DefTinkering)
			{
				int randomnumber = Utility.Random(1, 17);
				DB.SkillrankexpTinkering += 1 + randomnumber;
			}
			if (craftSystem is DefWands)
			{
				int randomnumber = Utility.Random(1, 17);
				DB.SkillrankexpTinkering += 1 + randomnumber;
			}
		}

		public static void MagicRankResistExp (Mobile target)
		{
			if (target is PlayerMobile)
			{
				PlayerMobile pm = target as PlayerMobile;
				RankDatabase DB = Server.Items.RankDatabase.GetDB( pm );
			
				if (DB == null)
					return;
					
				int randomnumber = Utility.Random(1, 17);
				DB.SkillrankexpMagicResist += 1 + randomnumber; 
			}
		}
	}
}

/*
Layers:
TwoHanded
OneHanded
FirstValid

SkillName.Swords

*/