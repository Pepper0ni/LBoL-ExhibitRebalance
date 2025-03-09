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
    public sealed class BewitchedBroomExhibitDef : ExhibitTemplate
    {           
        public override IdContainer GetId() {
            return "BewitchedBroomExhibit";
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
                Index: 0,
                Id: "",
                Order: 10,
                IsDebug: false,
                IsPooled: true,
                IsSentinel: false,
                Revealable: false,
                Appearance: AppearanceType.Anywhere,
                Owner: null,
                LosableType: ExhibitLosableType.Losable,
                Rarity: Rarity.Rare,
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

    [EntityLogic(typeof(BewitchedBroomExhibitDef))]
    public sealed class BewitchedBroomExhibit : Exhibit
    {
        protected override void OnEnterBattle()
        {
            base.ReactBattleEvent<StatusEffectApplyEventArgs>(base.Battle.Player.StatusEffectAdding, 
                                                              new EventSequencedReactor<StatusEffectApplyEventArgs>(this.OnStatusEffectAdding));
        }

        private IEnumerable<BattleAction> OnStatusEffectAdding(StatusEffectApplyEventArgs args)
		{
			if (args.Effect.Type == StatusEffectType.Negative)
			{
				base.NotifyActivating();
				yield return new GainManaAction(base.Mana);
			}
			yield break;
		}
    }
}