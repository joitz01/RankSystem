using System;
using Server;
using System.Text;
using Server.Network;
using Server.Misc;
using Server.Mobiles;
using Server.Gumps;
using Server.Items;
using Server.Commands;
using Server.Spells;
using Server.Targets;
using Server.Targeting;
using System.Collections;
using Server.Menus.ItemLists;
using Server.Menus.Questions;
using System.Collections.Generic;
using Server.Commands.Generic;
using System.Text.RegularExpressions;

namespace Server.Gumps
{
    public class RankGump : Gump
    {
        private Mobile m_From;
        private GumpPage m_Page;
        private RankCategory m_Cat;
        private enum GumpPage
        {
            None,
            RankPage1
        }
        public enum RankCategory
        {
			Page1,
			Page2,
			Page3,
			Page4,
			Misc,
            Combat,
            Trade,
            Magic,
            Wild,
            Bard,
            Thief,
			Skills1,
			UniqueSkills1,
			RankQuestGoals
        }
        //public RankCategory m_Category;
        private const int LabelHue = 0x480;
        private const int TitleHue = 0x12B;
		private const int LabelHue2 = 155;
		private const int LabelHue3 = 1153;
		private const int NoActiveHue = 0x3A9;
		int hue = 1149;
		
	//	int hue = 1149;
		public static void Initialize()
		{
			/* not allowing players access to this command may break some options!  suggest to leave as is!*/
         CommandSystem.Register( "rank", AccessLevel.Player, new CommandEventHandler( level_OnCommand ) );
        }
		public static void Register( string command, AccessLevel access, CommandEventHandler handler )
		{
            CommandSystem.Register(command, access, handler);
		}
		[Usage( "rank" )]
		[Description( "Opens Rank Gump." )]
		public static void level_OnCommand( CommandEventArgs e )
		{
			Mobile from = e.Mobile;
			from.CloseGump( typeof( RankGump ) );
			from.SendGump( new RankGump( from, GumpPage.None, RankCategory.Page1 ) );
        }        
		private RankGump ( Mobile from, GumpPage page, RankCategory cat ) : base( 40, 40 )
		{			
            m_From = from;
            m_Page = page;
            m_Cat = cat;
            PlayerMobile pm = from as PlayerMobile;
			
			RankDatabase DB = Server.Items.RankDatabase.GetDB( pm );
			if ( DB == null )
			{
				RankDatabase MyDB = new RankDatabase();
				MyDB.CharacterOwner = pm;
				pm.BankBox.DropItem( MyDB );
				from.SendMessage("The database was added. Please try using the [rank command again.");
				return;
			}
			
			RankFeatures.RankGumpCheckForUskills(pm, DB);
			RankFeatures.RankSkillStatCheck(pm, DB);

			Closable=true;
			Disposable=true;
			Dragable=true;
			Resizable=false;
			AddPage(0);
			AddBackground(50, 35, 540, 382, 9270);
			AddBackground(68, 83, 516, 21, 9270);
			AddBackground(63, 99, 514, 304, 9270);
			
			AddImage(0, 4, 10440);
			AddImage(554, 4, 10441);
				
			AddLabel( 270, 49, LabelHue3, "RANK WINDOW");
			AddLabel( 295, 66, LabelHue3, "STATS");
			AddLabel( 447, 57, LabelHue3, "UNIQUE SKILLS");
			AddLabel( 99, 57, LabelHue3, "SKILLS");
			
			AddButton(114, 86, 2094, 2095, GetButtonID( 1, 0 ), GumpButtonType.Reply, 0);
			AddButton(305, 86, 2094, 2095, GetButtonID( 1, 7 ), GumpButtonType.Reply, 0);
			AddButton(498, 86, 2094, 2095, GetButtonID( 1, 8 ), GumpButtonType.Reply, 0);

			
			
			if (m_Cat == RankCategory.Misc)
			{
				AddLabel(195, 105, TitleHue, @"Rank Points");
				
				AddButton(75, 116, 4005, 4007, GetButtonID( 1, 0 ), GumpButtonType.Reply, 0);
				AddLabel(112, 117, TitleHue, @"Miscelaneous");
				
				AddButton(75, 138, 4005, 4007, GetButtonID( 1, 1 ), GumpButtonType.Reply, 0);
				AddLabel(112, 139, TitleHue, @"Combat");
				
				AddButton(75, 160, 4005, 4007, GetButtonID( 1, 2 ), GumpButtonType.Reply, 0);
				AddLabel(112, 161, TitleHue, @"Trade Skills");
				
				AddButton(75, 182, 4005, 4007, GetButtonID( 1, 3 ), GumpButtonType.Reply, 0);
				AddLabel(112, 183, TitleHue, @"Magic");

				AddButton(75, 204, 4005, 4007, GetButtonID( 1, 4 ), GumpButtonType.Reply, 0);
				AddLabel(112, 205, TitleHue, @"Wilderness");
				
				AddButton(75, 226, 4005, 4007, GetButtonID( 1, 5 ), GumpButtonType.Reply, 0);
				AddLabel(112, 227, TitleHue, @"Thieving");

				AddButton(75, 248, 4005, 4007, GetButtonID( 1, 6 ), GumpButtonType.Reply, 0);
				AddLabel(112, 249, TitleHue, @"Bard");
				
				AddLabel(190, 117, LabelHue2, @"Rank:  -");
				AddLabel(220, 117, LabelHue, DB.RankArmsLore.ToString());
				AddLabel(245, 117, LabelHue, DB.SkillrankexpArmsLore.ToString());
				AddButton(300, 116, 4005, 4007, GetButtonID(2, 1), GumpButtonType.Reply, 0);
				AddLabel(337, 117, LabelHue2, @"Arms Lore");  
				AddLabel(475, 117, LabelHue, pm.Skills.ArmsLore.Base.ToString());
				AddLabel(501, 117, LabelHue2, @"Points: ");
				AddLabel(551, 117, LabelHue, DB.SkillPointsUsedArmsLore.ToString());

				AddLabel(190, 139, LabelHue2, @"Rank:  -");
				AddLabel(220, 139, LabelHue, DB.RankBegging.ToString());
				AddLabel(245, 139, LabelHue, DB.SkillrankexpBegging.ToString());
				AddButton(300, 138, 4005, 4007, GetButtonID(2, 2), GumpButtonType.Reply, 0);
				AddLabel(337, 139,  LabelHue2, @"Begging");  
				AddLabel(475, 139, LabelHue, pm.Skills.Begging.Base.ToString());
				AddLabel(501, 139, LabelHue2, @"Points: ");
				AddLabel(551, 139, LabelHue, DB.SkillPointsUsedBegging.ToString());

				AddLabel(190, 161, LabelHue2, @"Rank:  -");
				AddLabel(220, 161, LabelHue, DB.RankCamping.ToString());
				AddLabel(245, 161, LabelHue, DB.SkillrankexpCamping.ToString());
				AddButton(300, 160, 4005, 4007, GetButtonID(2, 3), GumpButtonType.Reply, 0);
				AddLabel(337, 161, LabelHue2, pm.Skills.Camping.Name.ToString());
				AddLabel(475, 161, LabelHue, pm.Skills.Camping.Base.ToString());
				AddLabel(501, 161, LabelHue2, @"Points: ");
				AddLabel(551, 161, LabelHue, DB.SkillPointsUsedCamping.ToString());	

				AddLabel(190, 183, LabelHue2, @"Rank:  -");
				AddLabel(220, 183, LabelHue, DB.RankCartography.ToString());
				AddLabel(245, 183, LabelHue, DB.SkillrankexpCartography.ToString());
				AddButton(300, 182, 4005, 4007, GetButtonID(2, 4), GumpButtonType.Reply, 0);
				AddLabel(337, 183, LabelHue2, pm.Skills.Cartography.Name.ToString());
				AddLabel(475, 183, LabelHue, pm.Skills.Cartography.Base.ToString());
				AddLabel(501, 183, LabelHue2, @"Points: ");
				AddLabel(551, 183, LabelHue, DB.SkillPointsUsedCartography.ToString());
	
				AddLabel(190, 205, LabelHue2, @"Rank:  -");
				AddLabel(220, 205, LabelHue, DB.RankForensics.ToString());
				AddLabel(245, 205, LabelHue, DB.SkillrankexpForensics.ToString());
				AddButton(300, 204, 4005, 4007, GetButtonID(2, 5), GumpButtonType.Reply, 0);
				AddLabel(337, 205, LabelHue2, pm.Skills.Forensics.Name.ToString());
				AddLabel(475, 205, LabelHue, pm.Skills.Forensics.Base.ToString());
				AddLabel(501, 205, LabelHue2, @"Points: ");
				AddLabel(551, 205, LabelHue, DB.SkillPointsUsedForensics.ToString());

				AddLabel(190, 227, LabelHue2, @"Rank:  -");
				AddLabel(220, 227, LabelHue, DB.RankItemID.ToString());
				AddLabel(245, 227, LabelHue, DB.SkillrankexpItemID.ToString());
				AddButton(300, 226, 4005, 4007, GetButtonID(2, 6), GumpButtonType.Reply, 0);
				AddLabel(337, 227, LabelHue2, pm.Skills.ItemID.Name.ToString());
				AddLabel(475, 227, LabelHue, pm.Skills.ItemID.Base.ToString());
				AddLabel(501, 227, LabelHue2, @"Points: ");
				AddLabel(551, 227, LabelHue, DB.SkillPointsUsedItemID.ToString());

				AddLabel(190, 249, LabelHue2, @"Rank:  -");
				AddLabel(220, 249, LabelHue, DB.RankTasteID.ToString());
				AddLabel(245, 249, LabelHue, DB.SkillrankexpTasteID.ToString());
				AddButton(300, 248, 4005, 4007, GetButtonID(2, 7), GumpButtonType.Reply, 0);
				AddLabel(337, 249, LabelHue2, pm.Skills.TasteID.Name.ToString());
				AddLabel(475, 249, LabelHue, pm.Skills.TasteID.Base.ToString());
				AddLabel(501, 249, LabelHue2, @"Points: ");
				AddLabel(551, 249, LabelHue, DB.SkillPointsUsedTasteID.ToString());
			}
			if (m_Cat == RankCategory.Combat)
			{
				AddLabel(195, 105, TitleHue, @"Rank Points");
				
				AddButton(75, 116, 4005, 4007, GetButtonID( 1, 0 ), GumpButtonType.Reply, 0);
				AddLabel(112, 117, TitleHue, @"Miscelaneous");
				
				AddButton(75, 138, 4005, 4007, GetButtonID( 1, 1 ), GumpButtonType.Reply, 0);
				AddLabel(112, 139, TitleHue, @"Combat");
				
				AddButton(75, 160, 4005, 4007, GetButtonID( 1, 2 ), GumpButtonType.Reply, 0);
				AddLabel(112, 161, TitleHue, @"Trade Skills");
				
				AddButton(75, 182, 4005, 4007, GetButtonID( 1, 3 ), GumpButtonType.Reply, 0);
				AddLabel(112, 183, TitleHue, @"Magic");

				AddButton(75, 204, 4005, 4007, GetButtonID( 1, 4 ), GumpButtonType.Reply, 0);
				AddLabel(112, 205, TitleHue, @"Wilderness");
				
				AddButton(75, 226, 4005, 4007, GetButtonID( 1, 5 ), GumpButtonType.Reply, 0);
				AddLabel(112, 227, TitleHue, @"Thieving");

				AddButton(75, 248, 4005, 4007, GetButtonID( 1, 6 ), GumpButtonType.Reply, 0);
				AddLabel(112, 249, TitleHue, @"Bard");
				
				AddLabel(190, 117, LabelHue2, @"Rank:  -");
				AddLabel(220, 117, LabelHue, DB.RankAnatomy.ToString());
				AddLabel(245, 117, LabelHue, DB.SkillrankexpAnatomy.ToString());
				AddButton(300, 116, 4005, 4007, GetButtonID(2, 8), GumpButtonType.Reply, 0);
				AddLabel(337, 117, LabelHue2, pm.Skills.Anatomy.Name.ToString());
				AddLabel(475, 117, LabelHue, pm.Skills.Anatomy.Base.ToString());
				AddLabel(501, 117, LabelHue2, @"Points: ");
				AddLabel(551, 117, LabelHue, DB.SkillPointsUsedAnatomy.ToString());

				AddLabel(190, 139, LabelHue2, @"Rank:  -");
				AddLabel(220, 139, LabelHue, DB.RankArchery.ToString());
				AddLabel(245, 139, LabelHue, DB.SkillrankexpArchery.ToString());
				AddButton(300, 138, 4005, 4007, GetButtonID(2, 9), GumpButtonType.Reply, 0);
				AddLabel(337, 139, LabelHue2, pm.Skills.Archery.Name.ToString());
				AddLabel(475, 139, LabelHue, pm.Skills.Archery.Base.ToString());
				AddLabel(501, 139, LabelHue2, @"Points: ");
				AddLabel(551, 139, LabelHue, DB.SkillPointsUsedArchery.ToString());

				AddLabel(190, 161, LabelHue2, @"Rank:  -");
				AddLabel(220, 161, LabelHue, DB.RankFencing.ToString());
				AddLabel(245, 161, LabelHue, DB.SkillrankexpFencing.ToString());
				AddButton(300, 160, 4005, 4007, GetButtonID(2, 10), GumpButtonType.Reply, 0);
				AddLabel(337, 161, LabelHue2, pm.Skills.Fencing.Name.ToString());
				AddLabel(475, 161, LabelHue, pm.Skills.Fencing.Base.ToString());
				AddLabel(501, 161, LabelHue2, @"Points: ");
				AddLabel(551, 161, LabelHue, DB.SkillPointsUsedFencing.ToString());

				AddLabel(190, 183, LabelHue2, @"Rank:  -");
				AddLabel(220, 183, LabelHue, DB.RankFocus.ToString());
				AddLabel(245, 183, LabelHue, DB.SkillrankexpFocus.ToString());
				AddButton(300, 182, 4005, 4007, GetButtonID(2, 11), GumpButtonType.Reply, 0);
				AddLabel(337, 183, LabelHue2, pm.Skills.Focus.Name.ToString());
				AddLabel(475, 183, LabelHue, pm.Skills.Focus.Base.ToString());
				AddLabel(501, 183, LabelHue2, @"Points: ");
				AddLabel(551, 183, LabelHue, DB.SkillPointsUsedFocus.ToString());

				AddLabel(190, 205, LabelHue2, @"Rank:  -");
				AddLabel(220, 205, LabelHue, DB.RankHealing.ToString());
				AddLabel(245, 205, LabelHue, DB.SkillrankexpHealing.ToString());
				AddButton(300, 204, 4005, 4007, GetButtonID(2, 12), GumpButtonType.Reply, 0);
				AddLabel(337, 205, LabelHue2, pm.Skills.Healing.Name.ToString());
				AddLabel(475, 205, LabelHue, pm.Skills.Healing.Base.ToString());
				AddLabel(501, 205, LabelHue2, @"Points: ");
				AddLabel(551, 205, LabelHue, DB.SkillPointsUsedHealing.ToString());

				AddLabel(190, 227, LabelHue2, @"Rank:  -");
				AddLabel(220, 227, LabelHue, DB.RankMacing.ToString());
				AddLabel(245, 227, LabelHue, DB.SkillrankexpMacing.ToString());
				AddButton(300, 226, 4005, 4007, GetButtonID(2, 13), GumpButtonType.Reply, 0);
				AddLabel(337, 227, LabelHue2, pm.Skills.Macing.Name.ToString());
				AddLabel(475, 227, LabelHue, pm.Skills.Macing.Base.ToString());
				AddLabel(501, 227, LabelHue2, @"Points: ");
				AddLabel(551, 227, LabelHue, DB.SkillPointsUsedMacing.ToString());

				AddLabel(190, 249, LabelHue2, @"Rank:  -");
				AddLabel(220, 249, LabelHue, DB.RankParry.ToString());
				AddLabel(245, 249, LabelHue, DB.SkillrankexpParry.ToString());
				AddButton(300, 248, 4005, 4007, GetButtonID(2, 14), GumpButtonType.Reply, 0);
				AddLabel(337, 249, LabelHue2, pm.Skills.Parry.Name.ToString());
				AddLabel(475, 249, LabelHue, pm.Skills.Parry.Base.ToString());
				AddLabel(501, 249, LabelHue2, @"Points: ");
				AddLabel(551, 249, LabelHue, DB.SkillPointsUsedParry.ToString());
								
				AddLabel(190, 271, LabelHue2, @"Rank:  -");
				AddLabel(220, 271, LabelHue, DB.RankSwords.ToString());
				AddLabel(245, 271, LabelHue, DB.SkillrankexpSwords.ToString());
				AddButton(300, 270, 4005, 4007, GetButtonID(2, 15), GumpButtonType.Reply, 0);
				AddLabel(337, 271, LabelHue2, pm.Skills.Swords.Name.ToString());
				AddLabel(475, 271, LabelHue, pm.Skills.Swords.Base.ToString());
				AddLabel(501, 271, LabelHue2, @"Points: ");
				AddLabel(551, 271, LabelHue, DB.SkillPointsUsedSwords.ToString());

				AddLabel(190, 293, LabelHue2, @"Rank:  -");
				AddLabel(220, 293, LabelHue, DB.RankTactics.ToString());
				AddLabel(245, 293, LabelHue, DB.SkillrankexpTactics.ToString());
				AddButton(300, 292, 4005, 4007, GetButtonID(2, 16), GumpButtonType.Reply, 0);
				AddLabel(337, 293, LabelHue2, pm.Skills.Tactics.Name.ToString());
				AddLabel(475, 293, LabelHue, pm.Skills.Tactics.Base.ToString());
				AddLabel(501, 293, LabelHue2, @"Points: ");
				AddLabel(551, 293, LabelHue, DB.SkillPointsUsedTactics.ToString());
									
				AddLabel(190, 317, LabelHue2, @"Rank:  -");
				AddLabel(220, 317, LabelHue, DB.RankWrestling.ToString());
				AddLabel(245, 317, LabelHue, DB.SkillrankexpWrestling.ToString());
				AddButton(300, 316, 4005, 4007, GetButtonID(2, 17), GumpButtonType.Reply, 0);
				AddLabel(337, 317, LabelHue2, pm.Skills.Wrestling.Name.ToString());
				AddLabel(475, 317, LabelHue, pm.Skills.Wrestling.Base.ToString());
				AddLabel(501, 317, LabelHue2, @"Points: ");
				AddLabel(551, 317, LabelHue, DB.SkillPointsUsedWrestling.ToString());
				
		//		AddLabel(190, 339, LabelHue2, @"Rank:  -");
		//		AddLabel(220, 339, LabelHue, DB.RankThrowing.ToString());
		//		AddLabel(245, 339, LabelHue, DB.SkillrankexpThrowing.ToString());
		//		AddButton(300, 338, 4005, 4007, GetButtonID(2, 18), GumpButtonType.Reply, 0);
		//		AddLabel(337, 339, LabelHue2, pm.Skills.Throwing.Name.ToString());
		//		AddLabel(475, 339, LabelHue, pm.Skills.Throwing.Base.ToString());
		//		AddLabel(501, 339, LabelHue2, @"Points: ");
		//		AddLabel(551, 339, LabelHue, DB.SkillPointsUsedThrowing.ToString());
			}
			if (m_Cat == RankCategory.Trade)
			{
				AddLabel(195, 105, TitleHue, @"Rank Points");
				
				AddButton(75, 116, 4005, 4007, GetButtonID( 1, 0 ), GumpButtonType.Reply, 0);
				AddLabel(112, 117, TitleHue, @"Miscelaneous");
				
				AddButton(75, 138, 4005, 4007, GetButtonID( 1, 1 ), GumpButtonType.Reply, 0);
				AddLabel(112, 139, TitleHue, @"Combat");
				
				AddButton(75, 160, 4005, 4007, GetButtonID( 1, 2 ), GumpButtonType.Reply, 0);
				AddLabel(112, 161, TitleHue, @"Trade Skills");
				
				AddButton(75, 182, 4005, 4007, GetButtonID( 1, 3 ), GumpButtonType.Reply, 0);
				AddLabel(112, 183, TitleHue, @"Magic");

				AddButton(75, 204, 4005, 4007, GetButtonID( 1, 4 ), GumpButtonType.Reply, 0);
				AddLabel(112, 205, TitleHue, @"Wilderness");
				
				AddButton(75, 226, 4005, 4007, GetButtonID( 1, 5 ), GumpButtonType.Reply, 0);
				AddLabel(112, 227, TitleHue, @"Thieving");

				AddButton(75, 248, 4005, 4007, GetButtonID( 1, 6 ), GumpButtonType.Reply, 0);
				AddLabel(112, 249, TitleHue, @"Bard");
				
				AddLabel(190, 117, LabelHue2, @"Rank:  -");
				AddLabel(220, 117, LabelHue, DB.RankAlchemy.ToString());
				AddLabel(245, 117, LabelHue, DB.SkillrankexpAlchemy.ToString());
				AddButton(300, 116, 4005, 4007, GetButtonID(2, 19), GumpButtonType.Reply, 0);
				AddLabel(337, 117, LabelHue2, pm.Skills.Alchemy.Name.ToString());
				AddLabel(475, 117, LabelHue, pm.Skills.Alchemy.Base.ToString());
				AddLabel(501, 117, LabelHue2, @"Points: ");
				AddLabel(551, 117, LabelHue, DB.SkillPointsUsedAlchemy.ToString());

				AddLabel(190, 139, LabelHue2, @"Rank:  -");
				AddLabel(220, 139, LabelHue, DB.RankBlacksmith.ToString());
				AddLabel(245, 139, LabelHue, DB.SkillrankexpBlacksmith.ToString());
				AddButton(300, 138, 4005, 4007, GetButtonID(2, 20), GumpButtonType.Reply, 0);
				AddLabel(337, 139, LabelHue2, pm.Skills.Blacksmith.Name.ToString());
				AddLabel(475, 139, LabelHue, pm.Skills.Blacksmith.Base.ToString());
				AddLabel(501, 139, LabelHue2, @"Points: ");
				AddLabel(551, 139, LabelHue, DB.SkillPointsUsedBlacksmith.ToString());

				AddLabel(190, 161, LabelHue2, @"Rank:  -");
				AddLabel(220, 161, LabelHue, DB.RankFletching.ToString());
				AddLabel(245, 161, LabelHue, DB.SkillrankexpFletching.ToString());
				AddButton(300, 160, 4005, 4007, GetButtonID(2, 21), GumpButtonType.Reply, 0);
				AddLabel(337, 161, LabelHue2, pm.Skills.Fletching.Name.ToString());
				AddLabel(475, 161, LabelHue, pm.Skills.Fletching.Base.ToString());
				AddLabel(501, 161, LabelHue2, @"Points: ");
				AddLabel(551, 161, LabelHue, DB.SkillPointsUsedFletching.ToString());

				AddLabel(190, 183, LabelHue2, @"Rank:  -");
				AddLabel(220, 183, LabelHue, DB.RankCarpentry.ToString());
				AddLabel(245, 183, LabelHue, DB.SkillrankexpCarpentry.ToString());
				AddButton(300, 182, 4005, 4007, GetButtonID(2, 22), GumpButtonType.Reply, 0);
				AddLabel(337, 183, LabelHue2, pm.Skills.Carpentry.Name.ToString());
				AddLabel(475, 183, LabelHue, pm.Skills.Carpentry.Base.ToString());
				AddLabel(501, 183, LabelHue2, @"Points: ");
				AddLabel(551, 183, LabelHue, DB.SkillPointsUsedCarpentry.ToString());

				AddLabel(190, 205, LabelHue2, @"Rank:  -");
				AddLabel(220, 205, LabelHue, DB.RankCooking.ToString());
				AddLabel(245, 205, LabelHue, DB.SkillrankexpCooking.ToString());
				AddButton(300, 204, 4005, 4007, GetButtonID(2, 23), GumpButtonType.Reply, 0);
				AddLabel(337, 205, LabelHue2, pm.Skills.Cooking.Name.ToString());
				AddLabel(475, 205, LabelHue, pm.Skills.Cooking.Base.ToString());
				AddLabel(501, 205, LabelHue2, @"Points: ");
				AddLabel(551, 205, LabelHue, DB.SkillPointsUsedCooking.ToString());

				AddLabel(190, 227, LabelHue2, @"Rank:  -");
				AddLabel(220, 227, LabelHue, DB.RankInscribe.ToString());
				AddLabel(245, 227, LabelHue, DB.SkillrankexpInscribe.ToString());
				AddButton(300, 226, 4005, 4007, GetButtonID(2, 24), GumpButtonType.Reply, 0);
				AddLabel(337, 227, LabelHue2, pm.Skills.Inscribe.Name.ToString());
				AddLabel(475, 227, LabelHue, pm.Skills.Inscribe.Base.ToString());
				AddLabel(501, 227, LabelHue2, @"Points: ");
				AddLabel(551, 227, LabelHue, DB.SkillPointsUsedInscribe.ToString());

				AddLabel(190, 249, LabelHue2, @"Rank:  -");
				AddLabel(220, 249, LabelHue, DB.RankLumberjacking.ToString());
				AddLabel(245, 249, LabelHue, DB.SkillrankexpLumberjacking.ToString());
				AddButton(300, 248, 4005, 4007, GetButtonID(2, 25), GumpButtonType.Reply, 0);
				AddLabel(337, 249, LabelHue2, pm.Skills.Lumberjacking.Name.ToString());
				AddLabel(475, 249, LabelHue, pm.Skills.Lumberjacking.Base.ToString());
				AddLabel(501, 249, LabelHue2, @"Points: ");
				AddLabel(551, 249, LabelHue, DB.SkillPointsUsedLumberjacking.ToString());

				AddLabel(190, 271, LabelHue2, @"Rank:  -");
				AddLabel(220, 271, LabelHue, DB.RankMining.ToString());
				AddLabel(245, 271, LabelHue, DB.SkillrankexpMining.ToString());
				AddButton(300, 270, 4005, 4007, GetButtonID(2, 26), GumpButtonType.Reply, 0);
				AddLabel(337, 271, LabelHue2, pm.Skills.Mining.Name.ToString());
				AddLabel(475, 271, LabelHue, pm.Skills.Mining.Base.ToString());
				AddLabel(501, 271, LabelHue2, @"Points: ");
				AddLabel(551, 271, LabelHue, DB.SkillPointsUsedMining.ToString());

				AddLabel(190, 293, LabelHue2, @"Rank:  -");
				AddLabel(220, 293, LabelHue, DB.RankTailoring.ToString());
				AddLabel(245, 293, LabelHue, DB.SkillrankexpTailoring.ToString());
				AddButton(300, 292, 4005, 4007, GetButtonID(2, 27), GumpButtonType.Reply, 0);
				AddLabel(337, 293, LabelHue2, pm.Skills.Tailoring.Name.ToString());
				AddLabel(475, 293, LabelHue, pm.Skills.Tailoring.Base.ToString());
				AddLabel(501, 293, LabelHue2, @"Points: ");
				AddLabel(551, 293, LabelHue, DB.SkillPointsUsedTailoring.ToString());
				
				AddLabel(190, 317, LabelHue2, @"Rank:  -");
				AddLabel(220, 317, LabelHue, DB.RankTinkering.ToString());
				AddLabel(245, 317, LabelHue, DB.SkillrankexpTinkering.ToString());
				AddButton(300, 316, 4005, 4007, GetButtonID(2, 28), GumpButtonType.Reply, 0);
				AddLabel(337, 317, LabelHue2, pm.Skills.Tinkering.Name.ToString());
				AddLabel(475, 317, LabelHue, pm.Skills.Tinkering.Base.ToString());
				AddLabel(501, 317, LabelHue2, @"Points: ");
				AddLabel(551, 317, LabelHue, DB.SkillPointsUsedTinkering.ToString());
				
	//			AddLabel(190, 339, LabelHue2, @"Rank:  -");
	//			AddLabel(220, 339, LabelHue, DB.RankImbueing.ToString());
	//			AddLabel(245, 339, LabelHue, DB.SkillrankexpImbueing.ToString());
	//			AddButton(300, 338, 4005, 4007, GetButtonID(2, 29), GumpButtonType.Reply, 0);
	//			AddLabel(337, 339, LabelHue2, pm.Skills.Imbuing.Name.ToString());
	//			AddLabel(475, 339, LabelHue, pm.Skills.Imbuing.Base.ToString());
	//			AddLabel(501, 339, LabelHue2, @"Points: ");
	//			AddLabel(551, 339, LabelHue, DB.SkillPointsUsedImbuing.ToString());
			}
			
			if (m_Cat == RankCategory.Magic)
			{
				AddLabel(195, 105, TitleHue, @"Rank Points");
				
				AddButton(75, 116, 4005, 4007, GetButtonID( 1, 0 ), GumpButtonType.Reply, 0);
				AddLabel(112, 117, TitleHue, @"Miscelaneous");
				
				AddButton(75, 138, 4005, 4007, GetButtonID( 1, 1 ), GumpButtonType.Reply, 0);
				AddLabel(112, 139, TitleHue, @"Combat");
				
				AddButton(75, 160, 4005, 4007, GetButtonID( 1, 2 ), GumpButtonType.Reply, 0);
				AddLabel(112, 161, TitleHue, @"Trade Skills");
				
				AddButton(75, 182, 4005, 4007, GetButtonID( 1, 3 ), GumpButtonType.Reply, 0);
				AddLabel(112, 183, TitleHue, @"Magic");

				AddButton(75, 204, 4005, 4007, GetButtonID( 1, 4 ), GumpButtonType.Reply, 0);
				AddLabel(112, 205, TitleHue, @"Wilderness");
				
				AddButton(75, 226, 4005, 4007, GetButtonID( 1, 5 ), GumpButtonType.Reply, 0);
				AddLabel(112, 227, TitleHue, @"Thieving");

				AddButton(75, 248, 4005, 4007, GetButtonID( 1, 6 ), GumpButtonType.Reply, 0);
				AddLabel(112, 249, TitleHue, @"Bard");
				
				AddLabel(190, 117, LabelHue2, @"Rank:  -");
				AddLabel(220, 117, LabelHue, DB.RankBushido.ToString());
				AddLabel(245, 117, LabelHue, DB.SkillrankexpBushido.ToString());
				AddButton(300, 116, 4005, 4007, GetButtonID(2, 30), GumpButtonType.Reply, 0);
				AddLabel(337, 117,  LabelHue2, @"Bushido");  
				AddLabel(475, 117, LabelHue, pm.Skills.Bushido.Base.ToString());
				AddLabel(501, 117, LabelHue2, @"Points: ");
				AddLabel(551, 117, LabelHue, DB.SkillPointsUsedBushido.ToString());

				AddLabel(190, 139, LabelHue2, @"Rank:  -");
				AddLabel(220, 139, LabelHue, DB.RankChivalry.ToString());
				AddLabel(245, 139, LabelHue, DB.SkillrankexpChivalry.ToString());
				AddButton(300, 138, 4005, 4007, GetButtonID(2, 31), GumpButtonType.Reply, 0);
				AddLabel(337, 139,  LabelHue2, @"Chivalry");  
				AddLabel(475, 139, LabelHue, pm.Skills.Chivalry.Base.ToString());
				AddLabel(501, 139, LabelHue2, @"Points: ");
				AddLabel(551, 139, LabelHue, DB.SkillPointsUsedChivalry.ToString());

				AddLabel(190, 161, LabelHue2, @"Rank:  -");
				AddLabel(220, 161, LabelHue, DB.RankEvalInt.ToString());
				AddLabel(245, 161, LabelHue, DB.SkillrankexpEvalInt.ToString());
				AddButton(300, 160, 4005, 4007, GetButtonID(2, 32), GumpButtonType.Reply, 0);
				AddLabel(337, 161, LabelHue2, pm.Skills.EvalInt.Name.ToString());
				AddLabel(475, 161, LabelHue, pm.Skills.EvalInt.Base.ToString());
				AddLabel(501, 161, LabelHue2, @"Points: ");
				AddLabel(551, 161, LabelHue, DB.SkillPointsUsedEvalInt.ToString());

				AddLabel(190, 183, LabelHue2, @"Rank:  -");
				AddLabel(220, 183, LabelHue, DB.RankMagery.ToString());
				AddLabel(245, 183, LabelHue, DB.SkillrankexpMagery.ToString());
				AddButton(300, 182, 4005, 4007, GetButtonID(2, 33), GumpButtonType.Reply, 0);
				AddLabel(337, 183, LabelHue2, @"Magery");
				AddLabel(475, 183, LabelHue, pm.Skills.Magery.Base.ToString());
				AddLabel(501, 183, LabelHue2, @"Points: ");
				AddLabel(551, 183, LabelHue, DB.SkillPointsUsedMagery.ToString());

				AddLabel(190, 205, LabelHue2, @"Rank:  -");
				AddLabel(220, 205, LabelHue, DB.RankMeditation.ToString());
				AddLabel(245, 205, LabelHue, DB.SkillrankexpMeditation.ToString());
				AddButton(300, 204, 4005, 4007, GetButtonID(2, 34), GumpButtonType.Reply, 0);
				AddLabel(337, 205, LabelHue2, pm.Skills.Meditation.Name.ToString());
				AddLabel(475, 205, LabelHue, pm.Skills.Meditation.Base.ToString());
				AddLabel(501, 205, LabelHue2, @"Points: ");
				AddLabel(551, 205, LabelHue, DB.SkillPointsUsedMeditation.ToString());

				AddLabel(190, 227, LabelHue2, @"Rank:  -");
				AddLabel(220, 227, LabelHue, DB.RankNecromancy.ToString());
				AddLabel(245, 227, LabelHue, DB.SkillrankexpNecromancy.ToString());
				AddButton(300, 226, 4005, 4007, GetButtonID(2, 35), GumpButtonType.Reply, 0);
				AddLabel(337, 227,  LabelHue2, @"Necromancy");  
				AddLabel(475, 227, LabelHue, pm.Skills.Necromancy.Base.ToString());
				AddLabel(501, 227, LabelHue2, @"Points: ");
				AddLabel(551, 227, LabelHue, DB.SkillPointsUsedNecromancy.ToString());

				AddLabel(190, 249, LabelHue2, @"Rank:  -");
				AddLabel(220, 249, LabelHue, DB.RankNinjitsu.ToString());
				AddLabel(245, 249, LabelHue, DB.SkillrankexpNinjitsu.ToString());
				AddButton(300, 248, 4005, 4007, GetButtonID(2, 36), GumpButtonType.Reply, 0);
				AddLabel(337, 249,  LabelHue2, @"Ninjitsu");  
				AddLabel(475, 249, LabelHue, pm.Skills.Ninjitsu.Base.ToString());
				AddLabel(501, 249, LabelHue2, @"Points: ");
				AddLabel(551, 249, LabelHue, DB.SkillPointsUsedNinjitsu.ToString());

				AddLabel(190, 271, LabelHue2, @"Rank:  -");
				AddLabel(220, 271, LabelHue, DB.RankMagicResist.ToString());
				AddLabel(245, 271, LabelHue, DB.SkillrankexpMagicResist.ToString());
				AddButton(300, 270, 4005, 4007, GetButtonID(2, 37), GumpButtonType.Reply, 0);
				AddLabel(337, 271, LabelHue2, pm.Skills.MagicResist.Name.ToString());
				AddLabel(475, 271, LabelHue, pm.Skills.MagicResist.Base.ToString());
				AddLabel(501, 271, LabelHue2, @"Points: ");
				AddLabel(551, 271, LabelHue, DB.SkillPointsUsedMagicResist.ToString());

		//		AddLabel(190, 293, LabelHue2, @"Rank:  -");
		//		AddLabel(220, 293, LabelHue, DB.RankSpellweaving.ToString());
		//		AddLabel(245, 293, LabelHue, DB.SkillrankexpSpellweaving.ToString());
		//		AddButton(300, 292, 4005, 4007, GetButtonID(2, 38), GumpButtonType.Reply, 0);
		//		AddLabel(337, 293,  LabelHue2, @"Spellweaving");  
		//		AddLabel(475, 293, LabelHue, pm.Skills.Spellweaving.Base.ToString());
		//		AddLabel(501, 293, LabelHue2, @"Points: ");
		//		AddLabel(551, 293, LabelHue, DB.SkillPointsUsedSpellweaving.ToString());
				
				AddLabel(190, 293, LabelHue2, @"Rank:  -");
				AddLabel(220, 293, LabelHue, DB.RankSpiritSpeak.ToString());
				AddLabel(245, 293, LabelHue, DB.SkillrankexpSpiritSpeak.ToString());
				AddButton(300, 292, 4005, 4007, GetButtonID(2, 39), GumpButtonType.Reply, 0);
				AddLabel(337, 293,  LabelHue2, @"SpiritSpeak");  
				AddLabel(475, 293, LabelHue, pm.Skills.SpiritSpeak.Base.ToString());
				AddLabel(501, 293, LabelHue2, @"Points: ");
				AddLabel(551, 293, LabelHue, DB.SkillPointsUsedSpiritSpeak.ToString());
				
		//		AddLabel(190, 339, LabelHue2, @"Rank:  -");
		//		AddLabel(220, 339, LabelHue, DB.RankMysticism.ToString());
		//		AddLabel(245, 339, LabelHue, DB.SkillrankexpMysticism.ToString());
		//		AddButton(300, 338, 4005, 4007, GetButtonID(2, 40), GumpButtonType.Reply, 0);
		//		AddLabel(337, 339,  LabelHue2, @"Mysticism");  
		//		AddLabel(475, 339, LabelHue, pm.Skills.Mysticism.Base.ToString());
		//		AddLabel(501, 339, LabelHue2, @"Points: ");
		//		AddLabel(551, 339, LabelHue, DB.SkillPointsUsedMysticism.ToString());
				
			}
			
			if (m_Cat == RankCategory.Wild)
			{
				AddLabel(195, 105, TitleHue, @"Rank Points");
				
				AddButton(75, 116, 4005, 4007, GetButtonID( 1, 0 ), GumpButtonType.Reply, 0);
				AddLabel(112, 117, TitleHue, @"Miscelaneous");
				
				AddButton(75, 138, 4005, 4007, GetButtonID( 1, 1 ), GumpButtonType.Reply, 0);
				AddLabel(112, 139, TitleHue, @"Combat");
				
				AddButton(75, 160, 4005, 4007, GetButtonID( 1, 2 ), GumpButtonType.Reply, 0);
				AddLabel(112, 161, TitleHue, @"Trade Skills");
				
				AddButton(75, 182, 4005, 4007, GetButtonID( 1, 3 ), GumpButtonType.Reply, 0);
				AddLabel(112, 183, TitleHue, @"Magic");

				AddButton(75, 204, 4005, 4007, GetButtonID( 1, 4 ), GumpButtonType.Reply, 0);
				AddLabel(112, 205, TitleHue, @"Wilderness");
				
				AddButton(75, 226, 4005, 4007, GetButtonID( 1, 5 ), GumpButtonType.Reply, 0);
				AddLabel(112, 227, TitleHue, @"Thieving");

				AddButton(75, 248, 4005, 4007, GetButtonID( 1, 6 ), GumpButtonType.Reply, 0);
				AddLabel(112, 249, TitleHue, @"Bard");
				
				AddLabel(190, 117, LabelHue2, @"Rank:  -");
				AddLabel(220, 117, LabelHue, DB.RankAnimalLore.ToString());
				AddLabel(245, 117, LabelHue, DB.SkillrankexpAnimalLore.ToString());
				AddButton(300, 116, 4005, 4007, GetButtonID(2, 41), GumpButtonType.Reply, 0);
				AddLabel(337, 117,  LabelHue2, @"Animal Lore");  
				AddLabel(475, 117, LabelHue, pm.Skills.AnimalLore.Base.ToString());
				AddLabel(501, 117, LabelHue2, @"Points: ");
				AddLabel(551, 117, LabelHue, DB.SkillPointsUsedAnimalLore.ToString());

				AddLabel(190, 139, LabelHue2, @"Rank:  -");
				AddLabel(220, 139, LabelHue, DB.RankAnimalTaming.ToString());
				AddLabel(245, 139, LabelHue, DB.SkillrankexpAnimalTaming.ToString());
				AddButton(300, 138, 4005, 4007, GetButtonID(2, 42), GumpButtonType.Reply, 0);
				AddLabel(337, 139,  LabelHue2, @"Animal Taming");  
				AddLabel(475, 139, LabelHue, pm.Skills.AnimalTaming.Base.ToString());
				AddLabel(501, 139, LabelHue2, @"Points: ");
				AddLabel(551, 139, LabelHue, DB.SkillPointsUsedAnimalTaming.ToString());

				AddLabel(190, 161, LabelHue2, @"Rank:  -");
				AddLabel(220, 161, LabelHue, DB.RankFishing.ToString());
				AddLabel(245, 161, LabelHue, DB.SkillrankexpFishing.ToString());
				AddButton(300, 160, 4005, 4007, GetButtonID(2, 43), GumpButtonType.Reply, 0);
				AddLabel(337, 161, LabelHue2, pm.Skills.Fishing.Name.ToString());
				AddLabel(475, 161, LabelHue, pm.Skills.Fishing.Base.ToString());
				AddLabel(501, 161, LabelHue2, @"Points: ");
				AddLabel(551, 161, LabelHue, DB.SkillPointsUsedFishing.ToString());

				AddLabel(190, 183, LabelHue2, @"Rank:  -");
				AddLabel(220, 183, LabelHue, DB.RankHerding.ToString());
				AddLabel(245, 183, LabelHue, DB.SkillrankexpHerding.ToString());
				AddButton(300, 182, 4005, 4007, GetButtonID(2, 44), GumpButtonType.Reply, 0);
				AddLabel(337, 183, LabelHue2, pm.Skills.Herding.Name.ToString());
				AddLabel(475, 183, LabelHue, pm.Skills.Herding.Base.ToString());
				AddLabel(501, 183, LabelHue2, @"Points: ");
				AddLabel(551, 183, LabelHue, DB.SkillPointsUsedHerding.ToString());

				AddLabel(190, 205, LabelHue2, @"Rank:  -");
				AddLabel(220, 205, LabelHue, DB.RankTracking.ToString());
				AddLabel(245, 205, LabelHue, DB.SkillrankexpTracking.ToString());
				AddButton(300, 204, 4005, 4007, GetButtonID(2, 45), GumpButtonType.Reply, 0);
				AddLabel(337, 205, LabelHue2, pm.Skills.Tracking.Name.ToString());
				AddLabel(475, 205, LabelHue, pm.Skills.Tracking.Base.ToString());
				AddLabel(501, 205, LabelHue2, @"Points: ");
				AddLabel(551, 205, LabelHue, DB.SkillPointsUsedTracking.ToString());

				AddLabel(190, 227, LabelHue2, @"Rank:  -");
				AddLabel(220, 227, LabelHue, DB.RankVeterinary.ToString());
				AddLabel(245, 227, LabelHue, DB.SkillrankexpVeterinary.ToString());
				AddButton(300, 226, 4005, 4007, GetButtonID(2, 46), GumpButtonType.Reply, 0);
				AddLabel(337, 227, LabelHue2, pm.Skills.Veterinary.Name.ToString());
				AddLabel(475, 227, LabelHue, pm.Skills.Veterinary.Base.ToString());
				AddLabel(501, 227, LabelHue2, @"Points: ");
				AddLabel(551, 227, LabelHue, DB.SkillPointsUsedVeterinary.ToString());
				
			}
			
			if (m_Cat == RankCategory.Bard)
			{
				AddLabel(195, 105, TitleHue, @"Rank Points");
				
				AddButton(75, 116, 4005, 4007, GetButtonID( 1, 0 ), GumpButtonType.Reply, 0);
				AddLabel(112, 117, TitleHue, @"Miscelaneous");
				
				AddButton(75, 138, 4005, 4007, GetButtonID( 1, 1 ), GumpButtonType.Reply, 0);
				AddLabel(112, 139, TitleHue, @"Combat");
				
				AddButton(75, 160, 4005, 4007, GetButtonID( 1, 2 ), GumpButtonType.Reply, 0);
				AddLabel(112, 161, TitleHue, @"Trade Skills");
				
				AddButton(75, 182, 4005, 4007, GetButtonID( 1, 3 ), GumpButtonType.Reply, 0);
				AddLabel(112, 183, TitleHue, @"Magic");

				AddButton(75, 204, 4005, 4007, GetButtonID( 1, 4 ), GumpButtonType.Reply, 0);
				AddLabel(112, 205, TitleHue, @"Wilderness");
				
				AddButton(75, 226, 4005, 4007, GetButtonID( 1, 5 ), GumpButtonType.Reply, 0);
				AddLabel(112, 227, TitleHue, @"Thieving");

				AddButton(75, 248, 4005, 4007, GetButtonID( 1, 6 ), GumpButtonType.Reply, 0);
				AddLabel(112, 249, TitleHue, @"Bard");
				
				AddLabel(190, 117, LabelHue2, @"Rank:  -");
				AddLabel(220, 117, LabelHue, DB.RankDiscordance.ToString());
				AddLabel(245, 117, LabelHue, DB.SkillrankexpDiscordance.ToString());
				AddButton(300, 116, 4005, 4007, GetButtonID(2, 47), GumpButtonType.Reply, 0);
				AddLabel(337, 117, LabelHue2, pm.Skills.Discordance.Name.ToString());
				AddLabel(475, 117, LabelHue, pm.Skills.Discordance.Base.ToString());
				AddLabel(501, 117, LabelHue2, @"Points: ");
				AddLabel(551, 117, LabelHue, DB.SkillPointsUsedDiscordance.ToString());

				AddLabel(190, 139, LabelHue2, @"Rank:  -");
				AddLabel(220, 139, LabelHue, DB.RankMusicianship.ToString());
				AddLabel(245, 139, LabelHue, DB.SkillrankexpMusicianship.ToString());
				AddButton(300, 138, 4005, 4007, GetButtonID(2, 48), GumpButtonType.Reply, 0);
				AddLabel(337, 139, LabelHue2, pm.Skills.Musicianship.Name.ToString());
				AddLabel(475, 139, LabelHue, pm.Skills.Musicianship.Base.ToString());
				AddLabel(501, 139, LabelHue2, @"Points: ");
				AddLabel(551, 139, LabelHue, DB.SkillPointsUsedMusicianship.ToString());

				AddLabel(190, 161, LabelHue2, @"Rank:  -");
				AddLabel(220, 161, LabelHue, DB.RankPeacemaking.ToString());
				AddLabel(245, 161, LabelHue, DB.SkillrankexpPeacemaking.ToString());
				AddButton(300, 160, 4005, 4007, GetButtonID(2, 49), GumpButtonType.Reply, 0);
				AddLabel(337, 161, LabelHue2, pm.Skills.Peacemaking.Name.ToString());
				AddLabel(475, 161, LabelHue, pm.Skills.Peacemaking.Base.ToString());
				AddLabel(501, 161, LabelHue2, @"Points: ");
				AddLabel(551, 161, LabelHue, DB.SkillPointsUsedPeacemaking.ToString());

				AddLabel(190, 183, LabelHue2, @"Rank:  -");
				AddLabel(220, 183, LabelHue, DB.RankProvocation.ToString());
				AddLabel(245, 183, LabelHue, DB.SkillrankexpProvocation.ToString());
				AddButton(300, 182, 4005, 4007, GetButtonID(2, 50), GumpButtonType.Reply, 0);
				AddLabel(337, 183, LabelHue2, pm.Skills.Provocation.Name.ToString());
				AddLabel(475, 183, LabelHue, pm.Skills.Provocation.Base.ToString());
				AddLabel(501, 183, LabelHue2, @"Points: ");
				AddLabel(551, 183, LabelHue, DB.SkillPointsUsedProvocation.ToString());
				
			}
			
			if (m_Cat == RankCategory.Thief)
			{
				AddLabel(195, 105, TitleHue, @"Rank Points");
				
				AddButton(75, 116, 4005, 4007, GetButtonID( 1, 0 ), GumpButtonType.Reply, 0);
				AddLabel(112, 117, TitleHue, @"Miscelaneous");
				
				AddButton(75, 138, 4005, 4007, GetButtonID( 1, 1 ), GumpButtonType.Reply, 0);
				AddLabel(112, 139, TitleHue, @"Combat");
				
				AddButton(75, 160, 4005, 4007, GetButtonID( 1, 2 ), GumpButtonType.Reply, 0);
				AddLabel(112, 161, TitleHue, @"Trade Skills");
				
				AddButton(75, 182, 4005, 4007, GetButtonID( 1, 3 ), GumpButtonType.Reply, 0);
				AddLabel(112, 183, TitleHue, @"Magic");

				AddButton(75, 204, 4005, 4007, GetButtonID( 1, 4 ), GumpButtonType.Reply, 0);
				AddLabel(112, 205, TitleHue, @"Wilderness");
				
				AddButton(75, 226, 4005, 4007, GetButtonID( 1, 5 ), GumpButtonType.Reply, 0);
				AddLabel(112, 227, TitleHue, @"Thieving");

				AddButton(75, 248, 4005, 4007, GetButtonID( 1, 6 ), GumpButtonType.Reply, 0);
				AddLabel(112, 249, TitleHue, @"Bard");
				
				AddLabel(190, 117, LabelHue2, @"Rank:  -");
				AddLabel(220, 117, LabelHue, DB.RankDetectHidden.ToString());
				AddLabel(245, 117, LabelHue, DB.SkillrankexpDetectHidden.ToString());
				AddButton(300, 116, 4005, 4007, GetButtonID(2, 51), GumpButtonType.Reply, 0);
				AddLabel(337, 117, LabelHue2, pm.Skills.DetectHidden.Name.ToString());
				AddLabel(475, 117, LabelHue, pm.Skills.DetectHidden.Base.ToString());
				AddLabel(501, 117, LabelHue2, @"Points: ");
				AddLabel(551, 117, LabelHue, DB.SkillPointsUsedDetectHidden.ToString());

				AddLabel(190, 139, LabelHue2, @"Rank:  -");
				AddLabel(220, 139, LabelHue, DB.RankHiding.ToString());
				AddLabel(245, 139, LabelHue, DB.SkillrankexpHiding.ToString());
				AddButton(300, 138, 4005, 4007, GetButtonID(2, 52), GumpButtonType.Reply, 0);
				AddLabel(337, 139, LabelHue2, pm.Skills.Hiding.Name.ToString());
				AddLabel(475, 139, LabelHue, pm.Skills.Hiding.Base.ToString());
				AddLabel(501, 139, LabelHue2, @"Points: ");
				AddLabel(551, 139, LabelHue, DB.SkillPointsUsedHiding.ToString());

				AddLabel(190, 161, LabelHue2, @"Rank:  -");
				AddLabel(220, 161, LabelHue, DB.RankLockpicking.ToString());
				AddLabel(245, 161, LabelHue, DB.SkillrankexpLockpicking.ToString());
				AddButton(300, 160, 4005, 4007, GetButtonID(2, 53), GumpButtonType.Reply, 0);
				AddLabel(337, 161, LabelHue2, pm.Skills.Lockpicking.Name.ToString());
				AddLabel(475, 161, LabelHue, pm.Skills.Lockpicking.Base.ToString());
				AddLabel(501, 161, LabelHue2, @"Points: ");
				AddLabel(551, 161, LabelHue, DB.SkillPointsUsedLockpicking.ToString());

				AddLabel(190, 183, LabelHue2, @"Rank:  -");
				AddLabel(220, 183, LabelHue, DB.RankPoisoning.ToString());
				AddLabel(245, 183, LabelHue, DB.SkillrankexpPoisoning.ToString());
				AddButton(300, 182, 4005, 4007, GetButtonID(2, 54), GumpButtonType.Reply, 0);
				AddLabel(337, 183, LabelHue2, pm.Skills.Poisoning.Name.ToString());
				AddLabel(475, 183, LabelHue, pm.Skills.Poisoning.Base.ToString());
				AddLabel(501, 183, LabelHue2, @"Points: ");
				AddLabel(551, 183, LabelHue, DB.SkillPointsUsedPoisoning.ToString());

				AddLabel(190, 205, LabelHue2, @"Rank:  -");
				AddLabel(220, 205, LabelHue, DB.RankRemoveTrap.ToString());
				AddLabel(245, 205, LabelHue, DB.SkillrankexpRemoveTrap.ToString());
				AddButton(300, 204, 4005, 4007, GetButtonID(2, 55), GumpButtonType.Reply, 0);
				AddLabel(337, 205, LabelHue2, pm.Skills.RemoveTrap.Name.ToString());
				AddLabel(475, 205, LabelHue, pm.Skills.RemoveTrap.Base.ToString());
				AddLabel(501, 205, LabelHue2, @"Points: ");
				AddLabel(551, 205, LabelHue, DB.SkillPointsUsedRemoveTrap.ToString());

				AddLabel(190, 227, LabelHue2, @"Rank:  -");
				AddLabel(220, 227, LabelHue, DB.RankSnooping.ToString());
				AddLabel(245, 227, LabelHue, DB.SkillrankexpSnooping.ToString());
				AddButton(300, 226, 4005, 4007, GetButtonID(2, 56), GumpButtonType.Reply, 0);
				AddLabel(337, 227, LabelHue2, pm.Skills.Snooping.Name.ToString());
				AddLabel(475, 227, LabelHue, pm.Skills.Snooping.Base.ToString());
				AddLabel(501, 227, LabelHue2, @"Points: ");
				AddLabel(551, 227, LabelHue, DB.SkillPointsUsedSnooping.ToString());

				AddLabel(190, 249, LabelHue2, @"Rank:  -");
				AddLabel(220, 249, LabelHue, DB.RankStealing.ToString());
				AddLabel(245, 249, LabelHue, DB.SkillrankexpStealing.ToString());
				AddButton(300, 248, 4005, 4007, GetButtonID(2, 57), GumpButtonType.Reply, 0);
				AddLabel(337, 249, LabelHue2, pm.Skills.Stealing.Name.ToString());
				AddLabel(475, 249, LabelHue, pm.Skills.Stealing.Base.ToString());
				AddLabel(501, 249, LabelHue2, @"Points: ");
				AddLabel(551, 249, LabelHue, DB.SkillPointsUsedStealing.ToString());

				AddLabel(190, 270, LabelHue2, @"Rank:  -");
				AddLabel(220, 270, LabelHue, DB.RankStealth.ToString());
				AddLabel(245, 270, LabelHue, DB.SkillrankexpStealth.ToString());
				AddButton(300, 270, 4005, 4007, GetButtonID(2, 58), GumpButtonType.Reply, 0);
				AddLabel(337, 271, LabelHue2, pm.Skills.Stealth.Name.ToString());
				AddLabel(475, 271, LabelHue, pm.Skills.Stealth.Base.ToString());
				AddLabel(501, 271, LabelHue2, @"Points: ");
				AddLabel(551, 271, LabelHue, DB.SkillPointsUsedStealth.ToString());
				
			}

			if (m_Cat == RankCategory.Page1) //skills stats window
			{
				// 22 between lines 
				AddLabel(100, 125, LabelHue2, @"Player Rank:");
				AddLabel(180, 125, LabelHue, DB.PlayerRankLevel.ToString());
				
				AddLabel(100, 147, TitleHue, @"Quest stats reset with each rankup.");
				
				AddLabel(100, 169, LabelHue2, @"F Rank Quest Completed:");
				AddLabel(255, 169, LabelHue, DB.fRankQuestCompleted.ToString());
				
				AddLabel(100, 191, LabelHue2, @"E Rank Quest Completed:");
				AddLabel(255, 191, LabelHue, DB.eRankQuestCompleted.ToString());
				
				AddLabel(100, 213, LabelHue2, @"D Rank Quest Completed:");
				AddLabel(255, 213, LabelHue, DB.dRankQuestCompleted.ToString());
				
				AddLabel(100, 235, LabelHue2, @"C Rank Quest Completed:");
				AddLabel(255, 235, LabelHue, DB.cRankQuestCompleted.ToString());
				
				AddLabel(100, 257, LabelHue2, @"B Rank Quest Completed:");
				AddLabel(255, 257, LabelHue, DB.bRankQuestCompleted.ToString());
				
				AddLabel(100, 279, LabelHue2, @"A Rank Quest Completed:");
				AddLabel(255, 279, LabelHue, DB.aRankQuestCompleted.ToString());
				
				AddLabel(100, 301, LabelHue2, @"S Rank Quest Completed:");
				AddLabel(255, 301, LabelHue, DB.sRankQuestCompleted.ToString());
				
				
				if (DB.Rankquesttype == "Subjugation")
				{//Current Issue, the creature name can be long, need to adjust x y
			
					AddLabel(100, 323, TitleHue, @"Current Quest");
					
					AddLabel(200, 323, TitleHue, @"Subjugation / Elimination");
					
					AddButton(365, 323, 4005, 4007, GetButtonID( 2, 59 ), GumpButtonType.Reply, 0);
					AddLabel(400, 323, TitleHue, @"Cancel Rank Quest!");
					
					AddButton(100, 345, 4005, 4007, GetButtonID( 1, 12 ), GumpButtonType.Reply, 0);
					AddLabel(135, 345, TitleHue, @"Quest Goals!");
				}
				if (DB.Rankquesttype == "Gathering")
				{
					AddLabel(100, 323, TitleHue, @"Current Quest");
					
					AddLabel(200, 323, TitleHue, @"Gathering");
					
					AddButton(365, 345, 4005, 4007, GetButtonID( 2, 59 ), GumpButtonType.Reply, 0);
					AddLabel(400, 345, TitleHue, @"Cancel Rank Quest!");
					
					AddButton(100, 345, 4005, 4007, GetButtonID( 1, 12 ), GumpButtonType.Reply, 0);
					AddLabel(135, 345, TitleHue, @"Quest Goals!");
				}
				if (DB.Rankquesttype == "Escort")
				{
					AddLabel(100, 323, TitleHue, @"Current Quest");
										
					AddLabel(200, 323, TitleHue, @"Escort Job");
					
					AddButton(365, 345, 4005, 4007, GetButtonID( 2, 59 ), GumpButtonType.Reply, 0);
					AddLabel(400, 345, TitleHue, @"Cancel Rank Quest!");
					
					AddButton(100, 345, 4005, 4007, GetButtonID( 1, 12 ), GumpButtonType.Reply, 0);
					AddLabel(135, 345, TitleHue, @"Quest Goals!");

				}
				if (DB.Rankquesttype == null)
				{
					AddLabel(100, 323, TitleHue, @"No Active Rank Quest! Seek out Rank Quest Board to sign up!");
				}
				

				
				/*-------------------------------------*/
				
				int ExpNeeded = DB.ToLevel - DB.Exp;
				
				AddLabel(400, 169, LabelHue2, @"Player Level:");
				AddLabel(480, 169, LabelHue, DB.Level.ToString());
				
				AddLabel(400, 191, LabelHue2, @"Max Level:");
				AddLabel(480, 191, LabelHue, DB.MaxLevel.ToString());
				
				AddLabel(400, 213, LabelHue2, @"Experience:");
				AddLabel(480, 213, LabelHue, DB.Exp.ToString());
				
				AddLabel(400, 235, LabelHue2, @"Exp Needed:");
				AddLabel(480, 235, LabelHue, ExpNeeded.ToString());
				
				AddLabel(400, 257, LabelHue2, @"Skill Points:");
				AddLabel(480, 257, LabelHue, DB.TotalSkillPoints.ToString());
				
				AddButton(365, 279, 4005, 4007, GetButtonID( 1, 9 ), GumpButtonType.Reply, 0);
				AddLabel(400, 279, TitleHue, @"Kill Stats Towards Rankup");
				
				AddButton(365, 301, 4005, 4007, GetButtonID( 1, 10 ), GumpButtonType.Reply, 0);
				AddLabel(400, 301, TitleHue, @"Item Usage Stats");
				
			}
			if (m_Cat == RankCategory.Page2) //kill stats with weapons 
			{
				AddLabel(100, 125, LabelHue2, @"Weapon group specialization towards rank up");
				AddLabel(100, 147, TitleHue, @"These stats do not reset at rank up.");
				
				AddLabel(100, 169, LabelHue2, @"Kills with Swords:");
				AddLabel(260, 169, LabelHue, DB.TotalKillsWithSwords.ToString());
				
				AddLabel(100, 191, LabelHue2, @"Kills with Fencing:");
				AddLabel(260, 191, LabelHue, DB.TotalKillsWithFencing.ToString());
				
				AddLabel(100, 213, LabelHue2, @"Kills with Maces:");
				AddLabel(260, 213, LabelHue, DB.TotalKillswithMacing.ToString());
				
				AddLabel(100, 235, LabelHue2, @"Kills with Hands:");
				AddLabel(260, 235, LabelHue, DB.TotalKillsWithHands.ToString());
				
				AddLabel(100, 257, LabelHue2, @"Kills with Archery:");
				AddLabel(260, 257, LabelHue, DB.TotalKillsWithArchery.ToString());
				
	//			AddLabel(100, 279, LabelHue2, @"Successful Provocation:");
	//			AddLabel(260, 279, LabelHue, DB.TotalKillsWithInstruments.ToString());
				
			}
			if (m_Cat == RankCategory.Page3)
			{
				AddLabel(100, 125, LabelHue2, @"Item Usage Stats");
				AddLabel(100, 147, TitleHue, @"These do not reset at rank up. Also may or may not count towards rankup!");
				
				AddLabel(100, 169, LabelHue2, @"Total Potions Used:");
				AddLabel(260, 169, LabelHue, DB.Potiontotalused.ToString());
				
				AddLabel(100, 191, LabelHue2, @"Heal Potions Used:");
				AddLabel(260, 191, LabelHue, DB.Potionhealused.ToString());
				
				AddLabel(100, 213, LabelHue2, @"Cure potions Used:");
				AddLabel(260, 213, LabelHue, DB.Potioncureused.ToString());
				
				AddLabel(100, 235, LabelHue2, @"Explosion Potions Used:");
				AddLabel(260, 235, LabelHue, DB.Potionexplosionused.ToString());
				
				AddLabel(100, 257, LabelHue2, @"Poison Potion Used:");
				AddLabel(260, 257, LabelHue, DB.Potionpoisonedused.ToString());
				
				AddLabel(100, 279, LabelHue2, @"Instruments Played:");
				AddLabel(260, 279, LabelHue, DB.Timesinstrumentplayed.ToString());
				
				AddLabel(100, 301, LabelHue2, @"Bandages Used:");
				AddLabel(260, 301, LabelHue, DB.Bandagesused.ToString());
				
				AddLabel(100, 323, LabelHue2, @"Tool Uses:");
				AddLabel(260, 323, LabelHue, DB.Tooluses.ToString());
				
				AddLabel(100, 345, LabelHue2, @"Doors Opened:");
				AddLabel(260, 345, LabelHue, DB.DoorsOpened.ToString());
				
			}		
			if (m_Cat == RankCategory.RankQuestGoals)
			{
				if (DB.Rankquesttype == "Subjugation")
				{
			
					AddLabel(100, 125, TitleHue, @"Current Quest:");
					
					int SetKillTotal = RankQuestAnimals.Quest_SetKillTotal(pm, DB);
					
					AddLabel(200, 125, TitleHue, @"Subjugation / Elimination");
					
					AddLabel(100, 147, LabelHue2, @"Objective 1:");
					AddLabel(180, 147, LabelHue, DB.Rankquestcreaturenameone);
					AddLabel(290, 147, LabelHue, DB.Rankquestobjectiveone.ToString());
					AddLabel(330, 147, LabelHue, @" / ");
					AddLabel(365, 147, LabelHue, SetKillTotal.ToString());
					
					AddLabel(100, 169, LabelHue2, @"Objective 2:");
					AddLabel(180, 169, LabelHue, DB.Rankquestcreaturenametwo);
					AddLabel(290, 169, LabelHue, DB.Rankquestobjectivetwo.ToString());
					AddLabel(330, 169, LabelHue, @" / ");
					AddLabel(365, 169, LabelHue, SetKillTotal.ToString());
					
					AddLabel(100, 191, LabelHue2, @"Objective 3:");
					AddLabel(180, 191, LabelHue, DB.Rankquestcreaturenamethree);
					AddLabel(290, 191, LabelHue, DB.Rankquestobjectivethree.ToString());
					AddLabel(330, 191, LabelHue, @" / ");
					AddLabel(365, 191, LabelHue, SetKillTotal.ToString());
					
					AddLabel(100, 213, LabelHue2, @"Objective 4:");
					AddLabel(180, 213, LabelHue, DB.Rankquestcreaturenamefour);
					AddLabel(290, 213, LabelHue, DB.Rankquestobjectivefour.ToString());
					AddLabel(330, 213, LabelHue, @" / ");
					AddLabel(365, 213, LabelHue, SetKillTotal.ToString());
					
					AddButton(365, 323, 4005, 4007, GetButtonID( 2, 59 ), GumpButtonType.Reply, 0);
					AddLabel(400, 323, TitleHue, @"Cancel Rank Quest!");
					
					AddButton(100, 323, 4005, 4007, GetButtonID( 1, 7 ), GumpButtonType.Reply, 0);
					AddLabel(135, 323, TitleHue, @"Previous Page");
				}
				if (DB.Rankquesttype == "Gathering")
				{
					AddLabel(100, 125, TitleHue, @"Current Quest");
					
					int SetKillTotal = RankQuestAnimals.Quest_SetKillTotal(pm, DB);
					
					AddLabel(200, 125, TitleHue, @"Gathering or Treasure Hunting");
					
					AddLabel(100, 147, LabelHue2, @"Objective 1:");
					AddLabel(180, 147, LabelHue, DB.Rankquestcreaturenameone);
					AddLabel(290, 147, LabelHue, DB.Rankquestobjectiveone.ToString());
					AddLabel(300, 147, LabelHue, @" / ");
					AddLabel(330, 147, LabelHue, SetKillTotal.ToString());
					
					AddLabel(100, 169, LabelHue2, @"Objective 2:");
					AddLabel(180, 169, LabelHue, DB.Rankquestcreaturenametwo);
					AddLabel(290, 169, LabelHue, DB.Rankquestobjectivetwo.ToString());
					AddLabel(300, 169, LabelHue, @" / ");
					AddLabel(330, 169, LabelHue, SetKillTotal.ToString());
					
					AddLabel(100, 191, LabelHue2, @"Objective 3:");
					AddLabel(180, 191, LabelHue, DB.Rankquestcreaturenamethree);
					AddLabel(290, 191, LabelHue, DB.Rankquestobjectivethree.ToString());
					AddLabel(300, 191, LabelHue, @" / ");
					AddLabel(330, 191, LabelHue, SetKillTotal.ToString());
					
					AddLabel(100, 213, LabelHue2, @"Objective 4:");
					AddLabel(180, 213, LabelHue, DB.Rankquestcreaturenamefour);
					AddLabel(290, 213, LabelHue, DB.Rankquestobjectivefour.ToString());
					AddLabel(300, 213, LabelHue, @" / ");
					AddLabel(330, 213, LabelHue, SetKillTotal.ToString());
					
					AddButton(365, 323, 4005, 4007, GetButtonID( 2, 59 ), GumpButtonType.Reply, 0);
					AddLabel(400, 323, TitleHue, @"Cancel Rank Quest!");
					
					AddButton(100, 323, 4005, 4007, GetButtonID( 1, 7 ), GumpButtonType.Reply, 0);
					AddLabel(135, 323, TitleHue, @"Previous Page");
				}
				if (DB.Rankquesttype == "Escort")
				{
					AddLabel(100, 125, TitleHue, @"Current Quest");
					AddLabel(200, 125, TitleHue, @"Escort Job");
					
					AddLabel(100, 147, LabelHue2, @"Name:");
					AddLabel(140, 147, LabelHue, DB.RankQuestEscort.Name);
					AddLabel(290, 147, LabelHue2, @"Destination:"); 
					AddLabel(360, 147, LabelHue, DB.EscortDestination.ToString());
					
					AddButton(365, 323, 4005, 4007, GetButtonID( 2, 59 ), GumpButtonType.Reply, 0);
					AddLabel(400, 323, TitleHue, @"Cancel Rank Quest!");
					
					AddButton(100, 323, 4005, 4007, GetButtonID( 1, 7 ), GumpButtonType.Reply, 0);
					AddLabel(135, 323, TitleHue, @"Previous Page");
				}
			}
			if (m_Cat == RankCategory.UniqueSkills1)
			{
				AddLabel(100, 125, LabelHue2, @"Unique Skills");
				AddLabel(100, 147, TitleHue, @"These are ranked skills! Must meet conditions to use them!");

				if (DB.USkill_smitheseyes == true)
				{
		//			AddButton(65, 169, 4005, 4007, GetButtonID( 1, 10 ), GumpButtonType.Reply, 0);
					AddLabel(100, 169, LabelHue2, @"Smithes Eyes - Passive Active");
				}
				else
				{
					AddLabel(100, 169, NoActiveHue, @"Smithes Eyes");
				}
				

			}
			
		}

