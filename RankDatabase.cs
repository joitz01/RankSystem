using System;
using Server; 
using Server.Network;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Targeting;
using Server.Commands;
using Server.Commands.Generic;
using System.Collections.Generic;
using System.Collections;

namespace Server.Items
{
	public class RankDatabase : Item
	{
		public Mobile CharacterOwner;
        private int m_StatPoints;
		private int m_StrPointsUsed;
		private int m_DexPointsUsed;
		private int m_IntPointsUsed;
		private int m_TotalStatPointsAquired;
		public int m_TotalSkillPointsUsed;
		public int m_SkillPointsUsedArmsLore;
		public int m_SkillPointsUsedBegging;
		public int m_SkillPointsUsedCamping;
		public int m_SkillPointsUsedCartography;
		public int m_SkillPointsUsedForensics;
		public int m_SkillPointsUsedItemID;
		public int m_SkillPointsUsedTasteID;
		public int m_SkillPointsUsedAnatomy;
		public int m_SkillPointsUsedArchery;
		public int m_SkillPointsUsedFencing;
		public int m_SkillPointsUsedFocus;
		public int m_SkillPointsUsedHealing;
		public int m_SkillPointsUsedMacing;
		public int m_SkillPointsUsedParry;
		public int m_SkillPointsUsedSwords;
		public int m_SkillPointsUsedTactics;
		public int m_SkillPointsUsedWrestling;
		public int m_SkillPointsUsedThrowing;
		public int m_SkillPointsUsedAlchemy;
		public int m_SkillPointsUsedBlacksmith;
		public int m_SkillPointsUsedFletching;
		public int m_SkillPointsUsedCarpentry;
		public int m_SkillPointsUsedCooking;
		public int m_SkillPointsUsedInscribe;
		public int m_SkillPointsUsedLumberjacking;
		public int m_SkillPointsUsedMining;
		public int m_SkillPointsUsedTailoring;
		public int m_SkillPointsUsedTinkering;
		public int m_SkillPointsUsedImbuing;
		public int m_SkillPointsUsedBushido;
		public int m_SkillPointsUsedChivalry;
		public int m_SkillPointsUsedEvalInt;
		public int m_SkillPointsUsedMagery;
		public int m_SkillPointsUsedMeditation;
		public int m_SkillPointsUsedNecromancy;
		public int m_SkillPointsUsedNinjitsu;
		public int m_SkillPointsUsedMagicResist;
		public int m_SkillPointsUsedSpellweaving;
		public int m_SkillPointsUsedSpiritSpeak;
		public int m_SkillPointsUsedMysticism;
		public int m_SkillPointsUsedAnimalLore;
		public int m_SkillPointsUsedAnimalTaming;
		public int m_SkillPointsUsedFishing;
		public int m_SkillPointsUsedHerding;
		public int m_SkillPointsUsedTracking;
		public int m_SkillPointsUsedVeterinary;
		public int m_SkillPointsUsedDetectHidden;
		public int m_SkillPointsUsedHiding;
		public int m_SkillPointsUsedLockpicking;
		public int m_SkillPointsUsedPoisoning;
		public int m_SkillPointsUsedRemoveTrap;
		public int m_SkillPointsUsedSnooping;
		public int m_SkillPointsUsedStealing;
		public int m_SkillPointsUsedStealth;
		public int m_SkillPointsUsedDiscordance;
		public int m_SkillPointsUsedMusicianship;
		public int m_SkillPointsUsedPeacemaking;
		public int m_SkillPointsUsedProvocation;
		public int m_skillrankexpAlchemy = 0;
		public int m_skillrankexpBlacksmith = 0;
		public int m_skillrankexpCartography = 0;
		public int m_skillrankexpCarpentry = 0;
		public int m_skillrankexpCooking = 0;
		public int m_skillrankexpFletching = 0;
		public int m_skillrankexpInscribe = 0;
		public int m_skillrankexpTailoring = 0;
		public int m_skillrankexpTinkering = 0;
		public int m_skillrankexpDiscordance = 0;
		public int m_skillrankexpMusicianship = 0;
		public int m_skillrankexpPeacemaking = 0;
		public int m_skillrankexpProvocation = 0;
		public int m_skillrankexpChivalry = 0;
		public int m_skillrankexpEvalInt = 0;
		public int m_skillrankexpMagery = 0;
		public int m_skillrankexpMagicResist = 0;
		public int m_skillrankexpMeditation = 0;
		public int m_skillrankexpNecromancy = 0;
		public int m_skillrankexpSpiritSpeak = 0;
		public int m_skillrankexpNinjitsu = 0;
		public int m_skillrankexpBushido = 0;
		public int m_skillrankexpSpellweaving = 0;
		public int m_skillrankexpCamping = 0;
		public int m_skillrankexpFishing = 0;
		public int m_skillrankexpFocus = 0;
		public int m_skillrankexpHealing = 0;
		public int m_skillrankexpHerding = 0;
		public int m_skillrankexpLockpicking = 0;
		public int m_skillrankexpLumberjacking = 0;
		public int m_skillrankexpMining = 0;
		public int m_skillrankexpSnooping = 0;
		public int m_skillrankexpVeterinary = 0;
		public int m_skillrankexpArchery = 0;
		public int m_skillrankexpFencing = 0;
		public int m_skillrankexpMacing = 0;
		public int m_skillrankexpParry = 0;
		public int m_skillrankexpSwords = 0;
		public int m_skillrankexpTactics = 0;
		public int m_skillrankexpWrestling = 0;
		public int m_skillrankexpAnimalTaming = 0;
		public int m_skillrankexpBegging = 0;
		public int m_skillrankexpDetectHidden = 0;
		public int m_skillrankexpHiding = 0;
		public int m_skillrankexpRemoveTrap = 0;
		public int m_skillrankexpPoisoning = 0;
		public int m_skillrankexpStealing = 0;
		public int m_skillrankexpStealth = 0;
		public int m_skillrankexpTracking = 0;
		public int m_skillrankexpAnatomy = 0;
		public int m_skillrankexpAnimalLore = 0;
		public int m_skillrankexpArmsLore = 0;
		public int m_skillrankexpForensics = 0;
		public int m_skillrankexpItemID = 0;
		public int m_skillrankexpTasteID = 0;
		public int m_skillrankexpThrowing = 0;
		public int m_skillrankexpImbueing = 0;
		public int m_skillrankexpMysticism = 0;
		public string m_skillrankAlchemy = "F";
		public string m_skillrankBlacksmith = "F";
		public string m_skillrankCartography = "F";
		public string m_skillrankCarpentry = "F";
		public string m_skillrankCooking = "F";
		public string m_skillrankFletching = "F";
		public string m_skillrankInscribe = "F";
		public string m_skillrankTailoring = "F";
		public string m_skillrankTinkering = "F";
		public string m_skillrankDiscordance = "F";
		public string m_skillrankMusicianship = "F";
		public string m_skillrankPeacemaking = "F";
		public string m_skillrankProvocation = "F";
		public string m_skillrankChivalry = "F";
		public string m_skillrankEvalInt = "F";
		public string m_skillrankMagery = "F";
		public string m_skillrankMagicResist = "F";
		public string m_skillrankMeditation = "F";
		public string m_skillrankNecromancy = "F";
		public string m_skillrankSpiritSpeak = "F";
		public string m_skillrankNinjitsu = "F";
		public string m_skillrankBushido = "F";
		public string m_skillrankSpellweaving = "F";
		public string m_skillrankCamping = "F";
		public string m_skillrankFishing = "F";
		public string m_skillrankFocus = "F";
		public string m_skillrankHealing = "F";
		public string m_skillrankHerding = "F";
		public string m_skillrankLockpicking = "F";
		public string m_skillrankLumberjacking = "F";
		public string m_skillrankMining = "F";
		public string m_skillrankSnooping = "F";
		public string m_skillrankVeterinary = "F";
		public string m_skillrankArchery = "F";
		public string m_skillrankFencing = "F";
		public string m_skillrankMacing = "F";
		public string m_skillrankParry = "F";
		public string m_skillrankSwords = "F";
		public string m_skillrankTactics = "F";
		public string m_skillrankWrestling = "F";
		public string m_skillrankAnimalTaming = "F";
		public string m_skillrankBegging = "F";
		public string m_skillrankDetectHidden = "F";
		public string m_skillrankHiding = "F";
		public string m_skillrankRemoveTrap = "F";
		public string m_skillrankPoisoning = "F";
		public string m_skillrankStealing = "F";
		public string m_skillrankStealth = "F";
		public string m_skillrankTracking = "F";
		public string m_skillrankAnatomy = "F";
		public string m_skillrankAnimalLore = "F";
		public string m_skillrankArmsLore = "F";
		public string m_skillrankForensics = "F";
		public string m_skillrankItemID = "F";
		public string m_skillrankTasteID = "F";
		public string m_skillrankThrowing = "F";
		public string m_skillrankImbueing = "F";
		public string m_skillrankMysticism = "F";
		public bool uniqueskill_concealment = false;
		public bool uniqueskill_rampart = false;
		public bool uniqueskill_puppetry = false;
		public bool uniqueskill_summoner = false;
		public bool uniqueskill_pugilist  = false;
		public bool uniqueskill_magicamp = false;
		public bool uniqueskill_whitemage = false;
		public bool uniqueskill_reviver = false;
		public bool uniqueskill_blackmage = false;
		public bool uniqueskill_assassinspoise = false;
		public bool uniqueskill_petscompanion = false;
		public bool uniqueskill_thrasher = false;
		public bool uniqueskill_treasuretrove = false;
		public bool uniqueskill_murderer  = false;
		public bool uniqueskill_greenmage = false;
		public bool uniqueskill_returntoashes = false;
		public bool uniqueskill_smitheseyes = false;
		public string m_ranklevel = "F";
		public int m_f_rankquestcompleted;
		public int m_e_rankquestcompleted;
		public int m_d_rankquestcompleted;
		public int m_c_rankquestcompleted;
		public int m_b_rankquestcompleted;
		public int m_a_rankquestcompleted;
		public int m_s_rankquestcompleted;
		private int m_level;
		private int m_maxlevel = 150;
		private int m_exp;
		private int m_tolevel = 100;
		private int m_gainedskillpoints;
		private int m_totalstatpoints;
		private int m_totalskillpoints = 50;
		private int m_age;
		public string m_customtitle = "";
		private int m_l2to20multipier		= 50;		// leve 2 to level 20 
		private int m_l21to40multiplier		= 100;		// leve 21 to level 40 
		private int m_l41to60multiplier		= 300;		// leve 41 to level 60 
		private int m_l61to70multiplier		= 400;		// leve 61 to level 70 
		private int m_l71to80multiplier		= 500;		// leve 71 to level 80 
		private int m_l81to90multipier		= 1100;		// leve 81 to level 90 
		private int m_l91to100multipier		= 1300;		// leve 91 to level 100 
		private int m_l101to110multiplier	= 1500;		// leve 101 to level 110 
		private int m_l111to120multiplier	= 1700;		// leve 110 to level 120 
		private int m_l121to130multiplier	= 1900;		// leve 121 to level 130 
		private int m_l131to140multiplier	= 2200;		// leve 131 to level 140 
		private int m_l141to150multiplier	= 2500;		// leve 141 to level 150 
		private int m_l151to160multiplier	= 3500;		// leve 151 to level 160 
		private int m_l161to170multiplier	= 3900;		// leve 161 to level 170 
		private int m_l171to180multiplier	= 4110;		// leve 171 to level 180 
		private int m_l181to190multiplier	= 4300;		// leve 181 to level 190 
		private int m_l191to200multiplier	= 6000;		// leve 191 to level 200
		private int	m_below20					= 4;	//below level 20
		private int m_below40					= 4;	//below level 40
		private int m_below60					= 6;	//below level 60
		private int m_below70					= 8;	//below level 70
		private int m_below80					= 8;	//below level 80
		private int m_below90					= 8;	//below level 90
		private int m_below100					= 8;	//below level 100
		private int m_below110					= 10;	//below level 110
		private int m_below120					= 10;	//below level 120
		private int m_below130					= 25;	//below level 130
		private int m_below140					= 25;	//below level 140
		private int m_below150					= 25;	//below level 150
		private int m_below160					= 25;	//below level 160
		private int m_below170					= 25;	//below level 170
		private int m_below180					= 25;	//below level 180
		private int m_below190					= 25;	//below level 190
		private int m_below200					= 25;	//below level 200
		private int m_totalKillsWithSwords;
		private int m_totalKillsWithFencing;
		private int m_totalKillswithMacing;
		private int m_totalKillsWithHands;
		private int m_totalKillsWithArchery;
		private int m_totalKillsWithInstruments;
		public int m_potionexplosionused = 0;
		public int m_potioncureused = 0;
		public int m_potionhealused = 0;
		public int m_potiontotalused = 0;
		public int m_potionpoisonedused = 0;
		public int m_timesinstrumentplayed = 0;
		public int m_bandagesused = 0;
		public int m_tooluses = 0;
		public int m_doorsopened = 0;
		
