using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Reusable;
using Reusable.Services;

namespace Jewely
{
	public class Game1 : Game
	{
		private GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;
		private DisplayManager displayManager;
		private BitmapFont title;
		private Texture2D box;
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
			displayManager.SetWindowSize(new Point(256, 144), 3);
			displayManager.ToggleFullScreen();
			title = new BitmapFont("Jewely", new Vector2(50, 50), Color.Blue, scale: 2, filePath: "all_8x8");

			box = Utils.RectangleTexture(75, 55, Color.White, GraphicsDevice);
			

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

			// TODO: Add your update logic here

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			//GraphicsDevice.Clear(Color.CornflowerBlue);

			// TODO: Add your drawing code here

			_graphics.GraphicsDevice.SetRenderTarget(displayManager.RenderTarget);
			GraphicsDevice.Clear(Color.Black);

			_spriteBatch.Begin(samplerState: SamplerState.PointClamp);



			title.Draw(t => Content.Load<Texture2D>(t), _spriteBatch);
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
