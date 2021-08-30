
function getMaxCount(studentsCountByClass) {
    let max = 0;

    Object.keys(studentsCountByClass).forEach(classroom => {
        max = studentsCountByClass[classroom] > max ? studentsCountByClass[classroom] : max;
    });

    return max + (10 - (max % 10));
};

function drawSvg(studentsCountByClass) {
    d3.selectAll("svg").remove();

    // set the dimensions and margins of the graph
    const margin = { top: 30, right: 30, bottom: 30, left: 60 },
        width = 600 - margin.left - margin.right,
        height = 520 - margin.top - margin.bottom;

    // append the svg object
    const svg = d3.select("#studentsByBehaviorChart")
        .append("svg")
        .attr("width", width + margin.left + margin.right)
        .attr("height", height + margin.top + margin.bottom)
        .append("g")
        .attr("transform", "translate(" + margin.left + "," + margin.top + ")");

    // Add Y axis
    var y = d3.scaleLinear()
        .domain([0, getMaxCount(studentsCountByClass)])
        .rangeRound([height, 0]);
    svg.append("g").call(d3.axisLeft(y))
        .selectAll("text")
        .attr("transform", "translate(-12, 0)")
        .attr("font-size", "14px");


    // X axis
    var x = d3.scaleBand()
        .range([0, width])
        .domain(Object.keys(studentsCountByClass))
        .padding(0.5);
    svg.append("g")
        .attr("transform", "translate(0," + height + ")")
        .call(d3.axisBottom(x))
        .selectAll("text")
        .attr("font-size", "14px");

    // Bars
    svg.selectAll("mybar")
        .data(Object.keys(studentsCountByClass))
        .enter()
        .append("rect")
        .attr("x", function(b) { return x(b); })
        .attr("y", function (b) { return y(studentsCountByClass[b]); })
        .attr("width", x.bandwidth())
        .attr("height", function (b) { return height - y(studentsCountByClass[b]); })
        .attr("fill", "#3c96cf");
}

function updateChart() {
    $.get("/students/studentsByClass",
        data => {
            drawSvg(data);
        });
};

$(document).ready(function() { updateChart() });