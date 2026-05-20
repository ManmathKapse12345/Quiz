using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System;

public class CheckQuiz : MonoBehaviour
{
    public string actualAns;
    public string ansGiven;
    public TMP_Text childOptions;

    public TMP_Text option1;
    public TMP_Text option2;
    public TMP_Text option3;
    public TMP_Text option4;
    public TMP_Text result;

    public TMP_Text QuizResult;
    private int cnt;
    public int score;

    public List<string> questions = new List<string>{
        "A particle is projected vertically upward with velocity 20m/s.\nWhat is the maximum height reached?\n(Take g=10m/s<b><sup>2</sup></b>)",
        "Which molecule has a trigonal planar geometry?",
        "If\n f(x)=x<b><sup>3</b></sup> − 3x<b><sup>2</sup></b> + 2 \n then f′(x) is:",
        "The SI unit of electric resistance is:",
        "The value of \nsin<b><sup>2</sup></b>θ + cos<b><sup>2</sup></b>θ \n is:"
    };
    public List<List<string>> answers = new List<List<string>>()
    {
        new List<string>()
        {
            "1) 10m",
            "2) 20m",
            "3) 30m",
            "4) 40m"
        },
        new List<string>()
        {
            "1) NH<b><sup>3</sup></b>",
            "2) CH<b><sup>4</sup></b>",
            "3) BF<b><sup>3</sup></b>",
            "4) H<b><sup>2</sup></b>O"
        },
        new List<string>()
        {
            "1) 3x<b><sup>2</sup></b> − 6x",
            "2) x<b><sup>2</sup></b> − 6x",
            "3) 3x − 6",
            "4) 6x<b><sup>2</sup></b> − 3x"
        },
        new List<string>()
        {
            "1) Volt",
            "2) Ampere",
            "3) Ohm",
            "4) Coulomb"
        },
        new List<string>()
        {
            "1) 0",
            "2) 1",
            "3) 2",
            "4) sinθ"
        }
    };

    public List<string> correctAns = new List<string>(){
                                        "20m",
                                        "BF<b><sup>3</sup></b>",
                                        "3x<b><sup>2</sup></b> − 6x",
                                        "Ohm",
                                        "1"
                                    };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Quiz Started");
        transform.gameObject.SetActive(false);
        // result = transform.GetChild(4).GetComponent<TMP_Text>();
        cnt = 0;
        ShowQuestion(cnt);
        result.gameObject.SetActive(false);
        score = 0;
        QuizResult.gameObject.SetActive(false);
        // cnt = cnt + 1;


    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Quiz Updated");
        Debug.Log("Cnt :- " + cnt);

        if (cnt < 5)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                childOptions = option1;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                childOptions = option2;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                childOptions = option3;
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                childOptions = option4;
            }
        }
        else
        {
            Debug.Log("Quiz Completed");
            // QuizResult.text = "Quiz Completed\nYour Score is :- " + score + "/5";
            // QuizResult.gameObject.SetActive(true);
        }

    }

    public void ShowQuestion(int i)
    {
        if(i<5)
        {
            Debug.Log("Showing Question :- " + i);
            transform.GetComponent<TMP_Text>().text = questions[i];
            option1.text = answers[i][0];
            option2.text = answers[i][1];
            option3.text = answers[i][2];
            option4.text = answers[i][3];
            transform.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("Quiz Completed");
            QuizResult.text = "Quiz Completed\nYour Score is :- " + score + "/5";
            transform.gameObject.SetActive(false);
            QuizResult.gameObject.SetActive(true);
        }
        // childOptions = null;




    }

    public void CheckAns()
    {
        Debug.Log("Checking Answer");
        if (childOptions != null)
        {
            actualAns = correctAns[cnt];

            ansGiven = childOptions.text;
            if (actualAns != null)
            {
                Debug.Log(actualAns);
            }
            else
            {
                Debug.Log("actualAns is null");
            }
            if (ansGiven != null)
            {
                Debug.Log(ansGiven);
            }
            else
            {
                Debug.Log("ansGiven is null");
            }
            if (ansGiven[3..] == actualAns)
            {
                Debug.Log("You give Correct Answer :- " + ansGiven[3..]);
                result.text = "You had Given Correct Answer :- " + ansGiven[3..] + "\nCorrect Answer :- " + actualAns;
                score++;
            }
            else
            {
                Debug.Log("You give Wrong Answer :- " + ansGiven[3..]);
                result.text = "You had Give Wrong Answer :- " + ansGiven[3..] + "\nCorrect Answer :- " + actualAns;
            }
        }
        else
        {
            Debug.Log("childOptions is null");
        }
        result.gameObject.SetActive(true);
    }

    public void SubmitAns()
    {
        Debug.Log("Submitting Answer");
        if (cnt < 5)
        {
            cnt = cnt + 1;
            Debug.Log("In SubmitAns, Cnt :- " + cnt);
            ShowQuestion(cnt);
            result.gameObject.SetActive(false);
        }

    }
}

