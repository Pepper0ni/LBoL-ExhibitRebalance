using System.Collections.Generic;
using System.Linq;
using LBoL.Base;
using LBoL.ConfigData;
using LBoL.Core;
using LBoLEntitySideloader.Attributes;
using LBoLEntitySideloader.Entities;
using LBoLEntitySideloader;
using LBoLEntitySideloader.Resource;
using ExhibitRebalance.Localization;
using LBoL.Core.Cards;
using LBoL.Core.Units;

namespace ExhibitRebalance.Exhibits
{
    [OverwriteVanilla]
    [ExhibitInfo(ExpireStageLevel = 3, ExpireStationLevel = 9)]
    public sealed class JudaShaoziDef : ExhibitTemplate
    {  
        public override IdContainer GetId() {
            return "JudaShaozi";
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
                Index: 525,
                Id: "JudaShaozi",
                Order: 10,
                IsDebug: false,
                IsPooled: true,
                IsSentinel: false,
                Revealable: true,
                Appearance: AppearanceType.Anywhere,
                Owner: null,
                LosableType: ExhibitLosableType.Losable,
                Rarity: Rarity.Common,
                Value1: 11,
                Value2: null,
                Value3: null,
                Mana: null,
                BaseManaRequirement: null,
                BaseManaColor: null,
                BaseManaAmount: 1,
                HasCounter: false,
                InitialCounter: null,
                Keywords: Keyword.Misfortune,
                RelativeEffects: new List<string>() { },
                RelativeCards: new List<string>() {}
            );
        }
    }
    
  	[EntityLogic(typeof(JudaShaoziDef))]
    public sealed class JudaShaozi : Exhibit
	{
        protected override void OnGain(PlayerUnit player)
		{
            int count = 0;
			foreach (Card card in base.GameRun.BaseDeck) {
                if (card.CardType == CardType.Misfortune) {
                    count += 1;
                }
			}
            if (count >= 1) {
				base.NotifyActivating();
				base.GameRun.GainMaxHp(count * base.Value1, true, true);
            }
		}

		protected override void OnAdded(PlayerUnit player)
		{
			base.HandleGameRunEvent<CardsEventArgs>(base.GameRun.DeckCardsAdded, delegate(CardsEventArgs args)
			{
				int num = args.Cards.Count((Card card) => card.CardType == CardType.Misfortune);
				if (num > 0)
				{
					base.NotifyActivating();
					base.GameRun.GainMaxHp(num * base.Value1, true, true);
				}
			});
		}
    }
}
