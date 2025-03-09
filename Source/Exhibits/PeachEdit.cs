using System.Collections.Generic;
using LBoL.Base;
using LBoL.ConfigData;
using LBoL.Core;
using LBoL.EntityLib.Exhibits;
using LBoL.Core.Battle;
using LBoLEntitySideloader.Attributes;
using LBoL.Core.Battle.BattleActions;
using LBoLEntitySideloader.Entities;
using LBoLEntitySideloader;
using LBoLEntitySideloader.Resource;
using ExhibitRebalance.Localization;
using LBoL.Core.Units;

namespace ExhibitRebalance.Exhibits
{
    [OverwriteVanilla]
    public sealed class TaoziDef : ExhibitTemplate
    {  
        public override IdContainer GetId() {
            return "Taozi";
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
                Index: 304,
                Id: "Taozi",
                Order: 10,
                IsDebug: false,
                IsPooled: true,
                IsSentinel: false,
                Revealable: false,
                Appearance: AppearanceType.Anywhere,
                Owner: null,
                LosableType: ExhibitLosableType.Losable,
                Rarity: Rarity.Rare,
                Value1: 16,
                Value2: null,
                Value3: null,
                Mana: new ManaGroup() { Colorless = 1 },
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
    
  	[EntityLogic(typeof(TaoziDef))]
    public sealed class Taozi : Exhibit
	{
        
		protected override void OnGain(PlayerUnit player)
		{
			base.GameRun.GainMaxHp(base.Value1, true, true);
		}

        protected override void OnEnterBattle()
        {
            base.ReactBattleEvent<UnitEventArgs>(base.Battle.Player.TurnStarted, new EventSequencedReactor<UnitEventArgs>(this.OnPlayerTurnStarted));
        }

        private IEnumerable<BattleAction> OnPlayerTurnStarted(GameEventArgs args)
		{
            if (base.Battle.Player.Hp >= base.Battle.Player.MaxHp)
            {
                base.NotifyActivating();
				yield return new GainManaAction(base.Mana);
            }

			yield break;
		}
    }
}