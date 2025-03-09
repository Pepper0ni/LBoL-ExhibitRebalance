using System.Collections.Generic;
using LBoL.Base;
using LBoL.Base.Extensions;
using LBoL.ConfigData;
using LBoL.Core;
using LBoLEntitySideloader.Attributes;
using LBoLEntitySideloader.Entities;
using LBoLEntitySideloader;
using LBoLEntitySideloader.Resource;
using ExhibitRebalance.Localization;
using LBoL.Core.Battle;
using LBoL.Core.Battle.BattleActions;
using LBoL.Core.Units;

namespace ExhibitRebalance.Exhibits
{
    [OverwriteVanilla]
    public sealed class PutaoDef : ExhibitTemplate
    {  
        public override IdContainer GetId() {
            return "Putao";
        }

        public override LocalizationOption LoadLocalization()
        {
            return SampleCharacterLocalization.ExhibitsBatchLoc.AddEntity(this);
        }

        public override ExhibitSprites LoadSprite()
        {
            var exhibitSprites = new ExhibitSprites();
            exhibitSprites.main = ResourceLoader.LoadSprite(this.GetId() + ".png", BepinexPlugin.embeddedSource);;
            return exhibitSprites;
        }
        public override ExhibitConfig MakeConfig()
        {
            return new ExhibitConfig(
                Index: 507,
                Id: "Putao",
                Order: 10,
                IsDebug: false,
                IsPooled: true,
                IsSentinel: false,
                Revealable: true,
                Appearance: AppearanceType.Anywhere,
                Owner: null,
                LosableType: ExhibitLosableType.Losable,
                Rarity: Rarity.Common,
                Value1: 8,
                Value2: 2,
                Value3: null,
                Mana: null,
                BaseManaRequirement: null,
                BaseManaColor: null,
                BaseManaAmount: 1,
                HasCounter: false,
                InitialCounter: null,
                Keywords: Keyword.Power,
                RelativeEffects: new List<string>() { },
                RelativeCards: new List<string>() {}
            );
        }
    }
    
  	[EntityLogic(typeof(PutaoDef))]
    public sealed class Putao : Exhibit
	{		
		protected override void OnEnterBattle()
		{
			base.HandleBattleEvent<DamageEventArgs>(base.Battle.Player.DamageTaking, new GameEventHandler<DamageEventArgs>(this.OnPlayerDamageTaking));
            base.Active = true;
        }
        protected override void OnGain(PlayerUnit player)
        {
            base.GameRun.GainMaxHp(base.Value1, true, true);
        }
        private void OnPlayerDamageTaking(DamageEventArgs args)
		{
			if (base.Active == true && args.DamageInfo.Damage.RoundToInt() > 0)
			{
                base.NotifyActivating();
				base.Active = false;
                base.GameRun.GainPower(args.DamageInfo.Damage.RoundToInt() * base.Value2, true);
			}
		}
    }
}