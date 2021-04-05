using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Game_Sprint0.Classes.Header;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CSE3902_Game_Sprint0.Classes.Scripts;

namespace CSE3902_Game_Sprint0.Classes.SpriteFactories
{
    public class HudSpriteFactory
    {
        private ZeldaGame game;
        private float itemDepth = .4f;
        private Texture2D hudSpriteSheet;
        public HudSpriteFactory(ZeldaGame game)
        {
            this.game = game;
            game.spriteSheets.TryGetValue("HUD", out hudSpriteSheet);
        }
        //this is just the base template sprite. HUD still needs life, map, level, counters to be implemented and updated in real time.
        public UniversalSprite baseHud()
        {
            return new UniversalSprite(game, hudSpriteSheet, new Rectangle(258, 11, 260, 55), Color.White, SpriteEffects.None, new Vector2(1,1), 10, itemDepth);
        }

        //public UniversalSprite mapHUD()
        //{
        //}

        public UniversalSprite Digit(int offset)
        {
            return new UniversalSprite(game, hudSpriteSheet, new Rectangle(528 + offset, 117, 8, 8), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, itemDepth);
        }

        public UniversalSprite xHUD()
        {
            return new UniversalSprite(game, hudSpriteSheet, new Rectangle(519, 117, 8, 8), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, itemDepth);
        }

        public UniversalSprite livesHUD()
        {
            return new UniversalSprite(game, hudSpriteSheet, new Rectangle(645, 117, 8, 8), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, itemDepth);
        }

        public UniversalSprite levelHUD()
        {
            return new UniversalSprite(game, hudSpriteSheet, new Rectangle(584, 1, 64, 7), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, itemDepth);
        }

        public UniversalSprite primaryWeaponHUD()
        {
            return new UniversalSprite(game, hudSpriteSheet, new Rectangle(555, 137, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, itemDepth);
        }

        public UniversalSprite secondaryWeaponHUD()
        {
            if (game.link.linkState.weaponSelected == LinkStateMachine.Weapon.bomb)
            {
                return new UniversalSprite(game, hudSpriteSheet, new Rectangle(604, 137, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, itemDepth);
            }
            else if (game.link.linkState.weaponSelected == LinkStateMachine.Weapon.arrow)
            {
                return new UniversalSprite(game, hudSpriteSheet, new Rectangle(633, 137, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, itemDepth);
            }
            else if (game.link.linkState.weaponSelected == LinkStateMachine.Weapon.boomerang)
            {
                return new UniversalSprite(game, hudSpriteSheet, new Rectangle(584, 137, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, itemDepth);
            }
            else
            {
                return new UniversalSprite(game, hudSpriteSheet, new Rectangle(604, 137, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, itemDepth);
            }
        }

        public UniversalSprite top()
        {
            return new UniversalSprite(game, hudSpriteSheet, new Rectangle(258, 0, 260, 82), Color.Black, SpriteEffects.None, new Vector2(1, 1), 10, 0.0f);
        }

        public UniversalSprite bottom()
        {
            return new UniversalSprite(game, hudSpriteSheet, new Rectangle(258, 11, 260, 41), Color.Black, SpriteEffects.None, new Vector2(1, 1), 10, 0.0f);
        }
        public UniversalSprite right()
        {
            return new UniversalSprite(game, hudSpriteSheet, new Rectangle(0, 0, 44, 178), Color.Black, SpriteEffects.None, new Vector2(1, 1), 10, 0.0f);
        }
        public UniversalSprite left()
        {
            return new UniversalSprite(game, hudSpriteSheet, new Rectangle(0, 0, 42, 178), Color.Black, SpriteEffects.None, new Vector2(1, 1), 10, 0.0f);
        }
    }
}
