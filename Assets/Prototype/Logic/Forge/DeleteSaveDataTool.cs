using UnityEditor;
using static System.Diagnostics.Process;
using static System.IO.File;
using static Prototype.Logic.Forge.WorldDataHandler;
using static UnityEngine.Application;

namespace Prototype.Logic.Forge
{
    public static class DeleteSaveDataTool
    {
        [MenuItem("Prototype/Delete save data")]
        private static void Execute()
        {
            if (Exists(Path))
                Delete(Path);
        }

        [MenuItem("Prototype/Open save folder")]
        private static void OpenSaveFolder() =>
            Start(new System.Diagnostics.ProcessStartInfo() 
            {
                FileName = persistentDataPath,
                UseShellExecute = true,
                Verb = "open"
            });
    }
}