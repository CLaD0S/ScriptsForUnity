using System.Collections;
using UnityEngine.UI;
using UnityEngine;

namespace ClassSystems
{
    public class PointsSystem
    {
        [SerializeField] private string title;
        [SerializeField] private float points;
        [SerializeField] private float maxPoints;
        [SerializeField] private float regenPoints;
        [SerializeField] private float delay;
        [SerializeField] private float periodicity;
        [SerializeField] private bool lastChangePositiv = true;
        public GameObject panel;
        private MonoBehaviour mono;
        private IEnumerator coroutineRegeneration;
        public float Points
        {
            get => points;
            set
            {
                if (value > 0)
                {
                    lastChangePositiv = value >= points;
                    points = value > maxPoints ? maxPoints : value;
                    ChangePoints();
                }
                else
                {
                    points = 0;
                    UpdateState();
                    Debug.Log(mono.name + " погиб");
                }
            }
        }
        public float MaxPoints
        {
            get => maxPoints;
            set
            {
                maxPoints = value;
                ChangeMaxPoints();
            }
        }
        public float RegenPoints
        {
            get => regenPoints;
            set
            {
                regenPoints = value;
                ChangeRegenPoints();
            }
        }
        #region конструктор
        public PointsSystem(
            MonoBehaviour mono,
            string title = "Status",
            float points = 100f,
            float maxPoints = 100f,
            float regenPoints = 1f,
            float delay = 2.0f,
            float periodicity = .2f)
        {
            this.title = title;
            this.points = points;
            this.maxPoints = maxPoints;
            this.regenPoints = regenPoints;
            this.mono = mono;
            this.delay = delay;
            this.periodicity = periodicity;
            this.coroutineRegeneration = Regeneration();
            UpdateState();
            mono.StartCoroutine(coroutineRegeneration);
        }
        #endregion
        private void ChangePoints()
        {
            UpdateState();
            if (points < maxPoints)
            {
                mono.StopCoroutine(coroutineRegeneration);
                coroutineRegeneration = Regeneration();
                mono.StartCoroutine(coroutineRegeneration);
            }
        }
        private void ChangeMaxPoints()
        {
            UpdateState();
        }
        private void ChangeRegenPoints()
        {

        }
        private void UpdateState()
        {
            if (panel != default)
            {
                panel.GetComponent<Slider>().value = points;
                panel.GetComponent<Slider>().maxValue = maxPoints;
                panel.GetComponentInChildren<Text>().text = title + " :" + points.ToString("#.##") + "/" + maxPoints.ToString("#.##");
            }
        }
        private IEnumerator Regeneration()
        {
            if (!lastChangePositiv) yield return new WaitForSeconds(delay);
            do
            {
                yield return new WaitForSeconds(periodicity);
                points += regenPoints;
                UpdateState();
            } while (points < maxPoints);
            points = maxPoints;
            UpdateState();
        }
        public override string ToString()
        {
            return "Тек. хп=" + points + "\nТек. маx.хп=" + maxPoints + "\nТек. регенер=" + regenPoints;
        }
    }
}