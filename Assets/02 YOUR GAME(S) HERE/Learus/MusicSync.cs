using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Learus
{
    public class MusicSync : Singleton<MusicSync>
    {
        public class Sync
        {
            public struct SyncTuple
            {
                public float timeStamp;
                public UnityAction action;

                public SyncTuple(float _timeStamp, UnityAction _action)
                {
                    timeStamp = _timeStamp;
                    action = _action;
                }
            }

            public List<SyncTuple> actions;

            private int currentAction;

            public SyncTuple next()
            {
                return actions[currentAction++];
            }

            public bool Done()
            {
                return currentAction == actions.Count;
            }

            public Sync(List<SyncTuple> _actions)
            {
                currentAction = 0;
                actions = _actions;
            }
        }
        private Sync sync;

        public AudioSource Music;
        public AudioClip Clip;
        public float BPM;
        public float TimePerBeat => 60f / BPM;
        public float LastBeat = 0;

        // Start is called before the first frame update
        void Start()
        {
            int numberOfBeatsInClip = (int)(Clip.length / TimePerBeat);
            List<Sync.SyncTuple> actions = new List<Sync.SyncTuple>();

            for (int i = 0; i < numberOfBeatsInClip; i++)
            {
                actions.Add(new Sync.SyncTuple(i * TimePerBeat, OnQuarter));
            }

            sync = new Sync(actions);

            Music.Stop();
            Music.clip = Clip;
            Music.volume = 1;
            Music.loop = false;

            GameManager.Instance.Play();
            Music.Play();
            StartCoroutine(Synchronizer());
        }

        public void OnQuarter()
        {
            GameManager.Instance.RotateFelix();
            LastBeat = Time.time;
            // Debug.Log(LastBeat);
        }

        IEnumerator Synchronizer()
        {
            Sync.SyncTuple action = sync.next();

            while (true)
            {
                // Debug.Log($"{action.timeStamp} {Music.time}");
                if (Music.time >= action.timeStamp)
                {
                    action.action();

                    if (sync.Done()) yield break;
                    Debug.Log("quarter");
                    

                    action = sync.next();
                }

                yield return new WaitForSecondsRealtime(TimePerBeat / 4);
            }
        }
    }

}

