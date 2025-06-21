using UnityEngine;

public class BarTester : MonoBehaviour {
    public StatManager stat;
    public float healthMax;
    public float healthCurrent;
    private float healthChecker;
    public float healthPercent;
    public Animator anim;
    private bool show;
    private float showTimer;
    public Vector2 here;
    public Vector2 gone;
    public bool Fullhealth;

    // Use this for initialization
    void Start()
    {

        anim = GetComponent<Animator>();
        anim.SetFloat("HealthAmount", 0);
        healthChecker = healthCurrent;
        Fullhealth = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (healthCurrent < healthMax)
        { healthCurrent = healthCurrent + stat.healthRegen * Time.deltaTime; }

        healthMax = stat.health;
        if (Fullhealth)
        {
            healthCurrent = healthMax;
        }

        float mid = healthMax / healthCurrent;
        healthPercent = 100 / mid;
        if (show == false)
        {
            transform.localScale = gone;
        }
        else
        { transform.localScale = here; };

        if (healthChecker != healthCurrent)
        {
            Fullhealth = false;
            show = true;
            healthChecker = healthCurrent;
            showTimer = 3;

        }
        if (show)
        {
            showTimer = showTimer - Time.deltaTime;
            if (showTimer <= 0)
            {
                show = false;
            }
        }
        if (healthPercent > 98)
        {
            anim.SetFloat("HealthAmount", 0);
        }
        if (healthPercent > 96 && healthPercent <= 98)
        {
            anim.SetFloat("HealthAmount", 0.02f);
        }
        if (healthPercent > 94 && healthPercent <= 96)
        {
            anim.SetFloat("HealthAmount", 0.04f);
        }
        if (healthPercent > 92 && healthPercent <= 94)
        {
            anim.SetFloat("HealthAmount", 0.06f);
        }
        if (healthPercent > 90 && healthPercent <= 92)
        {
            anim.SetFloat("HealthAmount", 0.08f);
        }
        if (healthPercent > 88 && healthPercent <= 90)
        {
            anim.SetFloat("HealthAmount", 0.1f);
        }
        if (healthPercent > 86 && healthPercent <= 88)
        {
            anim.SetFloat("HealthAmount", 0.12f);
        }
        if (healthPercent > 84 && healthPercent <= 86)
        {
            anim.SetFloat("HealthAmount", 0.14f);
        }
        if (healthPercent > 82 && healthPercent <= 84)
        {
            anim.SetFloat("HealthAmount", 0.16f);
        }
        if (healthPercent > 80 && healthPercent <= 82)
        {
            anim.SetFloat("HealthAmount", 0.18f);
        }
        if (healthPercent > 78 && healthPercent <= 80)
        {
            anim.SetFloat("HealthAmount", 0.2f);
        }
        if (healthPercent > 76 && healthPercent <= 78)
        {
            anim.SetFloat("HealthAmount", 0.22f);
        }
        if (healthPercent > 74 && healthPercent <= 76)
        {
            anim.SetFloat("HealthAmount", 0.24f);
        }
        if (healthPercent > 72 && healthPercent <= 74)
        {
            anim.SetFloat("HealthAmount", 0.26f);
        }
        if (healthPercent > 70 && healthPercent <= 72)
        {
            anim.SetFloat("HealthAmount", 0.28f);
        }
        if (healthPercent > 68 && healthPercent <= 70)
        {
            anim.SetFloat("HealthAmount", 0.3f);
        }
        if (healthPercent > 66 && healthPercent <= 68)
        {
            anim.SetFloat("HealthAmount", 0.32f);
        }
        if (healthPercent > 64 && healthPercent <= 66)
        {
            anim.SetFloat("HealthAmount", 0.34f);
        }
        if (healthPercent > 62 && healthPercent <= 64)
        {
            anim.SetFloat("HealthAmount", 0.36f);
        }
        if (healthPercent > 60 && healthPercent <= 62)
        {
            anim.SetFloat("HealthAmount", 0.38f);
        }
        if (healthPercent > 58 && healthPercent <= 60)
        {
            anim.SetFloat("HealthAmount", 0.4f);
        }
        if (healthPercent > 56 && healthPercent <= 58)
        {
            anim.SetFloat("HealthAmount", 0.42f);
        }
        if (healthPercent > 54 && healthPercent <= 56)
        {
            anim.SetFloat("HealthAmount", 0.44f);
        }
        if (healthPercent > 52 && healthPercent <= 54)
        {
            anim.SetFloat("HealthAmount", 0.46f);
        }
        if (healthPercent > 50 && healthPercent <= 52)
        {
            anim.SetFloat("HealthAmount", 0.48f);
        }
        if (healthPercent > 48 && healthPercent <= 50)
        {
            anim.SetFloat("HealthAmount", 0.5f);
        }
        if (healthPercent > 46 && healthPercent <= 48)
        {
            anim.SetFloat("HealthAmount", 0.52f);
        }
        if (healthPercent > 44 && healthPercent <= 46)
        {
            anim.SetFloat("HealthAmount", 0.54f);
        }
        if (healthPercent > 42 && healthPercent <= 44)
        {
            anim.SetFloat("HealthAmount", 0.56f);
        }
        if (healthPercent > 40 && healthPercent <= 42)
        {
            anim.SetFloat("HealthAmount", 0.58f);
        }
        if (healthPercent > 38 && healthPercent <= 40)
        {
            anim.SetFloat("HealthAmount", 0.6f);
        }
        if (healthPercent > 36 && healthPercent <= 38)
        {
            anim.SetFloat("HealthAmount", 0.62f);
        }
        if (healthPercent > 34 && healthPercent <= 36)
        {
            anim.SetFloat("HealthAmount", 0.64f);
        }
        if (healthPercent > 32 && healthPercent <= 34)
        {
            anim.SetFloat("HealthAmount", 0.66f);
        }
        if (healthPercent > 30 && healthPercent <= 32)
        {
            anim.SetFloat("HealthAmount", 0.68f);
        }
        if (healthPercent > 28 && healthPercent <= 30)
        {
            anim.SetFloat("HealthAmount", 0.7f);
        }
        if (healthPercent > 26 && healthPercent <= 28)
        {
            anim.SetFloat("HealthAmount", 0.72f);
        }
        if (healthPercent > 24 && healthPercent <= 26)
        {
            anim.SetFloat("HealthAmount", 0.74f);
        }
        if (healthPercent > 22 && healthPercent <= 24)
        {
            anim.SetFloat("HealthAmount", 0.76f);
        }
        if (healthPercent > 20 && healthPercent <= 22)
        {
            anim.SetFloat("HealthAmount", 0.78f);
        }
        if (healthPercent > 18 && healthPercent <= 20)
        {
            anim.SetFloat("HealthAmount", 0.8f);
        }
        if (healthPercent > 16 && healthPercent <= 18)
        {
            anim.SetFloat("HealthAmount", 0.82f);
        }
        if (healthPercent > 14 && healthPercent <= 16)
        {
            anim.SetFloat("HealthAmount", 0.84f);
        }
        if (healthPercent > 12 && healthPercent <= 14)
        {
            anim.SetFloat("HealthAmount", 0.86f);
        }
        if (healthPercent > 10 && healthPercent <= 12)
        {
            anim.SetFloat("HealthAmount", 0.88f);
        }
        if (healthPercent > 8 && healthPercent <= 10)
        {
            anim.SetFloat("HealthAmount", 0.90f);
        }
        if (healthPercent > 6 && healthPercent <= 8)
        {
            anim.SetFloat("HealthAmount", 0.92f);
        }
        if (healthPercent > 4 && healthPercent <= 6)
        {
            anim.SetFloat("HealthAmount", 0.94f);
        }
        if (healthPercent > 2 && healthPercent <= 4)
        {
            anim.SetFloat("HealthAmount", 0.96f);
        }
        if (healthPercent <= 2)
        {
            anim.SetFloat("HealthAmount", 1f);
            Destroy(gameObject);
        }


    }
}
