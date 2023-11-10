using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Learus
{
    public class GameManager : Singleton<GameManager>
    {
        public SpriteRenderer Felix;
        public TMPro.TextMeshProUGUI InstructionText;
        public TMPro.TextMeshProUGUI ScoreText;
        public SpriteRenderer TopBackground;
        public SpriteRenderer BottomBackground;
        public Transform KeyContainer;
        public GameObject KeyPrefab;
        public string[] Words;
        public string CurrentWord;
        public HashSet<char> AttemptedKeys = new HashSet<char>();
        public int HitKeys = 0;
        public int AllKeys = 0;
        public Dictionary<string, Key> Keys = new Dictionary<string, Key>();
        public Color[] BackgroundColors;
        private bool EvenRotation = false;

        public float timer = 7f;

        void Start()
        {

        }

        public void Play()
        {
            ChangeWord();
        }

        void Update()
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                if (HitKeys > AllKeys / 2)
                    GoFelixManager.Instance.Win();
                else
                    GoFelixManager.Instance.Lose();
            }

            if (Input.anyKeyDown)
            {
                bool hit = false;

                for (int i = 0; i < CurrentWord.Length; i++)
                {
                    char lowCharacter = CurrentWord.ToLower()[i];
                    char upCharacter = CurrentWord.ToUpper()[i];

                    if (AttemptedKeys.Contains(upCharacter)) continue;

                    if (Input.GetKeyDown(lowCharacter.ToString()))
                    {
                        HitKey(upCharacter, i);
                        hit = true;
                    }
                }

                if (!hit)
                {
                    MissKey();
                }
            }

            ScoreText.text = $"{HitKeys}/{AllKeys}";
        }

        public void SpawnKeys()
        {
            // Destroy all children of key container
            foreach (Transform child in KeyContainer)
            {
                Destroy(child.gameObject);
            }

            Keys.Clear();

            // Spawn new keys
            for (int i = 0; i < CurrentWord.Length; i++)
            {
                char character = CurrentWord[i];
                GameObject key = Instantiate(KeyPrefab, KeyContainer);
                key.GetComponent<Key>().Init(character.ToString());
                Keys.Add(character.ToString(), key.GetComponent<Key>());
            }
        }

        public void HitKey(char character, int index)
        {
            float errorMargin = 0.2f;
            AttemptedKeys.Add(character);

            Keys.TryGetValue(character.ToString(), out Key key);

            if (!key) return;

            var diff = Math.Abs(Time.time - MusicSync.Instance.LastBeat);

            if (diff < errorMargin)
            {
                key.Hit();
                HitKeys++;
            }
            else
            {
                key.Miss();
            }

            if (AttemptedKeys.Count == CurrentWord.Length)
            {
                Invoke("ChangeWord", 0.2f);
            }
        }

        public void ChangeWord()
        {
            AttemptedKeys.Clear();
            CurrentWord = Words[UnityEngine.Random.Range(0, Words.Length)];
            SpawnKeys();
            AllKeys += CurrentWord.Length;
        }

        public void MissKey()
        {

        }

        public void RotateFelix()
        {
            EvenRotation = !EvenRotation;

            // Rotate felix to the right if its an even rotation
            // to the left if it's an odd rotation
            Felix.transform.rotation = Quaternion.Euler(new Vector3(0, 0, EvenRotation ? 40 : -40));
            InstructionText.transform.rotation = Quaternion.Euler(new Vector3(0, 0, EvenRotation ? -3 : 3));
            ScoreText.transform.rotation = Quaternion.Euler(new Vector3(0, 0, EvenRotation ? 3 : -3));

            // Pick random background color
            Color c = BackgroundColors[UnityEngine.Random.Range(0, BackgroundColors.Length)];
            Color c2 = BackgroundColors[UnityEngine.Random.Range(0, BackgroundColors.Length)];

            TopBackground.color = c;
            InstructionText.color = c2;
            ScoreText.color = c2;

            foreach (Key key in Keys.Values)
            {
                key.ToggleSprite(EvenRotation);
            }
        }
    }
}