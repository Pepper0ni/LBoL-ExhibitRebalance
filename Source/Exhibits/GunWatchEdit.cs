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
using LBoL.Core.StatusEffects;
using LBoL.Core.Units;

namespace ExhibitRebalance.Exhibits
{
    [OverwriteVanilla]
    public sealed class ShoubiaoMazuiqiangDef : ExhibitTemplate
    {  
        public override IdContainer GetId() {
            return "ShoubiaoMazuiqiang";
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
                Index: 611,
                Id: "ShoubiaoMazuiqiang",
                Order: 10,
                IsDebug: false,
                IsPooled: true,
                IsSentinel: false,
                Revealable: true,
                Appearance: AppearanceType.Anywhere,
                Owner: null,
                LosableType: ExhibitLosableType.Losable,
                Rarity: Rarity.Uncommon,
                Value1: 1,
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
    
  	[EntityLogic(typeof(ShoubiaoMazuiqiangDef))]
    public sealed class ShoubiaoMazuiqiang : Exhibit
	{
        protected override void OnEnterBattle()
		{
			base.ReactBattleEvent<GameEventArgs>(base.Battle.BattleStarted, new EventSequencedReactor<GameEventArgs>(this.OnBattleStarted));
		}

		private IEnumerable<BattleAction> OnBattleStarted(GameEventArgs args)
		{
			foreach (EnemyUnit enemyUnit in base.Battle.EnemyGroup)
			{
				if (enemyUnit.IsAlive)
				{
                    yield return new ApplyStatusEffectAction<Weak>(enemyUnit, new int?(1), new int?(base.Value1), null, null, 0f, true);
                    yield return new ApplyStatusEffectAction<Vulnerable>(enemyUnit, new int?(1), new int?(base.Value1), null, null, 0f, true);
				}
			}
			yield break;
		}
    }
}