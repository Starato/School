from itertools import zip_longest

def getAndFilterInput():
    string1 = input("1st word: ")
    string2 = input("2nd word: ")
    newString1 = ""
    newString2 = ""

    #filter out invalid characters
    for s1, s2 in zip_longest(string1, string2):
        if s1 is not None and s1.isalpha():
            newString1 += s1
        if s2 is not None and s2.isalpha():
            newString2 += s2

    #return 1 object rather than 2
    strings = []
    strings.append(newString1)
    strings.append(newString2)
    
    # print(strings)
    # print(newString1.lower()) 
    # print(newString2.lower())
    return strings

def checkAnagramAndPalindrome(strings):
    #filter string to lowercase
    s1Lower = strings[0].lower()
    s2Lower = strings[1].lower()
    status = {"string1": strings[0],
            "string2": strings[1],
            "isAnagram": False,
            "isPalindrome": False,
            "errorLog": ""}

    #Prelim
    if len(s1Lower) is not len(s2Lower):
        status["errorLog"] = "The 2 words given does not have the same length, cannont be an anagram or palindrome."
        return status
    #Anagram
    if sorted(s2Lower) == sorted(s1Lower):
        status["isAnagram"] = True
    #Palindrome
    if s1Lower[::-1] == s2Lower:
        status["isPalindrome"] = True

    return status    

def results(status):

    palindrome = status["isPalindrome"]
    anagram = status["isAnagram"]
    string1 = status["string1"]
    string2 = status["string2"]

    if palindrome is False and anagram is True:
        print(f"{string1} and {string2} are anagrams, but not palindromes")
    if palindrome is True and anagram is False :
        print(f"{string1} and {string2} are palindromes, but are not anagrams.")
    if palindrome is True and anagram is True:
        print(f"{string1} and {string2} are both palindromes and anagrams ")

def main():
    strings = getAndFilterInput()
    status = checkAnagramAndPalindrome(strings)
    results(status)

main()