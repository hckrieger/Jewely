using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Reusable;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jewely.Screens
{
	public class PlayingScreen : Screen
	{
		private GraphicsDevice graphicsDevice;
		public PlayingScreen(Game game)
		{
			graphicsDevice = game.Services.GetService<GraphicsDevice>();
		}

		public override void Update(GameTime gameTime)
		{

		}

		public override void Draw(SpriteBatch spriteBatch)
		{

			spriteBatch.Draw(Utils.RectangleTexture(50, 75, Color.Green, graphicsDevice), new Vector2(50, 50), Color.White);
		}
	}
}
