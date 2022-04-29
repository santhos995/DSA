/**
 * @param {string} s
 * @return {boolean}
 */
var validPalindrome = function (s) {
    if (s.length <= 2)
        return true;
    var l = 0, r = s.length - 1;
    while (l < r) {
        if (s[l] != s[r]) {
            return isPalindrome(s, l + 1, r) || isPalindrome(s, l, r - 1);
        }
        l++;
        r--;
    }
    return true;
};

//abcd - 2
//abcde - 2

var isPalindrome = function (s, l, r) {
    while (l < r) {
        if (s[l] != s[r]) {
            return false;
        }
        l++;
        r--;
    }
    return true;
}

console.log(validPalindrome("abc"));