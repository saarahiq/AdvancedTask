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

    var data = {"OkPercent": 99.11111111111111, "KoPercent": 0.8888888888888888};
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
    createTable($("#apdexTable"), {"supportsControllersDiscrimination": true, "overall": {"data": [0.9902777777777778, 500, 1500, "Total"], "isController": false}, "titles": ["Apdex", "T (Toleration threshold)", "F (Frustration threshold)", "Label"], "items": [{"data": [0.995, 500, 1500, "Enable/Disbale Listing"], "isController": false}, {"data": [1.0, 500, 1500, "Add Education"], "isController": false}, {"data": [1.0, 500, 1500, "Add Certification"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Education"], "isController": false}, {"data": [1.0, 500, 1500, "Add Description"], "isController": false}, {"data": [1.0, 500, 1500, "Update Description"], "isController": false}, {"data": [0.995, 500, 1500, "Delete Listing"], "isController": false}, {"data": [0.96, 500, 1500, "Update Education"], "isController": false}, {"data": [1.0, 500, 1500, "Add Language"], "isController": false}, {"data": [1.0, 500, 1500, "Add Skill"], "isController": false}, {"data": [0.945, 500, 1500, "Update Certification"], "isController": false}, {"data": [0.98, 500, 1500, "Delete Language"], "isController": false}, {"data": [1.0, 500, 1500, "Add Listing"], "isController": false}, {"data": [1.0, 500, 1500, "SignIn"], "isController": false}, {"data": [1.0, 500, 1500, "Update Language"], "isController": false}, {"data": [0.95, 500, 1500, "Delete Certification"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Skill"], "isController": false}, {"data": [1.0, 500, 1500, "Update Skill"], "isController": false}]}, function(index, item){
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
    createTable($("#statisticsTable"), {"supportsControllersDiscrimination": true, "overall": {"data": ["Total", 1800, 16, 0.8888888888888888, 114.16277777777789, 1, 651, 117.0, 222.0, 258.0, 275.99, 5.983923193021416, 1.326098673231252, 4.263149203722666], "isController": false}, "titles": ["Label", "#Samples", "FAIL", "Error %", "Average", "Min", "Max", "Median", "90th pct", "95th pct", "99th pct", "Transactions/s", "Received", "Sent"], "items": [{"data": ["Enable/Disbale Listing", 100, 0, 0.0, 222.35999999999993, 203, 614, 217.0, 229.0, 235.0, 610.2699999999982, 0.3371407765026364, 0.06255541751513762, 0.19128788198049976], "isController": false}, {"data": ["Add Education", 100, 0, 0.0, 124.67999999999998, 111, 297, 118.0, 138.70000000000002, 157.95, 295.76999999999936, 0.33711009004210507, 0.06835697177377216, 0.22748346896395955], "isController": false}, {"data": ["Add Certification", 100, 0, 0.0, 47.14999999999999, 39, 183, 46.0, 51.0, 53.0, 181.71999999999935, 0.3371817004747519, 0.06842417710805998, 0.21666558487537763], "isController": false}, {"data": ["Delete Education", 100, 0, 0.0, 40.91000000000001, 2, 263, 39.0, 45.0, 46.94999999999999, 260.8399999999989, 0.3373056697710032, 0.07183556685904334, 0.242543858169712], "isController": false}, {"data": ["Add Description", 100, 0, 0.0, 123.5, 108, 272, 119.0, 132.0, 137.89999999999998, 271.92999999999995, 0.33722149719600325, 0.07244993103820382, 0.19956662822341598], "isController": false}, {"data": ["Update Description", 100, 0, 0.0, 123.35000000000002, 110, 249, 120.0, 132.9, 135.95, 248.8099999999999, 0.3372249087806622, 0.07245066399584539, 0.2183399555874795], "isController": false}, {"data": ["Delete Listing", 100, 0, 0.0, 267.02, 247, 651, 263.0, 272.9, 276.0, 647.3299999999981, 0.33711577229852274, 0.06518449503428467, 0.19324898275315708], "isController": false}, {"data": ["Update Education", 100, 4, 4.0, 179.14999999999998, 5, 314, 167.0, 235.60000000000002, 248.74999999999994, 313.8099999999999, 0.3371373666200293, 0.07122026869848119, 0.24242283768521483], "isController": false}, {"data": ["Add Language", 100, 0, 0.0, 43.95, 38, 157, 41.0, 47.0, 50.89999999999998, 156.67999999999984, 0.3371839743200685, 0.06839171041628733, 0.19954442230269678], "isController": false}, {"data": ["Add Skill", 100, 0, 0.0, 44.339999999999996, 39, 133, 42.0, 48.0, 50.89999999999998, 132.27999999999963, 0.33697604437300555, 0.07384514097392816, 0.2069901678814653], "isController": false}, {"data": ["Update Certification", 100, 5, 5.0, 158.15999999999994, 9, 508, 159.5, 181.9, 194.4999999999999, 506.11999999999904, 0.33706463888579913, 0.05686649122452213, 0.23243964330977254], "isController": false}, {"data": ["Delete Language", 100, 2, 2.0, 40.81, 4, 51, 41.0, 46.0, 47.0, 50.989999999999995, 0.3371828373935767, 0.06396924787153334, 0.21029803801736494], "isController": false}, {"data": ["Add Listing", 100, 0, 0.0, 175.4100000000001, 161, 450, 170.0, 187.0, 191.0, 447.5899999999988, 0.3371794266601029, 0.07375799958189752, 0.7477875761182556], "isController": false}, {"data": ["SignIn", 100, 0, 0.0, 166.36, 146, 413, 160.0, 175.9, 189.95, 412.2399999999996, 0.33665386259809255, 0.16175166054517726, 0.12260249847664127], "isController": false}, {"data": ["Update Language", 100, 0, 0.0, 157.64, 45, 374, 155.5, 174.9, 181.0, 373.91999999999996, 0.33703964597355585, 0.07106467769741254, 0.2102087307592492], "isController": false}, {"data": ["Delete Certification", 100, 5, 5.0, 40.489999999999995, 5, 58, 41.0, 48.0, 51.89999999999998, 57.949999999999974, 0.33719420700352365, 0.06471889594186772, 0.23252899343314282], "isController": false}, {"data": ["Delete Skill", 100, 0, 0.0, 18.339999999999982, 1, 49, 3.0, 43.0, 44.0, 48.989999999999995, 0.33718056356359394, 0.07676455545271549, 0.2147550425353281], "isController": false}, {"data": ["Update Skill", 100, 0, 0.0, 81.31000000000002, 38, 184, 45.0, 165.8, 172.95, 183.95, 0.33698285768202974, 0.08101081062068873, 0.2146291208791209], "isController": false}]}, function(index, item){
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
    createTable($("#errorsTable"), {"supportsControllersDiscrimination": false, "titles": ["Type of error", "Number of errors", "% in errors", "% in all samples"], "items": [{"data": ["500/Internal Server Error", 16, 100.0, 0.8888888888888888], "isController": false}]}, function(index, item){
        switch(index){
            case 2:
            case 3:
                item = item.toFixed(2) + '%';
                break;
        }
        return item;
    }, [[1, 1]]);

        // Create top5 errors by sampler
    createTable($("#top5ErrorsBySamplerTable"), {"supportsControllersDiscrimination": false, "overall": {"data": ["Total", 1800, 16, "500/Internal Server Error", 16, "", "", "", "", "", "", "", ""], "isController": false}, "titles": ["Sample", "#Samples", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors"], "items": [{"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": ["Update Education", 100, 4, "500/Internal Server Error", 4, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": ["Update Certification", 100, 5, "500/Internal Server Error", 5, "", "", "", "", "", "", "", ""], "isController": false}, {"data": ["Delete Language", 100, 2, "500/Internal Server Error", 2, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": ["Delete Certification", 100, 5, "500/Internal Server Error", 5, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}]}, function(index, item){
        return item;
    }, [[0, 0]], 0);

});
