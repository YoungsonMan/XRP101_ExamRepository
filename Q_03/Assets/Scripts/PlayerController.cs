using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed; // 테스트용움직임


    [field: SerializeField]
    [field: Range(0, 100)]
    public int Hp { get; private set; }

    private AudioSource _audio;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _audio = GetComponent<AudioSource>();
    }
    private void Update()
    {
        MovePosition();
    }


    // 마우스 잡고 왔다갔다 번거로우니 테스트용 이동함수 작성(2번문제 복붙)
    private void MovePosition()
    {
        Vector3 direction = Vector3.zero;
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.z = Input.GetAxisRaw("Vertical");

        if (direction == Vector3.zero) return;

        transform.Translate(_moveSpeed * Time.deltaTime * direction.normalized);
    }
    public void TakeHit(int damage)
    {
        Hp -= damage;

        if (Hp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        _audio.Play();
        gameObject.SetActive(false);
    }
}
