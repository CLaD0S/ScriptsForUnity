using UnityEngine;
using System.Collections;

namespace Effects
{
    public abstract class BaseEffect : MonoBehaviour
    {

    }
    public class Healing : BaseEffect
    {
        [SerializeField] private float thisHeal;
        [SerializeField] private string title;
        [SerializeField] private string longTitle;
        [SerializeField] private Sprite SpriteEffect;
        [SerializeField] private float time;
        [SerializeField] private float deltaTime = 0;
        [SerializeField] private const float stepTime = 1f;
        public float ThisHeal
        {
            get => thisHeal;
        }
        public void Awake()
        {
            this.thisHeal = 3f;
            this.title = "Healing";
            this.longTitle = "Восстановление здоровья";
            this.SpriteEffect = default;
            this.time = 5f;
        }
        private void FixedUpdate()
        {
            deltaTime += Time.deltaTime;
            if (deltaTime >= stepTime)
            {
                if (time >= 0f)
                {
                    time -= stepTime;
                    Debug.Log(gameObject.name + " получает лечение в размере " + thisHeal);
                    deltaTime = 0f;
                }
                else
                {
                    Destroy(this);
                }
            }
        }

        private void Start()
        {
            StartCoroutine("ChangeColor");
        }

        private IEnumerator ChangeColor()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                transform.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);
                yield return new WaitForSeconds(1);
                transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            }
        }

        private void OnDestroy()
        {
            StopCoroutine("ChangeColor");
        }
    }
}