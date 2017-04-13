using CSV_reader.Modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_reader
{
    class Program
    {
        static void Main(string[] args)
        {
            var printFilePath = AppDomain.CurrentDomain.BaseDirectory + @"\result.csv";

            //files should come  from args
            var filesToLoad = new List<FileContainer>();
            filesToLoad.Add(new FileContainer($"{AppDomain.CurrentDomain.BaseDirectory}\\..\\..\\..\\..\\..\\Sample files\\Sample files\\LP_210095893_20150901T011608049.csv", FileType.LPFile));
            filesToLoad.Add(new FileContainer($"{AppDomain.CurrentDomain.BaseDirectory}\\..\\..\\..\\..\\..\\Sample files\\Sample files\\LP_214612534_20150907T084333712.csv", FileType.LPFile));
            filesToLoad.Add(new FileContainer($"{AppDomain.CurrentDomain.BaseDirectory}\\..\\..\\..\\..\\..\\Sample files\\Sample files\\LP_214612653_20150907T220027915.csv", FileType.LPFile));
            filesToLoad.Add(new FileContainer($"{AppDomain.CurrentDomain.BaseDirectory}\\..\\..\\..\\..\\..\\Sample files\\Sample files\\TOU_212621145_20150911T022358.csv", FileType.TOUFile));
            filesToLoad.Add(new FileContainer($"{AppDomain.CurrentDomain.BaseDirectory}\\..\\..\\..\\..\\..\\Sample files\\Sample files\\TOU_212621147_20150911T022240.csv", FileType.TOUFile));
            filesToLoad.Add(new FileContainer($"{AppDomain.CurrentDomain.BaseDirectory}\\..\\..\\..\\..\\..\\Sample files\\Sample files\\TOU_214667141_20150901T040057.csv", FileType.TOUFile));

            #region console results
            //foreach (var fileStore in filesToLoad)
            //{
            //    IFileResult fileResult;

            //    switch (fileStore.FileType)
            //    {
            //        case FileType.LPFile:
            //            fileResult = new LPFileResult(fileStore.FilePath);
            //            break;
            //        case FileType.TOUFile:
            //            fileResult = new TOUFileResult(fileStore.FilePath);
            //            break;
            //        default:
            //            throw new Exception("Unknown file type :" + fileStore.FileType.ToString());
            //    }

            //    Console.WriteLine("File " + fileResult.FileName);

            //    var fullList = fileResult.TwentyPrctAboveMedian;
            //    fullList.AddRange(fileResult.TwentyPrctBelowMedian);

            //    foreach (var result in fullList)
            //    {
            //        var date = fileResult.FileDate.ToShortDateString();

            //        Console.WriteLine(string.Format("{0} {1} {2} {3}",
            //            fileResult.FileName, date, result, fileResult.MedianValue));
            //    }

            //    if (fullList.Count == 0) Console.WriteLine("No abnormal values found in " + fileResult.FileName);

            //    Console.WriteLine("Press Enter to read next file");
            //    Console.ReadLine();
            //}
            #endregion

            Console.WriteLine("Writing a file. Please, wait ...");

            var tasks = new List<Task<IFileResult>>();

            var fileResults = new List<IFileResult>();

            //read async - if large number of files to read
            foreach (var fileStore in filesToLoad)
            {
                tasks.Add(Task.Run(() => GetResultData(fileStore)));
            }

            Task.WaitAll(tasks.ToArray());

            // write sync
            using (FileStream fileStream = new FileStream(printFilePath,
                        FileMode.Append, FileAccess.Write, FileShare.None,
                        bufferSize: 4096, useAsync: true))
            {
                foreach (var task in tasks)
                {
                    var fileResult = task.Result;

                    var fullList = fileResult.TwentyPrctAboveAverage;
                    fullList.AddRange(fileResult.TwentyPrctBelowAverage);

                    foreach (var result in fullList)
                    {
                        var date = fileResult.FileDate.ToShortDateString();

                        var value = string.Format("{0},{1},{2},{3}{4}",
                                    fileResult.FileName, date, result, fileResult.AverageValue, Environment.NewLine);

                        byte[] encodedText = Encoding.Unicode.GetBytes(value);

                        fileStream.Write(encodedText, 0, encodedText.Length);

                    }
                }
            }
        }

        /// <summary>
        /// create an object of IFileResult with data
        /// </summary>
        /// <param name="fileStore"></param>
        /// <returns></returns>
        private static IFileResult GetResultData(FileContainer fileStore)
        {
            IFileResult fileResult;

            switch (fileStore.FileType)
            {
                case FileType.LPFile:
                    fileResult = new LPFileResult(fileStore.FilePath);
                    break;
                case FileType.TOUFile:
                    fileResult = new TOUFileResult(fileStore.FilePath);
                    break;
                default:
                    throw new Exception("Unknown file type :" + fileStore.FileType.ToString());
            }

            return fileResult;
        }
    }
}
