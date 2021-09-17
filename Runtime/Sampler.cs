namespace Sonderistic.General
{
    using Sonderistic.Events;
    using UnityEngine;

    public abstract class Sampler
    {
        #region Variables
        [SerializeField]
        private Schedule sampleSchedule;

        private EventRepeater sampleEventRepeater;
        private bool hasBeenInitialized = false;
        #endregion

        #region Constructors
        public Sampler(Schedule sampleSchedule)
        {
            this.sampleSchedule = sampleSchedule;
            sampleEventRepeater = new EventRepeater(sampleSchedule);
            Initialize();
        }
        #endregion

        #region Methods
        public void StartSampling()
        {
            if (hasBeenInitialized == false)
            {
                Initialize();
            }
            sampleEventRepeater.StartRepeater();
        }

        public void StopSampling()
        {
            sampleEventRepeater.StopRepeater();
        }

        public abstract string GetDataJson();

        protected abstract void Sample();

        protected virtual void Initialize()
        {
            if (sampleEventRepeater == null)
            {
                sampleEventRepeater = new EventRepeater(sampleSchedule);
            }
            sampleEventRepeater.SubscribeToEvent(Sample);
            hasBeenInitialized = true;
        }
        #endregion
    }
}