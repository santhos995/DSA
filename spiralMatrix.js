//LC-54:https://leetcode.com/problems/spiral-matrix/
/**
 * @param {number[][]} matrix
 * @return {number[]}
 */
var spiralOrder = function (matrix) {
    let dir = [[0, 1], [1, 0], [0, -1], [-1, 0]];
    let res = [];
    let n = matrix.length;
    let visited = new Array(n);
    for (let i = 0; i < n; i++) {
        visited[i] = new Array(matrix[0].length).fill(false);
    }
    let i=0,j=0;
    let k = 0;//current direction
    res.push(matrix[i][j]);
    visited[i][j] = true;
    while(true){
        if(!curDirectionpossible(matrix, visited,i,j,dir[k])){
            //we need to change direction
            k = (k+1)%dir.length;
            if(!curDirectionpossible(matrix, visited,i,j,dir[k])){//all itenms printed, so exit
                break;
            }
        }
        i= i+dir[k][0];
        j = j+dir[k][1];
        //console.log(`${newI},${newJ}-${matrix[newI][newJ]}`);
        res.push(matrix[i][j]);
        visited[i][j] = true;
    }
    return res;
};
var curDirectionpossible = function(matrix, visited, i,j,dir){
    let newI = i+dir[0];
    let newJ = j+dir[1];
    if(newI<0 || newI>=matrix.length || newJ<0 || newJ>=matrix[0].length)
        return false;
    if(visited[newI][newJ])
        return false;
    
        return true;
}

console.log(spiralOrder([[1,2,3],[4,5,6],[7,8,9]]));
console.log(spiralOrder([[1,2,3,4],[5,6,7,8],[9,10,11,12]]));