namespace F1FantasyAPI
{
    public class FileProcessor
    {
        public static byte[] FileToByteArray(IFormFile file)
        {
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                return ms.ToArray();
            }
        }

        public static IFormFile ByteArrayToFile(byte[] array, string filename)
        {
            using (var ms = new MemoryStream(array))
            {
                IFormFile file = new FormFile(ms, 0, array.Length, filename, filename);
                return file;
            }
        }

        public static void SaveFile(IFormFile file, string storageName)
        {
            string filepath = Path.Combine("wwwroot", storageName);

            if (file.Length > 0)
            {
                using (Stream fileStream = new FileStream(filepath, FileMode.Create, FileAccess.Write))
                {
                    file.CopyTo(fileStream);
                }
            }
        }
    }
}
