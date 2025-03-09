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
using LBoL.Core.Cards;
using LBoL.Core.Randoms;

namespace ExhibitRebalance.Exhibits
{
    [OverwriteVanilla]
    public sealed class HuangyouJiqirenDef : ExhibitTemplate
    {  
        public override IdContainer GetId() {
            return "HuangyouJiqiren";
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
                Index: 523,
                Id: "HuangyouJiqiren",
                Order: 10,
                IsDebug: false,
                IsPooled: true,
                IsSentinel: false,
                Revealable: true,
                Appearance: AppearanceType.Anywhere,
                Owner: null,
                LosableType: ExhibitLosableType.Losable,
                Rarity: Rarity.Common,
                Value1: 5,
                Value2: 2,
                Value3: 3,
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
    
  	[EntityLogic(typeof(HuangyouJiqirenDef))]
    public sealed class HuangyouJiqiren : Exhibit
	{
        protected override void OnEnterBattle()
        {
			base.ReactBattleEvent<UnitEventArgs>(base.Owner.TurnStarting, new EventSequencedReactor<UnitEventArgs>(this.OnTurnStarting));
        }
        private IEnumerable<BattleAction> OnTurnStarting(UnitEventArgs args)
		{
            if (base.Battle.Player.TurnCounter == base.Value2 || base.Battle.Player.TurnCounter == base.Value3){
                base.NotifyActivating();
                Card[] array = base.Battle.RollCards(new CardWeightTable(RarityWeightTable.OnlyRare, OwnerWeightTable.Valid, CardTypeWeightTable.CanBeLoot, false), 1);
                if (array.Length != 0)
                {
                    foreach (Card card in array)
                    {
                        card.IsExile = true;
                        card.IsEthereal = true;
                    }
                    yield return new AddCardsToHandAction(array);
                }
            }
			yield break;
		}
    }
}