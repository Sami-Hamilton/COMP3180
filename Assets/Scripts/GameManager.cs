using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject Panel1;
    [SerializeField] private GameObject Panel2;
    [SerializeField] private GameObject Panel3;
    [SerializeField] private GameObject Panel4;
    [SerializeField] private GameObject Panel5;
    [SerializeField] private GameObject Panel6;
    [SerializeField] private GameObject Panel7;
    [SerializeField] private GameObject Panel8;
    [SerializeField] private GameObject Furniture;
    [SerializeField] private GameObject BlackPanel;
    [SerializeField] private int TestVersion = 0;
    private int trial = 0;

    static private GameManager instance;
    static public GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.Log("No GameManager");
            }
            return instance;
        }
    }


    void Start()
    {
        if (TestVersion == 0) {
            Panel2.SetActive(true);
        } else {
            Panel1.SetActive(true);
        }
    }

    public void endTrial() {
        trial++;
        Furniture.SetActive(false);
        BlackPanel.SetActive(true);

        if (trial == 1) {
            if (TestVersion == 0) {
                Panel4.SetActive(true);
            } else {
                Panel3.SetActive(true);
            }
        }
        if (trial == 2) {
            if (TestVersion == 0) {
                Panel7.SetActive(true);
            } else {
                Panel8.SetActive(true);
            }
        }
        if (trial == 3) {
            if (TestVersion == 0) {
                Panel6.SetActive(true);
            } else {
                Panel5.SetActive(true);
            }
        }
        if (trial == 4) {
            if (TestVersion == 0) {
                Panel8.SetActive(true);
            } else {
                Panel7.SetActive(true);
            }
        }
        if (trial == 5) {
            if (TestVersion == 0) {
                Panel5.SetActive(true);
            } else {
                Panel6.SetActive(true);
            }
        }
        if (trial == 6) {
            if (TestVersion == 0) {
                Panel1.SetActive(true);
            } else {
                Panel2.SetActive(true);
            }
        }
        if (trial == 7) {
            if (TestVersion == 0) {
                Panel3.SetActive(true);
            } else {
                Panel4.SetActive(true);
            }
        }
    }
}