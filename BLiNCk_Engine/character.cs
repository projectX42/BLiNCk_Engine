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
    /// An implementation of an arbitrary character class
    /// </summary>
    public class character : sprite
    {
        public Animation Animation { get; set; }

        public const bool PASSABLE = false;

        /// <summary>
        /// Possible Character States
        /// </summary>
        public enum State
        {
            Still,
            Walking
        }

        public State CurrentState { get; set; }
        public Vector2 Direction { get; set; }
        public Vector2 Speed { get; set; }

        /// <summary>
        /// parametized constructor
        /// </summary>
        /// <param name="content">reference to the content manager object</param>
        /// <param name="AssetName">name of the asset to load</param>
        /// <param name="init_xpos">initial x position, default is 0.0f</param>
        /// <param name="init_ypos">initial y position, default is 0.0f</param>
        public character(ContentManager content, string AssetName, float init_xpos = 0.0f, float init_ypos = 0.0f)
        {
            this.position = new Vector2(init_xpos, init_ypos);
            this.LoadContent(content, AssetName);
            this.CurrentState = State.Still;
            this.Direction = Vector2.Zero;
            this.Speed = Vector2.Zero;
        }

        public void SetupAnimation(int XSizeOfFramePixels, int YSizeOfFramePixels, int XNumOfFrames,
            int YNumOfFrames, int XDefaultFrame, int YDefaultFrame, float updateFrequency)
        {
            this.Animation = new Animation(XNumOfFrames, YNumOfFrames, XSizeOfFramePixels, YSizeOfFramePixels, XDefaultFrame, YDefaultFrame, updateFrequency);
        }

        public character() { }

        public void Update(GameTime GameTime, Vector2 Speed, Vector2 Direction)
        {
            this.position += Direction * Speed * (float)GameTime.ElapsedGameTime.TotalSeconds;
        }

        public new void Draw(SpriteBatch sBatch)
        {
            sBatch.Draw(this.sTexture, this.position, this.Animation.CurrentFrame, Color.White);
        }
    }
}
