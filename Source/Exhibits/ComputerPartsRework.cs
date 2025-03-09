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
    public sealed class DiannaoPeijianDef : ExhibitTemplate
    {  
        public override IdContainer GetId() {
            return "DiannaoPeijian";
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
                Index: 522,
                Id: "DiannaoPeijian",
                Order: 10,
                IsDebug: false,
                IsPooled: true,
                IsSentinel: false,
                Revealable: true,
                Appearance: AppearanceType.Anywhere,
                Owner: null,
                LosableType: ExhibitLosableType.Losable,
                Rarity: Rarity.Common,
                Value1: 100,
                Value2: 1,
                Value3: null,
                Mana: null,
                BaseManaRequirement: null,
                BaseManaColor: null,
                BaseManaAmount: 1,
                HasCounter: false,
                InitialCounter: null,
                Keywords: Keyword.Power,
                RelativeEffects: new List<string>() { },
                RelativeCards: new List<string>() {}
            );
        }
    }
    
  	[EntityLogic(typeof(DiannaoPeijianDef))]
    public sealed class DiannaoPeijian : Exhibit
	{
		protected override void OnAdded(PlayerUnit player)
		{
			player.Us.MaxPowerLevel += base.Value2;
			base.GameRun.GainPower(base.Value1, false);
		}

		protected override void OnRemoved(PlayerUnit player)
		{
			player.Us.MaxPowerLevel -= base.Value2;
		}
    }
}