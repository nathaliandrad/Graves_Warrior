using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Variables")]
    float pMaxHealth;
    float pHealth;
    int countText;
    int levelNum;
    bool ePressed;
    bool specialAttackOn;
    float hori, verti, mHori, rotateSpeed;
    Vector3 movement;
    Rigidbody rigi;
    public float speed;
    public GameObject playerFlashObj;

    [Header("Animators")]
    Animator anim;
    public Animator levelUpAnimator;
    public Animator specialAttackAnimText;
    public Animator upgradeArmorAnimator;
    public Animator healthAnimation;
    Transform lookAtCube;
    float lookAtCubeSpeed;
   // public GameObject sword;

    [Header("UI")]
    public Image playerManaBar;
    public Image playerHealthBarImg;
    public Slider playerLevelBar;
    public Text specialAttackText;
    public Text levelNumText;
    public Text levelUpText;
    public Text upgradeArmorText;
    public Text healthText;


    [Header("Sounds")]
    AudioSource speaker;
    public AudioClip levelUpSound;

    [Header("GameObjs")]
    public GameObject swordFx3;
    public GameObject swordFx2;
    public GameObject swordFx;
    public GameObject redArmor;
    public GameObject yellowArmor;
    public GameObject blueArmor;

    //int jumpCounts;
    //int maxJump;

    void Start()
    {
        //maxJump = 1;
       // jumpCounts = maxJump;
        //jumpCounts = maxJump;
        pMaxHealth = 1;
        pHealth = pMaxHealth;
        speaker = GetComponent<AudioSource>();
        levelNum = 1;
        levelNumText.text = levelNum.ToString();
        ePressed = false;
        countText = 0;
        specialAttackOn = false;
        lookAtCubeSpeed = 2;
        playerManaBar.fillAmount = 0;
        playerLevelBar.value = 0;
        playerHealthBarImg.fillAmount = 1;
        rigi = GetComponent<Rigidbody>();
        rotateSpeed = 3;
        anim = transform.Find("GloryArmor_01").GetComponent<Animator>();
        lookAtCube = transform.Find("LookAtCube");
        Cursor.lockState = CursorLockMode.Locked;
       // StartCoroutine("SpecialAttackText");
    }

   public void SpecialAttackText()
    {
        
            specialAttackText.text = "Hold E for Special Attack";
            specialAttackAnimText.Play("SpecialAttack_Anim", 0, 0);
        countText += 1;
      //  yield return null;
    }

    void Update()
    {
        hori  = Input.GetAxis("Horizontal");
        verti = Input.GetAxis("Vertical");
        mHori = Input.GetAxis("Mouse X");

        transform.Rotate(new Vector3(0, mHori * rotateSpeed, 0));

        movement.z = verti * speed;
        movement.x = hori * speed;
        movement.y = rigi.velocity.y;
        movement = transform.TransformDirection(movement);

        rigi.velocity = movement;
        anim.SetFloat("runSpeed", rigi.velocity.magnitude);


        lookAtCube.localPosition = new Vector3(hori * lookAtCubeSpeed, -1, verti * lookAtCubeSpeed);

        anim.transform.LookAt(lookAtCube);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (specialAttackOn)
            {
                anim.SetBool("specialAttack2", true);
                playerManaBar.fillAmount = 0;
                countText = 0;
                


            }
            ePressed = true;
            specialAttackOn = false;

        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            anim.SetBool("specialAttack2", false);
        }
        if (Input.GetMouseButtonDown(0))
        {

            anim.SetInteger("attack", Random.Range(1, 6));
        }
        if (Input.GetMouseButtonUp(0))
        {
            anim.SetInteger("attack", 0);
        }

        if (Input.GetMouseButtonDown(1))
        {
            anim.SetBool("LeapAttack", true);
        }
        if (Input.GetMouseButtonUp(1))
        {
            anim.SetBool("LeapAttack", false);
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    print("Jump:" + jumpCounts);
            
        //    if (jumpCounts > 0)
        //    {
        //        rigi.AddRelativeForce(new Vector3(0, 200, 0));
        //        jumpCounts-=1;
        //    }
          
        //}
    }

    //public void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Enviroment"))
    //    {
    //        jumpCounts =maxJump;
    //    }
    //}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            playerManaBar.fillAmount += 0.3f;

            if (ePressed)
            {
                ePressed = false;
                other.SendMessage("HitEnemySpecial");
                
            }
            else
            {
                other.SendMessage("HitEnemy");
            }
           
            if (playerManaBar.fillAmount == 1)
            {
                countText += 1;
                if (countText == 1)
                {
                    SpecialAttackText();
                }
               
                specialAttackOn = true;
            }
        }
    }
    
    public void SetPlayerLevel()
    {
        playerLevelBar.value += 0.05f;
        if (playerLevelBar.value == 1)
        {
            levelNum++;
            levelNumText.text = levelNum.ToString();
            LevelUpAnim();
            playerLevelBar.value = 0;

            if (levelNum == 2)
            {
                StartCoroutine("UpgradeTextSword");
                swordFx3.SetActive(false);
                swordFx2.SetActive(true);
            }
            if (levelNum == 4)
            {
                StartCoroutine("UpgradeTextArmor");
                redArmor.SetActive(false);
                yellowArmor.SetActive(true);
            }
            if (levelNum == 6)
            {
                StartCoroutine("UpgradeTextSword");
                swordFx2.SetActive(false);
                swordFx.SetActive(true);
            }
            if (levelNum == 7)
            {
                StartCoroutine("UpgradeTextArmor");
                yellowArmor.SetActive(false);
                blueArmor.SetActive(true);

            }
           
        }
    }

    public void LevelUpAnim()
    {
        levelUpText.text = "LEVEL UP";
        levelUpAnimator.Play("LevelUP_Anim", 0, 0);
        speaker.PlayOneShot(levelUpSound);
    }

    public IEnumerator UpgradeTextArmor()
    {
        yield return new WaitForSeconds(1.5f);
        upgradeArmorText.text = "Armor Upgrade";
        upgradeArmorAnimator.Play("UpgradeTextAnim", 0, 0);
    }
    public IEnumerator UpgradeTextSword()
    {
        yield return new WaitForSeconds(1.5f);
        upgradeArmorText.text = "Sword Upgrade";
        upgradeArmorAnimator.Play("UpgradeTextAnim", 0, 0);
    }

    //weaker enemy damage
    public void PlayerDamageWeaker()
    {
        float damage = Random.Range(0.005f, 0.02f);
        pHealth -= damage;

        playerHealthBarImg.fillAmount = pHealth;
        playerFlashObj.SendMessage("FlashWhite");
        GenerateRandomHitAnim();

        if (pHealth < 0)
        {
            anim.SetBool("playerDeath", true);
            StartCoroutine("GameOverCanvas");
        }
    }

    //medium enemy damage
    public void PlayerDamageFatty()
    {
        float damage = Random.Range(0.02f, 0.05f);
        pHealth -= damage;

        playerHealthBarImg.fillAmount = pHealth;
        playerFlashObj.SendMessage("FlashWhite");
        GenerateRandomHitAnim();

        if (pHealth < 0)
        {
            anim.SetBool("playerDeath", true);
            StartCoroutine("GameOverCanvas");
        }
    }
    //stronger enemy damage
    public void PlayerDamage()
    {
        float damage = Random.Range(0.05f,0.08f);
        pHealth -= damage;

        playerHealthBarImg.fillAmount = pHealth;
        playerFlashObj.SendMessage("FlashWhite");

        GenerateRandomHitAnim();
        if (pHealth < 0)
        {
            anim.SetBool("playerDeath", true);
            StartCoroutine("GameOverCanvas");
        }

    }

    public void DamagePlayerFromBoss()
    {
        float damage = Random.Range(0.1f, 0.13f);
        pHealth -= damage;

        playerHealthBarImg.fillAmount = pHealth;
        playerFlashObj.SendMessage("FlashWhite");

        GenerateRandomHitAnim();
        if (pHealth < 0)
        {
            anim.SetBool("playerDeath", true);
            StartCoroutine("GameOverCanvas");
        }
        //PlayerDead();

    }
    //boss
    //public void PlayerDamageBoss()
    //{
    //    float damage = Random.Range(0.1f, 0.13f);
    //    pHealth -= damage;

    //    playerHealthBarImg.fillAmount = pHealth;
    //    playerFlashObj.SendMessage("FlashWhite");

    //    GenerateRandomHitAnim();
    //    if (pHealth < 0)
    //    {
    //        anim.SetBool("playerDeath", true);
    //        StartCoroutine("GameOverCanvas");
    //    }
    //    //PlayerDead();

    //}
    public GameObject gameOverCanvas;


    public IEnumerator GameOverCanvas()
    {
        yield return new WaitForSeconds(3f);
        gameOverCanvas.SetActive(true);
        yield return new WaitForSeconds(2f);
        gameOverCanvas.SetActive(false);
        SceneManager.LoadScene(0);

    }

    public void GenerateRandomHitAnim()
    {
        int randomHit = Random.Range(0, 2);
        if (randomHit == 0)
        {
            anim.SetTrigger("playerHit1");
        }
        else
        {
            anim.SetTrigger("playerHit2");
        }
    }

    public void AddPlayerHealth()
    {
        print("current player health: " + pHealth);
        if (pHealth < pMaxHealth)
        {
            DisplayAddedHealth();
            float healthPoints = Random.Range(0.05f, 0.15f);
            playerHealthBarImg.fillAmount += healthPoints;
        }
        

    }

    public void DisplayAddedHealth()
    {
        healthText.text = "+Health";
        healthAnimation.Play("HealthAnimator", 0, 0);
    }
    


}
