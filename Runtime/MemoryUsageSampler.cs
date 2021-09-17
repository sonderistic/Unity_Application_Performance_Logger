namespace Sonderistic.General
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using UnityEngine.Profiling;

    [Serializable]
    public class MemoryUsageSampler : Sampler
    {
        #region Constants
        private const string NAME_OF_DATA = "MemoryUsage";
        #endregion

        #region Variables
        private Dictionary<DateTime, float> sampleDateTimeToManagedMemoryUsed = new Dictionary<DateTime, float>();
        #endregion

        #region Constructors
        public MemoryUsageSampler(Schedule sampleSchedule) : base(sampleSchedule) { }
        #endregion

        #region Methods
        public override string GetDataJson()
        {
            JObject jObject = JObject.FromObject(sampleDateTimeToManagedMemoryUsed);
            Dictionary<string, JObject> nameToData = new Dictionary<string, JObject>();
            nameToData.Add(NAME_OF_DATA, jObject);
            return JsonConvert.SerializeObject(nameToData);
        }

        protected override void Initialize()
        {
            base.Initialize();
            sampleDateTimeToManagedMemoryUsed = new Dictionary<DateTime, float>();
        }

        protected override void Sample()
        {
            sampleDateTimeToManagedMemoryUsed.Add(DateTime.UtcNow, Profiler.GetTotalAllocatedMemoryLong());
        }
        #endregion
    }
}