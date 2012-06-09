using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Xml.Serialization;
using System.IO;

namespace BLiNCk_Engine
{
    /// <summary>
    /// the map handling class
    /// </summary>
    [Serializable]
    public class map
    {
        public string mapName { get; set; }
        public List<tile> background { get; set; }
        public List<tile> foreground { get; set; }
        public int XSize { get; set; }
        public int YSize { get; set; }
        
        /*
         * npc generation list
         * private List<npc> _npc;
         */

        public map() { }

        /// <summary>
        /// constructs a new map object
        /// </summary>
        /// <param name="mapname">the name of the map, will be used to as the filename when dumped to xml</param>
        /// <param name="content">reference to the content manager object</param>
        /// <param name="mapsizeX">the width of the draw frame</param>
        /// <param name="mapsizeY">the height of the draw frame</param>
        public map(string mapname, ContentManager content, int mapsizeX, int mapsizeY)
        {
            this.XSize = mapsizeX / 90;
            this.YSize = mapsizeY / 90;
            this.mapName = mapname;
            this.background = new List<tile>();
            this.foreground = new List<tile>();
        }

        /// <summary>
        /// REMOVABLE, will be used for the custom map building tool
        /// </summary>
        public void SaveMap()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(map));
            TextWriter writer = new StreamWriter(@"Maps/" + mapName + ".xml");
            serializer.Serialize(writer, this);
            writer.Close();
        }

        /// <summary>
        /// used for loading a map from an xml file
        /// </summary>
        /// <param name="mapname">the name of the file minus the .xml extension</param>
        /// <param name="content">reference to the content manager object</param>
        /// <returns>the deserialized object from the xml file</returns>
        public static map LoadMap(string mapname, ContentManager content)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(map));
            TextReader reader = new StreamReader(@"Maps/" + mapname + ".xml");
            map deserialized = (map)serializer.Deserialize(reader);
            reader.Close();
            foreach (tile bgtile in deserialized.background)
            {
                bgtile.LoadContent(content, bgtile.AssetName);
            }
            foreach (tile fgtile in deserialized.foreground)
            {
                fgtile.LoadContent(content, fgtile.AssetName);
            }
            return deserialized;
        }

        /// <summary>
        /// draws the current map onto the screen
        /// </summary>
        /// <param name="sBatch">reference to the spritebatch object</param>
        public void DrawMap(SpriteBatch sBatch)
        {
            //draw background
            foreach (tile maptile in this.background)
            {
                maptile.Draw(sBatch);
            }

            //draw foreground
            foreach (tile maptile in this.foreground)
            {
                maptile.Draw(sBatch);
            }
        }
    }
}