		/* Quest - Before and After quest these values are default*/
		public bool m_rankquestactive;
		public string m_rankquesttype;
		public bool m_rankquestobjectivesComplete;
		public Mobile RankQuestEscort;
		public Mobile RankQuestEscort2;
		public Mobile RankQuestEscort3;
		public Mobile RankQuestEscort4;
		public string m_rankquestcreaturenameone;
		public string m_rankquestcreaturenametwo;
		public string m_rankquestcreaturenamethree;
		public string m_rankquestcreaturenamefour;
		public string m_rankquestcreaturenamefive;
		public string m_rankquestcreaturenamesix;
		public string m_rankquestcreaturenameseven;
		public string m_rankquestcreaturenameeight;
		public string m_rankquestcreaturenamenine;
		public string m_rankquestcreaturenameten;
		public int m_rankquestobjectiveone;
		public int m_rankquestobjectivetwo;
		public int m_rankquestobjectivethree;
		public int m_rankquestobjectivefour;
		public int m_rankquestobjectivefive;
		public int m_rankquestobjectivesix;
		public int m_rankquestobjectiveseven;
		public int m_rankquestobjectiveeight;
		public int m_rankquestobjectivenine;
		public int m_rankquestobjectiveten;
		
		public int m_gatheringcompleted;
		public int m_subjugationcompleted;
		public int m_escortcompleted;
		
		public string m_EscortDestination;
		public string m_EscortDestination2;
		public string m_EscortDestination3;
		public string m_EscortDestination4;
		/* Quest */
		
