using Terraria.GameContent.ItemDropRules;

namespace Fargowiltas.ItemDropRules
{
    public static class ExtraItemDropRules
    {
        /// <summary>
        /// Makes NPCs drop an item based on a bool.
        /// </summary>
        /// <param name="shouldDrop"></param>
        /// <param name="itemID"></param>
        /// <param name="dropsOutOfX"></param>
        /// <param name="minimumDropped"></param>
        /// <param name="maximumDropped"></param>
        /// <returns><c>new Terraria.GameContent.ItemDropRules.DropNothing()</c> if the bool is false.</returns>
        public static IItemDropRule ByBoolean(bool shouldDrop, int itemId, int dropsOutOfX = 1, int minimumDropped = 1, int maximumDropped = 1, int dropsXoutofY = 1)
        {
            if (shouldDrop)
            {
                return new CommonDrop(itemId, dropsOutOfX, minimumDropped, maximumDropped, dropsXoutofY);
            }

            return new DropNothing();
        }

        /// <summary>
        /// Makes an NPC drop a random item from the <c>options</c> array.
        /// </summary>
        /// <param name="shouldDrop"></param>
        /// <param name="dropsOutOfX"></param>
        /// <param name="options"></param>
        /// <returns><c>new Terraria.GameContent.ItemDropRules.DropNothing()</c> if the bool is false.</returns>
        public static IItemDropRule OneFromOptionsByBoolean(bool shouldDrop, int dropsOutOfX, params int[] options)
        {
            if (shouldDrop)
            {
                return new OneFromOptionsDropRule(dropsOutOfX, 1, options);
            }

            return new DropNothing();
        }

        /// <summary>
        /// Makes the NPC drop multiple items at the same time.
        /// </summary>
        /// <param name="dropsOutOfX"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public static IItemDropRule AllFromOptions(int dropsOutOfX, params int[] items) => new MultipleItemsDropRule(dropsOutOfX, 1, items);
    }
}