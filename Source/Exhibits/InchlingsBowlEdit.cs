using System.Collections.Generic;
using LBoL.Base;
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
using JetBrains.Annotations;

namespace ExhibitRebalance.Exhibits
{
    [OverwriteVanilla]
    [UsedImplicitly]
    public sealed class XiaorenWanDef : ExhibitTemplate
    {  
        public override IdContainer GetId() {
            return "XiaorenWan";
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
                Index: 425,
                Id: "XiaorenWan",
                Order: 10,
                IsDebug: false,
                IsPooled: true,
                IsSentinel: false,
                Revealable: true,
                Appearance: AppearanceType.Anywhere,
                Owner: null,
                LosableType: ExhibitLosableType.Losable,
                Rarity: Rarity.Common,
                Value1: 2,
                Value2: 1,
                Value3: null,
                Mana: null,
                BaseManaRequirement: null,
                BaseManaColor: null,
                BaseManaAmount: 1,
                HasCounter: false,
                InitialCounter: null,
                Keywords: Keyword.None,
                RelativeEffects: new List<string>() {},
                RelativeCards: new List<string>() {}
            );
        }
    }
    
  	[EntityLogic(typeof(XiaorenWanDef))]
    public sealed class XiaorenWan : Exhibit
	{		
		protected override void OnAdded(PlayerUnit player)
		{
			base.HandleGameRunEvent<GameEventArgs>(base.GameRun.RewardAbandoned, delegate(GameEventArgs _)
			{
				base.NotifyActivating();
				base.GameRun.GainMaxHp(base.Value1, true, true);
			});
		}
        protected override void OnEnterBattle()
        {
			base.HandleBattleEvent<UnitEventArgs>(base.Battle.Player.TurnStarting, delegate(UnitEventArgs _)
			{
				base.Active = true;
			});
			base.ReactBattleEvent<CardUsingEventArgs>(base.Battle.CardUsed, new EventSequencedReactor<CardUsingEventArgs>(this.OnCardUsed));
        }

        private IEnumerable<BattleAction> OnCardUsed(CardUsingEventArgs args)
		{
			if (args.Card.IsBasic && base.Active == true){
				base.NotifyActivating();
                base.Active = false;
				yield return new DrawManyCardAction(base.Value2);
            }
            yield break;
		}
        protected override void OnLeaveBattle()
		{
			base.Active = false;
		}
    }
}