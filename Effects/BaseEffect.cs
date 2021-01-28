using UnityEngine;
using System.Collections;

namespace Effects
{
    public abstract class BaseEffect : MonoBehaviour
    {
        [SerializeField] protected string title;
        [TextArea(2, 8)]
        [SerializeField] protected string longTitle;
        [SerializeField] protected Sprite spriteEffect;
        public string Title
        {
            get => title;
        }
        public Sprite SpriteEffect
        {
            get => spriteEffect;
            set => spriteEffect = value;
        }
        private void Awake()
        {

        }
    }
    public class Healing : BaseEffect
    {
        [SerializeField] private float thisHeal;
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
            this.longTitle = "¬осстановление здоровь€";
            this.spriteEffect = transform.parent.GetComponent<SpriteRenderer>() != null ? transform.parent.GetComponent<SpriteRenderer>().sprite : default;
            this.time = 5f;
        }
        private void Step()
        {
            if (time > 0f)
            {
                Debug.Log(GetComponent<MonoBehaviour>().GetType() + " получает лечение в размере " + thisHeal);
            }
            else
            {
                Destroy(this);
            }
            time -= stepTime;
        }
        private void Start()
        {
            StartCoroutine("ChangeColor");
        }
        private IEnumerator ChangeColor()
        {
            Debug.Log(transform.name);
            Debug.Log(transform.parent.name);
            SpriteRenderer spriteParent = transform.parent.GetComponent<SpriteRenderer>();
            while (true)
            {
                Step();
                yield return new WaitForSeconds(stepTime / 2);
                spriteParent.color = new Color(0, 1, 0);
                yield return new WaitForSeconds(stepTime / 2);
                spriteParent.color = new Color(1, 1, 1);
            }
        }

        private void OnDestroy()
        {
            StopCoroutine("ChangeColor");
        }
    }
    public class Damaging : BaseEffect
    {
        [SerializeField] private float thisDamage;
        [SerializeField] private float time;
        [SerializeField] private float deltaTime = 0;
        [SerializeField] private const float stepTime = 1f;
        public float ThisDamage
        {
            get => thisDamage;
        }
        public void Awake()
        {
            this.thisDamage = 2f;
            base.title = "Damaging";
            this.longTitle = "ѕолучение урона";
            this.spriteEffect = default;
            this.time = 4f;
        }
        private void Step()
        {
            if (time > 0f)
            {
                Debug.Log(gameObject.name + " получает урон в размере " + thisDamage);
            }
            else
            {
                Destroy(this);
            }
            time -= stepTime;
        }
        private void Start()
        {
            StartCoroutine("ChangeColor");
        }
        private IEnumerator ChangeColor()
        {
            while (true)
            {
                Step();
                yield return new WaitForSeconds(stepTime / 2);
                transform.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
                yield return new WaitForSeconds(stepTime / 2);
                transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            }
        }

        private void OnDestroy()
        {
            StopCoroutine("ChangeColor");
        }
    }
}