using System;
using System.Windows.Forms;
using SoftwareLocker;

namespace Example
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Locker locker = new Locker("TMTest1", Application.StartupPath + "\\RegFile.reg",
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\TMSetp.dbf",
                "Phone: +98 21 88281536\nMobile: +98 912 2881860",
                5, 10, "745");

            byte[] MyOwnKey = { 97, 250, 1, 5, 84, 21, 7, 63,
            4, 54, 87, 56, 123, 10, 3, 62,
            7, 9, 20, 36, 37, 21, 101, 57};
            locker.TripleDESKey = MyOwnKey;

            Locker.RunTypes runType = locker.ShowDialog();
            bool isTrial;
            if (runType != Locker.RunTypes.Expired)
            {
                if (runType == Locker.RunTypes.Full)
                    isTrial = false;
                else
                    isTrial = true;

                Application.Run(new ExampleForm(runType));
            }            
        }
    }
}