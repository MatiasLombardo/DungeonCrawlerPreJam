using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SistemaDeVida : MonoBehaviour
{


    [SerializeField] AudioClip au_PerderVidaP, au_PerderVidaE;
    
    public static SistemaDeVida Instance { get; private set; }

    private void Awake() 
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

    }


    //public Text healthText;
    public Image p_healthBar;
    float p_health, p_maxHealth = 10;
    float lerpSpeed;
    [SerializeField]TMP_Text numero_vidaP;
    [SerializeField]TMP_Text numero_vidaE;
    [SerializeField] TMP_Text com_ResultadoP, com_ResultadoE;


    public Image e_healthBar;
    float e_health, e_maxHealth = 10;


    private void Start()
    {
        p_health = p_maxHealth;
        numero_vidaP.text = p_health.ToString();
        e_health = e_maxHealth;
        numero_vidaE.text = e_health.ToString();
    }

    private void Update()
    {
        //healthText.text = "Health: " + health + "%";
        
        if (p_health > p_maxHealth)
            p_health = p_maxHealth;
        
        lerpSpeed = 3f * Time.deltaTime;
        
        HealthBarFiller(p_health, p_maxHealth, p_healthBar);
        HealthBarFiller(e_health, e_maxHealth, e_healthBar);
        ColorChanger(p_health, p_maxHealth, p_healthBar);
        ColorChanger(e_health, e_maxHealth, e_healthBar);
    }
    
    void HealthBarFiller(float health, float maxHealth, Image healthBar)
        {
            healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, health / maxHealth, lerpSpeed);
        }
    
    void ColorChanger(float health, float maxHealth, Image healthBar)
        {
            Color healthColor = Color.Lerp(Color.red, Color.green, (health / maxHealth));

            healthBar.color = healthColor;
        }

  public void HacerDañoPlayer(int daño)
  {

    if (daño > 0)
    {
        AudioManager.Instance.Play(au_PerderVidaP);
        p_health = p_health - daño;
        numero_vidaP.text = p_health.ToString();
        StartCoroutine(DañoTempoP(daño));
    }
    

    if (p_health <= 0)
    {
        Debug.Log("Has muerto");
    }
  }


  public void HacerDañoEnemigo(int daño)
  {
    if (daño > 0)
    {
        AudioManager.Instance.Play(au_PerderVidaE);
        e_health = e_health - daño;
        numero_vidaE.text = e_health.ToString();
        StartCoroutine(DañoTempoE(daño));
    }

    

    if (e_health <= 0)
    {
        Debug.Log("Has ganado");
        SistemaDeTurnos.Instance.TerminarCombate();
    }
  }

  public void Set_VidaMaxEnemigo(float vidaMax)
  {
    e_maxHealth = vidaMax;
    e_health = vidaMax;
    numero_vidaE.text = e_health.ToString();
  }




  IEnumerator DañoTempoE(int daño)
  {
    com_ResultadoE.text = daño.ToString();
    yield return new WaitForSeconds(1.2f);
    com_ResultadoE.text = " ";
  }
  IEnumerator DañoTempoP(int daño)
  {
    com_ResultadoP.text = daño.ToString();
    yield return new WaitForSeconds(1.2f);
    com_ResultadoP.text = " ";
  }

}
