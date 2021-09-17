namespace Sonderistic.General
{
    using System;
    using UnityEngine;

    [Serializable]
    public class Schedule
    {
        #region Variables
        [SerializeField]
        private float _durationSeconds;
        [SerializeField]
        private float _intervalSeconds;
        #endregion

        #region Constructors
        public Schedule(float durationSeconds, float intervalSeconds)
        {
            _durationSeconds = durationSeconds;
            _intervalSeconds = intervalSeconds;
        }
        #endregion

        #region Properties
        public float durationSeconds
        {
            get
            {
                return _durationSeconds;
            }
        }

        public float intervalSeconds
        {
            get
            {
                return _intervalSeconds;
            }
        }
        #endregion
    }
}
