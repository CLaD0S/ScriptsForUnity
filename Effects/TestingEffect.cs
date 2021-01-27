using Effects;
using System.Collections;
using UnityEngine;

public class Healing : BaseEffect
{
    [SerializeField] private float thisHeal;
    [SerializeField] private float time;
    [SerializeField] private float deltaTime = 0;
    [SerializeField] private const float stepTime = 1f;
    public float ThisHeal
    {
        get => thisHeal;
    }
    public void Awake()
    {
        this.thisHeal = 3f;
        this.title = "Healing";
        this.longTitle = "Восстановление здоровья";
        this.spriteEffect = default;
        this.time = 5f;
    }
    private void Step()
    {
        if (time > 0f)
        {
            Debug.Log(GetComponent<MonoBehaviour>().GetType() + " получает лечение в размере " + thisHeal);
        }
        else
        {
            Destroy(this);
        }
        time -= stepTime;
    }
    private void Start()
    {
        StartCoroutine("ChangeColor");
    }
    private IEnumerator ChangeColor()
    {
        SpriteRenderer spriteParent = transform.parent.GetComponent<SpriteRenderer>();
        while (true)
        {
            Step();
            yield return new WaitForSeconds(stepTime / 2);
            spriteParent.color = new Color(0, 1, 0);
            yield return new WaitForSeconds(stepTime / 2);
            spriteParent.color = new Color(1, 1, 1);
        }
    }

    private void OnDestroy()
    {
        StopCoroutine("ChangeColor");
    }
}
