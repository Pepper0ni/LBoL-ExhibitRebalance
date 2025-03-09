using HarmonyLib;
using LBoL.Base;
using LBoL.ConfigData;
using LBoL.Core.Exhibits;
using LBoL.EntityLib.Exhibits.Common;

namespace MyAwesomeBalancePatch
{
    [HarmonyPatch]
    class ExhibitConfigPatch
    {
        [HarmonyPatch(typeof(ExhibitConfig), nameof(ExhibitConfig.Load))]
        private static void Postfix(ExhibitConfig __instance)
        {  
            //Just-a-knife
            ExhibitConfig._IdTable[nameof(PingfanDao)].Appearance = AppearanceType.ShopOnly;
            ExhibitConfig._IdTable[nameof(PingfanDao)].Value1 = 5; // Buff damage from 2 to 5.
            ExhibitConfig._IdTable[nameof(PingfanDao)].Value2 = 10; // Buff damage from 4 to 10.

            //Roukanken
            ExhibitConfig._IdTable[nameof(LouguanJian)].Appearance = AppearanceType.Anywhere;

            //Bottle
            ExhibitConfig._IdTable[nameof(Moping)].Appearance = AppearanceType.Anywhere;

            //Model Robot
            ExhibitConfig._IdTable[nameof(LuoboMoxing)].Appearance = AppearanceType.Anywhere;
            ExhibitConfig._IdTable[nameof(LuoboMoxing)].Rarity = Rarity.Uncommon;

            //Take-Copter
            ExhibitConfig._IdTable[nameof(ZhuQingting)].Appearance = AppearanceType.Anywhere;

            //Omikuji
            ExhibitConfig._IdTable[nameof(Yushenqian)].Appearance = AppearanceType.Anywhere;
            ExhibitConfig._IdTable[nameof(Yushenqian)].Rarity = Rarity.Uncommon;

            //Hakurei Amulet
            ExhibitConfig._IdTable[nameof(BoliHufu)].Appearance = AppearanceType.Anywhere;

            //Membership Card
            ExhibitConfig._IdTable[nameof(Huiyuanka)].Appearance = AppearanceType.Anywhere;
            ExhibitConfig._IdTable[nameof(Huiyuanka)].Rarity = Rarity.Uncommon;

            //Sutra of Dharmatic Power
            ExhibitConfig._IdTable[nameof(FaliJingdian)].Appearance = AppearanceType.Anywhere;
            ExhibitConfig._IdTable[nameof(FaliJingdian)].Rarity = Rarity.Uncommon;

            //Silver Pocket Watch
            ExhibitConfig._IdTable[nameof(YinzhiHuaibiao)].Appearance = AppearanceType.Anywhere;
            ExhibitConfig._IdTable[nameof(YinzhiHuaibiao)].Rarity = Rarity.Rare;

            //Ribbon
            ExhibitConfig._IdTable[nameof(Duandai)].Appearance = AppearanceType.Anywhere;
            ExhibitConfig._IdTable[nameof(Duandai)].Rarity = Rarity.Rare;

            //Chopper
            ExhibitConfig._IdTable[nameof(Chaidao)].Appearance = AppearanceType.ShopOnly;

            //Tape
            ExhibitConfig._IdTable[nameof(Jiaobu)].Appearance = AppearanceType.ShopOnly;

            //TNT
            ExhibitConfig._IdTable[nameof(Tnt)].Appearance = AppearanceType.ShopOnly;

            /*//Ice Cube
            ExhibitConfig._IdTable[nameof(Bingkuai)].Rarity = Rarity.Uncommon;

            //Peony
            ExhibitConfig._IdTable[nameof(Shaoyao)].Rarity = Rarity.Uncommon;
            //Buff to trigger 3 times for 9 total healing
            ExhibitConfig._IdTable[nameof(Shaoyao)].Value3 = 3;

            //Oil
            ExhibitConfig._IdTable[nameof(Shiyou)].Rarity = Rarity.Uncommon;

            //Peony Stone
            ExhibitConfig._IdTable[nameof(JingwanMudan)].Rarity = Rarity.Uncommon;

            //Leaf
            ExhibitConfig._IdTable[nameof(Shuye)].Rarity = Rarity.Uncommon;*/

            //Crow Tengu's Wing
            ExhibitConfig._IdTable[nameof(TiangouYuyi)].Appearance = AppearanceType.ShopOnly;

            //Fox Mask
            ExhibitConfig._IdTable[nameof(HuliMianju)].Appearance = AppearanceType.ShopOnly;
            ExhibitConfig._IdTable[nameof(HuliMianju)].Rarity = Rarity.Common;

            //Hannya Mask
            ExhibitConfig._IdTable[nameof(BoreMianju)].Appearance = AppearanceType.ShopOnly;
            ExhibitConfig._IdTable[nameof(BoreMianju)].Rarity = Rarity.Common;

            //Hyottoko Mask
            ExhibitConfig._IdTable[nameof(HuonanMianju)].Appearance = AppearanceType.ShopOnly;
            ExhibitConfig._IdTable[nameof(HuonanMianju)].Rarity = Rarity.Common;
            ExhibitConfig._IdTable[nameof(HuonanMianju)].Value2 = 10;

            //Mask of Hope
            ExhibitConfig._IdTable[nameof(XiwangMianju)].Appearance = AppearanceType.ShopOnly;
            ExhibitConfig._IdTable[nameof(XiwangMianju)].Rarity = Rarity.Uncommon;

            //Ibuki Gourd
            ExhibitConfig._IdTable[nameof(YichuiPiao)].Appearance = AppearanceType.ShopOnly;
            ExhibitConfig._IdTable[nameof(YichuiPiao)].Rarity = Rarity.Common;

            //Lunatic Gun
            ExhibitConfig._IdTable[nameof(YuekuangQiang)].Appearance = AppearanceType.ShopOnly;
            ExhibitConfig._IdTable[nameof(YuekuangQiang)].Rarity = Rarity.Uncommon;

            //Gensokyo Chronicle
            ExhibitConfig._IdTable[nameof(HuanxiangxiangYuanqi)].Appearance = AppearanceType.ShopOnly;
            ExhibitConfig._IdTable[nameof(HuanxiangxiangYuanqi)].Rarity = Rarity.Common;

            //Purple Mirror
            ExhibitConfig._IdTable[nameof(Zijing)].Appearance = AppearanceType.ShopOnly;
            ExhibitConfig._IdTable[nameof(Zijing)].Rarity = Rarity.Uncommon;

            //Lunar Veil
            ExhibitConfig._IdTable[nameof(YueYuyi)].Rarity = Rarity.Uncommon;

            //Ticket to Hell
            ExhibitConfig._IdTable[nameof(DiyuChepiao)].Rarity = Rarity.Uncommon;

            //Spacesuit
            ExhibitConfig._IdTable[nameof(Yuhangfu)].Rarity = Rarity.Uncommon;

            //Lightsaber
            ExhibitConfig._IdTable[nameof(Guangjian)].Appearance = AppearanceType.Anywhere;
            //Buff lock on applied to 4
            ExhibitConfig._IdTable[nameof(Guangjian)].Value1 = 4;

            //Donation box
            //Buff money per skip to +10
            ExhibitConfig._IdTable[nameof(Saiqianxiang)].Value2 = 10;

            //TNT
            ExhibitConfig._IdTable[nameof(Tnt)].Appearance = AppearanceType.ShopOnly;
            ExhibitConfig._IdTable[nameof(Tnt)].Rarity = Rarity.Common;
            //Buff turns until use to 2
            ExhibitConfig._IdTable[nameof(Tnt)].Value1 = 2;

            //Dowsing rods
            ExhibitConfig._IdTable[nameof(Xunlongchi)].Appearance = AppearanceType.ShopOnly;
            ExhibitConfig._IdTable[nameof(Xunlongchi)].Rarity = Rarity.Common;

            //Broken Amulet
            ExhibitConfig._IdTable[nameof(SunhuaiHufu)].Rarity = Rarity.Uncommon;

            //Sword of Hisou
            ExhibitConfig._IdTable[nameof(FeixiangJian)].Rarity = Rarity.Uncommon;

            //Mighty Shaku
            ExhibitConfig._IdTable[nameof(WeifengHuban)].Rarity = Rarity.Common;

        }
    }
}