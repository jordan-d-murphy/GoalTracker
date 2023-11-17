"use strict";

$(document).ready(function () {

    console.log("Loading Polar.js for chart.js..."); // https://www.chartjs.org/docs/latest/charts/polar.html

    const ctx = document.getElementById('chartCanvas');

    const data = {
        labels: [
            'Red',
            'Green',
            'Yellow',
            'Grey',
            'Blue'
        ],
        datasets: [{
            label: 'My First Dataset',
            data: [18, 14, 11, 9, 22],
            backgroundColor: [
                'rgb(255, 99, 132)',
                'rgb(75, 192, 192)',
                'rgb(255, 205, 86)',
                'rgb(201, 203, 207)',
                'rgb(54, 162, 235)'
            ]
        }]
    };

    const config = {
        type: 'polarArea',
        data: data,
        options: {
            plugins: {
                legend: {
                    position: "right",
                    align: "start"
                }
            }
        }
    };

    console.log("Rendering Bar Chart!");
    new Chart(ctx, config);

});