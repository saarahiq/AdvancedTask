/*
   Licensed to the Apache Software Foundation (ASF) under one or more
   contributor license agreements.  See the NOTICE file distributed with
   this work for additional information regarding copyright ownership.
   The ASF licenses this file to You under the Apache License, Version 2.0
   (the "License"); you may not use this file except in compliance with
   the License.  You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/
var showControllersOnly = false;
var seriesFilter = "";
var filtersOnlySampleSeries = true;

/*
 * Add header in statistics table to group metrics by category
 * format
 *
 */
function summaryTableHeader(header) {
    var newRow = header.insertRow(-1);
    newRow.className = "tablesorter-no-sort";
    var cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 1;
    cell.innerHTML = "Requests";
    newRow.appendChild(cell);

    cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 3;
    cell.innerHTML = "Executions";
    newRow.appendChild(cell);

    cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 7;
    cell.innerHTML = "Response Times (ms)";
    newRow.appendChild(cell);

    cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 1;
    cell.innerHTML = "Throughput";
    newRow.appendChild(cell);

    cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 2;
    cell.innerHTML = "Network (KB/sec)";
    newRow.appendChild(cell);
}

/*
 * Populates the table identified by id parameter with the specified data and
 * format
 *
 */
function createTable(table, info, formatter, defaultSorts, seriesIndex, headerCreator) {
    var tableRef = table[0];

    // Create header and populate it with data.titles array
    var header = tableRef.createTHead();

    // Call callback is available
    if(headerCreator) {
        headerCreator(header);
    }

    var newRow = header.insertRow(-1);
    for (var index = 0; index < info.titles.length; index++) {
        var cell = document.createElement('th');
        cell.innerHTML = info.titles[index];
        newRow.appendChild(cell);
    }

    var tBody;

    // Create overall body if defined
    if(info.overall){
        tBody = document.createElement('tbody');
        tBody.className = "tablesorter-no-sort";
        tableRef.appendChild(tBody);
        var newRow = tBody.insertRow(-1);
        var data = info.overall.data;
        for(var index=0;index < data.length; index++){
            var cell = newRow.insertCell(-1);
            cell.innerHTML = formatter ? formatter(index, data[index]): data[index];
        }
    }

    // Create regular body
    tBody = document.createElement('tbody');
    tableRef.appendChild(tBody);

    var regexp;
    if(seriesFilter) {
        regexp = new RegExp(seriesFilter, 'i');
    }
    // Populate body with data.items array
    for(var index=0; index < info.items.length; index++){
        var item = info.items[index];
        if((!regexp || filtersOnlySampleSeries && !info.supportsControllersDiscrimination || regexp.test(item.data[seriesIndex]))
                &&
                (!showControllersOnly || !info.supportsControllersDiscrimination || item.isController)){
            if(item.data.length > 0) {
                var newRow = tBody.insertRow(-1);
                for(var col=0; col < item.data.length; col++){
                    var cell = newRow.insertCell(-1);
                    cell.innerHTML = formatter ? formatter(col, item.data[col]) : item.data[col];
                }
            }
        }
    }

    // Add support of columns sort
    table.tablesorter({sortList : defaultSorts});
}

