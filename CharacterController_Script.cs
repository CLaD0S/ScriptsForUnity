using ClassSystems;
using IInterfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController_Script : MonoBehaviour
{
    #region Характеристики здоровья
    [Header("Характеристики здоровья")]
    [SerializeField] private float _hitPoint;
    [SerializeField] private float _maxHitPoint;
    [SerializeField] private float _regenHitPoint;
    [SerializeField] private Text textLabel;
    [Header("Новая система здоровья")]
    [SerializeReference] public HealSystem heal;
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
    public float HitPoint
    {
        get => _hitPoint;
        set
        {
            _hitPoint = value;
        }
    }
    private void Awake()
    {
        ChangeState();
        heal = new HealSystem(this);
        Debug.Log(heal.ToString());
        ChangeHitPoint();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up / 100;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down / 100;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left / 100;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right / 100;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            heal.Heal -= 10;
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
        textLabel.text = "Здоровье :" + heal.Heal;
        //slider.value = _hitPoint;
    }
}
