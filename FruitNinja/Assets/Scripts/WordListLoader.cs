using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class WordListLoader : MonoBehaviour
{
    public List<string> words;
    public List<string> subWords;
    public List<string> findedWords;
    [SerializeField] private string path;
    void Start()
    {
        path = "D:\\Projects\\Improving_Projects\\FruitNinja\\Assets\\Resource\\wordList.txt";
        string filePath = Path.Combine(Application.streamingAssetsPath, path);

        if (File.Exists(filePath))
        {
            words = new List<string>();
            string[] columns = File.ReadAllLines(filePath);

            foreach (string column in columns)
            {
                string[] columnWords = column.Trim().Split(' ');
                
                foreach (string words in columnWords)
                {
                    this.words.Add(words.ToUpper());
                }
            }
        }
        else
        {
            Debug.LogError("File doesn't exist: " + filePath);
        }

        Quicksort(words, 0, words.Count- 1);
    }

    private void Quicksort(List<string> list, int start, int end)
    {
        if (start < end)
        {
            // Partition the list and get the pivot index
            int pivotIndex = Partition(list, start, end);

            // Sort the divided lists based on the pivot index
            Quicksort(list, start, pivotIndex - 1);
            Quicksort(list, pivotIndex + 1, end);
        }
    }

     private int Partition(List<string> list, int start, int end)
    {
        string pivot = list[end];
        int i = start - 1;

        for (int j = start; j < end; j++)
        {
            if (String.Compare(list[j], pivot) < 0)
            {
                i++;
                string temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }

        string temp1 = list[i + 1];
        list[i + 1] = list[end];
        list[end] = temp1;

        return i + 1;
    }

    public bool BinarySearch(List<string> list, string target)
    {
        int left = 0;
        int right = list.Count - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int comparison = string.Compare(list[mid], target);

            if (comparison < 0)
            {
                left = mid + 1;
            }
            else if (comparison > 0)
            {
                right = mid - 1;
            }
            else
            {
                return true;
            }
        }

        return false;
    }

    public int GetPositionOfSentence(string target)
    {
        int left = 0;
        int right = words.Count - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int comparison = string.Compare(words[mid], target);

            if (comparison < 0)
            {
                left = mid + 1;
            }
            else if (comparison > 0)
            {
                right = mid - 1;
            }
            else
            {
                return mid;
            }
        }

        return -1;
        
    }

    public List<string> GetAllSubstrings(string str)
    {
        // aynı kelimeyi denerse başarısız olsun.
        subWords.Clear();

        for (int i = 0; i < str.Length; i++)
        {
            for (int j = i + 1; j <= str.Length; j++)
            {
                subWords.Add(str.Substring(i, j - i));
            }
        }

        return subWords;
    }

    public void AddFindedWord(string sentence)
    {
        findedWords.Add(sentence);
        Quicksort(findedWords,0, findedWords.Count - 1);
    }

    public void RemoveAtSentence(string sentence)
    {
        words.RemoveAt(GetPositionOfSentence(sentence));
    }
}
