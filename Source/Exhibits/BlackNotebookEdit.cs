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
using LBoL.Core.Units;
using LBoL.Core.Cards;

namespace ExhibitRebalance.Exhibits
{
    [OverwriteVanilla]
    public sealed class HeiseBijibenDef : ExhibitTemplate
    {  
        public override IdContainer GetId() {
            return "HeiseBijiben";
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
                Index: 614,
                Id: "HeiseBijiben",
                Order: 10,
                IsDebug: false,
                IsPooled: true,
                IsSentinel: false,
                Revealable: true,
                Appearance: AppearanceType.Anywhere,
                Owner: null,
                LosableType: ExhibitLosableType.Losable,
                Rarity: Rarity.Common,
                Value1: 25,
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
    
  	[EntityLogic(typeof(HeiseBijibenDef))]
    public sealed class HeiseBijiben : Exhibit
	{

        protected override void OnEnterBattle()
        {
            base.ReactBattleEvent<GameEventArgs>(base.Battle.BattleStarted, new EventSequencedReactor<GameEventArgs>(this.OnBattleStarted));
        }

        private IEnumerable<BattleAction> OnBattleStarted(GameEventArgs args)
		{
            List<EnemyUnit> list = new List<EnemyUnit>();
			foreach (EnemyUnit enemyUnit in base.Battle.EnemyGroup)
			{
				if (enemyUnit.IsAlive && enemyUnit.Config.RealName)
				{
					list.Add(enemyUnit);
				}
			}
			if (list.Count > 0)
			{
				yield return new DamageAction(base.Owner, list, DamageInfo.HpLose((float)base.Value1 * (base.GameRun.CurrentStation.Stage.Index + 1), false), "Instant", GunType.Single);
			}
			yield break;
		}
    }
}