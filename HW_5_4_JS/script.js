// Task1 
function createCounter() {
    let sum = 0;
    function summary(num) {
      sum += num
      return sum
    }
    return summary;
}
let counter = createCounter();


// Task2
function pushToArray() {
    let arr = [];
    function push (value) {
        if(value !== undefined){
            arr.push(value);
        }
        else if(value === undefined){
            arr = [];
        }
        return arr;
    }
    return push;
}
let getUpdatedArr = pushToArray();
