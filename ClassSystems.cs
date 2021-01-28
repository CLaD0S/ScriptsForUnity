using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ClassSystems
{
    public class HealSystem
    {
        [SerializeField] private float heal;
        [SerializeField] private float maxHeal;
        [SerializeField] private float regenHeal;
        private GameObject panel;
        private MonoBehaviour mono;
        private IEnumerator coroutine;
        public float Heal
        {
            get => heal;
            set
            {
                if (value > 0)
                {
                    heal = value;
                    ChangeHeal();
                }
                else
                {
                    heal = 0;
                    UpdateState();
                    Debug.Log(mono.name + " погиб");
                }
            }
        }
        public float MaxHeal
        {
            get => maxHeal;
            set
            {
                maxHeal = value;
                ChangeMaxHeal();
            }
        }
        public float RegenHeal
        {
            get => regenHeal;
            set
            {
                regenHeal = value;
                ChangeRegenHeal();
            }
        }
        public HealSystem(MonoBehaviour mono, float heal = 50f, float maxHeal = 100f, float regenHeal = 1f)
        {
            this.heal = heal;
            this.maxHeal = maxHeal;
            this.regenHeal = regenHeal;
            panel = GameObject.Find("/Canvas/Slider");
            this.mono = mono;
            this.coroutine = Regeneration();
            if (heal < maxHeal)
            {
                ChangeHeal();
            }
        }
        private void ChangeHeal()
        {
            UpdateState();
            if (heal < maxHeal)
            {
                mono.StopCoroutine(coroutine);
                coroutine = Regeneration();
                mono.StartCoroutine(coroutine);
            }
        }
        private void ChangeMaxHeal()
        {
            UpdateState();
        }
        private void ChangeRegenHeal()
        {

        }
        private void UpdateState()
        {
            panel.GetComponent<Slider>().value = heal;
            panel.GetComponent<Slider>().maxValue = maxHeal;
            panel.GetComponentInChildren<Text>().text = "Здоровье :" + heal.ToString("#.##") + "/" + maxHeal.ToString("#.##");
        }
        private IEnumerator Regeneration()
        {
            do
            {
                yield return new WaitForSeconds(1f / 5f);
                heal += regenHeal / 5f;
                UpdateState();
            } while (heal < maxHeal);
            heal = maxHeal;
            UpdateState();
        }
        public override string ToString()
        {
            return "Тек. хп=" + heal + "\nТек. маx.хп=" + maxHeal + "\nТек. регенер=" + regenHeal;
        }
    }
}