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
    /// Generic Sprite Class
    /// </summary>
    [Serializable]
    public class sprite
    {
        public Vector2 position { get; set; }
        public string AssetName { get; set; }
        private Texture2D _sTexture;
        public Texture2D sTexture
        {
            get
            {
                return this._sTexture;
            }
        }

        /// <summary>
        /// default constructor
        /// </summary>
        public sprite() { this.position = new Vector2(); }

        /// <summary>
        /// Creates a new sprite object and assigns all those pesky important values
        /// </summary>
        /// <param name="content">The Content Manager</param>
        /// <param name="AssetName">The name of the sprite asset to load</param>
        /// <param name="init_xpos">the initial starting x position of the sprite, default is 0</param>
        /// <param name="init_ypos">the initial starting y position of the sprite, default is 0</param>
        public sprite(ContentManager content, string AssetName, float init_xpos = 0.0f, float init_ypos = 0.0f)
        {
            this.position = new Vector2(init_xpos, init_ypos);
            this._sTexture = content.Load<Texture2D>(AssetName);
        }

        /// <summary>
        /// Sets or modifies the current sprite texture
        /// </summary>
        /// <param name="content">the content manager</param>
        /// <param name="AssetName">the name of the sprite asset to load</param>
        public void LoadContent(ContentManager content, string AssetName)
        {
            this.AssetName = AssetName;
            this._sTexture = content.Load<Texture2D>(AssetName);
        }

        /// <summary>
        /// draws the sprite to the screen
        /// </summary>
        /// <param name="sBatch">reference to the spritebatch object</param>
        public void Draw(SpriteBatch sBatch)
        {
            sBatch.Draw(this.sTexture, this.position, Color.White);
        }
    }
}