$(document).ready(function() {

    // Customize table sorter default options
    $.extend( $.tablesorter.defaults, {
        theme: 'blue',
        cssInfoBlock: "tablesorter-no-sort",
        widthFixed: true,
        widgets: ['zebra']
    });

    var data = {"OkPercent": 99.76666666666667, "KoPercent": 0.23333333333333334};
    var dataset = [
        {
            "label" : "FAIL",
            "data" : data.KoPercent,
            "color" : "#FF6347"
        },
        {
            "label" : "PASS",
            "data" : data.OkPercent,
            "color" : "#9ACD32"
        }];
    $.plot($("#flot-requests-summary"), dataset, {
        series : {
            pie : {
                show : true,
                radius : 1,
                label : {
                    show : true,
                    radius : 3 / 4,
                    formatter : function(label, series) {
                        return '<div style="font-size:8pt;text-align:center;padding:2px;color:white;">'
                            + label
                            + '<br/>'
                            + Math.round10(series.percent, -2)
                            + '%</div>';
                    },
                    background : {
                        opacity : 0.5,
                        color : '#000'
                    }
                }
            }
        },
        legend : {
            show : true
        }
    });

    // Creates APDEX table
    createTable($("#apdexTable"), {"supportsControllersDiscrimination": true, "overall": {"data": [0.9961666666666666, 500, 1500, "Total"], "isController": false}, "titles": ["Apdex", "T (Toleration threshold)", "F (Frustration threshold)", "Label"], "items": [{"data": [0.996, 500, 1500, "Enable/Disbale Listing"], "isController": false}, {"data": [1.0, 500, 1500, "Add Education"], "isController": false}, {"data": [1.0, 500, 1500, "Add Certification"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Education"], "isController": false}, {"data": [1.0, 500, 1500, "Add Description"], "isController": false}, {"data": [1.0, 500, 1500, "Update Description"], "isController": false}, {"data": [0.987, 500, 1500, "Delete Listing"], "isController": false}, {"data": [0.982, 500, 1500, "Update Education"], "isController": false}, {"data": [1.0, 500, 1500, "Add Language"], "isController": false}, {"data": [1.0, 500, 1500, "Add Skill"], "isController": false}, {"data": [0.986, 500, 1500, "Update Certification"], "isController": false}, {"data": [0.996, 500, 1500, "Delete Language"], "isController": false}, {"data": [0.999, 500, 1500, "Add Listing"], "isController": false}, {"data": [1.0, 500, 1500, "SignIn"], "isController": false}, {"data": [0.999, 500, 1500, "Update Language"], "isController": false}, {"data": [0.986, 500, 1500, "Delete Certification"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Skill"], "isController": false}, {"data": [1.0, 500, 1500, "Update Skill"], "isController": false}]}, function(index, item){
        switch(index){
            case 0:
                item = item.toFixed(3);
                break;
            case 1:
            case 2:
                item = formatDuration(item);
                break;
        }
        return item;
    }, [[0, 0]], 3);

    // Create statistics table
    createTable($("#statisticsTable"), {"supportsControllersDiscrimination": true, "overall": {"data": ["Total", 9000, 21, 0.23333333333333334, 133.10188888888908, 1, 1055, 134.0, 247.0, 275.0, 455.0, 29.62182799591877, 6.533805139798572, 21.117792021854328], "isController": false}, "titles": ["Label", "#Samples", "FAIL", "Error %", "Average", "Min", "Max", "Median", "90th pct", "95th pct", "99th pct", "Transactions/s", "Received", "Sent"], "items": [{"data": ["Enable/Disbale Listing", 500, 0, 0.0, 236.09999999999982, 170, 745, 224.5, 243.0, 280.24999999999983, 494.96000000000004, 1.6707432802705267, 0.3100011945814454, 0.9479510213253673], "isController": false}, {"data": ["Add Education", 500, 0, 0.0, 147.88199999999992, 83, 470, 129.0, 217.0, 258.84999999999997, 444.17000000000075, 1.6717599620176136, 0.3382048766909852, 1.1281114587443075], "isController": false}, {"data": ["Add Certification", 500, 0, 0.0, 48.69799999999996, 39, 326, 47.0, 54.0, 56.0, 68.99000000000001, 1.6726379842705124, 0.33848704458249285, 1.0748005797363254], "isController": false}, {"data": ["Delete Education", 500, 0, 0.0, 47.02600000000001, 3, 325, 46.0, 51.0, 53.94999999999999, 68.98000000000002, 1.6734553170695787, 0.3562956330346773, 1.2041524231214626], "isController": false}, {"data": ["Add Description", 500, 0, 0.0, 141.472, 114, 440, 136.0, 150.0, 155.95, 401.98, 1.6729178028566745, 0.35941593420748863, 0.990027527862446], "isController": false}, {"data": ["Update Description", 500, 0, 0.0, 142.77200000000002, 114, 429, 136.0, 150.90000000000003, 156.0, 403.98, 1.6713185031671485, 0.35907233466481703, 1.0821134449216987], "isController": false}, {"data": ["Delete Listing", 500, 0, 0.0, 281.80999999999995, 185, 1055, 271.0, 291.0, 332.4499999999999, 547.98, 1.6704418652822046, 0.32299559504480124, 0.9575677489459512], "isController": false}, {"data": ["Update Education", 500, 5, 1.0, 242.444, 5, 893, 239.5, 337.7000000000001, 387.4499999999999, 576.9100000000001, 1.6723135119587138, 0.3575680652503286, 1.2033308252114638], "isController": false}, {"data": ["Add Language", 500, 0, 0.0, 50.96000000000002, 38, 388, 47.0, 53.0, 56.0, 309.40000000000146, 1.6725428672736882, 0.338330595241281, 0.9898056421561083], "isController": false}, {"data": ["Add Skill", 500, 0, 0.0, 51.45999999999997, 42, 341, 49.0, 55.0, 58.0, 70.99000000000001, 1.6715699384862264, 0.359492009895694, 1.026774893855309], "isController": false}, {"data": ["Update Certification", 500, 7, 1.4, 185.34999999999988, 4, 483, 179.0, 199.0, 212.0, 464.99, 1.6718382195591697, 0.2845651506994971, 1.1538981677071074], "isController": false}, {"data": ["Delete Language", 500, 2, 0.4, 47.135999999999996, 5, 332, 46.0, 51.0, 53.0, 74.93000000000006, 1.6726995363276886, 0.31959995613345465, 1.0436926368602761], "isController": false}, {"data": ["Add Listing", 500, 0, 0.0, 196.72200000000007, 146, 687, 183.0, 209.80000000000007, 249.79999999999995, 467.99, 1.6710280498768453, 0.3655373859105599, 3.705961622334293], "isController": false}, {"data": ["SignIn", 500, 0, 0.0, 191.5520000000001, 148, 493, 179.0, 198.90000000000003, 225.89999999999998, 478.0, 1.6697612909258492, 0.8022681202495291, 0.6095020062181911], "isController": false}, {"data": ["Update Language", 500, 0, 0.0, 185.75600000000014, 49, 686, 179.0, 197.90000000000003, 205.0, 457.97, 1.6718382195591697, 0.3513178630480286, 1.0431552122064252], "isController": false}, {"data": ["Delete Certification", 500, 7, 1.4, 46.98400000000001, 4, 319, 45.0, 51.0, 53.0, 66.98000000000002, 1.6725316777499768, 0.32625474371797103, 1.1543767906542275], "isController": false}, {"data": ["Delete Skill", 500, 0, 0.0, 28.12400000000003, 1, 334, 41.0, 50.0, 52.94999999999999, 70.90000000000009, 1.6725428672736882, 0.36417007586654443, 1.0694996964334695], "isController": false}, {"data": ["Update Skill", 500, 0, 0.0, 123.58600000000001, 41, 492, 162.0, 194.0, 204.95, 452.0, 1.6715922919536232, 0.3837218462068228, 1.068891855500876], "isController": false}]}, function(index, item){
        switch(index){
            // Errors pct
            case 3:
                item = item.toFixed(2) + '%';
                break;
            // Mean
            case 4:
            // Mean
            case 7:
            // Median
            case 8:
            // Percentile 1
            case 9:
            // Percentile 2
            case 10:
            // Percentile 3
            case 11:
            // Throughput
            case 12:
            // Kbytes/s
            case 13:
            // Sent Kbytes/s
                item = item.toFixed(2);
                break;
        }
        return item;
    }, [[0, 0]], 0, summaryTableHeader);

    // Create error table
    createTable($("#errorsTable"), {"supportsControllersDiscrimination": false, "titles": ["Type of error", "Number of errors", "% in errors", "% in all samples"], "items": [{"data": ["500/Internal Server Error", 21, 100.0, 0.23333333333333334], "isController": false}]}, function(index, item){
        switch(index){
            case 2:
            case 3:
                item = item.toFixed(2) + '%';
                break;
        }
        return item;
    }, [[1, 1]]);

        // Create top5 errors by sampler
    createTable($("#top5ErrorsBySamplerTable"), {"supportsControllersDiscrimination": false, "overall": {"data": ["Total", 9000, 21, "500/Internal Server Error", 21, "", "", "", "", "", "", "", ""], "isController": false}, "titles": ["Sample", "#Samples", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors"], "items": [{"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": ["Update Education", 500, 5, "500/Internal Server Error", 5, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": ["Update Certification", 500, 7, "500/Internal Server Error", 7, "", "", "", "", "", "", "", ""], "isController": false}, {"data": ["Delete Language", 500, 2, "500/Internal Server Error", 2, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": ["Delete Certification", 500, 7, "500/Internal Server Error", 7, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}]}, function(index, item){
        return item;
    }, [[0, 0]], 0);

});
