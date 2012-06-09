using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace BLiNCk_Engine
{
    /// <summary>
    /// player specific implementation of a character object
    /// </summary>
    public class player : character
    {
        private const int SPEED = 20;

        private KeyboardState PreviousState;

        /// <summary>
        /// constructs a new player object
        /// </summary>
        /// <param name="content">reference to the content manager</param>
        /// <param name="AssetName">name of the player sprite/spritesheet</param>
        /// <param name="init_xpos">starting x position of the player, default is 0.0f</param>
        /// <param name="init_ypos">starting y position of the player, default is 0.0f</param>
        public player(ContentManager content, string AssetName, float init_xpos = 0.0f, float init_ypos = 0.0f)
        {
            this.position = new Vector2(init_xpos, init_ypos);
            this.LoadContent(content, AssetName);
            this.CurrentState = State.Still;
            this.Direction = Vector2.Zero;
            this.Speed = Vector2.Zero;
            this.PreviousState = new KeyboardState();
        }

        /// <summary>
        /// takes the keyboard state and alters the player based upon that state
        /// </summary>
        /// <param name="keyboardState">reference to the keyboard state object</param>
        /// <param name="gametime">reference to the gametime object</param>
        public void updatePlayer(KeyboardState keyboardState, GameTime gametime)
        {
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                this.Speed = new Vector2(SPEED, 0.0f);
                this.Direction = new Vector2(-1.0f, 0.0f);
                this.CurrentState = State.Walking;
                this.Update(gametime, this.Speed, this.Direction);
                if (this.Animation.CurrentXFrame <= 3 && this.Animation.CurrentYFrame == 1)
                {
                    this.Animation.CurrentXFrame++;
                    this.Animation.GetNextAnimation(this.Animation.CurrentXFrame, this.Animation.CurrentYFrame, gametime);
                }
                else
                {
                    this.Animation.CurrentFrame = this.Animation.DefaultFrame;
                }
            }
            else if (keyboardState.IsKeyDown(Keys.Right))
            {
                this.Speed = new Vector2(SPEED, 0.0f);
                this.Direction = new Vector2(1.0f, 0.0f);
                this.CurrentState = State.Walking;
                this.Update(gametime, this.Speed, this.Direction);
                if (this.Animation.CurrentXFrame <= 3 && this.Animation.CurrentYFrame == 1)
                {
                    this.Animation.CurrentXFrame++;
                    this.Animation.GetNextAnimation(this.Animation.CurrentXFrame, this.Animation.CurrentYFrame, gametime);
                }
                else
                {
                    this.Animation.CurrentFrame = this.Animation.DefaultFrame;
                }
            }
            else if (keyboardState.IsKeyDown(Keys.Up))
            {
                this.Speed = new Vector2(0.0f, SPEED);
                this.Direction = new Vector2(0.0f, -1.0f);
                this.CurrentState = State.Walking;
                this.Update(gametime, this.Speed, this.Direction);
                if (this.Animation.CurrentXFrame <= 3 && this.Animation.CurrentYFrame == 1)
                {
                    this.Animation.CurrentXFrame++;
                    this.Animation.GetNextAnimation(this.Animation.CurrentXFrame, this.Animation.CurrentYFrame, gametime);
                }
                else
                {
                    this.Animation.CurrentFrame = this.Animation.DefaultFrame;
                }
            }
            else if (keyboardState.IsKeyDown(Keys.Down))
            {
                this.Speed = new Vector2(0.0f, SPEED);
                this.Direction = new Vector2(0.0f, 1.0f);
                this.CurrentState = State.Walking;
                this.Update(gametime, this.Speed, this.Direction);
                if (this.Animation.CurrentXFrame <= 3 && this.Animation.CurrentYFrame == 1)
                {
                    this.Animation.CurrentXFrame++;
                    this.Animation.GetNextAnimation(this.Animation.CurrentXFrame, this.Animation.CurrentYFrame, gametime);
                }
                else
                {
                    this.Animation.CurrentFrame = this.Animation.DefaultFrame;
                }
            }
            else
            {
                this.Speed = Vector2.Zero;
                this.Direction = Vector2.Zero;
                this.CurrentState = State.Still;
                this.Update(gametime, this.Speed, this.Direction);
                this.Animation.CurrentFrame = this.Animation.DefaultFrame;
            }
        }
    }
}
