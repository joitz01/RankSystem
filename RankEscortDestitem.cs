using System;
using Server;
using Server.Commands;
using Server.Mobiles;
using System.Collections;
using System.Collections.Generic;

namespace Server.Items
{
	public class RankEscortDestitem : Item
	{				
		public static void Initialize()
		{
			CommandHandlers.Register( "GenEscortDestinations", AccessLevel.GameMaster, new CommandEventHandler( GenDest_OnCommand ) );
			CommandHandlers.Register( "DelEscortDestinations", AccessLevel.GameMaster, new CommandEventHandler( DelDest_OnCommand ) );
		}
		
		[Usage( "GenEscortDestinations" )]
		[Description( "Generate Destinations." )]
		private static void GenDest_OnCommand( CommandEventArgs e )
		{
			PlayerMobile from = e.Mobile as PlayerMobile;

			RankEscortDestitem britainbridge = new RankEscortDestitem();
			britainbridge.MoveToWorld(new Point3D(2991, 985, 5), Map.Trammel);
			britainbridge.EscortDestination = "Britain Bridge";
			britainbridge.Name = "Britain Bridge";
			britainbridge.InvalidateProperties();
			
			RankEscortDestitem cityoffawn = new RankEscortDestitem();
			cityoffawn.MoveToWorld(new Point3D(2118, 276, 1), Map.Trammel);
			cityoffawn.EscortDestination = "City of Fawn";
			cityoffawn.Name = "City of Fawn";
			cityoffawn.InvalidateProperties();
			
			RankEscortDestitem glacialcostvil = new RankEscortDestitem();
			glacialcostvil.MoveToWorld(new Point3D(4766, 1196, 3), Map.Trammel);
			glacialcostvil.EscortDestination = "Glacial Coast Village";
			glacialcostvil.Name = "Glacial Coast Village";
			glacialcostvil.InvalidateProperties();
			
			RankEscortDestitem townofgrey = new RankEscortDestitem();
			townofgrey.MoveToWorld(new Point3D(902, 2063, 1), Map.Trammel);
			townofgrey.EscortDestination = "Town of Grey";
			townofgrey.Name = "Town of Grey";
			townofgrey.InvalidateProperties();
			
			RankEscortDestitem icecladfish = new RankEscortDestitem();
			icecladfish.MoveToWorld(new Point3D(4326, 1169, 3), Map.Trammel);
			icecladfish.EscortDestination = "Iceclad Fisherman";
			icecladfish.Name = "Iceclad Fisherman";
			icecladfish.InvalidateProperties();
			
			RankEscortDestitem montordocks = new RankEscortDestitem();
			montordocks.MoveToWorld(new Point3D(3212, 2610, 2), Map.Trammel);
			montordocks.EscortDestination = "Montor Docks";
			montordocks.Name = "Montor Docks";
			montordocks.InvalidateProperties();
			
			RankEscortDestitem mountaincrest = new RankEscortDestitem();
			mountaincrest.MoveToWorld(new Point3D(4514, 1276, 3), Map.Trammel);
			mountaincrest.EscortDestination = "Mountain Crest";
			mountaincrest.Name = "Mountain Crest";
			mountaincrest.InvalidateProperties();
			
			RankEscortDestitem sarthabbey = new RankEscortDestitem();
			sarthabbey.MoveToWorld(new Point3D(2698, 1462, 1), Map.Trammel);
			sarthabbey.EscortDestination = "Sarth Abbey";
			sarthabbey.Name = "Sarth Abbey";
			sarthabbey.InvalidateProperties();
			
			RankEscortDestitem umbratailor = new RankEscortDestitem();
			umbratailor.MoveToWorld(new Point3D(2662, 3272, 1), Map.Trammel);
			umbratailor.EscortDestination = "Umbra Tailor";
			umbratailor.Name = "Umbra Tailor";
			umbratailor.InvalidateProperties();
			
			RankEscortDestitem townofyew = new RankEscortDestitem();
			townofyew.MoveToWorld(new Point3D(2435, 877, 3), Map.Trammel);
			townofyew.EscortDestination = "Town of Yew";
			townofyew.Name = "Town of Yew";
			townofyew.InvalidateProperties();
			
			
			from.SendMessage( "You have generated all of the escort destination points for rank quest!");
		}
		
		[Usage( "DelEscortDestinations" )]
		[Description( "Delete Generate Destinations." )]
		private static void DelDest_OnCommand( CommandEventArgs e )
		{
			PlayerMobile from = e.Mobile as PlayerMobile;
			
			List<Item> itemList = new List<Item>(World.Items.Values);
			foreach (Item item in itemList)
            {
                if (item is RankEscortDestitem)
                {
					item.Delete();
					from.SendMessage( "You have deleted all of the escort destination points for rank quest!");
				}
			}
		}
		
		public string m_EscortDestination = "Escort Destination - None";
		
		[CommandProperty( AccessLevel.GameMaster )]
		public string EscortDestination 
		{
			get {return m_EscortDestination; }
			set { m_EscortDestination = value; InvalidateProperties(); } 
		}
		
		[Constructable]
		public RankEscortDestitem() : base( 0x1BC3 )
		{
			Weight = 2;
			Hue = Server.Misc.RandomThings.GetRandomColor(0);
			Name = EscortDestination;
			Visible = false;
			Movable = false;
		}

        public override bool Decays 
		{
			get 
			{
				return false; 
				
			}
		}

		public RankEscortDestitem(Serial serial) : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
            writer.Write( (int) 0 ); // version
			writer.Write(m_EscortDestination);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
            int version = reader.ReadInt();
			m_EscortDestination = reader.ReadString();
		}
	}
}