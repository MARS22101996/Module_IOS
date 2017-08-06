using System;
using System.IO;
using VTSClient.DAL.Infrastructure.Interfaces;

namespace VTSClient.iOS
{
	public class IOSDbLocation : IDbLocation
	{
		public string GetDatabasePath(string filename)
		{
			string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string libraryPath = Path.Combine(documentsPath, "..", "Library");
			var path = Path.Combine(libraryPath, filename);

			return path;
		}
	}
}
