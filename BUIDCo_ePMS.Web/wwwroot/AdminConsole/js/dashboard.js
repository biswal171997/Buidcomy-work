$(document).ready(function(){
  $('[data-toggle="popover"]').popover({
    html: true
  });   





// Themes begin
am4core.useTheme(am4themes_animated);
// Themes end

// Create chart
var chart = am4core.create("actionTrend", am4charts.XYChart);
chart.padding(0, 15, 0, 15);
chart.colors.step = 3;

// the following line makes value axes to be arranged vertically.
chart.leftAxesContainer.layout = "vertical";

// uncomment this line if you want to change order of axes
//chart.bottomAxesContainer.reverseOrder = true;

var dateAxis = chart.xAxes.push(new am4charts.DateAxis());
dateAxis.renderer.grid.template.location = 0;
dateAxis.renderer.ticks.template.length = 8;
dateAxis.renderer.ticks.template.strokeOpacity = 0.1;
dateAxis.renderer.grid.template.disabled = true;
dateAxis.renderer.ticks.template.disabled = false;
dateAxis.renderer.ticks.template.strokeOpacity = 0.2;
dateAxis.renderer.minLabelPosition = 0.01;
dateAxis.renderer.maxLabelPosition = 0.99;
dateAxis.minHeight = 30;

dateAxis.groupData = true;
dateAxis.minZoomCount = 5;

// these two lines makes the axis to be initially zoomed-in
// dateAxis.start = 0.7;
// dateAxis.keepSelection = true;

var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
valueAxis.tooltip.disabled = true;
valueAxis.zIndex = 1;
valueAxis.renderer.baseGrid.disabled = true;
// height of axis
valueAxis.height = am4core.percent(65);

valueAxis.renderer.gridContainer.background.fill = am4core.color("#ccc");
valueAxis.renderer.gridContainer.background.fillOpacity = 0.05;
valueAxis.renderer.inside = true;
valueAxis.renderer.labels.template.verticalCenter = "bottom";
valueAxis.renderer.labels.template.padding(2, 2, 2, 2);

//valueAxis.renderer.maxLabelPosition = 0.95;
valueAxis.renderer.fontSize = "0.8em"

var series1 = chart.series.push(new am4charts.LineSeries());
series1.defaultState.transitionDuration = 0;
series1.dataFields.dateX = "Date";
series1.dataFields.valueY = "Adj Close";
series1.dataFields.valueYShow = "changePercent";
series1.tooltipText = "{name}: {valueY.changePercent.formatNumber('[#0c0]+#.00|[#c00]#.##|0')}%";
series1.name = "Actions";
series1.tooltip.getFillFromObject = false;
series1.tooltip.getStrokeFromObject = true;
series1.tooltip.background.fill = am4core.color("#fff");
series1.tooltip.background.strokeWidth = 2;
series1.tooltip.label.fill = series1.stroke;

series1.dataSource.url = "https://www.amcharts.com/wp-content/uploads/assets/stock/MSFT.csv";
series1.dataSource.parser = new am4core.CSVParser();
series1.dataSource.parser.options.useColumnNames = true;
series1.dataSource.parser.options.reverse = true;

var series2 = chart.series.push(new am4charts.LineSeries());
series2.dataFields.dateX = "Date";
series2.dataFields.valueY = "Adj Close";
series2.dataFields.valueYShow = "changePercent";
series2.tooltipText = "{name}: {valueY.changePercent.formatNumber('[#0c0]+#.00|[#c00]#.##|0')}%";
series2.name = "Action Taken";
series2.tooltip.getFillFromObject = false;
series2.tooltip.getStrokeFromObject = true;
series2.tooltip.background.fill = am4core.color("#fff");
series2.tooltip.background.strokeWidth = 2;
series2.tooltip.label.fill = series2.stroke;

series2.dataSource.url = "https://www.amcharts.com/wp-content/uploads/assets/stock/TXN.csv";
series2.dataSource.parser = new am4core.CSVParser();
series2.dataSource.parser.options.useColumnNames = true;
series2.dataSource.parser.options.reverse = true;

var valueAxis2 = chart.yAxes.push(new am4charts.ValueAxis());
valueAxis2.tooltip.disabled = true;
// height of axis
valueAxis2.height = am4core.percent(35);
valueAxis2.zIndex = 3
// this makes gap between panels
valueAxis2.marginTop = 30;
valueAxis2.renderer.baseGrid.disabled = true;
valueAxis2.renderer.inside = true;
valueAxis2.renderer.labels.template.verticalCenter = "bottom";
valueAxis2.renderer.labels.template.padding(2, 2, 2, 2);
//valueAxis.renderer.maxLabelPosition = 0.95;
valueAxis2.renderer.fontSize = "0.8em";

valueAxis2.renderer.gridContainer.background.fill = am4core.color("#000000");
valueAxis2.renderer.gridContainer.background.fillOpacity = 0.05;

var volumeSeries = chart.series.push(new am4charts.ColumnSeries());
volumeSeries.defaultState.transitionDuration = 0
volumeSeries.fill = series1.stroke;
volumeSeries.stroke = series1.stroke;
volumeSeries.dataFields.dateX = "Date";
volumeSeries.dataFields.valueY = "Volume";
volumeSeries.yAxis = valueAxis2;
volumeSeries.tooltipText = "{name} Volume: {valueY.value}";
volumeSeries.name = "Actions";
// volume should be summed
volumeSeries.groupFields.valueY = "sum";
volumeSeries.tooltip.label.fill = volumeSeries.stroke;

volumeSeries.dataSource.url = "https://www.amcharts.com/wp-content/uploads/assets/stock/MSFT.csv";
volumeSeries.dataSource.parser = new am4core.CSVParser();
volumeSeries.dataSource.parser.options.useColumnNames = true;
volumeSeries.dataSource.parser.options.reverse = true;

// Cursor
chart.cursor = new am4charts.XYCursor();

// Scrollbar
var scrollbarX = new am4charts.XYChartScrollbar();
scrollbarX.series.push(series1);
scrollbarX.marginBottom = 20;
chart.scrollbarX = scrollbarX;
scrollbarX.scrollbarChart.xAxes.getIndex(0).minHeight = undefined;


/**
 * Set up external controls
 */

// Date format to be used in input fields
var inputFieldFormat = "yyyy-MM-dd";

document.getElementById("b1m").addEventListener("click", function() {
  resetButtonClass();
  var max = dateAxis.groupMax["day1"];
  var date = new Date(max);
  date.setMonth(date.getMonth() - 1);

  dateAxis.zoomToDates(
    date,
    new Date(max)
  );
  //this.className = "amcharts-input amcharts-input-selected";
});

document.getElementById("b3m").addEventListener("click", function() {
  resetButtonClass();
  var max = dateAxis.groupMax["day1"];
  var date = new Date(max);
  date.setMonth(date.getMonth() - 3);

  dateAxis.zoomToDates(
    date,
    new Date(max)
  );
  //this.className = "amcharts-input amcharts-input-selected";
});

document.getElementById("b6m").addEventListener("click", function() {
  resetButtonClass();
  var max = dateAxis.groupMax["day1"];
  var date = new Date(max);
  date.setMonth(date.getMonth() - 6);

  dateAxis.zoomToDates(
    date,
    new Date(max)
  );
  //this.className = "amcharts-input amcharts-input-selected";
});

document.getElementById("b1y").addEventListener("click", function() {
  resetButtonClass();
  var max = dateAxis.groupMax["week1"];
  var date = new Date(max);
  date.setFullYear(date.getFullYear() - 1);

  dateAxis.zoomToDates(
    date,
    new Date(max)
  );
  //this.className = "amcharts-input amcharts-input-selected";
});

document.getElementById("bytd").addEventListener("click", function() {
  resetButtonClass();
  var date = new Date(dateAxis.max);
  date.setMonth(0, 1);
  date.setHours(0, 0, 0, 0);
  dateAxis.zoomToDates(date, new Date(dateAxis.max));
  //this.className = "amcharts-input amcharts-input-selected";
});

document.getElementById("bmax").addEventListener("click", function() {
  resetButtonClass();
  dateAxis.zoom({start:0, end:1});
  //this.className = "amcharts-input amcharts-input-selected";
});

function resetButtonClass() {
  var selected = document.getElementsByClassName("amcharts-input-selected");
  for(var i = 0; i < selected.length; i++) {
    selected[i].className = "amcharts-input";
  }
}





// Active Departments Pie Chart

// Create chart instance
var chart = am4core.create("activeDept", am4charts.PieChart);

// Add data
chart.data = [
  { "sector": "Active Departments", "size": 8 },
  { "sector": "Inactive Departments", "size": 2 },
];

// Add label
chart.innerRadius = 85;
var label = chart.seriesContainer.createChild(am4core.Label);
label.text = "80%";
label.horizontalCenter = "middle";
label.verticalCenter = "middle";
label.fontSize = 50;

// Add and configure Series
var pieSeries = chart.series.push(new am4charts.PieSeries());
pieSeries.dataFields.value = "size";
pieSeries.dataFields.category = "sector";




// Closure Rate Pie Chart

// Create chart instance
var chart = am4core.create("closureRate", am4charts.PieChart);

// Add data
chart.data = [
  { "sector": "Closed", "size": 3 },
  { "sector": "Open", "size": 7 },
];

// Add label
chart.innerRadius = 85;
var label = chart.seriesContainer.createChild(am4core.Label);
label.text = "30%";
label.horizontalCenter = "middle";
label.verticalCenter = "middle";
label.fontSize = 50;

// Add and configure Series
var pieSeries = chart.series.push(new am4charts.PieSeries());
pieSeries.dataFields.value = "size";
pieSeries.dataFields.category = "sector";




});




