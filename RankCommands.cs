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

namespace Server.Commands
{
	public class CreateRankDB
	{
		public static void Initialize()
		{
			CommandSystem.Register( "CreateRankDB", AccessLevel.Counselor, new CommandEventHandler( DBs_OnCommand ) );
		}

		private class DBsTarget : Target
		{
			public DBsTarget() : base( -1, true, TargetFlags.None )
			{
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is PlayerMobile )
				{
					Mobile m = (Mobile)o;

					RankDatabase DB = Server.Items.RankDatabase.GetDB( m );

					if ( DB == null )
					{
						RankDatabase MyDB = new RankDatabase();
						MyDB.CharacterOwner = m;
						m.BankBox.DropItem( MyDB );
					}
				}
			}
		}

		[Usage( "CreateRankDB" )]
		[Description( "Creates a character statue in the character bank box, which acts as a database." )]
		private static void DBs_OnCommand( CommandEventArgs e )
		{
			e.Mobile.Target = new DBsTarget();
		}
	}
}