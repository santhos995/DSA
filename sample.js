var pin = 241294492511762325;
var ShardId  = (241294492511762325 >> 46) & 0xFFFF;
var TypeId  = (241294492511762325 >> 36) & 0x3FF ;
var LocalID = (241294492511762325 >>  0) & 0xFFFFFFFFF;

console.log(`pin - ${pin}`);
console.log(`ShardId - ${ShardId}`);
console.log(`TypeId - ${TypeId}`);
console.log(`LocalID - ${LocalID}`);
