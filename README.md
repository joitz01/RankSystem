# RankSystem

This is an add-in for Ultima Adventures.

https://www.servuo.com/archive/ultima-adventures-a-full-featured-content-packed-offline-online-server.1374/

This is a Rank system that is in part inspired by the Anime Black Summoner. 
The Skills all have ranks, including the player.  As the player fights
their level also gains and provides base stat gains.  Can Disable this
by commenting it out in the RankLevelHandler.cs, can also comment out 
or just set the skill points gained to 0 in the same file.  


------------------------------------------------------------------------
-------------------------------------Notes------------------------------
------------------------------------------------------------------------
So far not many edits are needed, a core edit is needed, can use the
included eventsink.cs file and Mobile.cs file as a reference point. I  
Do not suggest copying and pasting them, find the eventsink info needed
and manually add it to your core files, then recomplile the exe.  

Commands:
/Rank 

Items: 
RankQuestBoard.cs - Place this somewhere for players to obtain quest 
towards gaining rank.  

This is not entirely meant for a production shard yet, as some features
are missing or not complete yet, feel free to have fun with it thogh.

------------------------------------------------------------------------
-----------------------------Core Changes ------------------------------
------------------------------------------------------------------------

Add in the evensinks for 
OnItemUseEventHandler OnItemUse;


------------------------------------------------------------------------
----------------------------Feature In Testing -------------------------
------------------------------------------------------------------------


Add the below to all basearmor, jewel clothing and weapon
		Locate this method
		public override void OnSingleClick( Mobile from )
		
		Above this add the below
		
		public override void SendPropertiesTo(Mobile from)
		{
			RankFeatures.DisplayPropsOverride(from);			
		}
		


------------------------------------------------------------------------
---------------------------------Edits----------------------------------
------------------------------------------------------------------------
		
Add to BaseCreature.cs , in the OnDeath Container section
			/* Rank System */
			if (this.LastKiller is PlayerMobile)
			{
				Mobile pm = (Mobile)this.LastKiller;
				RankLevelHandler.RankKillInfo(pm,this);
			}
			
			if (this.LastKiller is BaseCreature)
			{
				BaseCreature bcc = (BaseCreature)this.LastKiller;
				Mobile owner = bcc.ControlMaster;
				
				if (owner == null)
				{
					return;
				}
				else
				{
					RankLevelHandler.RankKillInfo(owner,this);
				}
			}
			
			
		
Open BaseDoor.cd
Find
		public virtual void Use( Mobile from )
		{
			
			Add in after revealing action
			
			//Rnak
			RankFeatures.DoorOpenPoints(from);
			//Rank
			

In Craftitem.cs
Around line 2001 just before addtobackpack, put in the following
					//RankSystem
					RankFeatures.CraftSystemExp(from,item,craftSystem);
					//RankSystem
					
	
	
Spell.cs
Around line 670 . just before the OnBeginCast(); entry 

RankFeatures.MagicRankExp(this,m_Caster, CastSkill);	

then also find the following
public virtual double GetDamageScalar( Mobile target )

add
RankFeatures.MagicRankResistExp(target);

Just before the return scaller line at the end.
