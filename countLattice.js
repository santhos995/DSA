var countLatticePoints = function (circles) {
    var map = {};
    var dir = [[-1,1],[0,1],[1,1],[-1,0],[1,0],[-1,-1],[0,-1],[1,-1]];
    circles.forEach(c => {
        var center = getKey(c[0],c[1]);
        addIfNotExists(center);
        for (var r = 1; r <= c[2]; r++) {
            var c1 = c[0], c2 = c[1];
            dir.forEach(d => {
                var x = c1 + (r* d[0]), y = c2+ (r*d[1]);
                if(insideCircle(c1,c2,x,y,c[2])){
                    addIfNotExists(getKey(x,y));
                }
            });
        }
    });

    Object.keys(map).forEach(element => {
        console.log(element);
    });

    return Object.keys(map).length;

    function insideCircle(c1,c2,x,y,r){
        var res = Math.abs(c1-x) + Math.abs(c2-y);
        return res<=r;
    }
    function addIfNotExists(val) {
        if (!(val in map))
            map[val] = 1;
    }

    function getKey(x,y) {
        return `${x}-${y}`;
    }
};

console.log(countLatticePoints([[8,9,6],[9,8,4],[4,1,1],[8,5,1],[7,1,1],[6,7,5],[7,1,1],[7,1,1],[5,5,3]]));