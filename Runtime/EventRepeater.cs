namespace Sonderistic.Events
{
    using Sonderistic.General;
    using Sonderistic.Utilities;
    using System;
    using System.Collections;
    using UnityEngine;

    [Serializable]
    public class EventRepeater
    {
        #region Variables
        [SerializeField]
        private Schedule _schedule;
        [SerializeField]
        private float startDelay;

        private Action onEvent;
        private Coroutine coroutine;
        #endregion

        #region Properties
        public Schedule schedule
        {
            get
            {
                return _schedule;
            }
            private set
            {
                _schedule = value;
            }
        }
        #endregion

        #region Constructors
        public EventRepeater(Schedule schedule, Action callback = null)
        {
            this.schedule = schedule;
            onEvent += callback;
        }
        #endregion

        #region Methods
        public void StartRepeater(float startDelay = 0f)
        {
            StopRepeater();
            this.startDelay = startDelay;
            coroutine = CoroutineService.StartCoroutine(RepeatEventCoroutine());
        }

        public void StopRepeater()
        {
            if (coroutine != null)
            {
                CoroutineService.StopCoroutine(coroutine);
                coroutine = null;
            }
        }

        public void SubscribeToEvent(Action callback)
        {
            onEvent += callback;
        }

        public void UnsubscribeFromEvent(Action callback)
        {
            onEvent -= callback;
        }

        public void ClearAllEvents()
        {
            onEvent = null;
        }
        #endregion

        #region Coroutines
        private IEnumerator RepeatEventCoroutine()
        {
            float timer = 0;
            WaitForSeconds waitForSeconds = new WaitForSeconds(schedule.intervalSeconds);

            if (startDelay > 0f)
            {
                yield return new WaitForSeconds(startDelay);
                timer = startDelay;
            }

            while (timer < schedule.durationSeconds)
            {
                if (onEvent == null)
                {
                    yield break;
                }
                
                timer += Time.deltaTime;
                onEvent?.Invoke();
                
                if (schedule.intervalSeconds < 0)
                {
                    yield return null;
                }
                else
                {
                    yield return waitForSeconds;
                }
            }
        }
        #endregion
    }
}

