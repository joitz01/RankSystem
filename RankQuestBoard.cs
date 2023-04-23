using System;
using System.Collections;
using Server.ContextMenus;
using System.Collections.Generic;
using Server.Misc;
using System;
using Server;
using System.Text;
using Server.Gumps;
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Commands;

namespace Server.Items
{

	[Flipable(0x1E5E, 0x1E5F)]
    public class RankQuestBoard : Item
    {	
		int[] numArray = new int[1];

		string str = CommandSystem.Prefix;
		
        [Constructable]
        public RankQuestBoard() : base( 0x1E5E )
        {
            Name = "Rank Quest";
			Hue = 0x4A7;
        }

		public override void OnDoubleClick( Mobile e )
		{
			if ( e.InRange( this.GetWorldLocation(), 6 ) )
			{
				CommandSystem.Handle(e, string.Format("{0}QuestGump", str));
				return;
			}
			else
			{
				e.SendLocalizedMessage( 502138 ); // That is too far away for you to use
			}
		}
		
		public RankQuestBoard( Serial serial ) : base( serial )
		{
		}
		
        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );
            int version = reader.ReadInt();
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );
            writer.Write( (int)0 );
        }
	}
}