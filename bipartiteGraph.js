var isBipartiteBFS = function (graph) {
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

var isBipartiteDFS = function (graph) {
    var n = graph.length;
    let color = new Array(n).fill(0);
    for (let i = 0; i < graph.length; i++) {
        
        if(color[i]==0 && !validColor(graph, color,1,i)){
            return false;
        }
        
    }
    return true;
}
var validColor = function(graph, colors, color, idx){
    if(colors[idx]!=0)
        return (colors[idx]==color);
    
    colors[idx] = color;
    for(var i=0;i<graph[idx].length;i++){
        if(!validColor(graph, colors,-color,graph[idx][i]))
            return false;
    }
    return true;
}

console.log(isBipartiteBFS([[], [3], [], [1], []]));
console.log(isBipartiteBFS([[1, 2, 3], [0, 2], [0, 1, 3], [0, 2]]));
console.log(isBipartiteBFS([[1, 3], [0, 2], [1, 3], [0, 2]]));
console.log(isBipartiteDFS([[], [3], [], [1], []]));
console.log(isBipartiteDFS([[1, 2, 3], [0, 2], [0, 1, 3], [0, 2]]));
console.log(isBipartiteDFS([[1, 3], [0, 2], [1, 3], [0, 2]]));