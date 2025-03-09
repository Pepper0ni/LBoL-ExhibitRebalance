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

namespace ExhibitRebalance.Exhibits
{
    [OverwriteVanilla]
    public sealed class HeijiaoChangpianDef : ExhibitTemplate
    {  
        public override IdContainer GetId() {
            return "HeijiaoChangpian";
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
                Index: 603,
                Id: "HeijiaoChangpian",
                Order: 10,
                IsDebug: false,
                IsPooled: true,
                IsSentinel: false,
                Revealable: true,
                Appearance: AppearanceType.ShopOnly,
                Owner: null,
                LosableType: ExhibitLosableType.Losable,
                Rarity: Rarity.Common,
                Value1: null,
                Value2: null,
                Value3: null,
                Mana: new ManaGroup() { Black = 1 },
                BaseManaRequirement: null,
                BaseManaColor: null,
                BaseManaAmount: 1,
                HasCounter: false,
                InitialCounter: null,
                Keywords: Keyword.None,
                RelativeEffects: new List<string>() { },
                RelativeCards: new List<string>() {}
            );
        }
    }
    
  	[EntityLogic(typeof(HeijiaoChangpianDef))]
    public sealed class HeijiaoChangpian : Exhibit
	{

        protected override void OnEnterBattle()
        {
            base.ReactBattleEvent<CardEventArgs>(base.Battle.CardDrawn, new EventSequencedReactor<CardEventArgs>(this.OnCardDrawn));
        }

		private IEnumerable<BattleAction> OnCardDrawn(CardEventArgs args)
		{
			if (args.Card.CardType == CardType.Status || args.Card.CardType == CardType.Misfortune)
			{
				base.NotifyActivating();
				yield return new GainManaAction(base.Mana);
			}
			yield break;
		}
    }
}