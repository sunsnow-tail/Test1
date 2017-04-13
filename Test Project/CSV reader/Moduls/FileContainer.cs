namespace CSV_reader.Modules
{
    /// <summary>
    /// a module for files to read
    /// </summary>
    internal class FileContainer
    {
        internal FileContainer(string path, FileType type)
        {
            FilePath = path;
            FileType = type;
        }

        public string FilePath { get; set; }

        public FileType FileType { get; set; }
    }


}