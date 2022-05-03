/**
 * @param {number} n
 * @param {number[][]} roads
 * @return {number}
 */
var countPaths = function (n, roads) {

    let map = {};
    let visited = new Array(n).fill(false);

    let graph = {};
    roads.forEach(road => {
        let src = road[0];
        let desc = road[1];
        let time = road[2];
        if (!(src in graph))
            graph[src] = [];
        graph[src].push(new Node(desc, time));

        if (!(desc in graph))
            graph[desc] = [];
        graph[desc].push(new Node(src, time));
    });


    for (const key in graph) {
        if (Object.hasOwnProperty.call(graph, key)) {
            const element = graph[key];
            element.sort(function(a,b){return a.time-b.time});
            
        }
    }

    //var min = Number.MAX_VALUE;
    var minObj = {};
    minObj["min"] = Number.MAX_VALUE;
    graph[0].forEach(node => {
        visited[0] = true;
        dfs(graph, map, n, visited, node.time, node.desc, minObj);
        visited[0] = false;
    });

    // Object.keys(map).forEach(val => {
    //     min = Math.min(min, val);
    // });


    return map[minObj["min"]];
};

var dfs = function (graph, map, n, visited, path, i, minObj) {
    if (i == n - 1) {
        minObj["min"] = Math.min(minObj["min"], path);
        if (!(path in map))
            map[path] = 0;
        map[path] = (map[path] + 1) % 1000000007;

    } else {
        visited[i] = true;
        
        graph[i].forEach(node => {
            if (!visited[node.desc] && (path + node.time < minObj["min"]))
                dfs(graph, map, n, visited, path + node.time, node.desc, minObj);
        })
        visited[i] = false;//backtrack
    }
}

class Node {
    constructor(desc, time) {
        this.desc = desc;
        this.time = time;
    }
}

// console.log(countPaths(7, [[0, 6, 7], [0, 1, 2], [1, 2, 3], [1, 3, 3], [6, 3, 3], [3, 5, 1], [6, 5, 1], [2, 5, 1], [0, 4, 5], [4, 6, 2]]));
//console.log(countPaths(18, [[0,1,3972],[2,1,1762],[3,1,4374],[0,3,8346],[3,2,2612],[4,0,6786],[5,4,1420],[2,6,7459],[1,6,9221],[6,3,4847],[5,6,4987],[7,0,14609],[7,1,10637],[2,7,8875],[7,6,1416],[7,5,6403],[7,3,6263],[4,7,7823],[5,8,10184],[8,1,14418],[8,4,11604],[7,8,3781],[8,2,12656],[8,0,18390],[5,9,15094],[7,9,8691],[9,6,10107],[9,1,19328],[9,4,16514],[9,2,17566],[9,0,23300],[8,9,4910],[9,3,14954],[4,10,26060],[2,10,27112],[10,1,28874],[8,10,14456],[3,10,24500],[5,10,24640],[10,6,19653],[10,0,32846],[10,9,9546],[10,7,18237],[11,7,21726],[11,2,30601],[4,11,29549],[11,0,36335],[10,11,3489],[6,11,23142],[3,11,27989],[11,1,32363],[11,8,17945],[9,11,13035],[5,11,28129],[2,12,33902],[5,12,31430],[6,12,26443],[4,12,32850],[12,3,31290],[11,12,3301],[12,1,35664],[7,13,28087],[13,8,24306],[6,13,29503],[11,13,6361],[4,13,35910],[13,12,3060],[3,13,34350],[13,5,34490],[13,2,36962],[10,13,9850],[9,13,19396],[12,14,8882],[8,14,30128],[14,6,35325],[14,5,40312],[1,14,44546],[11,14,12183],[15,12,13581],[2,15,47483],[4,15,46431],[15,10,20371],[15,14,4699],[15,6,40024],[15,7,38608],[1,15,49245],[11,15,16882],[8,15,34827],[0,15,53217],[5,15,45011],[15,3,44871],[16,2,53419],[16,9,35853],[1,16,55181],[16,7,44544],[8,16,40763],[0,16,59153],[15,16,5936],[16,10,26307],[16,6,45960],[12,16,19517],[17,2,57606],[17,3,54994],[17,14,14822],[17,11,27005],[0,17,63340],[17,7,48731],[8,17,44950],[17,16,4187],[5,17,55134],[17,10,30494],[17,9,40040],[17,12,23704],[13,17,20644],[17,1,59368]]));