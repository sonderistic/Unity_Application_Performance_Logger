namespace Sonderistic.General
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    [Serializable]
    public class FPSSampler : Sampler
    {
        #region Constants
        private const string NAME_OF_DATA = "FPS";
        #endregion

        #region Variables
        private Dictionary<DateTime, float> sampleDateTimeToFPS = new Dictionary<DateTime, float>();
        #endregion

        #region Constructors
        public FPSSampler(Schedule sampleSchedule) : base(sampleSchedule) { }
        #endregion

        #region Methods
        protected override void Initialize()
        {
            base.Initialize();
            sampleDateTimeToFPS = new Dictionary<DateTime, float>();
        }

        public override string GetDataJson()
        {
            JObject jObject = JObject.FromObject(sampleDateTimeToFPS);
            Dictionary<string, JObject> nameToData = new Dictionary<string, JObject>();
            nameToData.Add(NAME_OF_DATA, jObject);
            return JsonConvert.SerializeObject(nameToData);
        }

        protected override void Sample()
        {
            sampleDateTimeToFPS.Add(DateTime.UtcNow, 1 / Time.deltaTime);
        }
        #endregion
    }
}