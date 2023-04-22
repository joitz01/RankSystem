using System;
using Server;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Items
{
	[Flipable( 0x2c7e, 0x1e3f )]
    public class GatheringPouchQuest : LargeSack
    {
		[Constructable]
		public GatheringPouchQuest() : base()
		{
			Weight = 1.0;
			MaxItems = 50;
			Name = "Gathering Pouch for Rank Quest";
			Hue = 0x31;
		}
		
		public override void OnDoubleClick( Mobile m )
		{
			//Need to setup commands 
			//Need failed message for wrong items
			
			if ( !IsChildOf( m.Backpack ) )
			{
				m.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
			}
			else
			{
				m.Target = new QuestGatherTarget( m, this);
			}
			
		}

		public override bool OnDragDropInto( Mobile from, Item dropped, Point3D p )
        {
			PlayerMobile pm = from as PlayerMobile;
			RankDatabase DB = Server.Items.RankDatabase.GetDB( pm );
			
			if (DB != null)
			{
				int SetKillTotal = RankQuestAnimals.Quest_SetKillTotal(from, DB);

				Type typ1 = dropped.GetType();
				string name1 = typ1.Name;

				if (DB.Rankquestobjectivefour >= SetKillTotal &&
				DB.Rankquestobjectivethree >= SetKillTotal &&
				DB.Rankquestobjectivetwo >= SetKillTotal &&
				DB.Rankquestobjectiveone >= SetKillTotal)
				{
					RankQuestAnimals.Quest_Gathering_Complete(from, DB);
					return false;
				}
				else if ( dropped is Container )
				{
					from.SendMessage("You can't add a container in this pouch.");
					return false;
				}
				else if ( dropped.Amount > 1)
				{
					from.SendMessage("You cannot add stacks!.");
					return false;
				}
				else if (name1 == DB.Rankquestcreaturenameone)
				{
					if (DB.Rankquestobjectiveone >= SetKillTotal)
					{
						return false;
					}
					else
					{
						DB.Rankquestobjectiveone += 1;
						dropped.Delete();
						return true;
					}
				}
				else if (name1 == DB.Rankquestcreaturenametwo)
				{
					if (DB.Rankquestobjectiveone >= SetKillTotal)
					{
						return false;
					}
					else
					{
						DB.Rankquestobjectivetwo += 1;
						dropped.Delete();
						return true;
					}
				}
				else if (name1 == DB.Rankquestcreaturenamethree)
				{
					if (DB.Rankquestobjectiveone >= SetKillTotal)
					{
						return false;
					}
					else
					{
						DB.Rankquestobjectivethree += 1;
						dropped.Delete();
						return true;
					}
				}
				else if (name1 == DB.Rankquestcreaturenamefour)
				{
					if (DB.Rankquestobjectiveone >= SetKillTotal)
					{
						return false;
					}
					else
					{
						DB.Rankquestobjectivefour += 1;
						dropped.Delete();
						return true;
					}
				}
				return false;
			}				
			return false;
        }

		public override bool OnDragDrop( Mobile from, Item dropped )
        {
			PlayerMobile pm = from as PlayerMobile;
			RankDatabase DB = Server.Items.RankDatabase.GetDB( pm );
			
			if (DB != null)
			{
				int SetKillTotal = RankQuestAnimals.Quest_SetKillTotal(from, DB);

				Type typ1 = dropped.GetType();
				string name1 = typ1.Name;

				if (DB.Rankquestobjectivefour >= SetKillTotal &&
				DB.Rankquestobjectivethree >= SetKillTotal &&
				DB.Rankquestobjectivetwo >= SetKillTotal &&
				DB.Rankquestobjectiveone >= SetKillTotal)
				{
					RankQuestAnimals.Quest_Gathering_Complete(from, DB);
					return false;
				}
				else if ( dropped is Container )
				{
					from.SendMessage("You can't add a container in this pouch.");
					return false;
				}
				else if ( dropped.Amount > 1)
				{
					from.SendMessage("You cannot add stacks!.");
					return false;
				}
				else if (name1 == DB.Rankquestcreaturenameone)
				{
					if (DB.Rankquestobjectiveone >= SetKillTotal)
					{
						return false;
					}
					else
					{
						DB.Rankquestobjectiveone += 1;
						dropped.Delete();
						from.SendMessage("You tuck the item into the pouch!");
						return true;
					}
				}
				else if (name1 == DB.Rankquestcreaturenametwo)
				{
					if (DB.Rankquestobjectiveone >= SetKillTotal)
					{
						return false;
					}
					else
					{
						DB.Rankquestobjectivetwo += 1;
						dropped.Delete();
						from.SendMessage("You tuck the item into the pouch!");
						return true;
					}
				}
				else if (name1 == DB.Rankquestcreaturenamethree)
				{
					if (DB.Rankquestobjectiveone >= SetKillTotal)
					{
						return false;
					}
					else
					{
						DB.Rankquestobjectivethree += 1;
						dropped.Delete();
						from.SendMessage("You tuck the item into the pouch!");
						return true;
					}
				}
				else if (name1 == DB.Rankquestcreaturenamefour)
				{
					if (DB.Rankquestobjectiveone >= SetKillTotal)
					{
						return false;
					}
					else
					{
						DB.Rankquestobjectivefour += 1;
						dropped.Delete();
						from.SendMessage("You tuck the item into the pouch!");
						return true;
					}
				}
				return false;
			}				
			return false;
        }

		public GatheringPouchQuest( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			Weight = 1.0;
			MaxItems = 50;
			Name = "Gathering Pouch for Rank Quest";
		}
	}
	
	public class QuestGatherTarget : Target
	{
		private GatheringPouchQuest m_gatherpouch;
		private bool m_StaffCommand;

		public QuestGatherTarget( Mobile from, GatheringPouchQuest gatherpouch ) : base( 10, false, TargetFlags.None )
		{
			m_gatherpouch = gatherpouch;

			from.SendMessage( "Target the gathered quest item." );
		}

		protected override void OnTarget( Mobile from, object target )
		{//NEED TO PREVENT STACKS FROM WORKING!!!
			if (target is Mobile)
			{
				from.SendMessage("You realize this won't work.");
				return;
			}
			Item item = target as Item;

			PlayerMobile pm = from as PlayerMobile;
			RankDatabase DB = Server.Items.RankDatabase.GetDB( pm );
			
			if (DB != null)
			{
				int SetKillTotal = RankQuestAnimals.Quest_SetKillTotal(from, DB);
				
				Type typ1 = item.GetType();
				string name1 = typ1.Name;
				
				if ( item is Container )
				{
					from.SendMessage("You can't add a container in this pouch.");
					return;
				}
				else if ( item.Amount > 1)
				{
					from.SendMessage("You can't add a stack of items!");
					return;
				}
				else if (name1 == DB.Rankquestcreaturenameone)
				{
					if (DB.Rankquestobjectiveone >= SetKillTotal)
					{
						return;
					}
					else
					{
						DB.Rankquestobjectiveone += 1;
						GatherCompleteCheck(pm,DB);
						from.SendMessage("You tuck the item into the pouch!");
						item.Delete();
						return;
					}
				}
				else if (name1 == DB.Rankquestcreaturenametwo)
				{
					if (DB.Rankquestobjectiveone >= SetKillTotal)
					{
						return;
					}
					else
					{
						DB.Rankquestobjectivetwo += 1;
						GatherCompleteCheck(pm,DB);
						item.Delete();
						from.SendMessage("You tuck the item into the pouch!");
						return;
					}
				}
				else if (name1 == DB.Rankquestcreaturenamethree)
				{
					if (DB.Rankquestobjectiveone >= SetKillTotal)
					{
						return;
					}
					else
					{
						DB.Rankquestobjectivethree += 1;
						GatherCompleteCheck(pm,DB);
						item.Delete();
						from.SendMessage("You tuck the item into the pouch!");
						return;
					}
				}
				else if (name1 == DB.Rankquestcreaturenamefour)
				{
					if (DB.Rankquestobjectiveone >= SetKillTotal)
					{
						return;
					}
					else
					{
						DB.Rankquestobjectivefour += 1;
						GatherCompleteCheck(pm,DB);
						item.Delete();
						from.SendMessage("You tuck the item into the pouch!");
						return;
					}
				}
				else
				{
					from.SendMessage("This is not on the gather list for your quest.");
					return;
				}
				
			}				
			return;
			
		}
		private static void GatherCompleteCheck (Mobile from, RankDatabase DB)
		{
			int SetKillTotal = RankQuestAnimals.Quest_SetKillTotal(from, DB);

			if (DB.Rankquestobjectivefour >= SetKillTotal &&
			DB.Rankquestobjectivethree >= SetKillTotal &&
			DB.Rankquestobjectivetwo >= SetKillTotal &&
			DB.Rankquestobjectiveone >= SetKillTotal)
			{
				RankQuestAnimals.Quest_Gathering_Complete(from, DB);
				return;
			}
		}
	}
}