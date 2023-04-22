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
			
			if (DB.SkillrankexpAlchemy > RankF)
			{
				int skillvalue = DB.SkillrankexpAlchemy;
		
				from.SendMessage("You have ranked up your skill!");
				DB.RankAlchemy = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankAlchemy = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankAlchemy = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankAlchemy = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankAlchemy = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankAlchemy = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpBlacksmith > RankF)
			{
				int skillvalue = DB.SkillrankexpBlacksmith;
		
				DB.RankBlacksmith = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankBlacksmith = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankBlacksmith = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankBlacksmith = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankBlacksmith = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankBlacksmith = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpCartography > RankF)
			{
				int skillvalue = DB.SkillrankexpCartography;
		
				DB.RankCartography = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankCartography = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankCartography = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankCartography = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankCartography = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankCartography = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpCarpentry > RankF)
			{
				int skillvalue = DB.SkillrankexpCarpentry;
		
				DB.RankCarpentry = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankCarpentry = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankCarpentry = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankCarpentry = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankCarpentry = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankCarpentry = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpCooking > RankF)
			{
				int skillvalue = DB.SkillrankexpCooking;
		
				DB.RankCooking = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankCooking = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankCooking = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankCooking = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankCooking = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankCooking = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpFletching > RankF)
			{
				int skillvalue = DB.SkillrankexpFletching;
		
				DB.RankFletching = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankFletching = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankFletching = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankFletching = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankFletching = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankFletching = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpInscribe > RankF)
			{
				int skillvalue = DB.SkillrankexpInscribe;
		
				DB.RankInscribe = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankInscribe = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankInscribe = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankInscribe = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankInscribe = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankInscribe = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpTailoring > RankF)
			{
				int skillvalue = DB.SkillrankexpTailoring;
		
				DB.RankTailoring = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankTailoring = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankTailoring = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankTailoring = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankTailoring = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankTailoring = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpTinkering > RankF)
			{
				int skillvalue = DB.SkillrankexpTinkering;
		
				DB.RankTinkering = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankTinkering = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankTinkering = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankTinkering = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankTinkering = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankTinkering = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpDiscordance > RankF)
			{
				int skillvalue = DB.SkillrankexpDiscordance;
		
				DB.RankDiscordance = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankDiscordance = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankDiscordance = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankDiscordance = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankDiscordance = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankDiscordance = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpMusicianship > RankF)
			{
				int skillvalue = DB.SkillrankexpMusicianship;
		
				DB.RankMusicianship = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankMusicianship = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankMusicianship = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankMusicianship = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankMusicianship = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankMusicianship = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpPeacemaking > RankF)
			{
				int skillvalue = DB.SkillrankexpPeacemaking;
		
				DB.RankPeacemaking = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankPeacemaking = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankPeacemaking = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankPeacemaking = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankPeacemaking = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankPeacemaking = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpProvocation > RankF)
			{
				int skillvalue = DB.SkillrankexpProvocation;
		
				DB.RankProvocation = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankProvocation = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankProvocation = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankProvocation = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankProvocation = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankProvocation = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpChivalry > RankF)
			{
				int skillvalue = DB.SkillrankexpChivalry;
		
				DB.RankChivalry = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankChivalry = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankChivalry = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankChivalry = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankChivalry = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankChivalry = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpEvalInt > RankF)
			{
				int skillvalue = DB.SkillrankexpEvalInt;
		
				DB.RankEvalInt = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankEvalInt = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankEvalInt = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankEvalInt = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankEvalInt = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankEvalInt = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpMagery > RankF)
			{
				int skillvalue = DB.SkillrankexpMagery;
		
				DB.RankMagery = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankMagery = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankMagery = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankMagery = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankMagery = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankMagery = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpMagicResist > RankF)
			{
				int skillvalue = DB.SkillrankexpMagicResist;
		
				DB.RankMagicResist = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankMagicResist = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankMagicResist = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankMagicResist = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankMagicResist = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankMagicResist = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpMeditation > RankF)
			{
				int skillvalue = DB.SkillrankexpMeditation;
		
				DB.RankMeditation = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankMeditation = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankMeditation = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankMeditation = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankMeditation = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankMeditation = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpNecromancy > RankF)
			{
				int skillvalue = DB.SkillrankexpNecromancy;
		
				DB.RankNecromancy = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankNecromancy = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankNecromancy = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankNecromancy = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankNecromancy = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankNecromancy = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpSpiritSpeak > RankF)
			{
				int skillvalue = DB.SkillrankexpSpiritSpeak;
		
				DB.RankSpiritSpeak = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankSpiritSpeak = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankSpiritSpeak = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankSpiritSpeak = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankSpiritSpeak = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankSpiritSpeak = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpNinjitsu > RankF)
			{
				int skillvalue = DB.SkillrankexpNinjitsu;
		
				DB.RankNinjitsu = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankNinjitsu = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankNinjitsu = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankNinjitsu = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankNinjitsu = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankNinjitsu = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpBushido > RankF)
			{
				int skillvalue = DB.SkillrankexpBushido;
		
				DB.RankBushido = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankBushido = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankBushido = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankBushido = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankBushido = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankBushido = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpSpellweaving > RankF)
			{
				int skillvalue = DB.SkillrankexpSpellweaving;
		
				DB.RankSpellweaving = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankSpellweaving = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankSpellweaving = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankSpellweaving = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankSpellweaving = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankSpellweaving = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpCamping > RankF)
			{
				int skillvalue = DB.SkillrankexpCamping;
		
				DB.RankCamping = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankCamping = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankCamping = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankCamping = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankCamping = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankCamping = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpFishing > RankF)
			{
				int skillvalue = DB.SkillrankexpFishing;
		
				DB.RankFishing = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankFishing = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankFishing = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankFishing = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankFishing = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankFishing = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpFocus > RankF)
			{
				int skillvalue = DB.SkillrankexpFocus;
		
				DB.RankFocus = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankFocus = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankFocus = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankFocus = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankFocus = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankFocus = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpHealing > RankF)
			{
				int skillvalue = DB.SkillrankexpHealing;
		
				DB.RankHealing = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankHealing = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankHealing = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankHealing = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankHealing = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankHealing = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpHerding > RankF)
			{
				int skillvalue = DB.SkillrankexpHerding;
		
				DB.RankHerding = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankHerding = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankHerding = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankHerding = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankHerding = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankHerding = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpLockpicking > RankF)
			{
				int skillvalue = DB.SkillrankexpLockpicking;
		
				DB.RankLockpicking = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankLockpicking = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankLockpicking = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankLockpicking = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankLockpicking = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankLockpicking = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpLumberjacking > RankF)
			{
				int skillvalue = DB.SkillrankexpLumberjacking;
		
				DB.RankLumberjacking = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankLumberjacking = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankLumberjacking = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankLumberjacking = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankLumberjacking = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankLumberjacking = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpMining > RankF)
			{
				int skillvalue = DB.SkillrankexpMining;
		
				DB.RankMining = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankMining = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankMining = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankMining = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankMining = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankMining = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpSnooping > RankF)
			{
				int skillvalue = DB.SkillrankexpSnooping;
		
				DB.RankSnooping = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankSnooping = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankSnooping = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankSnooping = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankSnooping = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankSnooping = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpVeterinary > RankF)
			{
				int skillvalue = DB.SkillrankexpVeterinary;
		
				DB.RankVeterinary = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankVeterinary = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankVeterinary = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankVeterinary = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankVeterinary = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankVeterinary = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpArchery > RankF)
			{
				int skillvalue = DB.SkillrankexpArchery;
		
				DB.RankArchery = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankArchery = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankArchery = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankArchery = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankArchery = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankArchery = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpFencing > RankF)
			{
				int skillvalue = DB.SkillrankexpFencing;
		
				DB.RankFencing = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankFencing = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankFencing = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankFencing = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankFencing = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankFencing = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpMacing > RankF)
			{
				int skillvalue = DB.SkillrankexpMacing;
		
				DB.RankMacing = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankMacing = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankMacing = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankMacing = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankMacing = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankMacing = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpParry > RankF)
			{
				int skillvalue = DB.SkillrankexpParry;
		
				DB.RankParry = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankParry = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankParry = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankParry = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankParry = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankParry = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpSwords > RankF)
			{
				int skillvalue = DB.SkillrankexpSwords;
		
				DB.RankSwords = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankSwords = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankSwords = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankSwords = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankSwords = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankSwords = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpTactics > RankF)
			{
				int skillvalue = DB.SkillrankexpTactics;
		
				DB.RankTactics = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankTactics = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankTactics = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankTactics = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankTactics = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankTactics = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpWrestling > RankF)
			{
				int skillvalue = DB.SkillrankexpWrestling;
		
				DB.RankWrestling = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankWrestling = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankWrestling = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankWrestling = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankWrestling = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankWrestling = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpAnimalTaming > RankF)
			{
				int skillvalue = DB.SkillrankexpAnimalTaming;
		
				DB.RankAnimalTaming = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankAnimalTaming = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankAnimalTaming = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankAnimalTaming = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankAnimalTaming = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankAnimalTaming = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpBegging > RankF)
			{
				int skillvalue = DB.SkillrankexpBegging;
		
				DB.RankBegging = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankBegging = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankBegging = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankBegging = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankBegging = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankBegging = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpDetectHidden > RankF)
			{
				int skillvalue = DB.SkillrankexpDetectHidden;
		
				DB.RankDetectHidden = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankDetectHidden = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankDetectHidden = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankDetectHidden = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankDetectHidden = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankDetectHidden = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpHiding > RankF)
			{
				int skillvalue = DB.SkillrankexpHiding;
		
				DB.RankHiding = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankHiding = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankHiding = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankHiding = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankHiding = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankHiding = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpRemoveTrap > RankF)
			{
				int skillvalue = DB.SkillrankexpRemoveTrap;
		
				DB.RankRemoveTrap = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankRemoveTrap = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankRemoveTrap = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankRemoveTrap = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankRemoveTrap = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankRemoveTrap = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpPoisoning > RankF)
			{
				int skillvalue = DB.SkillrankexpPoisoning;
		
				DB.RankPoisoning = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankPoisoning = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankPoisoning = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankPoisoning = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankPoisoning = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankPoisoning = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpStealing > RankF)
			{
				int skillvalue = DB.SkillrankexpStealing;
		
				DB.RankStealing = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankStealing = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankStealing = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankStealing = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankStealing = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankStealing = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpStealth > RankF)
			{
				int skillvalue = DB.SkillrankexpStealth;
		
				DB.RankStealth = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankStealth = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankStealth = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankStealth = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankStealth = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankStealth = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpTracking > RankF)
			{
				int skillvalue = DB.SkillrankexpTracking;
		
				DB.RankTracking = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankTracking = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankTracking = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankTracking = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankTracking = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankTracking = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpAnatomy > RankF)
			{
				int skillvalue = DB.SkillrankexpAnatomy;
		
				DB.RankAnatomy = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankAnatomy = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankAnatomy = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankAnatomy = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankAnatomy = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankAnatomy = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpAnimalLore > RankF)
			{
				int skillvalue = DB.SkillrankexpAnimalLore;
		
				DB.RankAnimalLore = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankAnimalLore = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankAnimalLore = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankAnimalLore = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankAnimalLore = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankAnimalLore = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpArmsLore > RankF)
			{
				int skillvalue = DB.SkillrankexpArmsLore;
		
				DB.RankArmsLore = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankArmsLore = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankArmsLore = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankArmsLore = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankArmsLore = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankArmsLore = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpForensics > RankF)
			{
				int skillvalue = DB.SkillrankexpForensics;
		
				DB.RankForensics = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankForensics = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankForensics = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankForensics = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankForensics = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankForensics = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpItemID > RankF)
			{
				int skillvalue = DB.SkillrankexpItemID;
		
				DB.RankItemID = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankItemID = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankItemID = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankItemID = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankItemID = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankItemID = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpTasteID > RankF)
			{
				int skillvalue = DB.SkillrankexpTasteID;
		
				DB.RankTasteID = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankTasteID = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankTasteID = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankTasteID = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankTasteID = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankTasteID = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpThrowing > RankF)
			{
				int skillvalue = DB.SkillrankexpThrowing;
		
				DB.RankThrowing = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankThrowing = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankThrowing = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankThrowing = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankThrowing = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankThrowing = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpImbueing > RankF)
			{
				int skillvalue = DB.SkillrankexpImbueing;
		
				DB.RankImbueing = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankImbueing = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankImbueing = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankImbueing = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankImbueing = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankImbueing = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
									}
								}
							}
						}
					}
				}
			}
			if (DB.SkillrankexpMysticism > RankF)
			{
				int skillvalue = DB.SkillrankexpMysticism;
		
				DB.RankMysticism = "E";
				if (skillvalue < RankE){return;}
				if (skillvalue > RankE)
				{
					DB.RankMysticism = "D";
					if (skillvalue < RankD){return;}
					if (skillvalue > RankD)
					{
						DB.RankMysticism = "C";
						if (skillvalue < RankC){return;}
						if (skillvalue > RankC)
						{
							DB.RankMysticism = "B";
							if (skillvalue < RankB){return;}
							if (skillvalue > RankB)
							{
								DB.RankMysticism = "A";
								if (skillvalue < RankA){return;}
								if (skillvalue > RankA)
								{
									DB.RankMysticism = "S";
									if (skillvalue < RankS){return;}
									if (skillvalue > RankS)
									{
										{return;}
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