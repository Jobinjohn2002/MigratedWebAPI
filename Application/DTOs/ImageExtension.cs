using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum ImageSize
    {
        /// <summary>
        /// Sets the size to 96.
        /// </summary>
        Thumbnail = 96,
        /// <summary>
        /// Sets the size to 360.
        /// </summary>
        Small = 360,
        /// <summary>
        /// Sets the size to 800.
        /// </summary>
        Medium = 800,
        /// <summary>
        /// Sets the size to 1024.
        /// </summary>
        Large = 1024,
        /// <summary>
        /// Sets the size to 1280.
        /// </summary>
        XL = 1280,
        /// <summary>
        /// Sets the size to 1600.
        /// </summary>
        XXL = 1600,
        /// <summary>
        /// Retain the image original size.
        /// </summary>
        Original = 0
    }

    public static class ImageExtension
    {
        /// <summary>
        /// Resize the image to the new size and return back the image as a stream.
        /// Currently supported for only .jpeg, .gif, .bmp and .png Images.
        /// </summary>
        /// <param name="image">Image to be resized</param>
        /// <param name="newWidth">New Width of the image needed.</param>
        /// <param name="onlyResizeIfWider">Resize image only if wider (default, true).</param>
        /// <returns>Memory Stream of the resized image.</returns>
        /// <summary>
        /// Resize operation
        /// </summary>
        public static MemoryStream Resize(this Image image, ImageSize size, bool onlyResizeIfWider = true)
        {
            var newWidth = size == 0
                    ? image.Width
                    : (int)size;

            var encoder = image.RawFormat.Guid.Equals(ImageFormat.Bmp.Guid)
                ? GetEncoder(ImageFormat.Bmp)
                : image.RawFormat.Guid.Equals(ImageFormat.Gif.Guid)
                    ? GetEncoder(ImageFormat.Gif)
                    : image.RawFormat.Guid.Equals(ImageFormat.Jpeg.Guid)
                        ? GetEncoder(ImageFormat.Jpeg)
                            : image.RawFormat.Guid.Equals(ImageFormat.Png.Guid)
                            ? GetEncoder(ImageFormat.Png) : null;

            if (encoder == null)
            {
                throw new NotSupportedException(string.Format("Image type {0} is not supported", image.RawFormat.Guid));
            }

            image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            image.RotateFlip(RotateFlipType.Rotate180FlipNone);

            if (onlyResizeIfWider && image.Width <= newWidth)
            {
                newWidth = image.Width;
            }

            var newHeight = image.Height * newWidth / image.Width;

            MemoryStream memoryStream = null;

            using (var newImage = image.GetThumbnailImage(newWidth, newHeight, null, IntPtr.Zero))
            {
                var myEncoder = Encoder.Quality;

                var myEncoderParameters = new EncoderParameters(1);

                var myEncoderParameter = new EncoderParameter(myEncoder, 100L);

                myEncoderParameters.Param[0] = myEncoderParameter;

                memoryStream = new MemoryStream();

                newImage.Save(memoryStream, encoder, myEncoderParameters);

                memoryStream.Seek(0, 0);
            }

            return memoryStream;

        }

        /// <summary>
        /// Get encoder for the image format.
        /// </summary>
        /// <param name="format">Image Format</param>
        /// <returns>ImageCodecInfo object</returns>
        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            var codecs = ImageCodecInfo.GetImageDecoders();

            foreach (var codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
    }    
}
