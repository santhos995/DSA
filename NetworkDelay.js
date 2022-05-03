/**
 * @param {number[][]} times
 * @param {number} n
 * @param {number} k
 * @return {number}
 */
var networkDelayTime = function (times, n, k) {
    let graph = {};

    times.forEach(edge => {
        let src = edge[0];
        let desc = edge[1];
        let time = edge[2];
        if (!(src in graph))
            graph[src] = [];
        graph[src].push(new Node(desc, time));

    });
for (const key in graph) {
    if (Object.hasOwnProperty.call(graph, key)) {
        const element = graph[key];
        element.sort(function(a,b){return a.time-b.time});
        
    }
}

    let dist = new Array(n+1).fill(Number.MAX_VALUE);
    let q = [];
    q.push(k);
    dist[0]=0;//we are using 1-index dist array
    dist[k] = 0;
    while (q.length > 0) {
        let node = q.shift();
        if (node in graph) {
            graph[node].forEach(child => {
                if ((dist[node] + child.time) < dist[child.desc]) {
                    dist[child.desc] = dist[node] + child.time;
                    q.push(child.desc);
                }
            })
        }
    }
    let res = dist.filter(val => val === Number.MAX_VALUE);
    return res.length > 0 ? -1 : Math.max(...dist);
};
class Node {
    constructor(desc, time) {
        this.desc = desc;
        this.time = time;
    }
}
 console.log(networkDelayTime([[2,1,2],[2,3,1],[3,4,1]],4,2));
// console.log(networkDelayTime([[1,2,1]],2,1));
// console.log(networkDelayTime([[1,2,1]],2,2));