
Add in the evensinks for 
OnItemUseEventHandler OnItemUse;

Need to add to Provocation.cs -  Where the provocation is successful.
//Rank System
RankDatabase DBcheck = Server.Items.RankDatabase.GetDB( from );
if (DB != null){DBB.TotalKillsWithInstruments += 1;}
									
									




Add the below to all basearmor, jewel clothing and weapon
		Locate this method
		public override void OnSingleClick( Mobile from )
		
		Above this add the below
		
		public override void SendPropertiesTo(Mobile from)
		{
			RankFeatures.DisplayPropsOverride(from);			
		}
		



		
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