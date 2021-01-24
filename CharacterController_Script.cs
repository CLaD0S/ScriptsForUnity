using IInterfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController_Script : MonoBehaviour
{
    #region
    [Header("�������������� ��������")]
    [SerializeField]
    private float _hitPoint;
    [SerializeField]
    private int _maxHitPoint;
    [SerializeField]
    private int _regenHitPoint;
    [SerializeField]
    private Text textLabel;
    #endregion
    [SerializeField]
    private int _strong;
    [SerializeField]
    private int baseStrong;
    [SerializeField]
    private Text textStrong;
    [SerializeField]
    private int _agility;
    [SerializeField]
    private int baseAgility;
    [SerializeField]
    private Text textAgility;
    [SerializeField]
    private int _intelekt;
    [SerializeField]
    private int baseIntelekt;
    [SerializeField]
    private Text textIntelekt;

    public float HitPoint
    {
        get => _hitPoint;
        set => _hitPoint = value;
    }
    private void Awake()
    {
        ChangeHitPoint();
        ChangeState();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up);
        }
        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.down);
        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.left);
        }
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.right);
        }
    }
    public void ChangeState()
    {
        textStrong.text = "���� :" + _strong.ToString();
        textAgility.text = "�������� :" + _agility.ToString();
        textIntelekt.text = "��������� :" + _intelekt.ToString();
    }
    public void ChangeHitPoint(float hit = 0)
    {
        HitPoint += hit;
        textLabel.text = "�������� :" + _hitPoint.ToString();
    }
}
