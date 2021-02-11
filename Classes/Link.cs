using CSE3902_Game_Sprint0.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes
{
    public class Link : IPlayer
    {
        private StateMachine linkState;
        public ISprite LinkSprite;
        public Vector2 drawLocation = new Vector2(0, 0);
        public Vector2 velocity = new Vector2(0, 0);

        //Initialize Link's default state(s) in a new stateMachine
        public Link(EeveeSim game)
        {
            linkState = new StateMachine(game, this);
        }

        //Sets direction of Link's sprite (0, 90, 180, 270 degrees moving counter-clockwise from east)
        public void setDirection()
        {
            //Call statemachine & have it adjust it adjust stored direction
        }

        //Set Link to be using an item
        public void useItem()
        {
            //Call statemachine & have it use its currently selected item
        }

        //Set Link to be using his sword
        public void useSword()
        {
            //Call statemachine & have it use Link's sword
        }

        //TODO more state altering 

        public void update()
        {

        }

        public void draw()
        {

        }
    }
}
