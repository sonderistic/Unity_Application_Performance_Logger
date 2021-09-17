namespace Sonderistic.Utilities
{
    using System.Collections;
    using UnityEngine;

    public static partial class CoroutineService
    {
        #region Constants
        private const string COROUTINE_RUNNER_GO_NAME = "CoroutineRunner";
        #endregion

        #region Variables
        private static CoroutineRunner coroutineRunner;
        #endregion

        #region Constructors
        static CoroutineService()
        {
            GameObject coroutineRunnerGO = new GameObject(COROUTINE_RUNNER_GO_NAME);
            coroutineRunner = coroutineRunnerGO.AddComponent<CoroutineRunner>();
        }
        #endregion

        #region Methods
        public static Coroutine StartCoroutine(IEnumerator coroutine)
        {
            if (coroutineRunner == null) 
            {
                Debug.LogWarning("Coroutine Runner has been deleted: Unable to start coroutine.");
            }

            return coroutineRunner?.Run(coroutine);
        }

        public static void StopCoroutine(Coroutine coroutine)
        {
            coroutineRunner?.StopCoroutine(coroutine);
        }
        #endregion
    }
}