		[CommandProperty( AccessLevel.GameMaster )]
		public string EscortDestination 
		{
			get {return m_EscortDestination; }
			set { m_EscortDestination = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string EscortDestination2 
		{
			get {return m_EscortDestination2; }
			set { m_EscortDestination2 = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string EscortDestination3 
		{
			get {return m_EscortDestination3; }
			set { m_EscortDestination3 = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string EscortDestination4 
		{
			get {return m_EscortDestination4; }
			set { m_EscortDestination4 = value; InvalidateProperties(); } 
		}

        [CommandProperty(AccessLevel.GameMaster)]
        public int GatheringCompleted
        {
            get { return m_gatheringcompleted; }
            set { m_gatheringcompleted = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int SubjugationCompleted
        {
            get { return m_subjugationcompleted; }
            set { m_subjugationcompleted = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int EscortCompleted
        {
            get { return m_escortcompleted; }
            set { m_escortcompleted = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public bool Rankquestactive
        {
            get { return m_rankquestactive; }
            set { m_rankquestactive = value; InvalidateProperties(); }
        }
		[CommandProperty( AccessLevel.GameMaster )]
		public string Rankquesttype 
		{
			get {return m_rankquesttype; }
			set { m_rankquesttype = value; InvalidateProperties(); } 
		}
        [CommandProperty(AccessLevel.GameMaster)]
        public bool RankquestobjectivesComplete
        {
            get { return m_rankquestobjectivesComplete; }
            set { m_rankquestobjectivesComplete = value; InvalidateProperties(); }
        }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile RankQuest_Escort { get{ return RankQuestEscort; } set{ RankQuestEscort = value; } }
		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile RankQuest_Escort2 { get{ return RankQuestEscort2; } set{ RankQuestEscort2 = value; } }
		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile RankQuest_Escort3 { get{ return RankQuestEscort3; } set{ RankQuestEscort3 = value; } }
		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile RankQuest_Escort4 { get{ return RankQuestEscort4; } set{ RankQuestEscort4 = value; } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public string Rankquestcreaturenameone
		{
			get {return m_rankquestcreaturenameone; }
			set { m_rankquestcreaturenameone = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string Rankquestcreaturenametwo
		{
			get {return m_rankquestcreaturenametwo; }
			set { m_rankquestcreaturenametwo = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string Rankquestcreaturenamethree
		{
			get {return m_rankquestcreaturenamethree; }
			set { m_rankquestcreaturenamethree = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string Rankquestcreaturenamefour
		{
			get {return m_rankquestcreaturenamefour; }
			set { m_rankquestcreaturenamefour = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string Rankquestcreaturenamefive
		{
			get {return m_rankquestcreaturenamefive; }
			set { m_rankquestcreaturenamefive = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string Rankquestcreaturenamesix
		{
			get {return m_rankquestcreaturenamesix; }
			set { m_rankquestcreaturenamesix = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string Rankquestcreaturenameseven
		{
			get {return m_rankquestcreaturenameseven; }
			set { m_rankquestcreaturenameseven = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string Rankquestcreaturenameeight
		{
			get {return m_rankquestcreaturenameeight; }
			set { m_rankquestcreaturenameeight = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string Rankquestcreaturenamenine
		{
			get {return m_rankquestcreaturenamenine; }
			set { m_rankquestcreaturenamenine = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string Rankquestcreaturenameten
		{
			get {return m_rankquestcreaturenameten; }
			set { m_rankquestcreaturenameten = value; InvalidateProperties(); } 
		}
        [CommandProperty(AccessLevel.GameMaster)]
        public int Rankquestobjectiveone
        {
            get { return m_rankquestobjectiveone; }
            set { m_rankquestobjectiveone = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int Rankquestobjectivetwo
        {
            get { return m_rankquestobjectivetwo; }
            set { m_rankquestobjectivetwo = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int Rankquestobjectivethree
        {
            get { return m_rankquestobjectivethree; }
            set { m_rankquestobjectivethree = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int Rankquestobjectivefour
        {
            get { return m_rankquestobjectivefour; }
            set { m_rankquestobjectivefour = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int Rankquestobjectivefive
        {
            get { return m_rankquestobjectivefive; }
            set { m_rankquestobjectivefive = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int Rankquestobjectivesix
        {
            get { return m_rankquestobjectivesix; }
            set { m_rankquestobjectivesix = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int Rankquestobjectiveseven
        {
            get { return m_rankquestobjectiveseven; }
            set { m_rankquestobjectiveseven = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int Rankquestobjectiveeight
        {
            get { return m_rankquestobjectiveeight; }
            set { m_rankquestobjectiveeight = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int Rankquestobjectivenine
        {
            get { return m_rankquestobjectivenine; }
            set { m_rankquestobjectivenine = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int Rankquestobjectiveten
        {
            get { return m_rankquestobjectiveten; }
            set { m_rankquestobjectiveten = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public bool USkill_smitheseyes
        {
            get { return uniqueskill_smitheseyes; }
            set { uniqueskill_smitheseyes = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int DoorsOpened
        {
            get { return m_doorsopened; }
            set { m_doorsopened = value; InvalidateProperties(); }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Tooluses
        {
            get { return m_tooluses; }
            set { m_tooluses = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int Bandagesused
        {
            get { return m_bandagesused; }
            set { m_bandagesused = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int Timesinstrumentplayed
        {
            get { return m_timesinstrumentplayed; }
            set { m_timesinstrumentplayed = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int Potionpoisonedused
        {
            get { return m_potionpoisonedused; }
            set { m_potionpoisonedused = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int Potiontotalused
        {
            get { return m_potiontotalused; }
            set { m_potiontotalused = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int Potionhealused
        {
            get { return m_potionhealused; }
            set { m_potionhealused = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int Potioncureused
        {
            get { return m_potioncureused; }
            set { m_potioncureused = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int Potionexplosionused
        {
            get { return m_potionexplosionused; }
            set { m_potionexplosionused = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int TotalKillsWithInstruments
        {
            get { return m_totalKillsWithInstruments; }
            set { m_totalKillsWithInstruments = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int TotalKillsWithSwords
        {
            get { return m_totalKillsWithSwords; }
            set { m_totalKillsWithSwords = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int TotalKillsWithFencing
        {
            get { return m_totalKillsWithFencing; }
            set { m_totalKillsWithFencing = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int TotalKillswithMacing
        {
            get { return m_totalKillswithMacing; }
            set { m_totalKillswithMacing = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int TotalKillsWithHands
        {
            get { return m_totalKillsWithHands; }
            set { m_totalKillsWithHands = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int TotalKillsWithArchery
        {
            get { return m_totalKillsWithArchery; }
            set { m_totalKillsWithArchery = value; InvalidateProperties(); }
        }
		
        [CommandProperty(AccessLevel.GameMaster)]
        public int L2to20Multipier
        {
            get { return m_l2to20multipier; }
            set { m_l2to20multipier = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int L21to40Multiplier
        {
            get { return m_l21to40multiplier; }
            set { m_l21to40multiplier = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int L41to60Multiplier
        {
            get { return m_l41to60multiplier; }
            set { m_l41to60multiplier = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int L61to70Multiplier
        {
            get { return m_l61to70multiplier; }
            set { m_l61to70multiplier = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int L71to80Multiplier
        {
            get { return m_l71to80multiplier; }
            set { m_l71to80multiplier = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int L81to90Multipier
        {
            get { return m_l81to90multipier; }
            set { m_l81to90multipier = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int L91to100Multipier
        {
            get { return m_l91to100multipier; }
            set { m_l91to100multipier = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int L101to110Multiplier
        {
            get { return m_l101to110multiplier; }
            set { m_l101to110multiplier = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int L111to120Multiplier
        {
            get { return m_l111to120multiplier; }
            set { m_l111to120multiplier = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int L121to130Multiplier
        {
            get { return m_l121to130multiplier; }
            set { m_l121to130multiplier = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int L131to140Multiplier
        {
            get { return m_l131to140multiplier; }
            set { m_l131to140multiplier = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int L141to150Multiplier
        {
            get { return m_l141to150multiplier; }
            set { m_l141to150multiplier = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int L151to160Multiplier
        {
            get { return m_l151to160multiplier; }
            set { m_l151to160multiplier = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int L161to170Multiplier
        {
            get { return m_l161to170multiplier; }
            set { m_l161to170multiplier = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int L171to180Multiplier
        {
            get { return m_l171to180multiplier; }
            set { m_l171to180multiplier = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int L181to190Multiplier
        {
            get { return m_l181to190multiplier; }
            set { m_l181to190multiplier = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int L191to200Multiplier
        {
            get { return m_l191to200multiplier; }
            set { m_l191to200multiplier = value; InvalidateProperties(); }
        }
		/* how many skill points awarded per level.
		scenario: if turning level 18, below20 applies*/
		[CommandProperty(AccessLevel.GameMaster)]
		public int Below20
        {
            get { return m_below20; }
            set { m_below20 = value; InvalidateProperties(); }
        }
		[CommandProperty(AccessLevel.GameMaster)]
		public int Below40
        {
            get { return m_below40; }
            set { m_below40 = value; InvalidateProperties(); }
        }
		[CommandProperty(AccessLevel.GameMaster)]
		public int Below60
        {
            get { return m_below60; }
            set { m_below60 = value; InvalidateProperties(); }
        }
		[CommandProperty(AccessLevel.GameMaster)]
		public int Below70
        {
            get { return m_below70; }
            set { m_below70 = value; InvalidateProperties(); }
        }
		[CommandProperty(AccessLevel.GameMaster)]
		public int Below80
        {
            get { return m_below80; }
            set { m_below80 = value; InvalidateProperties(); }
        }
		[CommandProperty(AccessLevel.GameMaster)]
		public int Below90
        {
            get { return m_below90; }
            set { m_below90 = value; InvalidateProperties(); }
        }
		[CommandProperty(AccessLevel.GameMaster)]
		public int Below100
        {
            get { return m_below100; }
            set { m_below100 = value; InvalidateProperties(); }
        }
		[CommandProperty(AccessLevel.GameMaster)]
		public int Below110
        {
            get { return m_below110; }
            set { m_below110 = value; InvalidateProperties(); }
        }
		[CommandProperty(AccessLevel.GameMaster)]
		public int Below120
        {
            get { return m_below120; }
            set { m_below120 = value; InvalidateProperties(); }
        }
		[CommandProperty(AccessLevel.GameMaster)]
		public int Below130
        {
            get { return m_below130; }
            set { m_below130 = value; InvalidateProperties(); }
        }
		[CommandProperty(AccessLevel.GameMaster)]
		public int Below140
        {
            get { return m_below140; }
            set { m_below140 = value; InvalidateProperties(); }
        }
		[CommandProperty(AccessLevel.GameMaster)]
		public int Below150
        {
            get { return m_below150; }
            set { m_below150 = value; InvalidateProperties(); }
        }
		[CommandProperty(AccessLevel.GameMaster)]
		public int Below160
        {
            get { return m_below160; }
            set { m_below160 = value; InvalidateProperties(); }
        }
		[CommandProperty(AccessLevel.GameMaster)]
		public int Below170
        {
            get { return m_below170; }
            set { m_below170 = value; InvalidateProperties(); }
        }
		[CommandProperty(AccessLevel.GameMaster)]
		public int Below180
        {
            get { return m_below180; }
            set { m_below180 = value; InvalidateProperties(); }
        }
		[CommandProperty(AccessLevel.GameMaster)]
		public int Below190
        {
            get { return m_below190; }
            set { m_below190 = value; InvalidateProperties(); }
        }
		[CommandProperty(AccessLevel.GameMaster)]
		public int Below200
        {
            get { return m_below200; }
            set { m_below200 = value; InvalidateProperties(); }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int StatPoints
        {
            get { return m_StatPoints; }
            set { m_StatPoints = value; }
        }
		
        [CommandProperty(AccessLevel.GameMaster)]
        public int StrPointsUsed
        {
            get { return m_StrPointsUsed; }
            set { m_StrPointsUsed = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int DexPointsUsed
        {
            get { return m_DexPointsUsed; }
            set { m_DexPointsUsed = value; }
        }
		
        [CommandProperty(AccessLevel.GameMaster)]
        public int IntPointsUsed
        {
            get { return m_IntPointsUsed; }
            set { m_IntPointsUsed = value; }
        }
		
        [CommandProperty(AccessLevel.GameMaster)]
        public int TotalStatPointsAquired
        {
            get { return m_TotalStatPointsAquired; }
            set { m_TotalStatPointsAquired = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int TotalSkillPointsUsed
        { get { return m_TotalSkillPointsUsed; } set { m_TotalSkillPointsUsed = value; } }
		
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedArmsLore
        { get { return m_SkillPointsUsedArmsLore; } set { m_SkillPointsUsedArmsLore = value; } }
		
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedBegging
        { get { return m_SkillPointsUsedBegging; } set { m_SkillPointsUsedBegging = value; } }
		
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedCamping
        { get { return m_SkillPointsUsedCamping; } set { m_SkillPointsUsedCamping = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedCartography
        { get { return m_SkillPointsUsedCartography; } set { m_SkillPointsUsedCartography = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedForensics
        { get { return m_SkillPointsUsedForensics; } set { m_SkillPointsUsedForensics = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedItemID
        { get { return m_SkillPointsUsedItemID; } set { m_SkillPointsUsedItemID = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedTasteID
        { get { return m_SkillPointsUsedTasteID; } set { m_SkillPointsUsedTasteID = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedAnatomy
        { get { return m_SkillPointsUsedAnatomy; } set { m_SkillPointsUsedAnatomy = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedArchery
        { get { return m_SkillPointsUsedArchery; } set { m_SkillPointsUsedArchery = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedFencing
        { get { return m_SkillPointsUsedFencing; } set { m_SkillPointsUsedFencing = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedFocus
        { get { return m_SkillPointsUsedFocus; } set { m_SkillPointsUsedFocus = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedHealing
        { get { return m_SkillPointsUsedHealing; } set { m_SkillPointsUsedHealing = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedMacing
        { get { return m_SkillPointsUsedMacing; } set { m_SkillPointsUsedMacing = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedParry
        { get { return m_SkillPointsUsedParry; } set { m_SkillPointsUsedParry = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedSwords
        { get { return m_SkillPointsUsedSwords; } set { m_SkillPointsUsedSwords = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedTactics
        { get { return m_SkillPointsUsedTactics; } set { m_SkillPointsUsedTactics = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedWrestling
        { get { return m_SkillPointsUsedWrestling; } set { m_SkillPointsUsedWrestling = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedThrowing
        { get { return m_SkillPointsUsedThrowing; } set { m_SkillPointsUsedThrowing = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedAlchemy
        { get { return m_SkillPointsUsedAlchemy; } set { m_SkillPointsUsedAlchemy = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedBlacksmith
        { get { return m_SkillPointsUsedBlacksmith; } set { m_SkillPointsUsedBlacksmith = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedFletching
        { get { return m_SkillPointsUsedFletching; } set { m_SkillPointsUsedFletching = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedCarpentry
        { get { return m_SkillPointsUsedCarpentry; } set { m_SkillPointsUsedCarpentry = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedCooking
        { get { return m_SkillPointsUsedCooking; } set { m_SkillPointsUsedCooking = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedInscribe
        { get { return m_SkillPointsUsedInscribe; } set { m_SkillPointsUsedInscribe = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedLumberjacking
        { get { return m_SkillPointsUsedLumberjacking; } set { m_SkillPointsUsedLumberjacking = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedMining
        { get { return m_SkillPointsUsedMining; } set { m_SkillPointsUsedMining = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedTailoring
        { get { return m_SkillPointsUsedTailoring; } set { m_SkillPointsUsedTailoring = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedTinkering
        { get { return m_SkillPointsUsedTinkering; } set { m_SkillPointsUsedTinkering = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedImbuing
        { get { return m_SkillPointsUsedImbuing; } set { m_SkillPointsUsedImbuing = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedBushido
        { get { return m_SkillPointsUsedBushido; } set { m_SkillPointsUsedBushido = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedChivalry
        { get { return m_SkillPointsUsedChivalry; } set { m_SkillPointsUsedChivalry = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedEvalInt
        { get { return m_SkillPointsUsedEvalInt; } set { m_SkillPointsUsedEvalInt = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedMagery
        { get { return m_SkillPointsUsedMagery; } set { m_SkillPointsUsedMagery = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedMeditation
        { get { return m_SkillPointsUsedMeditation; } set { m_SkillPointsUsedMeditation = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedNecromancy
        { get { return m_SkillPointsUsedNecromancy; } set { m_SkillPointsUsedNecromancy = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedNinjitsu
        { get { return m_SkillPointsUsedNinjitsu; } set { m_SkillPointsUsedNinjitsu = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedMagicResist
        { get { return m_SkillPointsUsedMagicResist; } set { m_SkillPointsUsedMagicResist = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedSpellweaving
        { get { return m_SkillPointsUsedSpellweaving; } set { m_SkillPointsUsedSpellweaving = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedSpiritSpeak
        { get { return m_SkillPointsUsedSpiritSpeak; } set { m_SkillPointsUsedSpiritSpeak = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedMysticism
        { get { return m_SkillPointsUsedMysticism; } set { m_SkillPointsUsedMysticism = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedAnimalLore
        { get { return m_SkillPointsUsedAnimalLore; } set { m_SkillPointsUsedAnimalLore = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedAnimalTaming
        { get { return m_SkillPointsUsedAnimalTaming; } set { m_SkillPointsUsedAnimalTaming = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedFishing
        { get { return m_SkillPointsUsedFishing; } set { m_SkillPointsUsedFishing = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedHerding
        { get { return m_SkillPointsUsedHerding; } set { m_SkillPointsUsedHerding = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedTracking
        { get { return m_SkillPointsUsedTracking; } set { m_SkillPointsUsedTracking = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedVeterinary
        { get { return m_SkillPointsUsedVeterinary; } set { m_SkillPointsUsedVeterinary = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedDetectHidden
        { get { return m_SkillPointsUsedDetectHidden; } set { m_SkillPointsUsedDetectHidden = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedHiding
        { get { return m_SkillPointsUsedHiding; } set { m_SkillPointsUsedHiding = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedLockpicking
        { get { return m_SkillPointsUsedLockpicking; } set { m_SkillPointsUsedLockpicking = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedPoisoning
        { get { return m_SkillPointsUsedPoisoning; } set { m_SkillPointsUsedPoisoning = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedRemoveTrap
        { get { return m_SkillPointsUsedRemoveTrap; } set { m_SkillPointsUsedRemoveTrap = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedSnooping
        { get { return m_SkillPointsUsedSnooping; } set { m_SkillPointsUsedSnooping = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedStealing
        { get { return m_SkillPointsUsedStealing; } set { m_SkillPointsUsedStealing = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedStealth
        { get { return m_SkillPointsUsedStealth; } set { m_SkillPointsUsedStealth = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedDiscordance
        { get { return m_SkillPointsUsedDiscordance; } set { m_SkillPointsUsedDiscordance = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedMusicianship
        { get { return m_SkillPointsUsedMusicianship; } set { m_SkillPointsUsedMusicianship = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedPeacemaking
        { get { return m_SkillPointsUsedPeacemaking; } set { m_SkillPointsUsedPeacemaking = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int SkillPointsUsedProvocation
        { get { return m_SkillPointsUsedProvocation; } set { m_SkillPointsUsedProvocation = value; } }		
		

		[CommandProperty( AccessLevel.GameMaster )]
		public string RankAlchemy 
		{
			get {return m_skillrankAlchemy; }
			set { m_skillrankAlchemy = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankBlacksmith 
		{
			get {return m_skillrankBlacksmith; }
			set { m_skillrankBlacksmith = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankCartography 
		{
			get {return m_skillrankCartography; }
			set { m_skillrankCartography = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankCarpentry 
		{
			get {return m_skillrankCarpentry; }
			set { m_skillrankCarpentry = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankCooking 
		{
			get {return m_skillrankCooking; }
			set { m_skillrankCooking = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankFletching 
		{
			get {return m_skillrankFletching; }
			set { m_skillrankFletching = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankInscribe 
		{
			get {return m_skillrankInscribe; }
			set { m_skillrankInscribe = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankTailoring 
		{
			get {return m_skillrankTailoring; }
			set { m_skillrankTailoring = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankTinkering 
		{
			get {return m_skillrankTinkering; }
			set { m_skillrankTinkering = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankDiscordance 
		{
			get {return m_skillrankDiscordance; }
			set { m_skillrankDiscordance = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankMusicianship 
		{
			get {return m_skillrankMusicianship; }
			set { m_skillrankMusicianship = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankPeacemaking 
		{
			get {return m_skillrankPeacemaking; }
			set { m_skillrankPeacemaking = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankProvocation 
		{
			get {return m_skillrankProvocation; }
			set { m_skillrankProvocation = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankChivalry 
		{
			get {return m_skillrankChivalry; }
			set { m_skillrankChivalry = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankEvalInt 
		{
			get {return m_skillrankEvalInt; }
			set { m_skillrankEvalInt = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankMagery 
		{
			get {return m_skillrankMagery; }
			set { m_skillrankMagery = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankMagicResist 
		{
			get {return m_skillrankMagicResist; }
			set { m_skillrankMagicResist = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankMeditation 
		{
			get {return m_skillrankMeditation; }
			set { m_skillrankMeditation = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankNecromancy 
		{
			get {return m_skillrankNecromancy; }
			set { m_skillrankNecromancy = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankSpiritSpeak 
		{
			get {return m_skillrankSpiritSpeak; }
			set { m_skillrankSpiritSpeak = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankNinjitsu 
		{
			get {return m_skillrankNinjitsu; }
			set { m_skillrankNinjitsu = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankBushido 
		{
			get {return m_skillrankBushido; }
			set { m_skillrankBushido = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankSpellweaving 
		{
			get {return m_skillrankSpellweaving; }
			set { m_skillrankSpellweaving = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankCamping 
		{
			get {return m_skillrankCamping; }
			set { m_skillrankCamping = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankFishing 
		{
			get {return m_skillrankFishing; }
			set { m_skillrankFishing = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankFocus 
		{
			get {return m_skillrankFocus; }
			set { m_skillrankFocus = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankHealing 
		{
			get {return m_skillrankHealing; }
			set { m_skillrankHealing = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankHerding 
		{
			get {return m_skillrankHerding; }
			set { m_skillrankHerding = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankLockpicking 
		{
			get {return m_skillrankLockpicking; }
			set { m_skillrankLockpicking = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankLumberjacking 
		{
			get {return m_skillrankLumberjacking; }
			set { m_skillrankLumberjacking = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankMining 
		{
			get {return m_skillrankMining; }
			set { m_skillrankMining = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankSnooping 
		{
			get {return m_skillrankSnooping; }
			set { m_skillrankSnooping = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankVeterinary 
		{
			get {return m_skillrankVeterinary; }
			set { m_skillrankVeterinary = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankArchery 
		{
			get {return m_skillrankArchery; }
			set { m_skillrankArchery = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankFencing 
		{
			get {return m_skillrankFencing; }
			set { m_skillrankFencing = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankMacing 
		{
			get {return m_skillrankMacing; }
			set { m_skillrankMacing = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankParry 
		{
			get {return m_skillrankParry; }
			set { m_skillrankParry = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankSwords 
		{
			get {return m_skillrankSwords; }
			set { m_skillrankSwords = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankTactics 
		{
			get {return m_skillrankTactics; }
			set { m_skillrankTactics = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankWrestling 
		{
			get {return m_skillrankWrestling; }
			set { m_skillrankWrestling = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankAnimalTaming 
		{
			get {return m_skillrankAnimalTaming; }
			set { m_skillrankAnimalTaming = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankBegging 
		{
			get {return m_skillrankBegging; }
			set { m_skillrankBegging = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankDetectHidden 
		{
			get {return m_skillrankDetectHidden; }
			set { m_skillrankDetectHidden = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankHiding 
		{
			get {return m_skillrankHiding; }
			set { m_skillrankHiding = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankRemoveTrap 
		{
			get {return m_skillrankRemoveTrap; }
			set { m_skillrankRemoveTrap = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankPoisoning 
		{
			get {return m_skillrankPoisoning; }
			set { m_skillrankPoisoning = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankStealing 
		{
			get {return m_skillrankStealing; }
			set { m_skillrankStealing = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankStealth 
		{
			get {return m_skillrankStealth; }
			set { m_skillrankStealth = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankTracking 
		{
			get {return m_skillrankTracking; }
			set { m_skillrankTracking = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankAnatomy 
		{
			get {return m_skillrankAnatomy; }
			set { m_skillrankAnatomy = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankMysticism
		{
			get {return m_skillrankMysticism; }
			set { m_skillrankMysticism = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankThrowing 
		{
			get {return m_skillrankThrowing; }
			set { m_skillrankThrowing = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankAnimalLore 
		{
			get {return m_skillrankAnimalLore; }
			set { m_skillrankAnimalLore = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankImbueing 
		{
			get {return m_skillrankImbueing; }
			set { m_skillrankImbueing = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankArmsLore 
		{
			get {return m_skillrankArmsLore; }
			set { m_skillrankArmsLore = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankForensics 
		{
			get {return m_skillrankForensics; }
			set { m_skillrankForensics = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankItemID 
		{
			get {return m_skillrankItemID; }
			set { m_skillrankItemID = value; InvalidateProperties(); } 
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string RankTasteID 
		{
			get {return m_skillrankTasteID; }
			set { m_skillrankTasteID = value; InvalidateProperties(); } 
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public string CustomTitle 
		{
			get {return m_customtitle; }
			set { m_customtitle = value; InvalidateProperties(); } 
		}
		
        [CommandProperty(AccessLevel.GameMaster)]
        public int Age
        {
            get { return m_age; }
            set { m_age = value; InvalidateProperties(); }
        }	
		[CommandProperty(AccessLevel.GameMaster)]
        public bool USkill_returntoashes 
		{ 
			get { return uniqueskill_returntoashes; } 
			set { uniqueskill_returntoashes = value; } 
		}
		[CommandProperty(AccessLevel.GameMaster)]
        public bool USkill_greenmage 
		{ 
			get { return uniqueskill_greenmage; } 
			set { uniqueskill_greenmage = value; } 
		}
		[CommandProperty(AccessLevel.GameMaster)]
        public bool USkill_murderer 
		{ 
			get { return uniqueskill_murderer; } 
			set { uniqueskill_murderer = value; } 
		}
		[CommandProperty(AccessLevel.GameMaster)]
        public bool USkill_treasuretrove 
		{ 
			get { return uniqueskill_treasuretrove; } 
			set { uniqueskill_treasuretrove = value; } 
		}
		[CommandProperty(AccessLevel.GameMaster)]
        public bool USkill_thrasher 
		{ 
			get { return uniqueskill_thrasher; } 
			set { uniqueskill_thrasher = value; } 
		}
		[CommandProperty(AccessLevel.GameMaster)]
        public bool USkill_petscompanion 
		{ 
			get { return uniqueskill_petscompanion; } 
			set { uniqueskill_petscompanion = value; } 
		}
		[CommandProperty(AccessLevel.GameMaster)]
        public bool USkill_assassinspoise 
		{ 
			get { return uniqueskill_assassinspoise; } 
			set { uniqueskill_assassinspoise = value; } 
		}
		[CommandProperty(AccessLevel.GameMaster)]
        public bool USkill_blackmage 
		{ 
			get { return uniqueskill_blackmage; } 
			set { uniqueskill_blackmage = value; } 
		}
		[CommandProperty(AccessLevel.GameMaster)]
        public bool USkill_reviver 
		{ 
			get { return uniqueskill_reviver; } 
			set { uniqueskill_reviver = value; } 
		}
		[CommandProperty(AccessLevel.GameMaster)]
        public bool USkill_whitemage 
		{ 
			get { return uniqueskill_whitemage; } 
			set { uniqueskill_whitemage = value; } 
		}
		[CommandProperty(AccessLevel.GameMaster)]
        public bool USkill_magicamp 
		{ 
			get { return uniqueskill_magicamp; } 
			set { uniqueskill_magicamp = value; } 
		}
		[CommandProperty(AccessLevel.GameMaster)]
        public bool USkill_pugilist 
		{ 
			get { return uniqueskill_pugilist; } 
			set { uniqueskill_pugilist = value; } 
		}
		[CommandProperty(AccessLevel.GameMaster)]
        public bool USkill_summoner 
		{ 
			get { return uniqueskill_summoner; } 
			set { uniqueskill_summoner = value; } 
		}
		[CommandProperty(AccessLevel.GameMaster)]
        public bool USkill_puppetry 
		{ 
			get { return uniqueskill_puppetry; } 
			set { uniqueskill_puppetry = value; } 
		}
		[CommandProperty(AccessLevel.GameMaster)]
        public bool USkill_rampart 
		{ 
			get { return uniqueskill_rampart; } 
			set { uniqueskill_rampart = value; } 
		}
		[CommandProperty(AccessLevel.GameMaster)]
        public bool USkill_concealment 
		{ 
			get { return uniqueskill_concealment; } 
			set { uniqueskill_concealment = value; } 
		}

        [CommandProperty(AccessLevel.GameMaster)]
        public int sRankQuestCompleted
        {
            get { return m_s_rankquestcompleted; }
            set { m_s_rankquestcompleted = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int aRankQuestCompleted
        {
            get { return m_a_rankquestcompleted; }
            set { m_a_rankquestcompleted = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int bRankQuestCompleted
        {
            get { return m_b_rankquestcompleted; }
            set { m_b_rankquestcompleted = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int cRankQuestCompleted
        {
            get { return m_c_rankquestcompleted; }
            set { m_c_rankquestcompleted = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int dRankQuestCompleted
        {
            get { return m_d_rankquestcompleted; }
            set { m_d_rankquestcompleted = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int eRankQuestCompleted
        {
            get { return m_e_rankquestcompleted; }
            set { m_e_rankquestcompleted = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int fRankQuestCompleted
        {
            get { return m_f_rankquestcompleted; }
            set { m_f_rankquestcompleted = value; InvalidateProperties(); }
        }
		[CommandProperty( AccessLevel.GameMaster )]
		public string PlayerRankLevel 
		{
			get {return m_ranklevel; }
			set { m_ranklevel = value; InvalidateProperties(); } 
		}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile Character_Owner { get{ return CharacterOwner; } set{ CharacterOwner = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Level
        {
            get { return m_level; }
            set { m_level = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int MaxLevel
        {
            get { return m_maxlevel; }
            set { m_maxlevel = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int Exp
        {
            get { return m_exp; }
            set { m_exp = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int ToLevel
        {
            get { return m_tolevel; }
            set { m_tolevel = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int GainedSkillPoints
        {
            get { return m_gainedskillpoints; }
            set { m_gainedskillpoints = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int TotalStatPoints
        {
            get { return m_totalstatpoints; }
            set { m_totalstatpoints = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int TotalSkillPoints
        {
            get { return m_totalskillpoints; }
            set { m_totalskillpoints = value; InvalidateProperties(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpAlchemy
        {
            get { return m_skillrankexpAlchemy; }
            set { m_skillrankexpAlchemy = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpBlacksmith
        {
            get { return m_skillrankexpBlacksmith; }
            set { m_skillrankexpBlacksmith = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpCartography
        {
            get { return m_skillrankexpCartography; }
            set { m_skillrankexpCartography = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpCarpentry
        {
            get { return m_skillrankexpCarpentry; }
            set { m_skillrankexpCarpentry = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpCooking
        {
            get { return m_skillrankexpCooking; }
            set { m_skillrankexpCooking = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpFletching
        {
            get { return m_skillrankexpFletching; }
            set { m_skillrankexpFletching = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpInscribe
        {
            get { return m_skillrankexpInscribe; }
            set { m_skillrankexpInscribe = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpTailoring
        {
            get { return m_skillrankexpTailoring; }
            set { m_skillrankexpTailoring = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpTinkering
        {
            get { return m_skillrankexpTinkering; }
            set { m_skillrankexpTinkering = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpDiscordance
        {
            get { return m_skillrankexpDiscordance; }
            set { m_skillrankexpDiscordance = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpMusicianship
        {
            get { return m_skillrankexpMusicianship; }
            set { m_skillrankexpMusicianship = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpPeacemaking
        {
            get { return m_skillrankexpPeacemaking; }
            set { m_skillrankexpPeacemaking = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpProvocation
        {
            get { return m_skillrankexpProvocation; }
            set { m_skillrankexpProvocation = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpChivalry
        {
            get { return m_skillrankexpChivalry; }
            set { m_skillrankexpChivalry = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpEvalInt
        {
            get { return m_skillrankexpEvalInt; }
            set { m_skillrankexpEvalInt = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpMagery
        {
            get { return m_skillrankexpMagery; }
            set { m_skillrankexpMagery = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpMagicResist
        {
            get { return m_skillrankexpMagicResist; }
            set { m_skillrankexpMagicResist = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpMeditation
        {
            get { return m_skillrankexpMeditation; }
            set { m_skillrankexpMeditation = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpNecromancy
        {
            get { return m_skillrankexpNecromancy; }
            set { m_skillrankexpNecromancy = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpSpiritSpeak
        {
            get { return m_skillrankexpSpiritSpeak; }
            set { m_skillrankexpSpiritSpeak = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpNinjitsu
        {
            get { return m_skillrankexpNinjitsu; }
            set { m_skillrankexpNinjitsu = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpBushido
        {
            get { return m_skillrankexpBushido; }
            set { m_skillrankexpBushido = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpSpellweaving
        {
            get { return m_skillrankexpSpellweaving; }
            set { m_skillrankexpSpellweaving = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpCamping
        {
            get { return m_skillrankexpCamping; }
            set { m_skillrankexpCamping = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpFishing
        {
            get { return m_skillrankexpFishing; }
            set { m_skillrankexpFishing = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpFocus
        {
            get { return m_skillrankexpFocus; }
            set { m_skillrankexpFocus = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpHealing
        {
            get { return m_skillrankexpHealing; }
            set { m_skillrankexpHealing = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpHerding
        {
            get { return m_skillrankexpHerding; }
            set { m_skillrankexpHerding = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpLockpicking
        {
            get { return m_skillrankexpLockpicking; }
            set { m_skillrankexpLockpicking = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpLumberjacking
        {
            get { return m_skillrankexpLumberjacking; }
            set { m_skillrankexpLumberjacking = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpMining
        {
            get { return m_skillrankexpMining; }
            set { m_skillrankexpMining = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpSnooping
        {
            get { return m_skillrankexpSnooping; }
            set { m_skillrankexpSnooping = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpVeterinary
        {
            get { return m_skillrankexpVeterinary; }
            set { m_skillrankexpVeterinary = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpArchery
        {
            get { return m_skillrankexpArchery; }
            set { m_skillrankexpArchery = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpFencing
        {
            get { return m_skillrankexpFencing; }
            set { m_skillrankexpFencing = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpMacing
        {
            get { return m_skillrankexpMacing; }
            set { m_skillrankexpMacing = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpParry
        {
            get { return m_skillrankexpParry; }
            set { m_skillrankexpParry = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpSwords
        {
            get { return m_skillrankexpSwords; }
            set { m_skillrankexpSwords = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpTactics
        {
            get { return m_skillrankexpTactics; }
            set { m_skillrankexpTactics = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpWrestling
        {
            get { return m_skillrankexpWrestling; }
            set { m_skillrankexpWrestling = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpAnimalTaming
        {
            get { return m_skillrankexpAnimalTaming; }
            set { m_skillrankexpAnimalTaming = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpBegging
        {
            get { return m_skillrankexpBegging; }
            set { m_skillrankexpBegging = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpDetectHidden
        {
            get { return m_skillrankexpDetectHidden; }
            set { m_skillrankexpDetectHidden = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpHiding
        {
            get { return m_skillrankexpHiding; }
            set { m_skillrankexpHiding = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpRemoveTrap
        {
            get { return m_skillrankexpRemoveTrap; }
            set { m_skillrankexpRemoveTrap = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpPoisoning
        {
            get { return m_skillrankexpPoisoning; }
            set { m_skillrankexpPoisoning = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpStealing
        {
            get { return m_skillrankexpStealing; }
            set { m_skillrankexpStealing = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpStealth
        {
            get { return m_skillrankexpStealth; }
            set { m_skillrankexpStealth = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpTracking
        {
            get { return m_skillrankexpTracking; }
            set { m_skillrankexpTracking = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpAnatomy
        {
            get { return m_skillrankexpAnatomy; }
            set { m_skillrankexpAnatomy = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpAnimalLore
        {
            get { return m_skillrankexpAnimalLore; }
            set { m_skillrankexpAnimalLore = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpArmsLore
        {
            get { return m_skillrankexpArmsLore; }
            set { m_skillrankexpArmsLore = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpForensics
        {
            get { return m_skillrankexpForensics; }
            set { m_skillrankexpForensics = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpItemID
        {
            get { return m_skillrankexpItemID; }
            set { m_skillrankexpItemID = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpTasteID
        {
            get { return m_skillrankexpTasteID; }
            set { m_skillrankexpTasteID = value; InvalidateProperties(); }
        }	
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpThrowing
        {
            get { return m_skillrankexpThrowing; }
            set { m_skillrankexpThrowing = value; InvalidateProperties(); }
        }			
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpImbueing
        {
            get { return m_skillrankexpImbueing; }
            set { m_skillrankexpImbueing = value; InvalidateProperties(); }
        }		
        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillrankexpMysticism
        {
            get { return m_skillrankexpMysticism; }
            set { m_skillrankexpMysticism = value; InvalidateProperties(); }
        }	

		[Constructable]
		public RankDatabase() : base( 0x3F1A )
		{
			LootType = LootType.Blessed;
			Visible = false;
			Movable = false;
			Weight = 1.0;
			Name = "Rank Database Statue";
		}

		public override bool DisplayLootType{ get{ return false; } }
		public override bool DisplayWeight{ get{ return false; } }


		public RankDatabase( Serial serial ) : base( serial )
		{
		}
		
		public static RankDatabase GetDB( Mobile m )
		{
			if (m == null || m.BankBox == null) return null;
			foreach ( Item item in m.BankBox.Items )
			{
				if ( item is RankDatabase )
				{
					RankDatabase db = (RankDatabase)item;
					if ( db.CharacterOwner == m )
					{
						return db;
					}
				}
			}
			return null;
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int)0 ); // version
			writer.Write( (Mobile)CharacterOwner );
			writer.Write((int) m_level);
			writer.Write((int) m_maxlevel);
			writer.Write((int) m_exp);
			writer.Write((int) m_tolevel);
			writer.Write((int) m_gainedskillpoints);
			writer.Write((int) m_totalstatpoints);
			writer.Write((int) m_totalskillpoints);
			writer.Write(m_ranklevel);
			writer.Write((int) m_f_rankquestcompleted);
			writer.Write((int) m_e_rankquestcompleted);
			writer.Write((int) m_d_rankquestcompleted);
			writer.Write((int) m_c_rankquestcompleted);
			writer.Write((int) m_b_rankquestcompleted);
			writer.Write((int) m_a_rankquestcompleted);
			writer.Write((int) m_s_rankquestcompleted);
			writer.Write((bool)uniqueskill_concealment);
			writer.Write((bool)uniqueskill_rampart);
			writer.Write((bool)uniqueskill_puppetry);
			writer.Write((bool)uniqueskill_summoner);
			writer.Write((bool)uniqueskill_pugilist);
			writer.Write((bool)uniqueskill_magicamp);
			writer.Write((bool)uniqueskill_whitemage);
			writer.Write((bool)uniqueskill_reviver);
			writer.Write((bool)uniqueskill_blackmage);
			writer.Write((bool)uniqueskill_assassinspoise);
			writer.Write((bool)uniqueskill_petscompanion);
			writer.Write((bool)uniqueskill_thrasher);
			writer.Write((bool)uniqueskill_treasuretrove);
			writer.Write((bool)uniqueskill_murderer);
			writer.Write((bool)uniqueskill_greenmage);
			writer.Write((bool)uniqueskill_returntoashes);
			writer.Write((bool)uniqueskill_smitheseyes);
			writer.Write((int) m_age);
			writer.Write(m_customtitle);
			writer.Write(m_skillrankAlchemy);
			writer.Write(m_skillrankBlacksmith);
			writer.Write(m_skillrankCartography);
			writer.Write(m_skillrankCarpentry);
			writer.Write(m_skillrankCooking);
			writer.Write(m_skillrankFletching);
			writer.Write(m_skillrankInscribe);
			writer.Write(m_skillrankTailoring);
			writer.Write(m_skillrankTinkering);
			writer.Write(m_skillrankDiscordance);
			writer.Write(m_skillrankMusicianship);
			writer.Write(m_skillrankPeacemaking);
			writer.Write(m_skillrankProvocation);
			writer.Write(m_skillrankChivalry);
			writer.Write(m_skillrankEvalInt);
			writer.Write(m_skillrankMagery);
			writer.Write(m_skillrankMagicResist);
			writer.Write(m_skillrankMeditation);
			writer.Write(m_skillrankNecromancy);
			writer.Write(m_skillrankSpiritSpeak);
			writer.Write(m_skillrankNinjitsu);
			writer.Write(m_skillrankBushido);
			writer.Write(m_skillrankSpellweaving);
			writer.Write(m_skillrankCamping);
			writer.Write(m_skillrankFishing);
			writer.Write(m_skillrankFocus);
			writer.Write(m_skillrankHealing);
			writer.Write(m_skillrankHerding);
			writer.Write(m_skillrankLockpicking);
			writer.Write(m_skillrankLumberjacking);
			writer.Write(m_skillrankMining);
			writer.Write(m_skillrankSnooping);
			writer.Write(m_skillrankVeterinary);
			writer.Write(m_skillrankArchery);
			writer.Write(m_skillrankFencing);
			writer.Write(m_skillrankMacing);
			writer.Write(m_skillrankParry);
			writer.Write(m_skillrankSwords);
			writer.Write(m_skillrankTactics);
			writer.Write(m_skillrankWrestling);
			writer.Write(m_skillrankAnimalTaming);
			writer.Write(m_skillrankBegging);
			writer.Write(m_skillrankDetectHidden);
			writer.Write(m_skillrankHiding);
			writer.Write(m_skillrankRemoveTrap);
			writer.Write(m_skillrankPoisoning);
			writer.Write(m_skillrankStealing);
			writer.Write(m_skillrankStealth);
			writer.Write(m_skillrankTracking);
			writer.Write(m_skillrankAnatomy);
			writer.Write(m_skillrankAnimalLore);
			writer.Write(m_skillrankArmsLore);
			writer.Write(m_skillrankForensics);
			writer.Write(m_skillrankItemID);
			writer.Write(m_skillrankTasteID);
			writer.Write(m_skillrankThrowing);
			writer.Write(m_skillrankImbueing);
			writer.Write(m_skillrankMysticism);
            writer.Write((int) m_StatPoints);
            writer.Write((int) m_StrPointsUsed);
            writer.Write((int) m_DexPointsUsed);
            writer.Write((int) m_IntPointsUsed);
            writer.Write((int) m_TotalStatPointsAquired);
            writer.Write((int) m_TotalSkillPointsUsed);			
			writer.Write((int) m_SkillPointsUsedArmsLore);
			writer.Write((int) m_SkillPointsUsedBegging);
			writer.Write((int) m_SkillPointsUsedCamping);
			writer.Write((int) m_SkillPointsUsedCartography);
			writer.Write((int) m_SkillPointsUsedForensics);
			writer.Write((int) m_SkillPointsUsedItemID);
			writer.Write((int) m_SkillPointsUsedTasteID);
			writer.Write((int) m_SkillPointsUsedAnatomy);
			writer.Write((int) m_SkillPointsUsedArchery);
			writer.Write((int) m_SkillPointsUsedFencing);
			writer.Write((int) m_SkillPointsUsedFocus);
			writer.Write((int) m_SkillPointsUsedHealing);
			writer.Write((int) m_SkillPointsUsedMacing);
			writer.Write((int) m_SkillPointsUsedParry);
			writer.Write((int) m_SkillPointsUsedSwords);
			writer.Write((int) m_SkillPointsUsedTactics);
			writer.Write((int) m_SkillPointsUsedWrestling);
			writer.Write((int) m_SkillPointsUsedThrowing);
			writer.Write((int) m_SkillPointsUsedAlchemy);
			writer.Write((int) m_SkillPointsUsedBlacksmith);
			writer.Write((int) m_SkillPointsUsedFletching);
			writer.Write((int) m_SkillPointsUsedCarpentry);
			writer.Write((int) m_SkillPointsUsedCooking);
			writer.Write((int) m_SkillPointsUsedInscribe);
			writer.Write((int) m_SkillPointsUsedLumberjacking);
			writer.Write((int) m_SkillPointsUsedMining);
			writer.Write((int) m_SkillPointsUsedTailoring);
			writer.Write((int) m_SkillPointsUsedTinkering);
			writer.Write((int) m_SkillPointsUsedImbuing);
			writer.Write((int) m_SkillPointsUsedBushido);
			writer.Write((int) m_SkillPointsUsedChivalry);
			writer.Write((int) m_SkillPointsUsedEvalInt);
			writer.Write((int) m_SkillPointsUsedMagery);
			writer.Write((int) m_SkillPointsUsedNecromancy);
			writer.Write((int) m_SkillPointsUsedNinjitsu);
			writer.Write((int) m_SkillPointsUsedMagicResist);
			writer.Write((int) m_SkillPointsUsedSpellweaving);
			writer.Write((int) m_SkillPointsUsedSpiritSpeak);
			writer.Write((int) m_SkillPointsUsedMysticism);
			writer.Write((int) m_SkillPointsUsedAnimalLore);
			writer.Write((int) m_SkillPointsUsedAnimalTaming);
			writer.Write((int) m_SkillPointsUsedFishing);
			writer.Write((int) m_SkillPointsUsedHerding);
			writer.Write((int) m_SkillPointsUsedTracking);
			writer.Write((int) m_SkillPointsUsedVeterinary);
			writer.Write((int) m_SkillPointsUsedDetectHidden);
			writer.Write((int) m_SkillPointsUsedHiding);
			writer.Write((int) m_SkillPointsUsedLockpicking);
			writer.Write((int) m_SkillPointsUsedPoisoning);
			writer.Write((int) m_SkillPointsUsedRemoveTrap);
			writer.Write((int) m_SkillPointsUsedSnooping);
			writer.Write((int) m_SkillPointsUsedStealing);
			writer.Write((int) m_SkillPointsUsedStealth);
			writer.Write((int) m_SkillPointsUsedDiscordance);
			writer.Write((int) m_SkillPointsUsedMusicianship);
			writer.Write((int) m_SkillPointsUsedPeacemaking);
			writer.Write((int) m_SkillPointsUsedProvocation);
			writer.Write((int) m_SkillPointsUsedMeditation);
			writer.Write((int) m_skillrankexpAlchemy);
			writer.Write((int) m_skillrankexpBlacksmith);
			writer.Write((int) m_skillrankexpCartography);
			writer.Write((int) m_skillrankexpCarpentry);
			writer.Write((int) m_skillrankexpCooking);
			writer.Write((int) m_skillrankexpFletching);
			writer.Write((int) m_skillrankexpInscribe);
			writer.Write((int) m_skillrankexpTailoring);
			writer.Write((int) m_skillrankexpTinkering);
			writer.Write((int) m_skillrankexpDiscordance);
			writer.Write((int) m_skillrankexpMusicianship);
			writer.Write((int) m_skillrankexpPeacemaking);
			writer.Write((int) m_skillrankexpProvocation);
			writer.Write((int) m_skillrankexpChivalry);
			writer.Write((int) m_skillrankexpEvalInt);
			writer.Write((int) m_skillrankexpMagery);
			writer.Write((int) m_skillrankexpMagicResist);
			writer.Write((int) m_skillrankexpMeditation);
			writer.Write((int) m_skillrankexpNecromancy);
			writer.Write((int) m_skillrankexpSpiritSpeak);
			writer.Write((int) m_skillrankexpNinjitsu);
			writer.Write((int) m_skillrankexpBushido);
			writer.Write((int) m_skillrankexpSpellweaving);
			writer.Write((int) m_skillrankexpCamping);
			writer.Write((int) m_skillrankexpFishing);
			writer.Write((int) m_skillrankexpFocus);
			writer.Write((int) m_skillrankexpHealing);
			writer.Write((int) m_skillrankexpHerding);
			writer.Write((int) m_skillrankexpLockpicking);
			writer.Write((int) m_skillrankexpLumberjacking);
			writer.Write((int) m_skillrankexpMining);
			writer.Write((int) m_skillrankexpSnooping);
			writer.Write((int) m_skillrankexpVeterinary);
			writer.Write((int) m_skillrankexpArchery);
			writer.Write((int) m_skillrankexpFencing);
			writer.Write((int) m_skillrankexpMacing);
			writer.Write((int) m_skillrankexpParry);
			writer.Write((int) m_skillrankexpSwords);
			writer.Write((int) m_skillrankexpTactics);
			writer.Write((int) m_skillrankexpWrestling);
			writer.Write((int) m_skillrankexpAnimalTaming);
			writer.Write((int) m_skillrankexpBegging);
			writer.Write((int) m_skillrankexpDetectHidden);
			writer.Write((int) m_skillrankexpHiding);
			writer.Write((int) m_skillrankexpRemoveTrap);
			writer.Write((int) m_skillrankexpPoisoning);
			writer.Write((int) m_skillrankexpStealing);
			writer.Write((int) m_skillrankexpStealth);
			writer.Write((int) m_skillrankexpTracking);
			writer.Write((int) m_skillrankexpAnatomy);
			writer.Write((int) m_skillrankexpAnimalLore);
			writer.Write((int) m_skillrankexpArmsLore);
			writer.Write((int) m_skillrankexpForensics);
			writer.Write((int) m_skillrankexpItemID);
			writer.Write((int) m_skillrankexpTasteID);
			writer.Write((int) m_skillrankexpThrowing);
			writer.Write((int) m_skillrankexpImbueing);
			writer.Write((int) m_skillrankexpMysticism);
			writer.Write((int) m_l2to20multipier);
			writer.Write((int) m_l21to40multiplier);
			writer.Write((int) m_l41to60multiplier);
			writer.Write((int) m_l61to70multiplier);
			writer.Write((int) m_l71to80multiplier);
			writer.Write((int) m_l81to90multipier);
			writer.Write((int) m_l91to100multipier);
			writer.Write((int) m_l101to110multiplier);
			writer.Write((int) m_l111to120multiplier);
			writer.Write((int) m_l121to130multiplier);
			writer.Write((int) m_l131to140multiplier);
			writer.Write((int) m_l141to150multiplier);
			writer.Write((int) m_l151to160multiplier);
			writer.Write((int) m_l161to170multiplier);
			writer.Write((int) m_l171to180multiplier);
			writer.Write((int) m_l181to190multiplier);
			writer.Write((int) m_l191to200multiplier);
			writer.Write((int) m_below20);
			writer.Write((int) m_below40);
			writer.Write((int) m_below60);
			writer.Write((int) m_below70);
			writer.Write((int) m_below80);
			writer.Write((int) m_below90);
			writer.Write((int) m_below100);
			writer.Write((int) m_below110);
			writer.Write((int) m_below120);
			writer.Write((int) m_below130);
			writer.Write((int) m_below140);
			writer.Write((int) m_below150);
			writer.Write((int) m_below160);
			writer.Write((int) m_below170);
			writer.Write((int) m_below180);
			writer.Write((int) m_below190);
			writer.Write((int) m_below200);
			writer.Write((int) m_totalKillsWithSwords);
			writer.Write((int) m_totalKillsWithFencing);
			writer.Write((int) m_totalKillswithMacing);
			writer.Write((int) m_totalKillsWithHands);
			writer.Write((int) m_totalKillsWithArchery);
			writer.Write((int) m_totalKillsWithInstruments);
			writer.Write((int) m_potiontotalused);
			writer.Write((int) m_potionhealused);
			writer.Write((int) m_potioncureused);
			writer.Write((int) m_potionexplosionused);			
			writer.Write((int) m_potionpoisonedused);			
			writer.Write((int) m_timesinstrumentplayed);			
			writer.Write((int) m_bandagesused);			
			writer.Write((int) m_tooluses);			
			writer.Write((int) m_doorsopened);		
			writer.Write((bool)m_rankquestactive);
			writer.Write(m_rankquesttype);
			writer.Write((bool)m_rankquestobjectivesComplete);
			writer.Write((Mobile)RankQuestEscort);
			writer.Write((Mobile)RankQuestEscort2);
			writer.Write((Mobile)RankQuestEscort3);
			writer.Write((Mobile)RankQuestEscort4);
			writer.Write(m_rankquestcreaturenameone);
			writer.Write(m_rankquestcreaturenametwo);
			writer.Write(m_rankquestcreaturenamethree);
			writer.Write(m_rankquestcreaturenamefour);
			writer.Write(m_rankquestcreaturenamefive);
			writer.Write(m_rankquestcreaturenamesix);
			writer.Write(m_rankquestcreaturenameseven);
			writer.Write(m_rankquestcreaturenameeight);
			writer.Write(m_rankquestcreaturenamenine);
			writer.Write(m_rankquestcreaturenameten);
			writer.Write((int) m_rankquestobjectiveone);
			writer.Write((int) m_rankquestobjectivetwo);
			writer.Write((int) m_rankquestobjectivethree);
			writer.Write((int) m_rankquestobjectivefour);
			writer.Write((int) m_rankquestobjectivefive);
			writer.Write((int) m_rankquestobjectivesix);
			writer.Write((int) m_rankquestobjectiveseven);
			writer.Write((int) m_rankquestobjectiveeight);
			writer.Write((int) m_rankquestobjectivenine);
			writer.Write((int) m_rankquestobjectiveten);	
			writer.Write(m_EscortDestination);
		}
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			CharacterOwner = reader.ReadMobile();
			m_level = reader.ReadInt();
			m_maxlevel = reader.ReadInt();
			m_exp = reader.ReadInt();
			m_tolevel = reader.ReadInt();
			m_gainedskillpoints = reader.ReadInt();
			m_totalstatpoints = reader.ReadInt();
			m_totalskillpoints = reader.ReadInt();
			m_ranklevel = reader.ReadString();
			m_f_rankquestcompleted = reader.ReadInt();
			m_e_rankquestcompleted = reader.ReadInt();
			m_d_rankquestcompleted = reader.ReadInt();
			m_c_rankquestcompleted = reader.ReadInt();
			m_b_rankquestcompleted = reader.ReadInt();
			m_a_rankquestcompleted = reader.ReadInt();
			m_s_rankquestcompleted = reader.ReadInt();
			uniqueskill_concealment = reader.ReadBool();
			uniqueskill_rampart = reader.ReadBool();
			uniqueskill_puppetry = reader.ReadBool();
			uniqueskill_summoner = reader.ReadBool();
			uniqueskill_pugilist = reader.ReadBool();
			uniqueskill_magicamp = reader.ReadBool();
			uniqueskill_whitemage = reader.ReadBool();
			uniqueskill_reviver = reader.ReadBool();
			uniqueskill_blackmage = reader.ReadBool();
			uniqueskill_assassinspoise = reader.ReadBool();
			uniqueskill_petscompanion = reader.ReadBool();
			uniqueskill_thrasher = reader.ReadBool();
			uniqueskill_treasuretrove = reader.ReadBool();
			uniqueskill_murderer = reader.ReadBool();
			uniqueskill_greenmage = reader.ReadBool();
			uniqueskill_returntoashes = reader.ReadBool();
			uniqueskill_smitheseyes = reader.ReadBool();
			m_age = reader.ReadInt();
			m_customtitle = reader.ReadString();
			m_skillrankAlchemy = reader.ReadString();
			m_skillrankBlacksmith = reader.ReadString();
			m_skillrankCartography = reader.ReadString();
			m_skillrankCarpentry = reader.ReadString();
			m_skillrankCooking = reader.ReadString();
			m_skillrankFletching = reader.ReadString();
			m_skillrankInscribe = reader.ReadString();
			m_skillrankTailoring = reader.ReadString();
			m_skillrankTinkering = reader.ReadString();
			m_skillrankDiscordance = reader.ReadString();
			m_skillrankMusicianship = reader.ReadString();
			m_skillrankPeacemaking = reader.ReadString();
			m_skillrankProvocation = reader.ReadString();
			m_skillrankChivalry = reader.ReadString();
			m_skillrankEvalInt = reader.ReadString();
			m_skillrankMagery = reader.ReadString();
			m_skillrankMagicResist = reader.ReadString();
			m_skillrankMeditation = reader.ReadString();
			m_skillrankNecromancy = reader.ReadString();
			m_skillrankSpiritSpeak = reader.ReadString();
			m_skillrankNinjitsu = reader.ReadString();
			m_skillrankBushido = reader.ReadString();
			m_skillrankSpellweaving = reader.ReadString();
			m_skillrankCamping = reader.ReadString();
			m_skillrankFishing = reader.ReadString();
			m_skillrankFocus = reader.ReadString();
			m_skillrankHealing = reader.ReadString();
			m_skillrankHerding = reader.ReadString();
			m_skillrankLockpicking = reader.ReadString();
			m_skillrankLumberjacking = reader.ReadString();
			m_skillrankMining = reader.ReadString();
			m_skillrankSnooping = reader.ReadString();
			m_skillrankVeterinary = reader.ReadString();
			m_skillrankArchery = reader.ReadString();
			m_skillrankFencing = reader.ReadString();
			m_skillrankMacing = reader.ReadString();
			m_skillrankParry = reader.ReadString();
			m_skillrankSwords = reader.ReadString();
			m_skillrankTactics = reader.ReadString();
			m_skillrankWrestling = reader.ReadString();
			m_skillrankAnimalTaming = reader.ReadString();
			m_skillrankBegging = reader.ReadString();
			m_skillrankDetectHidden = reader.ReadString();
			m_skillrankHiding = reader.ReadString();
			m_skillrankRemoveTrap = reader.ReadString();
			m_skillrankPoisoning = reader.ReadString();
			m_skillrankStealing = reader.ReadString();
			m_skillrankStealth = reader.ReadString();
			m_skillrankTracking = reader.ReadString();
			m_skillrankAnatomy = reader.ReadString();
			m_skillrankAnimalLore = reader.ReadString();
			m_skillrankArmsLore = reader.ReadString();
			m_skillrankForensics = reader.ReadString();
			m_skillrankItemID = reader.ReadString();
			m_skillrankTasteID = reader.ReadString();
			m_skillrankThrowing = reader.ReadString();
			m_skillrankImbueing = reader.ReadString();
			m_skillrankMysticism = reader.ReadString();
			m_StatPoints = reader.ReadInt();
			m_StrPointsUsed = reader.ReadInt();
			m_DexPointsUsed = reader.ReadInt();
			m_IntPointsUsed = reader.ReadInt();
			m_TotalStatPointsAquired = reader.ReadInt();
			m_TotalSkillPointsUsed = reader.ReadInt();
			m_SkillPointsUsedArmsLore = reader.ReadInt();
			m_SkillPointsUsedBegging = reader.ReadInt();
			m_SkillPointsUsedCamping = reader.ReadInt();
			m_SkillPointsUsedCartography = reader.ReadInt();
			m_SkillPointsUsedForensics = reader.ReadInt();
			m_SkillPointsUsedItemID = reader.ReadInt();
			m_SkillPointsUsedTasteID = reader.ReadInt();
			m_SkillPointsUsedAnatomy = reader.ReadInt();
			m_SkillPointsUsedArchery = reader.ReadInt();
			m_SkillPointsUsedFencing = reader.ReadInt();
			m_SkillPointsUsedFocus = reader.ReadInt();
			m_SkillPointsUsedHealing = reader.ReadInt();
			m_SkillPointsUsedMacing = reader.ReadInt();
			m_SkillPointsUsedParry = reader.ReadInt();
			m_SkillPointsUsedSwords = reader.ReadInt();
			m_SkillPointsUsedTactics = reader.ReadInt();
			m_SkillPointsUsedWrestling = reader.ReadInt();
			m_SkillPointsUsedThrowing = reader.ReadInt();
			m_SkillPointsUsedAlchemy = reader.ReadInt();
			m_SkillPointsUsedBlacksmith = reader.ReadInt();
			m_SkillPointsUsedFletching = reader.ReadInt();
			m_SkillPointsUsedCarpentry = reader.ReadInt();
			m_SkillPointsUsedCooking = reader.ReadInt();
			m_SkillPointsUsedInscribe = reader.ReadInt();
			m_SkillPointsUsedLumberjacking = reader.ReadInt();
			m_SkillPointsUsedMining = reader.ReadInt();
			m_SkillPointsUsedTailoring = reader.ReadInt();
			m_SkillPointsUsedTinkering = reader.ReadInt();
			m_SkillPointsUsedImbuing = reader.ReadInt();
			m_SkillPointsUsedBushido = reader.ReadInt();
			m_SkillPointsUsedChivalry = reader.ReadInt();
			m_SkillPointsUsedEvalInt = reader.ReadInt();
			m_SkillPointsUsedMagery = reader.ReadInt();
			m_SkillPointsUsedNecromancy = reader.ReadInt();
			m_SkillPointsUsedNinjitsu = reader.ReadInt();
			m_SkillPointsUsedMagicResist = reader.ReadInt();
			m_SkillPointsUsedSpellweaving = reader.ReadInt();
			m_SkillPointsUsedSpiritSpeak = reader.ReadInt();
			m_SkillPointsUsedMysticism = reader.ReadInt();
			m_SkillPointsUsedAnimalLore = reader.ReadInt();
			m_SkillPointsUsedAnimalTaming = reader.ReadInt();
			m_SkillPointsUsedFishing = reader.ReadInt();
			m_SkillPointsUsedHerding = reader.ReadInt();
			m_SkillPointsUsedTracking = reader.ReadInt();
			m_SkillPointsUsedVeterinary = reader.ReadInt();
			m_SkillPointsUsedDetectHidden = reader.ReadInt();
			m_SkillPointsUsedHiding = reader.ReadInt();
			m_SkillPointsUsedLockpicking = reader.ReadInt();
			m_SkillPointsUsedPoisoning = reader.ReadInt();
			m_SkillPointsUsedRemoveTrap = reader.ReadInt();
			m_SkillPointsUsedSnooping = reader.ReadInt();
			m_SkillPointsUsedStealing = reader.ReadInt();
			m_SkillPointsUsedStealth = reader.ReadInt();
			m_SkillPointsUsedDiscordance = reader.ReadInt();
			m_SkillPointsUsedMusicianship = reader.ReadInt();
			m_SkillPointsUsedPeacemaking = reader.ReadInt();
			m_SkillPointsUsedProvocation = reader.ReadInt();	
			m_SkillPointsUsedMeditation = reader.ReadInt();
			m_skillrankexpAlchemy = reader.ReadInt();
			m_skillrankexpBlacksmith = reader.ReadInt();
			m_skillrankexpCartography = reader.ReadInt();
			m_skillrankexpCarpentry = reader.ReadInt();
			m_skillrankexpCooking = reader.ReadInt();
			m_skillrankexpFletching = reader.ReadInt();
			m_skillrankexpInscribe = reader.ReadInt();
			m_skillrankexpTailoring = reader.ReadInt();
			m_skillrankexpTinkering = reader.ReadInt();
			m_skillrankexpDiscordance = reader.ReadInt();
			m_skillrankexpMusicianship = reader.ReadInt();
			m_skillrankexpPeacemaking = reader.ReadInt();
			m_skillrankexpProvocation = reader.ReadInt();
			m_skillrankexpChivalry = reader.ReadInt();
			m_skillrankexpEvalInt = reader.ReadInt();
			m_skillrankexpMagery = reader.ReadInt();
			m_skillrankexpMagicResist = reader.ReadInt();
			m_skillrankexpMeditation = reader.ReadInt();
			m_skillrankexpNecromancy = reader.ReadInt();
			m_skillrankexpSpiritSpeak = reader.ReadInt();
			m_skillrankexpNinjitsu = reader.ReadInt();
			m_skillrankexpBushido = reader.ReadInt();
			m_skillrankexpSpellweaving = reader.ReadInt();
			m_skillrankexpCamping = reader.ReadInt();
			m_skillrankexpFishing = reader.ReadInt();
			m_skillrankexpFocus = reader.ReadInt();
			m_skillrankexpHealing = reader.ReadInt();
			m_skillrankexpHerding = reader.ReadInt();
			m_skillrankexpLockpicking = reader.ReadInt();
			m_skillrankexpLumberjacking = reader.ReadInt();
			m_skillrankexpMining = reader.ReadInt();
			m_skillrankexpSnooping = reader.ReadInt();
			m_skillrankexpVeterinary = reader.ReadInt();
			m_skillrankexpArchery = reader.ReadInt();
			m_skillrankexpFencing = reader.ReadInt();
			m_skillrankexpMacing = reader.ReadInt();
			m_skillrankexpParry = reader.ReadInt();
			m_skillrankexpSwords = reader.ReadInt();
			m_skillrankexpTactics = reader.ReadInt();
			m_skillrankexpWrestling = reader.ReadInt();
			m_skillrankexpAnimalTaming = reader.ReadInt();
			m_skillrankexpBegging = reader.ReadInt();
			m_skillrankexpDetectHidden = reader.ReadInt();
			m_skillrankexpHiding = reader.ReadInt();
			m_skillrankexpRemoveTrap = reader.ReadInt();
			m_skillrankexpPoisoning = reader.ReadInt();
			m_skillrankexpStealing = reader.ReadInt();
			m_skillrankexpStealth = reader.ReadInt();
			m_skillrankexpTracking = reader.ReadInt();
			m_skillrankexpAnatomy = reader.ReadInt();
			m_skillrankexpAnimalLore = reader.ReadInt();
			m_skillrankexpArmsLore = reader.ReadInt();
			m_skillrankexpForensics = reader.ReadInt();
			m_skillrankexpItemID = reader.ReadInt();
			m_skillrankexpTasteID = reader.ReadInt();
			m_skillrankexpThrowing = reader.ReadInt();
			m_skillrankexpImbueing = reader.ReadInt();
			m_skillrankexpMysticism = reader.ReadInt();
			m_l2to20multipier = reader.ReadInt();
			m_l21to40multiplier = reader.ReadInt();
			m_l41to60multiplier = reader.ReadInt();
			m_l61to70multiplier = reader.ReadInt();
			m_l71to80multiplier = reader.ReadInt();
			m_l81to90multipier = reader.ReadInt();
			m_l91to100multipier = reader.ReadInt();
			m_l101to110multiplier = reader.ReadInt();
			m_l111to120multiplier = reader.ReadInt();
			m_l121to130multiplier = reader.ReadInt();
			m_l131to140multiplier = reader.ReadInt();
			m_l141to150multiplier = reader.ReadInt();
			m_l151to160multiplier = reader.ReadInt();
			m_l161to170multiplier = reader.ReadInt();
			m_l171to180multiplier = reader.ReadInt();
			m_l181to190multiplier = reader.ReadInt();
			m_l191to200multiplier = reader.ReadInt();
			m_below20 = reader.ReadInt();
			m_below40 = reader.ReadInt();
			m_below60 = reader.ReadInt();
			m_below70 = reader.ReadInt();
			m_below80 = reader.ReadInt();
			m_below90 = reader.ReadInt();
			m_below100 = reader.ReadInt();
			m_below110 = reader.ReadInt();
			m_below120 = reader.ReadInt();
			m_below130 = reader.ReadInt();
			m_below140 = reader.ReadInt();
			m_below150 = reader.ReadInt();
			m_below160 = reader.ReadInt();
			m_below170 = reader.ReadInt();
			m_below180 = reader.ReadInt();
			m_below190 = reader.ReadInt();
			m_below200 = reader.ReadInt();
			m_totalKillsWithSwords = reader.ReadInt();
			m_totalKillsWithFencing = reader.ReadInt();
			m_totalKillswithMacing = reader.ReadInt();
			m_totalKillsWithHands = reader.ReadInt();
			m_totalKillsWithArchery = reader.ReadInt();
			m_totalKillsWithInstruments = reader.ReadInt();
			m_potionexplosionused = reader.ReadInt();
			m_potioncureused = reader.ReadInt();
			m_potionhealused = reader.ReadInt();
			m_potiontotalused = reader.ReadInt();
			m_potionpoisonedused = reader.ReadInt();
			m_timesinstrumentplayed = reader.ReadInt();
			m_bandagesused = reader.ReadInt();
			m_tooluses = reader.ReadInt();
			m_doorsopened = reader.ReadInt();
			m_rankquestactive = reader.ReadBool();
			m_rankquesttype = reader.ReadString();
			m_rankquestobjectivesComplete = reader.ReadBool();
			RankQuestEscort = reader.ReadMobile();
			RankQuestEscort2 = reader.ReadMobile();
			RankQuestEscort3 = reader.ReadMobile();
			RankQuestEscort4 = reader.ReadMobile();
			m_rankquestcreaturenameone = reader.ReadString();
			m_rankquestcreaturenametwo = reader.ReadString();
			m_rankquestcreaturenamethree = reader.ReadString();
			m_rankquestcreaturenamefour = reader.ReadString();
			m_rankquestcreaturenamefive = reader.ReadString();
			m_rankquestcreaturenamesix = reader.ReadString();
			m_rankquestcreaturenameseven = reader.ReadString();
			m_rankquestcreaturenameeight = reader.ReadString();
			m_rankquestcreaturenamenine = reader.ReadString();
			m_rankquestcreaturenameten = reader.ReadString();
			m_rankquestobjectiveone = reader.ReadInt();
			m_rankquestobjectivetwo = reader.ReadInt();
			m_rankquestobjectivethree = reader.ReadInt();
			m_rankquestobjectivefour = reader.ReadInt();
			m_rankquestobjectivefive = reader.ReadInt();
			m_rankquestobjectivesix = reader.ReadInt();
			m_rankquestobjectiveseven = reader.ReadInt();
			m_rankquestobjectiveeight = reader.ReadInt();
			m_rankquestobjectivenine = reader.ReadInt();
			m_rankquestobjectiveten = reader.ReadInt();
			m_EscortDestination = reader.ReadString();
		}
	}
}
