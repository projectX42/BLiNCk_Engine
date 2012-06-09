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
    /// a class for handling map tiles. Note: all tiles are resized automatically to 90x90
    /// </summary>
    [Serializable]
    public class tile : sprite
    {
        public bool isPassable { get; set; }

        public Rectangle scaling { get; set; }

        /// <summary>
        /// creates a new tile object
        /// </summary>
        /// <param name="content">reference to the content manager object</param>
        /// <param name="AssetName">name of the file to load</param>
        /// <param name="isPassable">is this tile a passable or unpassable object</param>
        /// <param name="xpos">the x position of the tile, defaults to 0.0f</param>
        /// <param name="ypos">the y position of the tile, defaults to 0.0f</param>
        public tile(ContentManager content, string AssetName, bool isPassable, float xpos = 0.0f, float ypos = 0.0f) 
        {
            this.position = new Vector2(xpos, ypos);
            this.LoadContent(content, AssetName);
            scaling = new Rectangle((int)this.position.X, (int)this.position.Y, 90, 90);
            this.isPassable = isPassable;
        }

        /// <summary>
        /// used for serialization: SHOULD NOT BE USED OUTSIDE OF SERIALIZATION
        /// </summary>
        public tile() { }

        /// <summary>
        /// draws the tile onto the screen
        /// </summary>
        /// <param name="sBatch">reference to the spritebatch object</param>
        public new void Draw(SpriteBatch sBatch)
        {
            sBatch.Draw(this.sTexture, this.scaling, Color.White);
        }
    }
}
