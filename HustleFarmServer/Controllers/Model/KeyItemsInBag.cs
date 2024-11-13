namespace HustleFarmServer.Controllers.Model
{
   

    public static class KeyItemsInBag
    {
        public enum EKeyItemsInBag
        {
            Seed_Crop,
            Seed_Rice,
            Food_Crop,
            Food_Rice
        }

        private static Dictionary<EKeyItemsInBag, string> itemsInBagDictionary = new Dictionary<EKeyItemsInBag, string>() {
            { EKeyItemsInBag.Seed_Rice, "Seed Rice"},
            { EKeyItemsInBag.Seed_Crop, "Seed Crop"},
            { EKeyItemsInBag.Food_Rice, "Food Rice"},
            { EKeyItemsInBag.Food_Crop, "Food Crop"}
        };

        public static string GetItemInBag(EKeyItemsInBag itemKey) {

            if (itemsInBagDictionary.TryGetValue(itemKey, out string? item)) {
                return item;
            }

            return "";
        }

    }
}
