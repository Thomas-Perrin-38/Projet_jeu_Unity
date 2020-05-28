using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager instance;

    public static GameManager Instance { get { return instance; } }

    [SerializeField] private Transform playerPrefab;

    private Transform playerInstanciate;

    private Player playerScript;

    [SerializeField] private Transform SpawnPoint;

    [SerializeField] private GameObject particleSpawn;

    private void Awake() {
        if(instance != null) {
            Destroy(gameObject);
        }

        instance = this;
    }

    void Start () {
        InstanciatePlayer();
	}
	
    private void InstanciatePlayer() {
        playerInstanciate = Instantiate(playerPrefab, SpawnPoint.position, Quaternion.identity);

        playerScript = playerInstanciate.GetComponent<Player>();

        playerScript.MonEvent += PlayerScript_MonEvent;
    }

    private void PlayerScript_MonEvent() {

        Destroy(playerInstanciate.gameObject);
        StartCoroutine(RespawnPlayer());
    }


    private IEnumerator RespawnPlayer() {
        Debug.Log("3");

        yield return new WaitForSeconds(1);

        Debug.Log("2");

        yield return new WaitForSeconds(1);

        Debug.Log("1");

        yield return new WaitForSeconds(1);

        PlaySoundSpawn();

        InstanciatePlayer();

        SpawnParticle();
    }

    private void SpawnParticle() {
        var clone = Instantiate(particleSpawn, playerInstanciate.position, Quaternion.identity);
        Destroy(clone, 3f);
    }

    private void PlaySoundSpawn() {
        var audio = GetComponent<AudioSource>();
        audio.Play();
    }


}
