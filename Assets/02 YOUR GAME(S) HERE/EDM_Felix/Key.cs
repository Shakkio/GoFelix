using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Learus
{
    public class Key : MonoBehaviour
    {
        public Color ActivatedColor = Color.green;
        public Color MissedColor = Color.red;
        public Color DefaultColor = Color.white;
        public Sprite UpSprite;
        public Sprite DownSprite;

        public Image Image;
        public TMPro.TextMeshProUGUI Text;
        private string letter;

        public void Init(string _letter)
        {
            Text.text = _letter;
            letter = _letter;
            Image.color = DefaultColor;
        }

        public void Hit()
        {
            Image.color = ActivatedColor;
        }

        public void Miss()
        {
            Image.color = MissedColor;
        }

        public void ToggleSprite(bool even)
        {
            Image.sprite = even ? UpSprite : DownSprite;

            float y = Text.transform.localPosition.y + (even ? 5 : -5);
            Text.transform.localPosition = new Vector3(Text.transform.localPosition.x, y, Text.transform.localPosition.z);
        }
    }
}

