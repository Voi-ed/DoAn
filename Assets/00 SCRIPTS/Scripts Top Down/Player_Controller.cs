using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;

using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer characterSR;
    Animator animator;
    

    [SerializeField] float dashBoost = 8f;
    private float dashTime;
    [SerializeField] float DashTime;
    private bool once;

    [SerializeField] Vector3 moveInput;
    
    [SerializeField] GameObject damPopUp;
    [SerializeField] LosePanel losePanel;
    [Header("Turn/On GameObject")]
    [SerializeField] GameObject particle;
    [SerializeField] GameObject Skill;
    [SerializeField] GameObject Gun;
    [SerializeField] Vector2 X, Y;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        // Movement
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        transform.position += moveSpeed * Time.deltaTime * moveInput;



        if (Input.GetKeyDown(KeyCode.Space) && dashTime <= 0)
        {
            GameObject tmp = ObjectPoolingX.instant.GetObject(particle);
            tmp.SetActive(true);
            tmp.transform.position = this.transform.position;
            tmp.transform.rotation = this.transform.rotation;
            tmp.transform.SetParent(this.transform);
            Gun.SetActive(false);
            Skill.SetActive(true);
            animator.SetBool("Skill", true);
            moveSpeed += dashBoost;
            dashTime = DashTime;
            once = true;
        }

        if (dashTime <= 0 && once)
        {
            Gun.SetActive(true);
            Skill.SetActive(false);
            animator.SetBool("Skill", false);
            moveSpeed -= dashBoost;
            once = false;
        }
        else
        {
            dashTime -= Time.deltaTime;
        }

        // Rotate Face
        if (moveInput.x != 0)
            if (moveInput.x < 0)
                characterSR.transform.localScale = new Vector3(-1, 1, 0);
            else
                characterSR.transform.localScale = new Vector3(1, 1, 0);
    }

    public void TakeDamageEffect(int damage)
    {
        if (damPopUp != null)
        {
            GameObject instance = Instantiate(damPopUp, transform.position
                    + new Vector3(UnityEngine.Random.Range(-0.3f, 0.3f), 0.5f, 0), Quaternion.identity);
            instance.GetComponentInChildren<TextMeshProUGUI>().text = damage.ToString();
            Animator animator = instance.GetComponentInChildren<Animator>();
            animator.Play("red");
        }
        if (GetComponent<Health>().isDead)
        {
            losePanel.Show();
        }
    }
}
