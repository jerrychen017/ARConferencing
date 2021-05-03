using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slideshow : MonoBehaviour
{
    public GameObject nextBtn;
    public GameObject prevBtn;
    public string[] mImg;
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        // mImg = new string[] { "Slide1", "Slide2", "Slide3" };
        mImg = new string[] { "future-work" };
    }

    public void next()
    {
        counter++;
        checkBtns();
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(mImg[counter]);
    }

    public void prev()
    {
        counter--;
        checkBtns();
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(mImg[counter]);
    }

    private void checkBtns()
    {
        if (counter < 1)
        {
            prevBtn.SetActive(false);
        }
        else
        {
            prevBtn.SetActive(true);
        }
        if (counter > mImg.Length - 2)
        {
            nextBtn.SetActive(false);
        }
        else 
        {
            nextBtn.SetActive(true);
        }
    }
}
