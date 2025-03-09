using System.Collections.Generic;
using LBoL.Base;
using LBoL.ConfigData;
using LBoL.Core;
using LBoL.Core.Battle;
using LBoLEntitySideloader.Attributes;
using LBoL.Core.Battle.BattleActions;
using LBoLEntitySideloader.Entities;
using LBoLEntitySideloader;
using LBoLEntitySideloader.Resource;
using ExhibitRebalance.Localization;
using LBoL.Core.Cards;

namespace ExhibitRebalance.Exhibits
{
    [OverwriteVanilla]
    public sealed class SongjingMuyuDef : ExhibitTemplate
    {           
        public override IdContainer GetId() {
            return "SongjingMuyu";
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
                Index: 421,
                Id: "SongjingMuyu",
                Order: 10,
                IsDebug: false,
                IsPooled: true,
                IsSentinel: false,
                Revealable: false,
                Appearance: AppearanceType.ShopOnly,
                Owner: null,
                LosableType: ExhibitLosableType.Losable,
                Rarity: Rarity.Common,
                Value1: null,
                Value2: null,
                Value3: null,
                Mana: new ManaGroup() { White = 1 },
                BaseManaRequirement: null,
                BaseManaColor: null,
                BaseManaAmount: 1,
                HasCounter: false,
                InitialCounter: null,
                Keywords: Keyword.Exile,
                RelativeEffects: new List<string>() { },
                RelativeCards: new List<string>() {}
            );
        }

    }

    [EntityLogic(typeof(SongjingMuyuDef))]
    public sealed class SongjingMuyu : Exhibit
    {
        protected override void OnEnterBattle()
        {
            base.ReactBattleEvent<CardUsingEventArgs>(base.Battle.CardUsing, new EventSequencedReactor<CardUsingEventArgs>(this.OnCardUsing));
            base.ReactBattleEvent<CardUsingEventArgs>(base.Battle.CardUsed, new EventSequencedReactor<CardUsingEventArgs>(this.OnCardUsed));
            base.HandleBattleEvent<CardEventArgs>(base.Battle.CardExiled, new GameEventHandler<CardEventArgs>(this.OnCardExiled));
        }
        private IEnumerable<BattleAction> OnCardUsing(CardUsingEventArgs args)
		{
			base.Counter = 0;
            yield break;
		}
        private IEnumerable<BattleAction> OnCardUsed(CardUsingEventArgs args)
		{
			if (base.Counter > 0){
				base.NotifyActivating();
				yield return new GainManaAction(base.Mana);
            }
            yield break;
		}
        private void OnCardExiled(CardEventArgs args)
		{
            if (args.Cause == ActionCause.Card){
                Card card = args.ActionSource as Card;
                if (card.InstanceId != args.Card.InstanceId){
			        base.Counter = 1;
                }
            }
		}
    }
}