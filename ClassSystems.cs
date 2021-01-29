using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ClassSystems
{
    public class PointsSystem
    {
        [SerializeField] private float points;
        [SerializeField] private float maxPoints;
        [SerializeField] private float regenPoints;
        [SerializeField] private float delay = 2.0f;
        [SerializeField] private float periodicity = .2f;
        [SerializeField] private bool lastChangePositiv = true;
        private GameObject panel;
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
                    points = value;
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
        public PointsSystem(MonoBehaviour mono, float points = 50f, float maxPoints = 100f, float regenPoints = 1f)
        {
            this.points = points;
            this.maxPoints = maxPoints;
            this.regenPoints = regenPoints;
            panel = GameObject.Find("/Canvas/Slider");
            this.mono = mono;
            this.coroutineRegeneration = Regeneration();
            mono.StartCoroutine(coroutineRegeneration);
        }
        private void ChangePoints()
        {
            UpdateState();
            if ((points < maxPoints) && (!coroutineRegeneration.MoveNext()))
            {
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
            panel.GetComponent<Slider>().value = points;
            panel.GetComponent<Slider>().maxValue = maxPoints;
            panel.GetComponentInChildren<Text>().text = "Здоровье :" + points.ToString("#.##") + "/" + maxPoints.ToString("#.##");
        }
        private IEnumerator Regeneration()
        {
            while (true)
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
                mono.StopCoroutine(coroutineRegeneration);
            }
        }
        public override string ToString()
        {
            return "Тек. хп=" + points + "\nТек. маx.хп=" + maxPoints + "\nТек. регенер=" + regenPoints;
        }
    }
}