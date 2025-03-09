
using System.Collections.Generic;
using LBoL.Base;
using LBoL.ConfigData;
using LBoLEntitySideloader.Entities;

namespace ExhibitRebalance.Config
{
    public sealed class SampleCharacterDefaultConfig
    {
        private static readonly string OwnerName = BepinexPlugin.modUniqueID;
        public static string GetDefaultID(EntityDefinition entity)
        {
            string IDdef = entity.GetType().Name;
            //Remove the Def at the end of the entity (class name) to get the ID. 
            //string ID = IDdef.Replace(@"Def", "");
            string ID = IDdef.Remove(IDdef.Length - 3);
            return ID;
        }

        public static ExhibitConfig GetDefaultExhibitConfig()
        {
            return new ExhibitConfig(
                Index: 0,
                Id: "",
                Order: 10,
                IsDebug: false,
                IsPooled: false,
                IsSentinel: false,
                Revealable: false,
                Appearance: AppearanceType.Nowhere,
                Owner: OwnerName,
                LosableType: ExhibitLosableType.DebutLosable,
                Rarity: Rarity.Shining,
                Value1: null,
                Value2: null,
                Value3: null,
                Mana: new ManaGroup() { },
                BaseManaRequirement: null,
                BaseManaColor: ManaColor.White,
                BaseManaAmount: 1,
                HasCounter: false,
                InitialCounter: null,
                Keywords: Keyword.None,
                RelativeEffects: new List<string>() { },
                RelativeCards: new List<string>() {}
            );
        }

    }
}