		public static int GetButtonID( int type, int index )
		{
			return 1 + type + (index * 7);
		}
        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile m = sender.Mobile;
			PlayerMobile pm = m_From as PlayerMobile;
			
			RankDatabase DB = Server.Items.RankDatabase.GetDB( m_From );
			if ( DB == null )
			{
				return;
			}
			
            int AvlSkillPoints;
            int AvlStatPoints;
            AvlSkillPoints = DB.TotalSkillPoints;
            AvlStatPoints = DB.StatPoints;
			

            if (info.ButtonID <= 0)
                return; // Canceled
            int buttonID = info.ButtonID - 1;
            int type = buttonID % 7;
            int index = buttonID / 7;

            switch (type)
            {
                case 0:
				{
					break;
				}
                case 1:
				{
					switch (index)
					{
						case 0: 
						{
							m_From.SendGump( new RankGump( m_From, GumpPage.None, RankCategory.Misc ) );
							break;
						}
						case 1:
						{
							m_From.SendGump( new RankGump( m_From, GumpPage.None, RankCategory.Combat ) );

						   break;
						}
						case 2:
						{
							m_From.SendGump( new RankGump( m_From, GumpPage.None, RankCategory.Trade ) );
							break;
						}
						case 3:
						{
							m_From.SendGump( new RankGump( m_From, GumpPage.None, RankCategory.Magic ) );
							break;
						}
						case 4:
						{
							m_From.SendGump( new RankGump( m_From, GumpPage.None, RankCategory.Wild ) );
							break;
						}
						case 5:
						{
							m_From.SendGump( new RankGump( m_From, GumpPage.None, RankCategory.Thief ) );
							break;
						}
						case 6:
						{
							m_From.SendGump( new RankGump( m_From, GumpPage.None, RankCategory.Bard ) );
							break;
						}
						case 7: //stats
						{
							m_From.SendGump( new RankGump( m_From, GumpPage.None, RankCategory.Page1 ) );
							break;
						}
						case 8: //UniqueSkills1
						{
							m_From.SendGump( new RankGump( m_From, GumpPage.None, RankCategory.UniqueSkills1 ) );
							break;
						}
						case 9: //kills
						{
							m_From.SendGump( new RankGump( m_From, GumpPage.None, RankCategory.Page2 ) );
							break;
						}
						case 10: //potion stats
						{
							m_From.SendGump( new RankGump( m_From, GumpPage.None, RankCategory.Page3 ) );
							break;
						}
						case 11: //ItemsUsed
						{
							m_From.SendGump( new RankGump( m_From, GumpPage.None, RankCategory.Page4 ) );
							break;
						}
						case 12: //RankGoals
						{
							m_From.SendGump( new RankGump( m_From, GumpPage.None, RankCategory.RankQuestGoals ) );
							break;
						}
					}						
					
					break;
				}
                case 2: //Skill Gain System Portion
				{
					switch (index)
					{
						case 0: 
						{
							break;
						}
						#region MISC
                            case 1: // ArmsLore
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.ArmsLore.Base < pm.Skills.ArmsLore.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.ArmsLore.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedArmsLore += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Misc));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Misc));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Misc));
									return;
								}
							}
							case 2: // Begging
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Begging.Base < pm.Skills.Begging.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Begging.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedBegging += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Misc));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Misc));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Misc));
									return;
								}
							}
							case 3: // Camping
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Camping.Base < pm.Skills.Camping.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Camping.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedCamping += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Misc));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Misc));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Misc));
									return;
								}
							}
							case 4: // Cartography
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Cartography.Base < pm.Skills.Cartography.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Cartography.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedCartography += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Misc));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Misc));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Misc));
									return;
								}
							}
							case 5: // Forensics
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Forensics.Base < pm.Skills.Forensics.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Forensics.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedForensics += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Misc));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Misc));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Misc));
									return;
								}
							}
							case 6: // ItemID
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.ItemID.Base < pm.Skills.ItemID.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.ItemID.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedItemID += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Misc));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Misc));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Misc));
									return;
								}
							}
							case 7: // TasteID
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.TasteID.Base < pm.Skills.TasteID.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.TasteID.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedTasteID += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Misc));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Misc));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Misc));
									return;
								}
							}
							#endregion
							#region Combat
							case 8: // Anatomy
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Anatomy.Base < pm.Skills.Anatomy.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Anatomy.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedAnatomy += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Combat));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Combat));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Combat));
									return;
								}
							}
							case 9: // Archery
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Archery.Base < pm.Skills.Archery.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Archery.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedArchery += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Combat));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Combat));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Combat));
									return;
								}
							}
							case 10: // Fencing
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Fencing.Base < pm.Skills.Fencing.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Fencing.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedFencing += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Combat));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Combat));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Combat));
									return;
								}
							}
							case 11: // Focus
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Focus.Base < pm.Skills.Focus.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Focus.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedFocus += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Combat));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Combat));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Combat));
									return;
								}
							}
							case 12: // Healing
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Healing.Base < pm.Skills.Healing.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Healing.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedHealing += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Combat));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Combat));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Combat));
									return;
								}
							}
							case 13: // Macing
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Macing.Base < pm.Skills.Macing.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Macing.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedMacing += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Combat));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Combat));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Combat));
									return;
								}
							}
							case 14: // Parry
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Parry.Base < pm.Skills.Parry.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Parry.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedParry += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Combat));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Combat));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Combat));
									return;
								}
							}
							case 15: // Swords
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Swords.Base < pm.Skills.Swords.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Swords.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedSwords += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Combat));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Combat));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Combat));
									return;
								}
							}
							case 16: // Tactics
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Tactics.Base < pm.Skills.Tactics.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Tactics.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedTactics += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Combat));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Combat));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Combat));
									return;
								}
							}
							case 17: // Wrestling
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Wrestling.Base < pm.Skills.Wrestling.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Wrestling.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedWrestling += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Combat));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Combat));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Combat));
									return;
								}
							}
							case 18: // Throwing
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Throwing.Base < pm.Skills.Throwing.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Throwing.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedThrowing += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Combat));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Combat));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Combat));
									return;
								}
							}
							#endregion
							#region Trading
							case 19: // Alchemy
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Alchemy.Base < pm.Skills.Alchemy.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Alchemy.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedAlchemy += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Trade));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Trade));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Trade));
									return;
								}
							}
							case 20: // Blacksmith
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Blacksmith.Base < pm.Skills.Blacksmith.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Blacksmith.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedBlacksmith += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Trade));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Trade));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Trade));
									return;
								}
							}
							case 21: // Fletching
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Fletching.Base < pm.Skills.Fletching.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Fletching.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedFletching += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Trade));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Trade));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Trade));
									return;
								}
							}
							case 22: // Carpentry
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Carpentry.Base < pm.Skills.Carpentry.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Carpentry.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedCarpentry += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Trade));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Trade));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Trade));
									return;
								}
							}
							case 23: // Cooking
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Cooking.Base < pm.Skills.Cooking.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Cooking.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedCooking += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Trade));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Trade));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Trade));
									return;
								}
							}
							case 24: // Inscribe
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Inscribe.Base < pm.Skills.Inscribe.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Inscribe.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedInscribe += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Trade));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Trade));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Trade));
									return;
								}
							}
							
							case 25: // Lumberjacking
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Lumberjacking.Base < pm.Skills.Lumberjacking.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Lumberjacking.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedLumberjacking += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Trade));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Trade));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Trade));
									return;
								}
							}
							case 26: // Mining
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Mining.Base < pm.Skills.Mining.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Mining.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedMining += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Trade));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Trade));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Trade));
									return;
								}
							}
							case 27: // Tailoring
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Tailoring.Base < pm.Skills.Tailoring.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Tailoring.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedTailoring += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Trade));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Trade));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Trade));
									return;
								}
							}
							case 28: // Tinkering
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Tinkering.Base < pm.Skills.Tinkering.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Tinkering.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedTinkering += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Trade));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Trade));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Trade));
									return;
								}
							}
							case 29: // Imbuing
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Imbuing.Base < pm.Skills.Imbuing.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Imbuing.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedImbuing += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Trade));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Trade));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Trade));
									return;
								}
							}
							#endregion
							#region Magic
							case 30: // Bushido
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Bushido.Base < pm.Skills.Bushido.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Bushido.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedBushido += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Magic));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Magic));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Magic));
									return;
								}
							}
							case 31: // Chivalry
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Chivalry.Base < pm.Skills.Chivalry.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Chivalry.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedChivalry += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Magic));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Magic));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Magic));
									return;
								}
							}
							case 32: // EvalInt
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.EvalInt.Base < pm.Skills.EvalInt.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.EvalInt.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedEvalInt += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Magic));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Magic));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Magic));
									return;
								}
							}
							case 33: // Magery
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Magery.Base < pm.Skills.Magery.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Magery.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedMagery += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Magic));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Magic));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Magic));
									return;
								}
							}
							case 34: // Meditation
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Meditation.Base < pm.Skills.Meditation.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Meditation.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedMeditation += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Magic));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Magic));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Magic));
									return;
								}
							}
							case 35: // Necromancy
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Necromancy.Base < pm.Skills.Necromancy.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Necromancy.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedNecromancy += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Magic));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Magic));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Magic));
									return;
								}
							}
							case 36: // Ninjitsu
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Ninjitsu.Base < pm.Skills.Ninjitsu.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Ninjitsu.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedNinjitsu += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Magic));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Magic));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Magic));
									return;
								}
							}
							case 37: // MagicResist
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.MagicResist.Base < pm.Skills.MagicResist.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.MagicResist.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedMagicResist += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Magic));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Magic));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Magic));
									return;
								}
							}
							case 38: // Spellweaving
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Spellweaving.Base < pm.Skills.Spellweaving.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Spellweaving.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedSpellweaving += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Magic));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Magic));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Magic));
									return;
								}
							}
							case 39: // SpiritSpeak
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.SpiritSpeak.Base < pm.Skills.SpiritSpeak.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.SpiritSpeak.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedSpiritSpeak += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Magic));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Magic));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Magic));
									return;
								}
							}
							case 40: // Mysticism
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Mysticism.Base < pm.Skills.Mysticism.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Mysticism.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedMysticism += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Magic));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Magic));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Magic));
									return;
								}
							}
							#endregion
							#region Wild
							case 41: // AnimalLore
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.AnimalLore.Base < pm.Skills.AnimalLore.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.AnimalLore.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedAnimalLore += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Wild));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Wild));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Wild));
									return;
								}
							}
							case 42: // AnimalTaming
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.AnimalTaming.Base < pm.Skills.AnimalTaming.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.AnimalTaming.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedAnimalLore += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Wild));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Wild));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Wild));
									return;
								}
							}
							case 43: // Fishing
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Fishing.Base < pm.Skills.Fishing.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Fishing.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedFishing += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Wild));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Wild));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Wild));
									return;
								}
							}
							case 44: // Herding
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Herding.Base < pm.Skills.Herding.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Herding.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedHerding += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Wild));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Wild));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Wild));
									return;
								}
							}
							case 45: // Tracking
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Tracking.Base < pm.Skills.Tracking.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Tracking.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedTracking += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Wild));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Wild));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Wild));
									return;
								}
							}
							case 46: // Veterinary
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Veterinary.Base < pm.Skills.Veterinary.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Veterinary.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedVeterinary += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Wild));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Wild));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Wild));
									return;
								}
							}
							#endregion
							#region Bard
							case 47: // Discordance
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Discordance.Base < pm.Skills.Discordance.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Discordance.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedDiscordance += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Bard));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Bard));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Bard));
									return;
								}
							}
							case 48: // Musicianship
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Musicianship.Base < pm.Skills.Musicianship.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Musicianship.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedMusicianship += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Bard));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Bard));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Bard));
									return;
								}
							}
							case 49: // Peacemaking
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Peacemaking.Base < pm.Skills.Peacemaking.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Peacemaking.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedPeacemaking += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Bard));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Bard));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Bard));
									return;
								}
							}
							case 50: // Provocation
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Provocation.Base < pm.Skills.Provocation.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Provocation.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedProvocation += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Bard));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Bard));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Bard));
									return;
								}
							}
							#endregion
							#region thief
							case 51: // DetectHidden
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.DetectHidden.Base < pm.Skills.DetectHidden.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.DetectHidden.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedDetectHidden += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Thief));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Thief));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Thief));
									return;
								}
							}
							case 52: // Hiding
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Hiding.Base < pm.Skills.Hiding.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Hiding.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedHiding += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Thief));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Thief));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Thief));
									return;
								}
							}
							case 53: // Lockpicking
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Lockpicking.Base < pm.Skills.Lockpicking.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Lockpicking.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedLockpicking += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Thief));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Thief));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Thief));
									return;
								}
							}
							case 54: // Poisoning
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Poisoning.Base < pm.Skills.Poisoning.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Poisoning.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedPoisoning += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Thief));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Thief));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Thief));
									return;
								}
							}
							case 55: // RemoveTrap
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.RemoveTrap.Base < pm.Skills.RemoveTrap.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.RemoveTrap.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedRemoveTrap += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Thief));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Thief));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Thief));
									return;
								}
							}
							case 56: // Snooping
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Snooping.Base < pm.Skills.Snooping.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Snooping.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedSnooping += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Thief));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Thief));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Thief));
									return;
								}
							}
							case 57: // Stealing
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Stealing.Base < pm.Skills.Stealing.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Stealing.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedStealing += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Thief));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Thief));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Thief));
									return;
								}
							}
							case 58: // Stealth
							{
								if (AvlSkillPoints > 0)
								{
									if (pm.Skills.Stealth.Base < pm.Skills.Stealth.Cap)
									{
										m_From.SendMessage("One Skill point has been added.");
										pm.Skills.Stealth.Base += 1;
										AvlSkillPoints -= 1;
										DB.SkillPointsUsedStealth += 1;
										DB.TotalSkillPointsUsed += 1;
										DB.TotalSkillPoints = AvlSkillPoints;
										m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Thief));
										return;
									}
									pm.SendMessage("You have reached the cap in this skill");
									pm.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Thief));
									return;
								}
								else
								{
									m_From.SendMessage("You do not have any available skill points left");
									m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Thief));
									return;
								}
							}
							case 59: // Cancel Quest
							{
								m_From.SendMessage("You have canceled the Rank Quest");
								DB.Rankquestactive = false;
								DB.Rankquesttype = null;
								
								DB.Rankquestobjectiveone = 0;
								DB.Rankquestobjectivetwo = 0;
								DB.Rankquestobjectivethree = 0;
								DB.Rankquestobjectivefour = 0;
								DB.Rankquestobjectivefive = 0;
								DB.Rankquestobjectivesix = 0;
								DB.Rankquestobjectiveseven = 0;
								DB.Rankquestobjectiveeight = 0;
								DB.Rankquestobjectivenine = 0;
								DB.Rankquestobjectiveten = 0;
								DB.Rankquestcreaturenameone = null;
								DB.Rankquestcreaturenametwo = null;
								DB.Rankquestcreaturenamethree = null;
								DB.Rankquestcreaturenamefour = null;
								DB.Rankquestcreaturenamefive = null;
								DB.Rankquestcreaturenamesix = null;
								DB.Rankquestcreaturenameseven = null;
								DB.Rankquestcreaturenameeight = null;
								DB.Rankquestcreaturenamenine = null;
								DB.Rankquestcreaturenameten = null;
								DB.EscortDestination = null;
								
								RankSync.DeleteRankEscort(m_From);
								
								m_From.SendGump(new RankGump(m_From, GumpPage.None, RankCategory.Page1));
								break;
							}
							#endregion
					}
					break;
				}
            }
        }
    }
}