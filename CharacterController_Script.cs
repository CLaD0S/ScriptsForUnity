using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController_Script : MonoBehaviour
{
    [Header("Характеристики здоровья")]
    [SerializeField]
    private int _hitPoint;
    [SerializeField]
    private int _maxHitPoint;
    [SerializeField]
    private int _regenHitPoint;
    [SerializeField]
    private Text textLabel;

    public int HitPoint
    {
        get => _hitPoint;
        set => _hitPoint = value;
    }
    private void Awake()
    {
        ChangeHitPoint();
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

    public void ChangeHitPoint()
    {
        //transform.parent.parent.parent
        textLabel.text = _hitPoint.ToString();
    }
}
