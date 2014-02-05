using System.Reflection;
using System.Web;

namespace Cassette.Aspnet
{
	/// <summary>
	/// Wrapper around System.Web.MimeMapping which is an internal class.
	/// </summary>
	public class MimeMappingWrapper
	{
		/// <summary>
		/// Gets the MIME type of the specified file.
		/// </summary>
		/// <param name="fileName">Name of the file.</param>
		/// <returns>MIME type of the file, or <c>application/octet-stream</c> if the extension is unrecognised</returns>
		public string GetMimeMapping(string fileName)
		{
			var extension = fileName.Substring(fileName.LastIndexOf('.'));
			switch (extension)
			{
				// PNG isn't in the MimeMapping class :(
				case ".png":
					return "image/png";
				default:
			        return MimeMapping.GetMimeMapping(fileName);
			}
			
		}
	}
}
