using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerationFramework.Core
{
    /// <summary>
    /// Helper Class for commonly used file functions
    /// </summary>
    public  class FileHandler
    {
        /// <summary>
        /// Create text based test files
        /// </summary>
        public static void CreateTestFiles(int filesToCreate, string location)
        {
            CreateTestFiles(filesToCreate, location, 1);
        }

        /// <summary>
        /// Create text based test files
        /// </summary>
        public static void CreateTestFiles(int filesToCreate, string location, int sequencestartnumber)
        {
            //remove test folder then recreate
            DeleteADirectory(location);
            Directory.CreateDirectory(location);

            if (filesToCreate < 1) return;
            for (int i = sequencestartnumber; i < (filesToCreate  + sequencestartnumber); i++)
            {
                GenerateFile(location,i);
            }

        }
        private static void GenerateFile(string folder, int sequencenumber)
        {
            //Generate file content
            //RandomText target = new RandomText("Oh Rose Though art sick the invisible worm That flies in the night In the howling storm: has found out thy bed of crimson joy and his dark secret love does thy life destroy".Split(' '));
            var target = new RandomParagraphGeneratorHelper();
            target.AddContentParagraphs(100, 5, 15, 25, 100);
            string fileContent = target.Content;
            string filename = string.Format("{0}\\TestFile_{1}.abc",
                folder,
                sequencenumber.ToString("0000"));
            File.WriteAllText(filename, fileContent);
        }

        #region GetManifestResourceNames
        /// <summary>
        /// Get the manifest resouce names
        /// </summary>
        /// <returns></returns>
        public static string[] GetManifestResourceNames()
        {
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            string[] names = myAssembly.GetManifestResourceNames();
            return names;

        }
        #endregion

        #region Retrieve File list
        #region GetFiles

        /// <summary>
        /// Get a list of all files in this folder and its children.
        /// </summary>
        /// <param name="sourcepath">Root folder to search in</param>
        public static List<string> GetFiles(string sourcepath)
        {
            return GetFiles(sourcepath, "*.*", true);
        }
        /// <summary>
        ///Get a list of files in folder.
        /// </summary>
        /// <param name="sourcepath">root folder to look in</param>
        /// <param name="filter">what files are you after e.g. "*.*"</param>
        /// <param name="lookinsubfolders">do you want to look in sub folders</param>
        /// <returns>list of full file paths</returns>
        public static List<string> GetFiles(string sourcepath, string filter, bool lookinsubfolders)
        {
            List<string> fileArray = new List<string>();
            GetFilesList(sourcepath, filter, lookinsubfolders, ref  fileArray);
            return fileArray;
        }

        #endregion
        #region GetFilesList
        /// <summary>
        /// Get a list of fully qualifed filenames
        /// </summary>
        /// <param name="sourcepath">Folder to lookin</param>
        /// <param name="filter">what files are you after e.g. "*.*"</param>
        /// <param name="lookinsubfolders">do you want to look in sub folders</param>
        /// <param name="fileArray">referenced arraylist holding the names of the full filenames</param>
        private static void GetFilesList(string sourcepath, string filter, bool lookinsubfolders, ref List<string> fileArray)
        {
            #region Deal with the child folders
            if (lookinsubfolders)
            {
                foreach (string d in Directory.GetDirectories(sourcepath))
                {
                    GetFilesList(d, filter, lookinsubfolders, ref fileArray);
                }
            }
            #endregion

            // Deal with the files
            fileArray.AddRange(Directory.GetFiles(sourcepath, filter).Select(f => f.Trim()));
        }

        #endregion
        #endregion


        #region GetResourceAsString
        /// <summary>
        /// 
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        public static string GetResourceAsString(string resource)
        {
            //string template ;//= (Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            Assembly myAssembly = Assembly.GetExecutingAssembly();
            // string[] names = myAssembly.GetManifestResourceNames();
            Stream x = myAssembly.GetManifestResourceStream(resource);
            if (x == null) return string.Empty;

            StreamReader y = new StreamReader(x);
            string template = y.ReadToEnd();
            y.Close();
            x.Close();

            return template;

        }
        #endregion

        #region GetFileContents
        /// <summary>
        /// Load the contents of a file into a string
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static string GetFileContents(string filename)
        {

            StreamReader myFile = new StreamReader(filename);
            string myString = myFile.ReadToEnd();
            myFile.Close();

            return myString;
        }
        #endregion

        #region AppendToFile
        /// <summary>
        /// Append text to a text file with logging infomation
        /// </summary>
        /// <param name="filepath">Full File Path</param>
        /// <param name="textToAppend">text to append</param>
        public static void AppendToFile(string filepath, string textToAppend)
        {
            AppendToFile(filepath, textToAppend, true);
        }
        /// <summary>
        /// Append text to a text file
        /// </summary>
        /// <param name="filepath">Full File Path</param>
        /// <param name="textToAppend">text to append</param>
        /// <param name="addLogInformation">Do you want logging information</param>
        public static void AppendToFile(string filepath, string textToAppend, bool addLogInformation)
        {
            StreamWriter sw = null;
            try
            {
                #region Exit with no message if filepath is blank
                if (String.IsNullOrEmpty(filepath))
                {
                    return;
                }
                #endregion
                #region if dir does not exist then create it.
                string[] myArrray = filepath.Split(Convert.ToChar(@"\"));
                string filename = myArrray[myArrray.Length - 1];
                string path = filepath.Replace(filename, "");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                #endregion

                #region Add TimeStamp
                if (addLogInformation)
                {
                    textToAppend = String.Format("\r\n[{0} @ {1}] {3} {4}\r\n   {2}",
                                             DateTime.Now.ToLongDateString(),
                                             DateTime.Now.ToLongTimeString(),
                                             textToAppend,
                                             Environment.MachineName,
                                             Environment.UserName);
                }
                #endregion

                using (sw = File.AppendText(filepath))
                {
                    sw.WriteLine(textToAppend);
                }
            }

            finally
            {
                if (sw != null)
                {
                    sw.Close();
                    sw = null;
                }
            }
        }
        #endregion

        #region public class CompareFile
        /// <summary>
        /// Compare the file
        /// </summary>
        public class CompareFile
        {
            /// <summary>
            /// Are the 2 files specified the same
            /// </summary>
            /// <param name="sourcefile"></param>
            /// <param name="destinationfile"></param>
            /// <returns></returns>
            public static bool AreFilesTheSame(string sourcefile, string destinationfile)
            {

                FileInfo s = new FileInfo(sourcefile);
                FileInfo d = new FileInfo(destinationfile);

                return AreFilesTheSame(s, d);
            }
            /// <summary>
            /// Are the two specified files the same
            /// </summary>
            /// <param name="sourcefile"></param>
            /// <param name="destinationfile"></param>
            /// <returns></returns>
            public static bool AreFilesTheSame(FileInfo sourcefile, FileInfo destinationfile)
            {
                bool bReturn = !(sourcefile.Length != destinationfile.Length ||
                                 sourcefile.Name.ToLower().Trim() != destinationfile.Name.ToLower().Trim());
                //Basic tests

                return bReturn;
            }
        }
        #endregion

        #region public class Directories
        /// <summary>
        /// Handle directories
        /// </summary>
        public class Directories
        {
            /// <summary>
            /// Remove all empty directories
            /// </summary>
            public static void RemoveEmptyDirectories(string path)
            {
                foreach (string dir in Directory.GetDirectories(path))
                {
                    RemoveEmptyDirectories(dir);
                }

                if (Directory.GetDirectories(path).Length == 0 &&
                    Directory.GetFiles(path).Length == 0)
                {
                    Directory.Delete(path);
                }

            }
            /// <summary>
            /// Creates the directory for the specified path if it does not exist
            /// </summary>
            /// <param name="dir"></param>
            public static void Create(string dir)
            {
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);

                }
            }
        }
        #endregion

        #region DeleteFile
        /// <summary>
        /// Delete the specified file.
        /// </summary>
        /// <param name="destinationfilename"></param>
        public static void DeleteFile(string destinationfilename)
        {
            if (File.Exists(destinationfilename))
            {
                File.Delete(destinationfilename);
            }
        }
        #endregion

        #region DeleteADirectory
        /// <summary>
        ///  Resolve remove directory prompt  :System.IO.IOException:  The directory is not empty  .
        ///  Removes a directory, delete it first loops through all the files and directories  ( Recursive  )
        /// </summary>
        /// <param name="strPath"> Absolute path  </param>
        /// <returns> Has been deleted  </returns>
        public static bool DeleteADirectory(string strPath)
        {
            //http://www.codeweblog.com/resolve-to-delete-directory-tips-system-io-ioexception-directory-is-not-empty/
            try

            {
                //exit if path does not exist
                if (!Directory.Exists(strPath)) return true;
                // Delete the files in the directory  
                string[] strTemp = Directory.GetFiles(strPath);
                foreach (string str in strTemp)
                {
                    File.Delete(str);
                }
                // Delete subdirectories, recursive  
                strTemp = Directory.GetDirectories(strPath);
                foreach (string str in strTemp)
                {
                    DeleteADirectory(str);
                }
                // Delete the directory  
                Directory.Delete(strPath);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region CopyAll
        /// <summary>
        /// Copy all the files including sub folders form source to destination
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            // Check if the target directory exists, if not, create it.
            if (Directory.Exists(target.FullName) == false)
            {
                Directory.CreateDirectory(target.FullName);
            }

            // Copy each file into it’s new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                fi.CopyTo(Path.Combine(target.ToString(), fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }

        #endregion
    }
}
