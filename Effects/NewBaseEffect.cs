using ClassSystems;
using System.Collections;
using UnityEngine;

namespace Effects
{
    public abstract class NewBaseEffect //: Component
    {
        [Header("NewBaseEffect")]
        [SerializeField] protected string title;
        [TextArea(2, 8)]
        [SerializeField] protected string description;
        [SerializeField] protected MonoBehaviour mono;
        [SerializeField] protected Sprite spriteEffect;
    }
    public class NewHealing : NewBaseEffect
    {
        [Header("NewHealing")]
        [SerializeField] private float points;
        [SerializeField] private float maxPoints;
        [SerializeField] private float time;
        [SerializeField] private float delay;
        [SerializeField] private float periodicity;
        [SerializeField] private PointsSystem pointsSys;
        public GameObject panel;
        private IEnumerator coroutineProgress;
        public float ThisPoints
        {
            get => points;
            set => points = value;
        }
        public PointsSystem PointsSys
        {
            get => pointsSys;
            set => pointsSys = value;
        }
        public MonoBehaviour Mono
        {
            get => base.mono;
            set => base.mono = value;
        }
        #region конструктор
        public NewHealing(
            MonoBehaviour mono,
            string title = "NewHealing",
            string description = "description",
            Sprite spriteEffect = default,
            float points = 1f,
            float maxPoints = 10f,
            float time = 0f
            )
        {
            this.mono = mono;
            this.title = title;
            this.description = description;
            this.spriteEffect = spriteEffect;
            this.points = points;
            this.maxPoints = maxPoints;
            this.time = time;
            this.coroutineProgress = Progress();
        }
        #endregion
        public void Start()
        {
            try
            {
                mono.StartCoroutine(coroutineProgress);
            }
            catch
            {
                Debug.LogError("mono.StartCoroutine(coroutineProgress)");
                Debug.LogError(mono.name);
            }
        }
        private IEnumerator Progress()
        {
            if (pointsSys != default)
            {
                pointsSys.Points += points;
            }
            yield return new WaitForSeconds(periodicity);
        }
    }
    public class NewDamaging : NewBaseEffect
    {
        [SerializeField] private float points;
        [SerializeField] private float time;
        [SerializeField] private float deltaTime = 0f;
        [SerializeField] private const float stepTime = 1f;
        public float ThisPoints
        {
            get => points;
        }
        public NewDamaging(
            MonoBehaviour mono,
            string title = "NewDamaging",
            string description = "description",
            Sprite spriteEffect = default,
            float points = 1f,
            float time = 0f
            )
        {
            this.title = title;
            this.description = description;
            this.spriteEffect = spriteEffect;
            this.points = points;
            this.time = time;
        }
    }
}