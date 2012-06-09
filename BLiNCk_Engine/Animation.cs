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
    /// Class for dealing with animation frames
    /// </summary>
    public class Animation
    {
        //important stuff
        public int NumOfXFrames { get; set; }
        public int NumOfYFrames { get; set; }
        public int FrameSizeX { get; set; }
        public int FrameSizeY { get; set; }

        //details about current frames
        public int CurrentXFrame { get; set; }
        public int CurrentYFrame { get; set; }

        //currently in use frame and default
        public Rectangle CurrentFrame { get; set; }
        public Rectangle DefaultFrame { get; set; }

        //timer stuff
        private float timeElapsed { get; set; }
        public float timeToUpdate { get; set; }

        public Animation(int numberOfXFrames, int numberOfYFrames, int FrameSizeX, int FrameSizeY, int DefaultFrameX,
            int DefaultFrameY, float updateFrequency)
        {
            this.NumOfXFrames = numberOfXFrames;
            this.NumOfYFrames = numberOfYFrames;
            this.FrameSizeX = FrameSizeX;
            this.FrameSizeY = FrameSizeY;
            this.DefaultFrame = new Rectangle(DefaultFrameX * NumOfXFrames, DefaultFrameY * numberOfYFrames, FrameSizeX, FrameSizeY);
            this.CurrentFrame = this.DefaultFrame;
            this.CurrentXFrame = DefaultFrameX;
            this.CurrentYFrame = DefaultFrameY;
            this.timeToUpdate = updateFrequency;
        }

        public Rectangle GetNextAnimation(int FrameXPos, int FrameYPos, GameTime gTime)
        {
            this.timeElapsed += (float)gTime.ElapsedGameTime.TotalSeconds;

            if (this.timeElapsed > this.timeToUpdate)
            {
                timeElapsed -= this.timeToUpdate;
                this.CurrentFrame = new Rectangle(FrameSizeX * FrameXPos, FrameSizeY * FrameYPos, FrameSizeX, FrameSizeY);
                this.CurrentXFrame = FrameXPos;
                this.CurrentYFrame = FrameYPos;
            }
            return this.CurrentFrame;
        }
    }
}
