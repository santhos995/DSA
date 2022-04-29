var isBipartite = function (graph) {
    var n = graph.length;
    var color = new Array(n);
    var q = [];
    for (var j = 0; j < n; j++) {
        if (color[j] !== undefined)
            continue;
        color[j] = "blue";
        q.push(j);
        while (q.length > 0) {
            var parent = q.shift();

            for (var i = 0; i < graph[parent].length; i++) {
                var child = graph[parent][i];
                if (color[child] === undefined) {
                    color[child] = (color[parent] === 'blue') ? 'white' : 'blue';
                    q.push(child);
                } else if (color[child] === color[parent])
                    return false;
            }
        }
    }
    return true;
}


console.log(isBipartite([[], [3], [], [1], []]));
console.log(isBipartite([[1, 2, 3], [0, 2], [0, 1, 3], [0, 2]]));
console.log(isBipartite([[1, 3], [0, 2], [1, 3], [0, 2]]));