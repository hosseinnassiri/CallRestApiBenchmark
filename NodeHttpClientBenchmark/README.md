# CallRestApiBenchmark
To run a benchmark for calling REST Api from NodeJS.
Dataset is from free JSONPlaceholder:
https://jsonplaceholder.typicode.com/photos

## Scenario
* Read REST Api json response as a json

## Prerequisites
[Node JS](https://nodejs.org/dist/v12.16.3/node-v12.16.3-x64.msi)

## How to run:
```
node .\app.js
```

## Results
* time: 573.523ms
* memory consumption 10.636756896972656 MB

## Plans
Try to use [benchmark library](https://www.npmjs.com/package/benchmark)