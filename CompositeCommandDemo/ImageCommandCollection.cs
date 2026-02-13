// This source code is property of Atalsoft, Inc. (www.atalasoft.com)
// Permission for usage and modification of this code is only permitted 
// with the purchase of a DotImage source code license.

// Change History:

using System;
using System.Collections;
using Atalasoft.Imaging.ImageProcessing;

namespace CompositeCommandDemo
{
	// simple implementation of an collection of image commands
	[Serializable]
	public class ImageCommandCollection : CollectionBase
	{
		public ImageCommandCollection()
		{
		}

		public ImageCommand this[int index] 
		{
			get { return (ImageCommand)List[index]; }
			set { List[index] = value; }
		}
		public int Add( ImageCommand value )  
		{
			return( List.Add( value ) );
		}

		public int IndexOf( ImageCommand value )  
		{
			return( List.IndexOf( value ) );
		}

		public void Insert( int index, ImageCommand value )  
		{
			List.Insert( index, value );
		}

		public void Remove( ImageCommand value )  
		{
			List.Remove( value );
		}

		public bool Contains( ImageCommand value )  
		{
			// If value is not of type Int16, this will return false.
			return( List.Contains( value ) );
		}
		public void CopyTo(ImageCommand[] array, int index)
		{
			((ICollection)this).CopyTo(array, index);
		}
	}
}
