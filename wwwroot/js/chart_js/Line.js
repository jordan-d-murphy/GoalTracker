"use strict";

$(document).ready(function () {

    console.log("Loading Line.js for chart.js..."); // https://www.chartjs.org/docs/latest/charts/line.html

    const ctx = document.getElementById('chartCanvas');

    const labels = ['Red', 'Blue', 'Yellow'];

    const data = {
        labels: labels,
        datasets: [{
            label: 'My First Dataset',
            data: [65, 59, 80, 81, 56, 55, 40, 12, 26, 32],
            fill: false,
            borderColor: 'rgb(75, 192, 192)',
            tension: 0.1
        },
        {
            label: 'My Second Dataset',
            data: [17, 91, 6, 12, 83, 51, 24, 19, 81, 52],
            fill: false,
            borderColor: 'rgb(25, 150, 160)',
            tension: 0.1
        },
        {
            label: 'My Third Dataset',
            data: [73, 70, 51, 27, 86, 79, 20, 66, 85, 91],
            fill: false,
            borderColor: 'rgb(50, 160, 130)',
            tension: 0.1
        }]
    };

    const config = {
        type: 'line',
        data: data,
    };

    console.log("Rendering Bar Chart!");
    new Chart(ctx, config);

});