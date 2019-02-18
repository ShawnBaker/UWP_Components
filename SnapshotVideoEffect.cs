// Copyright © 2019 Shawn Baker using the MIT License.
using System.Collections.Generic;
using Windows.Foundation.Collections;
using Windows.Graphics.DirectX.Direct3D11;
using Windows.Graphics.Imaging;
using Windows.Media.Effects;
using Windows.Media.MediaProperties;

namespace UWP_Components
{
	public sealed class SnapshotVideoEffect : IBasicVideoEffect
	{
		// public snapshot variable
		private static SoftwareBitmap snapshot = null;

		// basic properties
		public bool IsReadOnly => true;
		public bool TimeIndependent => true;
		public MediaMemoryTypes SupportedMemoryTypes => MediaMemoryTypes.GpuAndCpu;
		public IReadOnlyList<VideoEncodingProperties> SupportedEncodingProperties => new List<VideoEncodingProperties>();

		/// <summary>
		/// Gets the most recent frame.
		/// </summary>
		/// <returns>The most recent frame.</returns>
		public static SoftwareBitmap GetSnapshot()
		{
			return snapshot;
		}

		public void ProcessFrame(ProcessVideoFrameContext context)
		{
			snapshot = context.InputFrame.SoftwareBitmap;
		}

		public void Close(MediaEffectClosedReason reason)
		{
			snapshot = null;
		}

		public void DiscardQueuedFrames()
		{
		}

		public void SetEncodingProperties(VideoEncodingProperties encodingProperties, IDirect3DDevice device)
		{
		}

		public void SetProperties(IPropertySet configuration)
		{
		}
	}
}
