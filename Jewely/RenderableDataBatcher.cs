using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Jewely
{
	public class RenderableDataBatcher
	{

		private RenderableDataStore data;
		private ContentManager Content;
		private int nth = 0;
		public RenderableDataBatcher(Game game)
		{
			Content = game.Services.GetService<ContentManager>();
		}

		public void AddDataEntity(RenderableDataInstance dataInstance)
		{
			data.TextureKey[nth] = dataInstance.TextureKey;
			data.Position[nth] = dataInstance.Position;
			data.SourceRectangle[nth] = dataInstance.SourceRectangle;
			data.Color[nth] = dataInstance.Color;
			data.Rotation[nth] = dataInstance.Rotation;
			data.Origin[nth] = dataInstance.Origin;
			data.Scale[nth] = dataInstance.Scale;
			data.SpriteEffects[nth] = dataInstance.SpriteEffects;
			data.LayerDepth[nth] = dataInstance.LayerDepth;

			nth++;
		}


		public void Draw(SpriteBatch spriteBatch)
		{
			for (int i = 0; i < nth; i++) 
			{
				spriteBatch.Draw(
					Content.Load<Texture2D>(data.TextureKey[i]),
					data.Position[i],
					data.SourceRectangle[i],
					data.Color[i],
					data.Rotation[i],
					data.Origin[i],
					data.Scale[i],
					data.SpriteEffects[i],
					data.LayerDepth[i]
					);
			}
		}
	
	}

	public struct RenderableDataStore
	{
		public string[] TextureKey;
		public Vector2[] Position;
		public Rectangle[] SourceRectangle;
		public Color[] Color;
		public int[] Rotation;
		public Vector2[] Origin;
		public Vector2[] Scale;
		public SpriteEffects[] SpriteEffects;
		public float[] LayerDepth;
		
	}

	public struct RenderableDataInstance
	{
		public string TextureKey;
		public Vector2 Position;
		public Rectangle SourceRectangle;
		public Color Color;
		public int Rotation;
		public Vector2 Origin;
		public Vector2 Scale;
		public SpriteEffects SpriteEffects;
		public float LayerDepth;
		
	}


}