$(function() {

  $(".progress").each(function() {

    var value = $(this).attr('data-value');
    var left = $(this).find('.progress-left .progress-bar');
    var right = $(this).find('.progress-right .progress-bar');

    if (value > 0) {
      if (value <= 50) {
        right.css('transform', 'rotate(' + percentageToDegrees(value) + 'deg)')
      } else {
        right.css('transform', 'rotate(180deg)')
        left.css('transform', 'rotate(' + percentageToDegrees(value - 50) + 'deg)')
      }
    }

  })

  function percentageToDegrees(percentage) {

    return percentage / 100 * 360

  }
});




//  Highcharts.chart('linegrap', {

//     title: {
//         text: ''
//     },

//     xAxis: {
//         tickInterval: 1,
//         type: 'logarithmic'
//     },

//     yAxis: {
//         type: 'logarithmic',
//         minorTickInterval: 0.1,
//     },

//     tooltip: {
//         headerFormat: '<b>{series.name}</b><br />',
//         pointFormat: 'x = {point.x}, y = {point.y}'
//     },

//     series: [{
//         name:"Planned",
//         data: [1, 2, 4, 8, 16, 32, 64, 128, 256, 512],
//         pointStart: 0.1
//     },
//     {
//       name:"Completed",
//       data: [0.5, 1, 1.5, 2, 2.3, 3, 3.2, 3.4, 10, 80],
//       pointStart: 0.1
//   }]
// });



 Highcharts.chart('linegrap2', {

    title: {
        text: ''
    },

    subtitle: {
        text: ''
    },

    yAxis: {
        title: {
            text: ''
        }
    },
    legend: {
        layout: 'vertical',
        align: 'right',
        verticalAlign: 'middle'
    },

    plotOptions: {
        series: {
            label: {
                connectorAllowed: false
            },
            pointStart: 2010
        }
    },

     series: [
    {
        name: 'Planned',
        data: [43934, 52503, 57177, 69658, 97031, 119931, 137133, 154175]
    }, {
        name: 'completed',
        data: [5948, 12105, 15248, 30989, 40816, 45274, 55511,73023]
    }],

    responsive: {
        rules: [{
            condition: {
                maxWidth: 500
            },
            chartOptions: {
                legend: {
                    layout: 'horizontal',
                    align: 'center',
                    verticalAlign: 'bottom'
                }
            }
        }]
    }

});