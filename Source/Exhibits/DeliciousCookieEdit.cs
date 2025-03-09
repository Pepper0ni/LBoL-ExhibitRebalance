using System.Collections.Generic;
using LBoL.Base;
using LBoL.ConfigData;
using LBoL.Core;
using LBoLEntitySideloader.Attributes;
using LBoLEntitySideloader.Entities;
using LBoLEntitySideloader;
using LBoLEntitySideloader.Resource;
using ExhibitRebalance.Localization;
using LBoL.Core.Units;

namespace ExhibitRebalance.Exhibits
{
    [OverwriteVanilla]
    public sealed class CookieDef : ExhibitTemplate
    {  
        public override IdContainer GetId() {
            return "Cookie";
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
                Index: 610,
                Id: "Cookie",
                Order: 10,
                IsDebug: false,
                IsPooled: true,
                IsSentinel: false,
                Revealable: true,
                Appearance: AppearanceType.ShopOnly,
                Owner: null,
                LosableType: ExhibitLosableType.Losable,
                Rarity: Rarity.Common,
                Value1: 4,
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
    
  	[EntityLogic(typeof(CookieDef))]
    public sealed class Cookie : Exhibit
	{		
        protected override void OnGain(PlayerUnit player)
		{
			base.GameRun.GainMaxHp(base.Value1, true, true);
			base.GameRun.HealToMaxHp(true, "Cookie");
            base.GameRun.GainPower(player.MaxPower - player.Power, false);
		}
    }
}