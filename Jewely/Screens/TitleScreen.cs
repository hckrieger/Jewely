using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Reusable;
using Reusable.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Jewely.Screens
{
	public class TitleScreen : Screen
	{
		private BitmapFont title;
		private ContentManager Content;
		private InputManager input;
		private ScreenManager screenManager;
		public TitleScreen(Game game)
		{

			title = new BitmapFont("Jewely", new Vector2(50, 50), Color.Blue, scale: 3, filePath: "all_8x8");
			Content = game.Services.GetService<ContentManager>();
			input = game.Services.GetService<InputManager>();
			screenManager = game.Services.GetService<ScreenManager>();
		}

		public override void Update(GameTime gameTime)
		{
			Debug.WriteLine($"{input.IsKeyPressed(Keys.Space)}");

			if (input.IsKeyPressed(Keys.Space))
			{
				screenManager.SwitchScreen(Game1.PLAYING_SCREEN);
			}
		}

		public override void Draw(SpriteBatch spriteBatch)
		{


			title.Draw(t => Content.Load<Texture2D>(t), spriteBatch);
		}
	}
}
