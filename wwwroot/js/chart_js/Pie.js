"use strict";

$(document).ready(function () {

    console.log("Loading Pie.js for chart.js..."); // https://www.chartjs.org/docs/latest/charts/doughnut.html

    const ctx = document.getElementById('chartCanvas');

    const data = {
        labels: [
            'Red',
            'Blue',
            'Yellow',
            'Pink',
            'Orange'
        ],
        datasets: [{
            label: 'My First Dataset',
            data: [329, 211, 87, 103, 261],
            backgroundColor: [
                'rgb(255, 99, 132)',
                'rgb(54, 162, 235)',
                'rgb(255, 205, 86)',
                'rgb(100, 90, 72)',
                'rgb(180, 70, 16)'
            ],
            hoverOffset: 4
        }]
    };

    const config = {
        type: 'doughnut',
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