using ClassSystems;
using Effects;
using IInterfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController_Script : MonoBehaviour
{
    [Header("NewBaseEffect")]
    [SerializeReference] public List<NewBaseEffect> effects = new List<NewBaseEffect>();
    #region Характеристики
    [Header("Здоровья")]
    [SerializeReference] public PointsSystem heal;
    [Header("Энергия")]
    [SerializeReference] public PointsSystem mana;
    [Header("Выносливость")]
    [SerializeReference] public PointsSystem stamina;
    #endregion
    [Header("Остальные характеристики")]
    [SerializeField] private int _strong;
    [SerializeField] private int baseStrong;
    [SerializeField] private Text textStrong;
    [SerializeField] private int _agility;
    [SerializeField] private int baseAgility;
    [SerializeField] private Text textAgility;
    [SerializeField] private int _intelekt;
    [SerializeField] private int baseIntelekt;
    [SerializeField] private Text textIntelekt;
    [SerializeField] private Slider slider;
    private void Awake()
    {
        ChangeState();
        heal = new PointsSystem(this, "Здоровье")
        {
            panel = GameObject.Find("HealBar")
        };
        mana = new PointsSystem(this, "Энергия", 100f, 190f, 3f, 1f, 1f)
        {
            panel = GameObject.Find("ManaBar")
        };
        stamina = new PointsSystem(this, "Выносливость", 80f, 100f, 4f, 1f, 0.5f)
        {
            panel = GameObject.Find("StaminaBar")
        };
        ChangeHitPoint();
    }
    private void Update()
    {
        if ((Input.GetKey(KeyCode.W)) ||
            (Input.GetKey(KeyCode.S)) ||
            (Input.GetKey(KeyCode.A)) ||
            (Input.GetKey(KeyCode.D)))
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += Vector3.up / 100;
                GetComponent<Animator>().SetBool("IsIdle", false);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += Vector3.down / 100;
                GetComponent<Animator>().SetBool("IsIdle", false);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position += Vector3.left / 100;
                GetComponent<Animator>().SetBool("IsIdle", false);
                if (!GetComponent<SpriteRenderer>().flipX) { GetComponent<SpriteRenderer>().flipX = true; };
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += Vector3.right / 100;
                GetComponent<Animator>().SetBool("IsIdle", false);
                if (GetComponent<SpriteRenderer>().flipX) { GetComponent<SpriteRenderer>().flipX = false; };
            }
        }
        else
        {
            GetComponent<Animator>().SetBool("IsIdle", true);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            heal.Points -= heal.MaxPoints * 0.1f;
            mana.Points -= mana.MaxPoints * 0.1f;
            stamina.Points -= stamina.MaxPoints * 0.1f;
        }
    }
    public void ChangeState()
    {
        //textStrong.text = "Сила :" + _strong.ToString();
        //textAgility.text = "Ловкость :" + _agility.ToString();
        //textIntelekt.text = "Интеллект :" + _intelekt.ToString();
    }
    public void ChangeHitPoint()
    {
        //slider.value = _hitPoint;
    }
}
