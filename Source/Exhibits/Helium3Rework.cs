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
using LBoL.Core.Battle;
using LBoL.Core.Battle.BattleActions;
using LBoL.Core.Cards;
using LBoL.Base.Extensions;

namespace ExhibitRebalance.Exhibits
{
    [OverwriteVanilla]
    public sealed class He3Def : ExhibitTemplate
    {  
        public override IdContainer GetId() {
            return "He3";
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
                Index: 301,
                Id: "He3",
                Order: 10,
                IsDebug: false,
                IsPooled: true,
                IsSentinel: false,
                Revealable: true,
                Appearance: AppearanceType.ShopOnly,
                Owner: null,
                LosableType: ExhibitLosableType.Losable,
                Rarity: Rarity.Uncommon,
                Value1: 3,
                Value2: null,
                Value3: null,
                Mana: null,
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
    
  	[EntityLogic(typeof(He3Def))]
    public sealed class He3 : Exhibit
	{
        protected override void OnEnterBattle()
        {
			base.ReactBattleEvent<UnitEventArgs>(base.Owner.TurnStarted, new EventSequencedReactor<UnitEventArgs>(this.OnPlayerTurnStarted));
        }
        private IEnumerable<BattleAction> OnPlayerTurnStarted(UnitEventArgs args)
		{
            List<Card> list = (from card in base.Battle.DrawZone where card.ConfigCost.Amount == base.Value1 select card).ToList<Card>();
            if (list.Count > 0)
            {
                yield return new MoveCardAction(list[0], CardZone.Hand);
            }
			/*foreach (Card card in base.Battle.DrawZone){
                if (card.ConfigCost.Amount == base.Value1){
                    yield return new MoveCardAction(card, CardZone.Hand);
                }
            }*/
			yield break;
		}
    }
}