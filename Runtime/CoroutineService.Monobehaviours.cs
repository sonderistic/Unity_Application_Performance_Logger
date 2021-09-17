namespace Sonderistic.Utilities
{
    using System.Collections;
    using UnityEngine;

    public static partial class CoroutineService
    {
        #region Classes
        private class CoroutineRunner : MonoBehaviour
        {
            #region Methods
            public Coroutine Run(IEnumerator coroutine)
            {
                return StartCoroutine(coroutine);
            }

            public void End(Coroutine coroutine)
            {
                StopCoroutine(coroutine);
            }
            #endregion

            #region Unity Callbacks
            private void Awake()
            {
                DontDestroyOnLoad(this);
            }
            #endregion
        }
        #endregion
    }
}