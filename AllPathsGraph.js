/**
 * @param {number[][]} graph
 * @return {number[][]}
 */
var allPathsSourceTarget = function (graph) {
    //we will do DFS, if we are able to reach n-1 then store this path.

    let res = [];
    dfs(graph, res, [], 0);
    return res;
};

var dfs = function (graph, res, path, i) {
    path.push(i)
    if (i === graph.length - 1) {
        res.push([...path]);
    } else {

        for (let j = 0; j < graph[i].length; j++) {
            dfs(graph, res, path, graph[i][j]);
        }
    }
    path.pop();
}


//console.log(allPathsSourceTarget([[1,2],[3],[3],[]]));
//console.log(allPathsSourceTarget([[4,3,1],[3,2,4],[3],[4],[]]));