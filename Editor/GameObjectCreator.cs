namespace Sonderistic.Editor
{
    using Sonderistic.General;
    using UnityEditor;
    using UnityEngine;

    internal static class GameObjectCreator
    {
        #region Constants
        private const string PERFORMANCE_LOGGER_GO_NAME = "PerformanceLogger";
        #endregion

        #region Methods
        [MenuItem("Performance Logger/Create Performance Logger")]
        private static void CreatePerformanceLogger()
        {
            GameObject performanceLoggerGO = new GameObject(PERFORMANCE_LOGGER_GO_NAME);
            performanceLoggerGO.AddComponent<ApplicationPerformanceService>();
        }
        #endregion
    }
}

