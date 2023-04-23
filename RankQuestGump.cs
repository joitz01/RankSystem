using System;
using Server;
using System.Text;
using Server.Network;
using Server.Misc;
using Server.Mobiles;
using Server.Gumps;
using Server.Items;
using Server.Commands;
using System.Linq;
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
    public class RankQuestGump : Gump
    {
        public Mobile m_From;
        public GumpPage m_Page;
        public QuestCategory m_Cat;
        public enum GumpPage
        {
            None,
            RankPage1
        }

        public enum QuestCategory
        {
			Page1,
			Page2,
			Page3,
			Main,
			Subjugation,
			Gathering,
			Escort
        }
        //public QuestCategory m_Category;
        private const int LabelHue = 0x480;
        private const int TitleHue = 0x12B;
		private const int LabelHue2 = 155;
		private const int LabelHue3 = 1153;
		private const int NoActiveHue = 0x3A9;
		int hue = 1149;
		
	//	int hue = 1149;
		public static void Initialize()
		{
			CommandSystem.Register( "QuestGump", AccessLevel.Player, new CommandEventHandler( level_OnCommand ) );
        }
		public static void Register( string command, AccessLevel access, CommandEventHandler handler )
		{
            CommandSystem.Register(command, access, handler);
		}
		[Usage( "QuestGump" )]
		[Description( "Opens Rank Gump." )]
		public static void level_OnCommand( CommandEventArgs e )
		{
			Mobile from = e.Mobile;
			IPooledEnumerable inRange = from.Map.GetItemsInRange( from.Location, 6 );
			
            foreach (Item item in inRange)
            {
                if (item is RankQuestBoard)
                {
					from.CloseGump( typeof( RankQuestGump ) );
					from.SendGump( new RankQuestGump( from, GumpPage.None, QuestCategory.Main ) );
					return;
                }
            }
        }        
		public RankQuestGump ( Mobile from, GumpPage page, QuestCategory cat ) : base( 40, 40 )
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
			

			Closable=true;
			Disposable=true;
			Dragable=true;
			Resizable=false;
			AddPage(0);

			AddImage(1, 1, 5400);
			AddLabel( 213, 39, TitleHue, "Rank Quest");
	

			if (m_Cat == QuestCategory.Main)
			{
				if (DB.Rankquestactive == true)
				{
					AddButton(260, 310, 4005, 4007, GetButtonID( 2, 1 ), GumpButtonType.Reply, 0);
					AddLabel(295, 310, TitleHue, @"Cancel Rank Quest!");
				}

				AddLabel( 199, 165, TitleHue, "Subjugation");
				AddButton(212, 192, 4005, 4007, GetButtonID( 1, 1 ), GumpButtonType.Reply, 0);
				
				AddLabel( 199, 225, TitleHue, "Gathering");
				AddButton(212, 250, 4005, 4007, GetButtonID( 1, 2 ), GumpButtonType.Reply, 0);
				
				AddLabel( 208, 284, TitleHue, "Escort");
				AddButton(212, 310, 4005, 4007, GetButtonID( 1, 3 ), GumpButtonType.Reply, 0);
			}
			if (m_Cat == QuestCategory.Subjugation)
			{
				AddLabel( 135, 165, TitleHue, "Accept Subjugation / Elimination Quest");
				AddButton(212, 192, 4005, 4007, GetButtonID( 2, 0 ), GumpButtonType.Reply, 0);
				
				AddHtml( 135, 235, 236, 109, String.Format( "<basefont color = #FFFFFF><basefont size = 10><center><i>To complete these quest you will need to adventure through the wilds and dungeons of the world.  The higher the Player Rank, the more tedious of a quest you will have.</i></center></basefont>"), false, false );
			}
			if (m_Cat == QuestCategory.Gathering)
			{
				AddLabel( 135, 165, TitleHue, "Item Gathering / Collection Quest");
				AddButton(212, 192, 4005, 4007, GetButtonID( 2, 2 ), GumpButtonType.Reply, 0);
				AddHtml( 135, 235, 236, 109, String.Format( "<basefont color = #FFFFFF><basefont size = 10><center><i>To complete these quest you will need to adventure through the wilds and dungeons of the world.  The higher the Player Rank, the more tedious of a quest you will have.</i></center></basefont>"), false, false );

			}
			if (m_Cat == QuestCategory.Escort)
			{
				AddLabel( 208, 165, TitleHue, "Escort");
				AddButton(212, 192, 4005, 4007, GetButtonID( 2, 3 ), GumpButtonType.Reply, 0);
				AddHtml( 135, 235, 236, 109, String.Format( "<basefont color = #FFFFFF><basefont size = 10><center><i>To complete these quest you will need to adventure through the wilds and dungeons of the world.  The higher the Player Rank, the more tedious of a quest you will have.</i></center></basefont>"), false, false );

			}
		}
		public static int GetButtonID( int type, int index )
		{
			return 1 + type + (index * 7);
		}
		
		/* Mobiles */ 
		private static Type[] m_TypesF = new Type[]
		{
			typeof(PolarBear),
			typeof(GrizzlyBear),
			typeof(BlackBear),
			typeof(Horse),
			typeof(Walrus),
			typeof(Chicken),
			typeof(Scorpion),
			typeof(GiantSerpent),
			typeof(Llama),
			typeof(Alligator),
			typeof(GreyWolf),
			typeof(Slime),
			typeof(Eagle),
			typeof(Gorilla),
			typeof(SnowLeopard),
			typeof(Pig),
			typeof(Hind),
			typeof(Rabbit)
		};
		
		private static Type[] m_TypesE = new Type[]
		{
			typeof(Fox),
			typeof(Cow),
			typeof(Bull),
			typeof(Cat),
			typeof(Cougar),
			typeof(Jaguar),
			typeof(Panther),
			typeof(WildCat),
			typeof(Bat),
			typeof(Ferret),
			typeof(Rat),
			typeof(Slime),
			typeof(Squirrel),
			typeof(Weasel),
			typeof(Boar),
			typeof(Ape),
			typeof(Goat),
			typeof(Elephant)
		};
		
		private static Type[] m_TypesD = new Type[]
		{
			typeof(SeaSerpent),
			typeof(LavaSnake),
			typeof(IceSnake),
			typeof(CaveLizard),
			typeof(GiantLizard),
			typeof(HugeLizard),
			typeof(Ridgeback),
			typeof(Slime),
			typeof(FrostOoze),
			typeof(GiantLeech),
			typeof(GreenSlime),
			typeof(AcidPuddle),
			typeof(FireToad),
			typeof(GiantToad),
			typeof(FireToad),
			typeof(FrostTroll),
			typeof(Troll),
			typeof(SwampTroll)
		};
		private static Type[] m_TypesC = new Type[]
		{
			typeof(AbysmalOgre),
			typeof(ArcticOgreLord),
			typeof(Ogre),
			typeof(OgreLord),
			typeof(OgreMagi),
			typeof(TundraOgre),
			typeof(AncientEttin),
			typeof(ArcticEttin),
			typeof(Ettin),
			typeof(EttinShaman),
			typeof(GreenSlime),
			typeof(AcidPuddle),
			typeof(FireToad),
			typeof(GiantToad),
			typeof(FireToad),
			typeof(FrostTroll),
			typeof(Troll),
			typeof(SwampTroll)
		};

		private static Type[] m_TypesB = new Type[]
		{
			typeof(FrozenCorpse),
			typeof(GhostDragyn),
			typeof(GhostGargoyle),
			typeof(Ghostly),
			typeof(GhostPirate),
			typeof(GhostWarrior),
			typeof(GhostWizard),
			typeof(Ghoul),
			typeof(GiantSkeleton),
			typeof(GraveSeeker),
			typeof(GrundulVarg),
			typeof(HellSteed),
			typeof(IceGhoul),
			typeof(Lich),
			typeof(LichKing),
			typeof(LichLord),
			typeof(Mummy),
			typeof(MummyGiant)
		};
		private static Type[] m_TypesA = new Type[]
		{
			typeof(MummyLord),
			typeof(Murk),
			typeof(Phantom),
			typeof(RestlessSoul),
			typeof(Revenant),
			typeof(RevenantLion),
			typeof(RottingCorpse),
			typeof(RottingMinotaur),
			typeof(RottingSquid),
			typeof(SeaGhost),
			typeof(SeaZombie),
			typeof(AbysmalDaemon),
			typeof(SkeletalDragon),
			typeof(Succubus),
			typeof(ShadowDemon),
			typeof(Ifreet),
			typeof(FireDemon),
			typeof(Daemon)
		};
		private static Type[] m_TypesS = new Type[]
		{
			typeof(PrimevalGreenDragon),
			typeof(PrimevalRedDragon),
			typeof(PrimevalRoyalDragon),
			typeof(PrimevalSilverDragon),
			typeof(ZombieDragon),
			typeof(Balron),
			typeof(Hydra),
			typeof(EnergyHydra),
			typeof(AshDragon),
			typeof(CrystalDragon),
			typeof(ElderDragon),
			typeof(RadiationDragon),
			typeof(VoidDragon),
			typeof(PrimevalBlackDragon),
			typeof(PrimevalAbysmalDragon),
			typeof(PrimevalAmberDragon),
			typeof(PrimevalDragon),
			typeof(PrimevalFireDragon)
		};
		/* Mobiles */ 
		
		/* Items */
		private static Type[] m_TypesItemS = new Type[]
		{
			typeof(Aegis),
			typeof(ArmorOfNobility),
			typeof(AuraOfShadows),
			typeof(BeggarsRobe),
			typeof(BladeOfInsanity),
			typeof(BlazeOfDeath),
			typeof(BraceletOfTheElements),
			typeof(BreathOfTheDead),
			typeof(PrimevalGreenDragon),
			typeof(FortunateBlades),
			typeof(GlassSword),
			typeof(HolyKnightsGloves),
			typeof(InquisitorsTunic),
			typeof(DeathsMask)
		};
		private static Type[] m_TypesItemA = new Type[]
		{
			typeof(QuiverOfBlight),
			typeof(QuiverOfFire),
			typeof(QuiverOfIce),
			typeof(QuiverOfLightning),
			typeof(ElvenQuiver),
			typeof(GreaterInvisibilityPotion),
			typeof(PotionOfMight),
			typeof(RubyIngot),
			typeof(TopazIngot)
		};
		private static Type[] m_TypesItemB = new Type[]
		{
			typeof(Amber),
			typeof(Amethyst),
			typeof(Citrine),
			typeof(Crystals),
			typeof(Diamond),
			typeof(Emerald),
			typeof(LargeCrystal),
			typeof(MysticalPearl),
			typeof(Ruby),
			typeof(Sapphire),
			typeof(StarSapphire),
			typeof(Tourmaline)
		};
		private static Type[] m_TypesItemC = new Type[]
		{
			typeof(HeaterShield),
			typeof(DragonArms),
			typeof(DragonChest),
			typeof(DragonGloves),
			typeof(DragonHelm),
			typeof(DragonLegs),
			typeof(LightSword),
			typeof(BottleOfAcid),
			typeof(PotionOfWisdom),
			typeof(HolyDraughtOfHumility),
			typeof(AutoResPotion),
			typeof(PlateArms),
			typeof(PlateDo),
			typeof(PlateLegs),
			typeof(FemalePlateChest),
			typeof(PlateGorget)
		};
		private static Type[] m_TypesItemD = new Type[]
		{
			typeof(HideChest),
			typeof(LeatherMempo),
			typeof(LeatherShorts),
			typeof(Bascinet),
			typeof(BoneHelm),
			typeof(ChainCoif),
			typeof(DaemonHelm),
			typeof(LeatherCap),
			typeof(RoyalHelm),
			typeof(RoyalArms),
			typeof(RoyalBoots),
			typeof(RoyalGloves),
			typeof(FemaleStuddedChest),
			typeof(StuddedGloves),
			typeof(StuddedHiroSode)
		};
		private static Type[] m_TypesItemE = new Type[]
		{
			typeof(FishingPole),
			typeof(ClothCowl),
			typeof(ClothHood),
			typeof(LoinCloth),
			typeof(RoyalCloak),
			typeof(FurArms),
			typeof(FurCap),
			typeof(FurLegs),
			typeof(FurRobe),
			typeof(ShortPants),
			typeof(LongPants),
			typeof(SailorPants),
			typeof(PiratePants),
			typeof(PirateRobe),
			typeof(FancyRobe)
		};
			
		private static Type[] m_TypesItemF = new Type[]
		{
			typeof(FruitBasket),
			typeof(SplitCoconut),
			typeof(Lemon),
			typeof(Lime),
			typeof(Coconut),
			typeof(Dates),
			typeof(Grapes),
			typeof(Peach),
			typeof(Pear),
			typeof(Apple),
			typeof(Watermelon),
			typeof(Squash),
			typeof(Cantaloupe),
			typeof(Carrot),
			typeof(Cabbage),
			typeof(Onion),
			typeof(Lettuce),
			typeof(Pumpkin),
			typeof(PumpkinLarge),
			typeof(PumpkinTall),
			typeof(PumpkinGreen),
			typeof(SmallWatermelon)
		};
		
		/* Items */
		
		
        private static readonly Point3D[] _Points =
        {
            new Point3D(123, 456, 0),
        };
		
        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile m = sender.Mobile;
			PlayerMobile pm = m_From as PlayerMobile;
			
			RankDatabase DB = Server.Items.RankDatabase.GetDB( m_From );
			if ( DB == null )
			{
				return;
			}		

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
							m_From.SendGump( new RankQuestGump( m_From, GumpPage.None, QuestCategory.Main ) );
							break;
						}
						case 1:
						{
							m_From.SendGump( new RankQuestGump( m_From, GumpPage.None, QuestCategory.Subjugation ) );
							break;
						}
						case 2:
						{
							m_From.SendGump( new RankQuestGump( m_From, GumpPage.None, QuestCategory.Gathering ) );
							break;
						}
						case 3:
						{
							m_From.SendGump( new RankQuestGump( m_From, GumpPage.None, QuestCategory.Escort ) );
							break;
						}
					}						
					
					break;
				}
                case 2:
				{
					switch (index)
					{
						case 0: //subjugation
						{
							/* 
							Consider adding a Warrior or Mage Npc to fight as an ally, a party member.  If subguation completed
							with ally alive, bigger reward.
							*/
							if (DB.Rankquestactive == true)
							{
								m_From.SendMessage( "You already have an active quest!" );
								return;
							}
							else
							{			
								m_From.CloseGump( typeof( RankGump ) );
								if(DB.PlayerRankLevel == "F")
								{
									BaseCreature creature = (BaseCreature)Activator.CreateInstance( m_TypesF[Utility.Random( m_TypesF.Length )] );
									BaseCreature creature2 = (BaseCreature)Activator.CreateInstance( m_TypesF[Utility.Random( m_TypesF.Length )] );
									BaseCreature creature3 = (BaseCreature)Activator.CreateInstance( m_TypesF[Utility.Random( m_TypesF.Length )] );
									BaseCreature creature4 = (BaseCreature)Activator.CreateInstance( m_TypesF[Utility.Random( m_TypesF.Length )] );

									DB.Rankquestcreaturenameone = creature.Name;
									DB.Rankquestcreaturenametwo = creature2.Name;
									DB.Rankquestcreaturenamethree = creature3.Name;
									DB.Rankquestcreaturenamefour = creature4.Name;
									
									DB.Rankquesttype = "Subjugation";
									m_From.SendMessage( "Activated Subjugation!" );
									DB.Rankquestactive = true;
									/* move creature to dead zone just in case. */ 
									creature.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									creature2.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									creature3.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									creature4.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									/* Delete creature */
									creature.Delete();
									creature2.Delete();
									creature3.Delete();
									creature4.Delete();
								}
								else if(DB.PlayerRankLevel == "E")
								{
									BaseCreature creature = (BaseCreature)Activator.CreateInstance( m_TypesE[Utility.Random( m_TypesE.Length )] );
									BaseCreature creature2 = (BaseCreature)Activator.CreateInstance( m_TypesE[Utility.Random( m_TypesE.Length )] );
									BaseCreature creature3 = (BaseCreature)Activator.CreateInstance( m_TypesE[Utility.Random( m_TypesE.Length )] );
									BaseCreature creature4 = (BaseCreature)Activator.CreateInstance( m_TypesE[Utility.Random( m_TypesE.Length )] );

									DB.Rankquestcreaturenameone = creature.Name;
									DB.Rankquestcreaturenametwo = creature2.Name;
									DB.Rankquestcreaturenamethree = creature3.Name;
									DB.Rankquestcreaturenamefour = creature4.Name;
									
									DB.Rankquesttype = "Subjugation";
									m_From.SendMessage( "Activated Subjugation!" );
									DB.Rankquestactive = true;
									/* move creature to dead zone just in case. */ 
									creature.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									creature2.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									creature3.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									creature4.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									/* Delete creature */
									creature.Delete();
									creature2.Delete();
									creature3.Delete();
									creature4.Delete();
								}
								else if(DB.PlayerRankLevel == "D")
								{
									BaseCreature creature = (BaseCreature)Activator.CreateInstance( m_TypesD[Utility.Random( m_TypesD.Length )] );
									BaseCreature creature2 = (BaseCreature)Activator.CreateInstance( m_TypesD[Utility.Random( m_TypesD.Length )] );
									BaseCreature creature3 = (BaseCreature)Activator.CreateInstance( m_TypesD[Utility.Random( m_TypesD.Length )] );
									BaseCreature creature4 = (BaseCreature)Activator.CreateInstance( m_TypesD[Utility.Random( m_TypesD.Length )] );

									DB.Rankquestcreaturenameone = creature.Name;
									DB.Rankquestcreaturenametwo = creature2.Name;
									DB.Rankquestcreaturenamethree = creature3.Name;
									DB.Rankquestcreaturenamefour = creature4.Name;
									
									DB.Rankquesttype = "Subjugation";
									m_From.SendMessage( "Activated Subjugation!" );
									DB.Rankquestactive = true;
									/* move creature to dead zone just in case. */ 
									creature.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									creature2.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									creature3.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									creature4.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									/* Delete creature */
									creature.Delete();
									creature2.Delete();
									creature3.Delete();
									creature4.Delete();
								}
								else if(DB.PlayerRankLevel == "C")
								{
									BaseCreature creature = (BaseCreature)Activator.CreateInstance( m_TypesC[Utility.Random( m_TypesC.Length )] );
									BaseCreature creature2 = (BaseCreature)Activator.CreateInstance( m_TypesC[Utility.Random( m_TypesC.Length )] );
									BaseCreature creature3 = (BaseCreature)Activator.CreateInstance( m_TypesC[Utility.Random( m_TypesC.Length )] );
									BaseCreature creature4 = (BaseCreature)Activator.CreateInstance( m_TypesC[Utility.Random( m_TypesC.Length )] );

									DB.Rankquestcreaturenameone = creature.Name;
									DB.Rankquestcreaturenametwo = creature2.Name;
									DB.Rankquestcreaturenamethree = creature3.Name;
									DB.Rankquestcreaturenamefour = creature4.Name;
									
									DB.Rankquesttype = "Subjugation";
									m_From.SendMessage( "Activated Subjugation!" );
									DB.Rankquestactive = true;
									/* move creature to dead zone just in case. */ 
									creature.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									creature2.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									creature3.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									creature4.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									/* Delete creature */
									creature.Delete();
									creature2.Delete();
									creature3.Delete();
									creature4.Delete();
								}
								else if(DB.PlayerRankLevel == "B")
								{
									BaseCreature creature = (BaseCreature)Activator.CreateInstance( m_TypesB[Utility.Random( m_TypesB.Length )] );
									BaseCreature creature2 = (BaseCreature)Activator.CreateInstance( m_TypesB[Utility.Random( m_TypesB.Length )] );
									BaseCreature creature3 = (BaseCreature)Activator.CreateInstance( m_TypesB[Utility.Random( m_TypesB.Length )] );
									BaseCreature creature4 = (BaseCreature)Activator.CreateInstance( m_TypesB[Utility.Random( m_TypesB.Length )] );

									DB.Rankquestcreaturenameone = creature.Name;
									DB.Rankquestcreaturenametwo = creature2.Name;
									DB.Rankquestcreaturenamethree = creature3.Name;
									DB.Rankquestcreaturenamefour = creature4.Name;
									
									DB.Rankquesttype = "Subjugation";
									m_From.SendMessage( "Activated Subjugation!" );
									DB.Rankquestactive = true;
									/* move creature to dead zone just in case. */ 
									creature.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									creature2.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									creature3.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									creature4.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									/* Delete creature */
									creature.Delete();
									creature2.Delete();
									creature3.Delete();
									creature4.Delete();
								}
								else if(DB.PlayerRankLevel == "A")
								{
									BaseCreature creature = (BaseCreature)Activator.CreateInstance( m_TypesA[Utility.Random( m_TypesA.Length )] );
									BaseCreature creature2 = (BaseCreature)Activator.CreateInstance( m_TypesA[Utility.Random( m_TypesA.Length )] );
									BaseCreature creature3 = (BaseCreature)Activator.CreateInstance( m_TypesA[Utility.Random( m_TypesA.Length )] );
									BaseCreature creature4 = (BaseCreature)Activator.CreateInstance( m_TypesA[Utility.Random( m_TypesA.Length )] );

									DB.Rankquestcreaturenameone = creature.Name;
									DB.Rankquestcreaturenametwo = creature2.Name;
									DB.Rankquestcreaturenamethree = creature3.Name;
									DB.Rankquestcreaturenamefour = creature4.Name;
									
									DB.Rankquesttype = "Subjugation";
									m_From.SendMessage( "Activated Subjugation!" );
									DB.Rankquestactive = true;
									/* move creature to dead zone just in case. */ 
									creature.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									creature2.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									creature3.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									creature4.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									/* Delete creature */
									creature.Delete();
									creature2.Delete();
									creature3.Delete();
									creature4.Delete();
								}
								else if(DB.PlayerRankLevel == "S")
								{
									BaseCreature creature = (BaseCreature)Activator.CreateInstance( m_TypesS[Utility.Random( m_TypesS.Length )] );
									BaseCreature creature2 = (BaseCreature)Activator.CreateInstance( m_TypesS[Utility.Random( m_TypesS.Length )] );
									BaseCreature creature3 = (BaseCreature)Activator.CreateInstance( m_TypesS[Utility.Random( m_TypesS.Length )] );
									BaseCreature creature4 = (BaseCreature)Activator.CreateInstance( m_TypesS[Utility.Random( m_TypesS.Length )] );

									DB.Rankquestcreaturenameone = creature.Name;
									DB.Rankquestcreaturenametwo = creature2.Name;
									DB.Rankquestcreaturenamethree = creature3.Name;
									DB.Rankquestcreaturenamefour = creature4.Name;
									
									DB.Rankquesttype = "Subjugation";
									m_From.SendMessage( "Activated Subjugation!" );
									DB.Rankquestactive = true;
									/* move creature to dead zone just in case. */ 
									creature.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									creature2.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									creature3.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									creature4.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									/* Delete creature */
									creature.Delete();
									creature2.Delete();
									creature3.Delete();
									creature4.Delete();
									
								}
								m_From.SendGump( new RankQuestGump( m_From, GumpPage.None, QuestCategory.Main));
							}
							break;
						}
						case 1:
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
							DB.RankQuestEscort = null;
								
								
							RankSync.DeleteRankEscort(m_From);
							
							m_From.SendGump( new RankQuestGump( m_From, GumpPage.None, QuestCategory.Main));
							break;
						}
						case 2: //Gathering Request
						{
							if (DB.Rankquestactive == true)
							{
								m_From.SendMessage( "You already have an active quest!" );
								return;
							}
							else
							{	
								m_From.CloseGump( typeof( RankGump ) );
								if(DB.PlayerRankLevel == "F")
								{
									Item item = (Item)Activator.CreateInstance( m_TypesItemF[Utility.Random( m_TypesItemF.Length )] );
									Item item2 = (Item)Activator.CreateInstance( m_TypesItemF[Utility.Random( m_TypesItemF.Length )] );
									Item item3 = (Item)Activator.CreateInstance( m_TypesItemF[Utility.Random( m_TypesItemF.Length )] );
									Item item4 = (Item)Activator.CreateInstance( m_TypesItemF[Utility.Random( m_TypesItemF.Length )] );
					
									Type typ1 = item.GetType();
									string name1 = typ1.Name;
									
									Type typ2 = item2.GetType();
									string name2 = typ2.Name;
									
									Type typ3 = item3.GetType();
									string name3 = typ3.Name;
									
									Type typ4 = item4.GetType();
									string name4 = typ4.Name;
									
									DB.Rankquestcreaturenameone = name1;
									DB.Rankquestcreaturenametwo = name2;
									DB.Rankquestcreaturenamethree = name3;
									DB.Rankquestcreaturenamefour = name4;
									
									DB.Rankquesttype = "Gathering";
									m_From.SendMessage( "Activated Gathering Quest!" );
									DB.Rankquestactive = true;
									
									item.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									item2.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									item3.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									item4.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									
									item.Delete();
									item2.Delete();
									item3.Delete();
									item4.Delete();
									return;
								}
								if(DB.PlayerRankLevel == "E")
								{
									Item item = (Item)Activator.CreateInstance( m_TypesItemE[Utility.Random( m_TypesItemE.Length )] );
									Item item2 = (Item)Activator.CreateInstance( m_TypesItemE[Utility.Random( m_TypesItemE.Length )] );
									Item item3 = (Item)Activator.CreateInstance( m_TypesItemE[Utility.Random( m_TypesItemE.Length )] );
									Item item4 = (Item)Activator.CreateInstance( m_TypesItemE[Utility.Random( m_TypesItemE.Length )] );
					
									Type typ1 = item.GetType();
									string name1 = typ1.Name;
									
									Type typ2 = item2.GetType();
									string name2 = typ2.Name;
									
									Type typ3 = item3.GetType();
									string name3 = typ3.Name;
									
									Type typ4 = item4.GetType();
									string name4 = typ4.Name;
									
									DB.Rankquestcreaturenameone = name1;
									DB.Rankquestcreaturenametwo = name2;
									DB.Rankquestcreaturenamethree = name3;
									DB.Rankquestcreaturenamefour = name4;
									
									DB.Rankquesttype = "Gathering";
									m_From.SendMessage( "Activated Gathering Quest!" );
									DB.Rankquestactive = true;
									
									item.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									item2.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									item3.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									item4.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									
									item.Delete();
									item2.Delete();
									item3.Delete();
									item4.Delete();
									return;
								}
								if(DB.PlayerRankLevel == "D")
								{
									Item item = (Item)Activator.CreateInstance( m_TypesItemD[Utility.Random( m_TypesItemD.Length )] );
									Item item2 = (Item)Activator.CreateInstance( m_TypesItemD[Utility.Random( m_TypesItemD.Length )] );
									Item item3 = (Item)Activator.CreateInstance( m_TypesItemD[Utility.Random( m_TypesItemD.Length )] );
									Item item4 = (Item)Activator.CreateInstance( m_TypesItemD[Utility.Random( m_TypesItemD.Length )] );
					
									Type typ1 = item.GetType();
									string name1 = typ1.Name;
									
									Type typ2 = item2.GetType();
									string name2 = typ2.Name;
									
									Type typ3 = item3.GetType();
									string name3 = typ3.Name;
									
									Type typ4 = item4.GetType();
									string name4 = typ4.Name;
									
									DB.Rankquestcreaturenameone = name1;
									DB.Rankquestcreaturenametwo = name2;
									DB.Rankquestcreaturenamethree = name3;
									DB.Rankquestcreaturenamefour = name4;
									
									DB.Rankquesttype = "Gathering";
									m_From.SendMessage( "Activated Gathering Quest!" );
									DB.Rankquestactive = true;
									
									item.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									item2.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									item3.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									item4.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									
									item.Delete();
									item2.Delete();
									item3.Delete();
									item4.Delete();
									return;
								}
								if(DB.PlayerRankLevel == "C")
								{
									Item item = (Item)Activator.CreateInstance( m_TypesItemC[Utility.Random( m_TypesItemC.Length )] );
									Item item2 = (Item)Activator.CreateInstance( m_TypesItemC[Utility.Random( m_TypesItemC.Length )] );
									Item item3 = (Item)Activator.CreateInstance( m_TypesItemC[Utility.Random( m_TypesItemC.Length )] );
									Item item4 = (Item)Activator.CreateInstance( m_TypesItemC[Utility.Random( m_TypesItemC.Length )] );
					
									Type typ1 = item.GetType();
									string name1 = typ1.Name;
									
									Type typ2 = item2.GetType();
									string name2 = typ2.Name;
									
									Type typ3 = item3.GetType();
									string name3 = typ3.Name;
									
									Type typ4 = item4.GetType();
									string name4 = typ4.Name;
									
									DB.Rankquestcreaturenameone = name1;
									DB.Rankquestcreaturenametwo = name2;
									DB.Rankquestcreaturenamethree = name3;
									DB.Rankquestcreaturenamefour = name4;
									
									DB.Rankquesttype = "Gathering";
									m_From.SendMessage( "Activated Gathering Quest!" );
									DB.Rankquestactive = true;
									
									item.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									item2.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									item3.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									item4.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									
									item.Delete();
									item2.Delete();
									item3.Delete();
									item4.Delete();
									return;
								}
								if(DB.PlayerRankLevel == "B")
								{
									Item item = (Item)Activator.CreateInstance( m_TypesItemB[Utility.Random( m_TypesItemB.Length )] );
									Item item2 = (Item)Activator.CreateInstance( m_TypesItemB[Utility.Random( m_TypesItemB.Length )] );
									Item item3 = (Item)Activator.CreateInstance( m_TypesItemB[Utility.Random( m_TypesItemB.Length )] );
									Item item4 = (Item)Activator.CreateInstance( m_TypesItemB[Utility.Random( m_TypesItemB.Length )] );
					
									Type typ1 = item.GetType();
									string name1 = typ1.Name;
									
									Type typ2 = item2.GetType();
									string name2 = typ2.Name;
									
									Type typ3 = item3.GetType();
									string name3 = typ3.Name;
									
									Type typ4 = item4.GetType();
									string name4 = typ4.Name;
									
									DB.Rankquestcreaturenameone = name1;
									DB.Rankquestcreaturenametwo = name2;
									DB.Rankquestcreaturenamethree = name3;
									DB.Rankquestcreaturenamefour = name4;
									
									DB.Rankquesttype = "Gathering";
									m_From.SendMessage( "Activated Gathering Quest!" );
									DB.Rankquestactive = true;
									
									item.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									item2.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									item3.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									item4.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									
									item.Delete();
									item2.Delete();
									item3.Delete();
									item4.Delete();
									return;
								}
								if(DB.PlayerRankLevel == "A")
								{
									Item item = (Item)Activator.CreateInstance( m_TypesItemA[Utility.Random( m_TypesItemA.Length )] );
									Item item2 = (Item)Activator.CreateInstance( m_TypesItemA[Utility.Random( m_TypesItemA.Length )] );
									Item item3 = (Item)Activator.CreateInstance( m_TypesItemA[Utility.Random( m_TypesItemA.Length )] );
									Item item4 = (Item)Activator.CreateInstance( m_TypesItemA[Utility.Random( m_TypesItemA.Length )] );
					
									Type typ1 = item.GetType();
									string name1 = typ1.Name;
									
									Type typ2 = item2.GetType();
									string name2 = typ2.Name;
									
									Type typ3 = item3.GetType();
									string name3 = typ3.Name;
									
									Type typ4 = item4.GetType();
									string name4 = typ4.Name;
									
									DB.Rankquestcreaturenameone = name1;
									DB.Rankquestcreaturenametwo = name2;
									DB.Rankquestcreaturenamethree = name3;
									DB.Rankquestcreaturenamefour = name4;
									
									DB.Rankquesttype = "Gathering";
									m_From.SendMessage( "Activated Gathering Quest!" );
									DB.Rankquestactive = true;
									
									item.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									item2.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									item3.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									item4.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									
									item.Delete();
									item2.Delete();
									item3.Delete();
									item4.Delete();
									return;
								}
								if(DB.PlayerRankLevel == "S")
								{
									Item item = (Item)Activator.CreateInstance( m_TypesItemS[Utility.Random( m_TypesItemS.Length )] );
									Item item2 = (Item)Activator.CreateInstance( m_TypesItemS[Utility.Random( m_TypesItemS.Length )] );
									Item item3 = (Item)Activator.CreateInstance( m_TypesItemS[Utility.Random( m_TypesItemS.Length )] );
									Item item4 = (Item)Activator.CreateInstance( m_TypesItemS[Utility.Random( m_TypesItemS.Length )] );
					
									Type typ1 = item.GetType();
									string name1 = typ1.Name;
									
									Type typ2 = item2.GetType();
									string name2 = typ2.Name;
									
									Type typ3 = item3.GetType();
									string name3 = typ3.Name;
									
									Type typ4 = item4.GetType();
									string name4 = typ4.Name;
									
									DB.Rankquestcreaturenameone = name1;
									DB.Rankquestcreaturenametwo = name2;
									DB.Rankquestcreaturenamethree = name3;
									DB.Rankquestcreaturenamefour = name4;
									
									DB.Rankquesttype = "Gathering";
									m_From.SendMessage( "Activated Gathering Quest!" );
									DB.Rankquestactive = true;
									
									item.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									item2.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									item3.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									item4.MoveToWorld(new Point3D(36, 2960, 2), Map.TerMur);
									
									item.Delete();
									item2.Delete();
									item3.Delete();
									item4.Delete();
									return;
								}
							}						
							break;
						}
						case 3:
						{
							/* 
							
							To add locations, you need to add them here as well as into the destination item 
							
							Additionally, 3 additional slots have been added to RankDatabase for Escorts. 
							Lets consider adding in multiple Escorts, either all same location, or different locations. 
							
							*/
							if (DB.Rankquestactive == true)
							{
								m_From.SendMessage( "You already have an active quest!" );
								return;
							}
							else
							{	
								m_From.CloseGump( typeof( RankGump ) );
								RankQuestEscortable m_Escort = new RankQuestEscortable();
								m_From.SendMessage( "You have accepted to a quest to escort {0} to their destination.", m_Escort.Name);
								m_Escort.MoveToWorld( m_From.Location, m_From.Map );
								m_Escort.SetControlMaster( m_From );
								m_Escort.ControlMaster = m_From;
								m_Escort.IsStabled = false;
								m_Escort.Controlled = true;
								m_Escort.Quest_Owner = m_From;
								m_Escort.ControlTarget = m_From;
								m_Escort.ControlOrder = OrderType.Follow;
								m_Escort.ControlOrder = OrderType.Come;
								
								switch ( Utility.Random( 10 ) )
								{
									case 0: 
									{
										m_Escort.EscortDestination = "Britain Bridge";
										break;
									}
									case 1: 
									{
										m_Escort.EscortDestination = "City of Fawn";
										break;
									}
									case 2: 
									{
										m_Escort.EscortDestination = "Glacial Coast Village";
										break;
									}
									case 3: 
									{
										m_Escort.EscortDestination = "Town of Grey";
										break;
									}
									case 4: 
									{
										m_Escort.EscortDestination = "Iceclad Fisherman";
										break;
									}
									case 5: 
									{
										m_Escort.EscortDestination = "Montor Docks";
										break;
									}
									case 6: 
									{
										m_Escort.EscortDestination = "Mountain Crest";
										break;
									}
									case 7: 
									{
										m_Escort.EscortDestination = "Sarth Abbey";
										break;
									}
									case 8: 
									{
										m_Escort.EscortDestination = "Umbra Tailor";
										break;
									}
									case 9: 
									{
										m_Escort.EscortDestination = "Town of Yew";
										break;
									}
								}

								DB.EscortDestination = m_Escort.EscortDestination;
								DB.Rankquesttype = "Escort";
								DB.RankQuestEscort = m_Escort;
								DB.Rankquestactive = true;
								
							}
							break;
						}
					}
					break;
				}
			}
		}
	}
}