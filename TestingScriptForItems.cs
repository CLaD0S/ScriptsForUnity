using IInterfaces;
using UnityEngine;
using UnityEngine.UI;

public class TestingScriptForItems : MonoBehaviour, IHeiling, ITiming
{
    private GameObject Parent;
    private Image image;
    public int power;
    public float time;
    private float timer = .0f;

    private void Awake()
    {
        //image = GetComponent<Image>().
        //power = 3;
        //time = 5;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            Timing();
            timer = .0f;
        }
        time -= Time.deltaTime;
        if (time < 0) Destroy(this);
    }
    public void Heiling()
    {
        GetComponent<CharacterController_Script>().ChangeHitPoint();
    }
    public void Timing()
    {
        Heiling();
    }
}
