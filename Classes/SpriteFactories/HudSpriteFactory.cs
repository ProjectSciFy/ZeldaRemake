using CSE3902_Game_Sprint0.Classes.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Game_Sprint0.Classes.SpriteFactories
{
    public class HudSpriteFactory
    {
        private ZeldaGame game { get; set; }
        private float itemDepth { get; set; } = .4f;
        private readonly Texture2D hudSpriteSheet;
        public HudSpriteFactory(ZeldaGame game)
        {
            this.game = game;
            game.spriteSheets.TryGetValue("HUD", out hudSpriteSheet);
        }
        public UniversalSprite baseHud()
        {
            return new UniversalSprite(game, hudSpriteSheet, new Rectangle(258, 11, 260, 55), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, itemDepth);
        }

        public UniversalSprite mapHUD()
        {
            return new UniversalSprite(game, hudSpriteSheet, new Rectangle(694, 30, 49, 25), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, itemDepth);
        }

        public UniversalSprite linkOnMap()
        {
            return new UniversalSprite(game, hudSpriteSheet, new Rectangle(683, 23, 3, 5), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, itemDepth);
        }

        public UniversalSprite compassBoss()
        {
            return new UniversalSprite(game, hudSpriteSheet, new Rectangle(683, 23, 3, 5), Color.Red, SpriteEffects.None, new Vector2(1, 1), 10, itemDepth);
        }

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

        public UniversalSprite staticBomb()
        {
            return new UniversalSprite(game, hudSpriteSheet, new Rectangle(604, 137, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, itemDepth);
        }

        public UniversalSprite staticBow()
        {
            return new UniversalSprite(game, hudSpriteSheet, new Rectangle(633, 137, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, itemDepth);
        }

        public UniversalSprite staticBoomerang()
        {
            return new UniversalSprite(game, hudSpriteSheet, new Rectangle(584, 137, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, itemDepth);
        }

        public UniversalSprite blankBox()
        {
            return new UniversalSprite(game, hudSpriteSheet, new Rectangle(654, 116, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, itemDepth);
        }

        public UniversalSprite primaryWeaponHUD()
        {
            return new UniversalSprite(game, hudSpriteSheet, new Rectangle(555, 137, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, itemDepth);
        }

        //this logic is used in ItemSelectState to reduce code, can be transferred over if we want to go back to just returning sprites. I felt that this logic was okay
        //to include since it only deals with returning the correct sprites, which a spriteFactory should do.
        public UniversalSprite secondaryWeaponHUD()
        {
            if (game.link.linkState.weaponSelected == LinkStateMachine.Weapon.bomb)
            {
                return staticBomb();
            }
            else if (game.link.linkState.weaponSelected == LinkStateMachine.Weapon.arrow)
            {
                if (game.util.hasBow)
                {
                    return staticBow();
                }
                else
                {
                    return blankBox();
                }
            }
            else if (game.link.linkState.weaponSelected == LinkStateMachine.Weapon.boomerang)
            {
                return staticBoomerang();
            }
            else
            {
                return blankBox();
            }
        }

        public UniversalSprite xpSegment()
        {
            return new UniversalSprite(game, hudSpriteSheet, new Rectangle(486, 100, 10, 4), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, itemDepth);
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
