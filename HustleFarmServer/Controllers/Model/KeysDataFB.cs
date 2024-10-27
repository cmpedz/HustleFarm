using System.Reflection.Metadata.Ecma335;

namespace HustleFarmServer.Controllers.Model
{
    public static class KeysDataFB
    {

        public enum EKeysDataFB
        {
            GameItemType,
            Plants,
            GachaRate,
            GachaPoint,
            Type,
            Id
        }

        private static Dictionary<EKeysDataFB, string> keysDataFBDictionary = new Dictionary<EKeysDataFB, string>()

        {         {EKeysDataFB.GachaRate, "GachaRate" },

                  {EKeysDataFB.GachaPoint, "GachaPoint" },

                  {EKeysDataFB.GameItemType, "GameItemType" },

                  {EKeysDataFB.Plants, "Plants" },

                  {EKeysDataFB.Type, "Type" },

                  { EKeysDataFB.Id, "Id"}
        };

        public static string GetKeysDataFB(EKeysDataFB key) {

            if (keysDataFBDictionary.TryGetValue(key, out string? value)) {
                return value;
            }

            return "";

        }



    }
}
