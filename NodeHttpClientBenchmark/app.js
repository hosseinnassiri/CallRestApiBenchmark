const fetch = require('node-fetch');

const Benchmark = require('benchmark');
const jsonReporter = require('benchmark-json-reporter');

const suite = new Benchmark.Suite('my-bench-suite');

const url = "https://jsonplaceholder.typicode.com/photos";

const get_data = async url => {
    console.time("time");
    try {
        const response = await fetch(url);
        const json = await response.json();
        console.log(json);
    } catch (error) {
        console.log(error);
    }
    console.timeEnd("time");
    const used = process.memoryUsage().heapUsed / 1024 / 1024;
    console.log(`The script uses approximately ${used} MB`);
};

get_data(url);

// jsonReporter(suite);

// suite.add('foo', {
//   fn: function () {
//     get_data(url);
//   }
// }).on('complete', function () {
//   console.log(this[0].stats)
// }).run({ 'async': true })
