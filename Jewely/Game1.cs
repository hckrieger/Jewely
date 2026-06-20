using Jewely.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Reusable;
using Reusable.Services;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Reflection.Metadata;

namespace Jewely
{
	public class Game1 : Game
	{
		private GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;
		private DisplayManager displayManager;
		private InputManager inputManager;
		private Texture2D box;
		private Screen playingScreen;
		private ScreenManager screenManager = new ScreenManager();
		public const string PLAYING_SCREEN = "PlayingScreen";
		public const string TITLE_SCREEN = "TitleScreen";

		public Game1()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
			_graphics.ApplyChanges();

		}

		protected override void Initialize()
		{
			// TODO: Add your initialization logic here

			base.Initialize();
			displayManager = new DisplayManager(_graphics);
			displayManager.SetWindowSize(new Point(320, 180), 3);
		//	displayManager.ToggleFullScreen();

			inputManager = new InputManager(displayManager);


			Services.AddService(typeof(DisplayManager), displayManager);
			Services.AddService(typeof(ScreenManager), screenManager);
			Services.AddService(typeof(ContentManager), Content);
			Services.AddService(typeof(InputManager), inputManager);
			Services.AddService(typeof(GraphicsDevice), GraphicsDevice);

			box = Utils.RectangleTexture(75, 55, Color.White, GraphicsDevice);

			screenManager.AddScreen(PLAYING_SCREEN, new PlayingScreen(this));
			screenManager.AddScreen(TITLE_SCREEN, new TitleScreen(this));
			screenManager.SwitchScreen(TITLE_SCREEN);

		}

		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);

			// TODO: use this.Content to load your game content here
		}

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			inputManager.Update();

			// TODO: Add your update logic here
			screenManager.Update(gameTime);
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			//GraphicsDevice.Clear(Color.CornflowerBlue);

			// TODO: Add your drawing code here

			_graphics.GraphicsDevice.SetRenderTarget(displayManager.RenderTarget);
			GraphicsDevice.Clear(Color.Black);

			_spriteBatch.Begin(samplerState: SamplerState.PointClamp);

			screenManager.Draw(_spriteBatch);

			
		//	_spriteBatch.Draw(box, new Vector2(0,0), Color.White);


			_spriteBatch.End();

			_graphics.GraphicsDevice.SetRenderTarget(null);

			_spriteBatch.Begin(samplerState: SamplerState.PointClamp);
			
			_spriteBatch.Draw(displayManager.RenderTarget, displayManager.AdjustedViewport, Color.White);
			_spriteBatch.End();




			base.Draw(gameTime);
		}
	}
}
