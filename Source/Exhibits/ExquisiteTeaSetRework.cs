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
using LBoL.Core.Stations;

namespace ExhibitRebalance.Exhibits
{
    [OverwriteVanilla]
    public sealed class JingzhiChajuDef : ExhibitTemplate
    {  
        public override IdContainer GetId() {
            return "JingzhiChaju";
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
                Index: 521,
                Id: "JingzhiChaju",
                Order: 10,
                IsDebug: false,
                IsPooled: true,
                IsSentinel: false,
                Revealable: true,
                Appearance: AppearanceType.Anywhere,
                Owner: null,
                LosableType: ExhibitLosableType.Losable,
                Rarity: Rarity.Common,
                Value1: 15,
                Value2: 50,
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
    
  	[EntityLogic(typeof(JingzhiChajuDef))]
    public sealed class JingzhiChaju : Exhibit
	{
		protected override void OnAdded(PlayerUnit player)
		{
			base.GameRun.DrinkTeaAdditionalEnergy += base.Value2;
            base.HandleGameRunEvent<StationEventArgs>(base.GameRun.StationEntered, delegate(StationEventArgs args)
			{
				if (args.Station.Type == StationType.Gap)
				{
                    base.NotifyActivating();
					base.GameRun.Heal((int)((float)base.GameRun.Player.MaxHp * ((float)base.Value1 / 100.0f)), true, "JingzhiChaju");
				}
			});
		}

		protected override void OnRemoved(PlayerUnit player)
		{
			base.GameRun.DrinkTeaAdditionalEnergy -= base.Value2;
		}
    }
}