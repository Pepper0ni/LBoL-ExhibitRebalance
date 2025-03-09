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
using LBoL.Core.StatusEffects;
using LBoL.EntityLib.StatusEffects.Basic;

namespace ExhibitRebalance.Exhibits
{
    [OverwriteVanilla]
    public sealed class PingguoDef : ExhibitTemplate
    {  
        public override IdContainer GetId() {
            return "Pingguo";
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
                Index: 408,
                Id: "Pingguo",
                Order: 10,
                IsDebug: false,
                IsPooled: true,
                IsSentinel: false,
                Revealable: true,
                Appearance: AppearanceType.Anywhere,
                Owner: null,
                LosableType: ExhibitLosableType.Losable,
                Rarity: Rarity.Common,
                Value1: 12,
                Value2: 1,
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
    
  	[EntityLogic(typeof(PingguoDef))]
    public sealed class Pingguo : Exhibit
	{		
        protected override void OnGain(PlayerUnit player)
		{
			base.GameRun.GainMaxHp(base.Value1, true, true);
		}

		protected override void OnEnterBattle()
		{
			base.ReactBattleEvent<GameEventArgs>(base.Battle.BattleStarted, new EventSequencedReactor<GameEventArgs>(this.OnBattleStarted));
		}

		private IEnumerable<BattleAction> OnBattleStarted(GameEventArgs args)
		{
			yield return new ApplyStatusEffectAction<AmuletForCard>(base.Owner, new int?(base.Value2), null, null, null, 0f, true);
            yield break;
		}
    }
}