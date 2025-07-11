using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    GameController gameController;
    public Transform respawnPoint;

    SpriteRenderer spriteRenderer;
    public Sprite passive, active;
    Collider2D coll;

    public void Awake(){
        gameController = GameObject.FindGameObjectWithTag("Player").GetComponent<GameController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>(); // ไม่ให้เกิดการเช็คพ้อยซํ้าซ็อน
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Player")){
            gameController.UpdateCheckpoint(respawnPoint.position);
            spriteRenderer.sprite = active;
            coll.enabled = false; // ไม่สารมารถโต้ตอบเช็คพ้อยกับผู้เล่นเป็นครั้งที่สอง
        }
    }

}
