using Microsoft.Xna.Framework;
using System;

namespace CSE3902_Game_Sprint0.Classes.Items
{
    public class DropMinorItem : ICommand
    {
        private readonly ItemUtility util = new ItemUtility();
        private ZeldaGame game { get; set; }
        private Vector2 location { get; set; }
        public DropMinorItem(ZeldaGame game, Vector2 location)
        {
            this.game = game;
            this.location = location;
        }

        public void Execute()
        {
            var random = new Random();
            int randomNumber = random.Next(util.chooseFromHundred);

            if (randomNumber <= util.randomChooseFive)
            {
                // 1/20 drop bomb
                game.currentRoom.items.Add(new Bomb(game, new SpriteFactories.ItemSpriteFactory(game), location));
            }
            else if (randomNumber <= util.randomChooseTen)
            {
                // 1/20 drop heart
                game.currentRoom.items.Add(new Heart(game, new SpriteFactories.ItemSpriteFactory(game), location));
            }
            else if (randomNumber <= util.randomChooseTwenty)
            {
                // 1/10 drop yellow rupee
                game.currentRoom.items.Add(new YellowRupee(game, new SpriteFactories.ItemSpriteFactory(game), location));
            }
            else if (randomNumber <= util.randomChooseTwentyFive)
            {
                // 1/20 drop blue rupee
                game.currentRoom.items.Add(new BlueRupee(game, new SpriteFactories.ItemSpriteFactory(game), location));
            }
            else if (randomNumber <= util.randomChooseTwentySix)
            {
                // 1/100 drop fairy
                game.currentRoom.items.Add(new Fairy(game, new SpriteFactories.ItemSpriteFactory(game), location));
            }
            else
            {
                game.currentRoom.items.Add(new XP(game, new SpriteFactories.ItemSpriteFactory(game), location));
            }
        }
    }
}
