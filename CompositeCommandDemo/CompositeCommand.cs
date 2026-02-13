// This source code is property of Atalsoft, Inc. (www.atalasoft.com)
// Permission for usage and modification of this code is only permitted 
// with the purchase of a DotImage source code license.

// Change History:

using System;
using Atalasoft.Imaging;
using Atalasoft.Imaging.ImageProcessing;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace CompositeCommandDemo
{

	// this command implements a composite command that is capable of encapsulating
	// any number of ImageCommands.

	[Serializable]
	public class CompositeCommand : ImageCommand, ISerializable
	{
		private ImageCommandCollection _commands = new ImageCommandCollection();

		#region ISerializable Members

		[SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags=SecurityPermissionFlag.SerializationFormatter)]
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
				throw new ArgumentNullException("info", "The parameter 'info' can't be null.");
			ImageCommandGetObjectData(info, context);
			info.AddValue("Commands", _commands);
		}

		protected CompositeCommand(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
				throw new ArgumentNullException("info", "The parameter 'info' can't be null.");
			object val = null;
			val = info.GetValue("Commands", typeof(ImageCommandCollection)); // may throw
			_commands = (ImageCommandCollection)val;
		}

		#endregion

		public CompositeCommand()
		{
		}

		// nothing to do - this gets done by the commands
		protected override void VerifyProperties(Atalasoft.Imaging.AtalaImage image)
		{
		}

		private static PixelFormat[] _allFormats = new PixelFormat[] {
																		 PixelFormat.Pixel16bppGrayscale,
																		 PixelFormat.Pixel16bppGrayscaleAlpha,
																		 PixelFormat.Pixel1bppIndexed,
																		 PixelFormat.Pixel24bppBgr,
																		 PixelFormat.Pixel32bppBgr,
																		 PixelFormat.Pixel32bppBgra,
																		 PixelFormat.Pixel32bppCmyk,
																		 PixelFormat.Pixel48bppBgr,
																		 PixelFormat.Pixel4bppIndexed,
																		 PixelFormat.Pixel64bppBgra,
																		 PixelFormat.Pixel8bppGrayscale,
																		 PixelFormat.Pixel8bppIndexed,
		};

		// the SupportedPixelFormats are either everything if there are no commands
		// or the SupportedPixelFormats of the first command 
		public override Atalasoft.Imaging.PixelFormat[] SupportedPixelFormats
		{
			get
			{
				if (_commands.Count == 0)
					return _allFormats;
				return _commands[0].SupportedPixelFormats;
			}
		}

		// don't let the base class allocate the final image
		// it will be done when the command is performed

		protected override AtalaImage ConstructFinalImage(AtalaImage image)
		{
			return null;
		}

		protected override AtalaImage PerformActualCommand(AtalaImage source, AtalaImage dest, System.Drawing.Rectangle imageArea, ref ImageResults results)
		{
			// always work on a copy of the source image

			dest = (AtalaImage)source.Clone();
			int count = _commands.Count;

			for (int i=0; i < count; i++)
			{
				ImageCommand command = _commands[i];

				// apply the command to the image (dest is actually the source here)
				ImageResults localresults = command.Apply(dest);

				// determine if we need to dispose dest
				if (!localresults.IsImageSourceImage)
				{
					dest.Dispose();
					dest = localresults.Image;
				}
				// handle progress
				if (Progress != null) 
				{
					Progress(this, new ProgressEventArgs(i+1, count, command.GetType().Name));
				}
			}
			// return the final image
			return dest;
		}


		public ImageCommandCollection Commands { get { return _commands; } }
	}
}
