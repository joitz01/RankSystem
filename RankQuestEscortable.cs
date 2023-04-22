using System;
using Server;
using Server.Items;
using Server.Misc;

namespace Server.Mobiles
{	
	[CorpseName( "an escort corpse" )]
	public class RankQuestEscortable : BaseCreature
	{
		public Mobile QuestOwner;
		public string m_EscortDestination = "null";
	
		[CommandProperty( AccessLevel.GameMaster )]
		public string EscortDestination 
		{
			get {return m_EscortDestination; }
			set { m_EscortDestination = value; InvalidateProperties(); } 
		}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile Quest_Owner { get{ return QuestOwner; } set{ QuestOwner = value; } }
		
		public int CitizenType;
		[CommandProperty(AccessLevel.Owner)]
		public int Citizen_Type { get { return CitizenType; } set { CitizenType = value; InvalidateProperties(); } }

		public int CitizenLevel;
		[CommandProperty(AccessLevel.Owner)]
		public int Citizen_Level { get { return CitizenLevel; } set { CitizenLevel = value; InvalidateProperties(); } }

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			PlayerMobile pm = this.ControlMaster as PlayerMobile;
			BaseCreature bc = this as BaseCreature;
			
			if (bc != null && pm != null)
			{
				RankDatabase DB = Server.Items.RankDatabase.GetDB( pm );
				bc.ControlOrder = OrderType.Follow;
				bc.Loyalty = 100;
				
				IPooledEnumerable inRange = bc.Map.GetItemsInRange( bc.Location, 15 );
				foreach (Item item in inRange)
				{
					if (item is RankEscortDestitem)
					{
						RankEscortDestitem escortitem = item as RankEscortDestitem;
						if (escortitem != null && this.EscortDestination == escortitem.EscortDestination)
						{							
							if (DB != null)
							{
								DB.RankQuestEscort = null;
								DB.Rankquestactive = false;
								pm.SendMessage( "You have completed the escort quest!");
								DB.EscortCompleted += 1;
								RankFeatures.RankQuestCompletedTotal(pm, DB);
								RankFeatures.PlayerRankUpControl(pm, DB);
								RankSync.DeleteRankEscort(pm);
								DB.EscortDestination = null;
							}
						}
					}
				}
				
				if (pm.Alive == false)
				{
					pm.SendMessage( "You have failed your quest.  The escort abandons you!");
					if (bc == null)
					{
						return;
					}
					else
					{
						RankSync.DeleteRankEscort(pm);
					}
				}
			}
			/*
			IPooledEnumerable inRange = this.Map.GetItemsInRange( this.Location, 25 );
            foreach (Item item in inRange)
            {
                if (item is RankEscortDestitem)
                {
					RankEscortDestitem escortitem = item as RankEscortDestitem;
					if (this.EscortDestination == escortitem.EscortDestination)
					{
						if (this.ControlMaster is PlayerMobile && this.ControlMaster != null)
						{
							PlayerMobile pm = this.ControlMaster as PlayerMobile;
							BaseCreature bc = this.ControlMaster as BaseCreature;
							RankDatabase DB = Server.Items.RankDatabase.GetDB( pm );
							if (DB != null)
							{
								DB.RankQuestEscort = null;
								DB.Rankquestactive = false;
								pm.SendMessage( "You have completed the escort quest!");
								DB.EscortCompleted += 1;
								RankFeatures.RankQuestCompletedTotal(pm, DB);
								RankFeatures.PlayerRankUpControl(pm, DB);
								if (bc != null)
								{
									bc.Delete();
								}
							}
						}
						return;
					}
                }
            }

			if (this.ControlMaster is PlayerMobile && this.ControlMaster != null)
			{
				PlayerMobile pm2 = this.ControlMaster as PlayerMobile;
				BaseCreature bc = this as BaseCreature;
				
				if (bc != null)
				{
					bc.ControlOrder = OrderType.Follow;
					bc.Loyalty = 100;
				}
				
				
				if (pm2 != null && pm2.Alive == false)
				{
					pm2.SendMessage( "You have failed your quest.  The escort abandons you!");
					if (bc == null)
					{
						return;
					}
					else
					{
						RankDatabase DB = Server.Items.RankDatabase.GetDB( pm2 );
						if (DB != null)
						{
							DB.RankQuestEscort = null;
							DB.Rankquestactive = false;
						}
						bc.Delete();
					}
				}
			}
			*/
		}
		
		public override void OnDeath( Container c )
		{
			base.OnDeath( c );
			if (this.ControlMaster is PlayerMobile && this.ControlMaster != null)
			{
				PlayerMobile pm = this.ControlMaster as PlayerMobile;
				pm.SendMessage( "You have failed your quest. The escort charge has perished!");
			}
		}
		
