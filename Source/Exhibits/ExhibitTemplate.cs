using LBoL.ConfigData;
using LBoLEntitySideloader;
using LBoLEntitySideloader.Entities;
using LBoLEntitySideloader.Resource;
using ExhibitRebalance.Config;
using ExhibitRebalance.ImageLoader;
using ExhibitRebalance.Localization;

namespace ExhibitRebalance.Exhibits
{
    public class SampleCharacterExhibitTemplate : ExhibitTemplate
    {
        public override IdContainer GetId()
        {
            string IDdef = this.GetType().Name;
            //Remove the Def at the end of the entity (class name) to get the ID. 
            //string ID = IDdef.Replace(@"Def", "");
            string ID = IDdef.Remove(IDdef.Length - 3);
            return ID;
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
            return GetDefaultExhibitConfig();
        }

        public ExhibitConfig GetDefaultExhibitConfig()
        {
            return SampleCharacterDefaultConfig.GetDefaultExhibitConfig();
        }

    }
}