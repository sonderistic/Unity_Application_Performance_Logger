using UnityEngine;

namespace Sonderistic.General
{
    using Sonderistic.Logging;

    public class ApplicationPerformanceService : MonoBehaviour
    {
        #region Variables
        [SerializeField]
        private MemoryUsageSampler memoryUsageSampler;

        private FPSSampler fpsSampler;
        #endregion

        #region Methods
        private void InitializeEvents()
        {
            fpsSampler = new FPSSampler(new Schedule(float.MaxValue, 5f));
            fpsSampler.StartSampling();
            memoryUsageSampler.StartSampling();
        }

        [ContextMenu("Log")]
        private void Log()
        {
            Logger.Log(fpsSampler.GetDataJson());
            Logger.Log(memoryUsageSampler.GetDataJson());
        }
        #endregion

        #region Unity Callbacks
        private void Awake()
        {
            InitializeEvents();
        }
        #endregion
    }
}

