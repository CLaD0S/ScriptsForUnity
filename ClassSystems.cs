using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ClassSystems
{
    public class HealSystem : MonoBehaviour
    {
        [SerializeField] private float heal;
        [SerializeField] private float maxHeal;
        [SerializeField] private float regenHeal;

        float dtime = 0;
        public GameObject panel;
        public float Heal
        {
            get => heal;
            set
            {
                heal = value;
                ChangeHeal();
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
        public HealSystem(float heal = 100f, float maxHeal = 100f, float regenHeal = 1f)
        {
            this.heal = heal;
            this.maxHeal = maxHeal;
            this.regenHeal = regenHeal;
        }
        private void ChangeHeal()
        {
            panel.GetComponent<Slider>().value = heal;
            if (heal < maxHeal) Regeneration();
        }
        private void ChangeMaxHeal()
        {
            panel.GetComponent<Slider>().maxValue = maxHeal;
        }
        private void ChangeRegenHeal()
        {

        }
        private IEnumerator Regeneration()
        {
            do
            {
                yield return new WaitForSeconds(1 / 5);
                heal += regenHeal;
            } while (heal < maxHeal);
            heal = maxHeal;
        }
    }
}