		[Constructable]
		public RankQuestEscortable () : base( AIType.AI_Animal, FightMode.None, 10, 1, 0.2, 0.4 )
		{
			((BaseCreature)this).midrace = 1;
			
			if ( Female = Utility.RandomBool() ) 
			{ 
				Body = 401; 
				Name = NameList.RandomName( "female" );
			}
			else 
			{ 
				Body = 400; 			
				Name = NameList.RandomName( "male" ); 
				FacialHairItemID = Utility.RandomList( 0, 0, 8254, 8255, 8256, 8257, 8267, 8268, 8269 );
			}

			switch ( Utility.Random( 3 ) )
			{
				case 0: Server.Misc.IntelligentAction.DressUpWizards( this ); 				CitizenType = 1;	break;
				case 1: Server.Misc.IntelligentAction.DressUpFighters( this, "", false, 0 );	CitizenType = 2;	break;
				case 2: Server.Misc.IntelligentAction.DressUpRogues( this, "", false, 0, "");		CitizenType = 3;	break;
			}
			
			Tamable = false;
			ControlSlots = 0;

			Title = TavernPatrons.GetTitle();
			Hue = Server.Misc.RandomThings.GetRandomSkinColor();
			Utility.AssignRandomHair( this );
			SpeechHue = Server.Misc.RandomThings.GetSpeechHue();
			AI = AIType.AI_Animal;
			HairHue = Utility.RandomHairHue();
			FacialHairHue = HairHue;
			CitizenLevel = Utility.RandomMinMax( 1, 9 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, (CitizenLevel*4), (CitizenLevel*7) );
			SetResistance( ResistanceType.Fire, (CitizenLevel*4), (CitizenLevel*7) );
			SetResistance( ResistanceType.Cold, (CitizenLevel*4), (CitizenLevel*7) );
			SetResistance( ResistanceType.Poison, (CitizenLevel*4), (CitizenLevel*7) );
			SetResistance( ResistanceType.Energy, (CitizenLevel*4), (CitizenLevel*7) );

			if ( CitizenType == 1 )
			{
				AI = AIType.AI_Mage;
				SetStr( (CitizenLevel*50), (CitizenLevel*70) );
				SetDex( (CitizenLevel*70), (CitizenLevel*90) );
				SetInt( (CitizenLevel*100), (CitizenLevel*130) );

				SetHits( (CitizenLevel*100), (CitizenLevel*130) );

				SetSkill( SkillName.EvalInt, (28+(CitizenLevel*7)) );
				SetSkill( SkillName.Magery, (28+(CitizenLevel*7)) );
				SetSkill( SkillName.Meditation, (28+(CitizenLevel*7)) );
				SetSkill( SkillName.MagicResist, (28+(CitizenLevel*7)) );
				SetSkill( SkillName.Tactics, (28+(CitizenLevel*7)) );
				SetSkill( SkillName.Wrestling, (28+(CitizenLevel*7)) );
				SetSkill( SkillName.Archery, (28+(CitizenLevel*7)) );

				AddRangeWeapon();
			}
			else if ( CitizenType == 2 )
			{
				AI = AIType.AI_Melee;
				SetStr( (CitizenLevel*100), (CitizenLevel*130) );
				SetDex( (CitizenLevel*70), (CitizenLevel*90) );
				SetInt( (CitizenLevel*50), (CitizenLevel*70) );

				SetHits( (CitizenLevel*100), (CitizenLevel*130) );

				SetSkill( SkillName.Fencing, (28+(CitizenLevel*7)) );
				SetSkill( SkillName.Macing, (28+(CitizenLevel*7)) );
				SetSkill( SkillName.Swords, (28+(CitizenLevel*7)) );
				SetSkill( SkillName.MagicResist, (28+(CitizenLevel*7)) );
				SetSkill( SkillName.Tactics, (28+(CitizenLevel*7)) );
				SetSkill( SkillName.Wrestling, (28+(CitizenLevel*7)) );
				SetSkill( SkillName.Archery, (28+(CitizenLevel*7)) );
				SetSkill( SkillName.Parry, (28+(CitizenLevel*7)) );
			}
			else
			{
				AI = AIType.AI_Archer;
				SetStr( (CitizenLevel*70), (CitizenLevel*90) );
				SetDex( (CitizenLevel*100), (CitizenLevel*130) );
				SetInt( (CitizenLevel*50), (CitizenLevel*70) );

				SetHits( (CitizenLevel*100), (CitizenLevel*130) );

				SetSkill( SkillName.MagicResist, (28+(CitizenLevel*7)) );
				SetSkill( SkillName.Tactics, (28+(CitizenLevel*7)) );
				SetSkill( SkillName.Wrestling, (28+(CitizenLevel*7)) );
				SetSkill( SkillName.Archery, (28+(CitizenLevel*7)) );

				AddRangeWeapon();
			}

			SetDamage( (CitizenLevel*2), (CitizenLevel*3) );

			Fame = 2500 * CitizenLevel;
			Karma = Fame;

			VirtualArmor = CitizenLevel * 10;
		}

