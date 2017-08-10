using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTSClient.Core.ValueConverters
{
	public class ImageUrlParameters
	{
		public ImageUrlParameters(int? width, int? height)
		{
			Width = width;
			Height = height;
		}

		public ImageUrlParameters(
			ImageScaleMode scaleMode,
			bool allowUpscale)
		{
			ScaleMode = scaleMode;
			AllowUpscale = allowUpscale;
		}

		public int? Width { get; }

		public int? Height { get; }

		public ImageScaleMode? ScaleMode { get; }

		public bool AllowUpscale { get; set; }

		public enum ImageScaleMode
		{
			LandscapeFullWidth,

			LandscapeHalfWidth
		}
	}
}