		public override void GenerateLoot()
		{
			if ( CitizenLevel > 8 ){ AddLoot( LootPack.FilthyRich ); }
			if ( CitizenLevel > 6 ){ AddLoot( LootPack.FilthyRich ); }
			if ( CitizenLevel > 4 ){ AddLoot( LootPack.Rich ); }
			if ( CitizenLevel > 2 ){ AddLoot( LootPack.Average ); }
			AddLoot( LootPack.Meager );

			if ( CitizenType == 1 ){ AddLoot( LootPack.MedScrolls, ( (int)( ( CitizenLevel / 3 ) + 1 ) ) ); }
		}

		public void AddRangeWeapon()
		{
			if ( FindItemOnLayer( Layer.OneHanded ) != null ) { FindItemOnLayer( Layer.OneHanded ).Delete(); }
			if ( FindItemOnLayer( Layer.TwoHanded ) != null ) { FindItemOnLayer( Layer.TwoHanded ).Delete(); }

			if ( Utility.RandomBool() )
			{
				ThrowingGloves glove = new ThrowingGloves();
				ThrowingWeapon ammo = new ThrowingWeapon( Utility.RandomMinMax( 15, 30 ) );

				switch ( Utility.Random( 5 ))		   
				{
					case 0: glove.GloveType = "Stones";		ammo.ammo = "Throwing Stones"; 	ammo.ItemID = 0x10B6; ammo.Name = "throwing stone";		break;
					case 1: glove.GloveType = "Axes"; 		ammo.ammo = "Throwing Axes"; 	ammo.ItemID = 0x10B3; ammo.Name = "throwing axe";		break;
					case 2: glove.GloveType = "Daggers"; 	ammo.ammo = "Throwing Daggers"; ammo.ItemID = 0x10B7; ammo.Name = "throwing dagger";	break;
					case 3: glove.GloveType = "Darts"; 		ammo.ammo = "Throwing Darts"; 	ammo.ItemID = 0x10B5; ammo.Name = "throwing dart";		break;
					case 4: glove.GloveType = "Stars"; 		ammo.ammo = "Throwing Stars"; 	ammo.ItemID = 0x10B2; ammo.Name = "throwing star";		break;
				};

				AddItem( glove );
				PackItem( ammo );
			}
			else if ( CitizenType == 1 )
			{
				switch ( Utility.Random( 2 ))		   
				{
					case 0: AddItem( new WizardStaff() );		break;
					case 1: AddItem( new WizardStick() );		break;
				};

				PackItem( new MageEye( Utility.RandomMinMax( 15, 30 ) ) );
			}
			else
			{
				switch ( Utility.Random( 8 ))		   
				{
					case 0: AddItem( new Bow() );					PackItem( new Arrow( Utility.RandomMinMax( 15, 30 ) ) );		break;
					case 1: AddItem( new Crossbow() );				PackItem( new Bolt( Utility.RandomMinMax( 15, 30 ) ) );			break;
					case 2: AddItem( new HeavyCrossbow() );			PackItem( new Bolt( Utility.RandomMinMax( 15, 30 ) ) );			break;
					case 3: AddItem( new RepeatingCrossbow() );		PackItem( new Bolt( Utility.RandomMinMax( 15, 30 ) ) );			break;
					case 4: AddItem( new CompositeBow() );			PackItem( new Arrow( Utility.RandomMinMax( 15, 30 ) ) );		break;
					case 5: AddItem( new MagicalShortbow() );		PackItem( new Arrow( Utility.RandomMinMax( 15, 30 ) ) );		break;
					case 6: AddItem( new ElvenCompositeLongbow() );	PackItem( new Arrow( Utility.RandomMinMax( 15, 30 ) ) );		break;
					case 7: AddItem( new Harpoon() );				PackItem( new HarpoonRope( Utility.RandomMinMax( 15, 30 ) ) );	break;
				};
			}
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override bool ClickTitle{ get{ return true; } }
		public override bool ShowFameTitle{ get{ return true; } }
		public override bool AlwaysAttackable{ get{ return true; } }
		public override int Meat{ get{ return 1; } }
		public override int TreasureMapLevel{ get{ return (int)((CitizenLevel/2)+1); } }

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );
			Server.Misc.IntelligentAction.CryOut( this );
		}

		public RankQuestEscortable( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
			writer.Write( CitizenType );
			writer.Write( CitizenLevel );
			writer.Write( (Mobile)QuestOwner );
			writer.Write(m_EscortDestination);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			CitizenType = reader.ReadInt();
			CitizenLevel = reader.ReadInt();
			QuestOwner = reader.ReadMobile();
			m_EscortDestination = reader.ReadString();
		}
	}
}