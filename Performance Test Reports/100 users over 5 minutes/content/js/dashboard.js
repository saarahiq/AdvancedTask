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
    createTable($("#apdexTable"), {"supportsControllersDiscrimination": true, "overall": {"data": [0.9905555555555555, 500, 1500, "Total"], "isController": false}, "titles": ["Apdex", "T (Toleration threshold)", "F (Frustration threshold)", "Label"], "items": [{"data": [1.0, 500, 1500, "Enable/Disbale Listing"], "isController": false}, {"data": [1.0, 500, 1500, "Add Education"], "isController": false}, {"data": [1.0, 500, 1500, "Add Certification"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Education"], "isController": false}, {"data": [1.0, 500, 1500, "Add Description"], "isController": false}, {"data": [1.0, 500, 1500, "Update Description"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Listing"], "isController": false}, {"data": [0.96, 500, 1500, "Update Education"], "isController": false}, {"data": [1.0, 500, 1500, "Add Language"], "isController": false}, {"data": [1.0, 500, 1500, "Add Skill"], "isController": false}, {"data": [0.95, 500, 1500, "Update Certification"], "isController": false}, {"data": [0.98, 500, 1500, "Delete Language"], "isController": false}, {"data": [0.995, 500, 1500, "Add Listing"], "isController": false}, {"data": [0.995, 500, 1500, "SignIn"], "isController": false}, {"data": [1.0, 500, 1500, "Update Language"], "isController": false}, {"data": [0.95, 500, 1500, "Delete Certification"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Skill"], "isController": false}, {"data": [1.0, 500, 1500, "Update Skill"], "isController": false}]}, function(index, item){
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
    createTable($("#statisticsTable"), {"supportsControllersDiscrimination": true, "overall": {"data": ["Total", 1800, 16, 0.8888888888888888, 111.54722222222208, 1, 644, 117.0, 208.0, 242.0, 265.0, 5.98346568981049, 1.3259907933576882, 4.262823262966669], "isController": false}, "titles": ["Label", "#Samples", "FAIL", "Error %", "Average", "Min", "Max", "Median", "90th pct", "95th pct", "99th pct", "Transactions/s", "Received", "Sent"], "items": [{"data": ["Enable/Disbale Listing", 100, 0, 0.0, 208.68000000000004, 192, 240, 205.0, 224.9, 231.95, 239.99, 0.33909914920023465, 0.06291878744926228, 0.19239902898958627], "isController": false}, {"data": ["Add Education", 100, 0, 0.0, 123.04000000000002, 111, 205, 118.0, 136.8, 158.69999999999993, 204.98, 0.33825608691828407, 0.06858934949971925, 0.22825679302786553], "isController": false}, {"data": ["Add Certification", 100, 0, 0.0, 47.64, 38, 64, 46.0, 53.0, 54.0, 63.969999999999985, 0.33831559431900454, 0.06865427783153237, 0.21739420025576658], "isController": false}, {"data": ["Delete Education", 100, 0, 0.0, 39.319999999999986, 2, 72, 40.0, 44.900000000000006, 46.0, 71.8099999999999, 0.3387981474517297, 0.07215341796511057, 0.24361704290200942], "isController": false}, {"data": ["Add Description", 100, 0, 0.0, 123.38, 106, 425, 119.0, 134.9, 138.84999999999997, 422.2699999999986, 0.33870978668057633, 0.07276968073215508, 0.20044739328948172], "isController": false}, {"data": ["Update Description", 100, 0, 0.0, 122.24000000000001, 107, 146, 121.0, 135.9, 139.95, 145.98, 0.33870978668057633, 0.07276968073215508, 0.21930135602463097], "isController": false}, {"data": ["Delete Listing", 100, 0, 0.0, 249.60999999999999, 227, 283, 247.0, 265.9, 271.0, 282.96, 0.3390290208841877, 0.06555443958502848, 0.19434573755763496], "isController": false}, {"data": ["Update Education", 100, 4, 4.0, 183.72, 5, 491, 169.0, 245.40000000000003, 250.84999999999997, 489.34999999999917, 0.3382858380016779, 0.07145627613258099, 0.24324866038808152], "isController": false}, {"data": ["Add Language", 100, 0, 0.0, 41.759999999999984, 37, 64, 40.5, 45.900000000000006, 47.94999999999999, 63.969999999999985, 0.3382972821196355, 0.06861752489867996, 0.20020327437939361], "isController": false}, {"data": ["Add Skill", 100, 0, 0.0, 47.120000000000005, 39, 339, 43.0, 49.0, 50.0, 336.21999999999855, 0.33741265229963596, 0.0739408195078499, 0.20725835771139747], "isController": false}, {"data": ["Update Certification", 100, 5, 5.0, 156.76000000000005, 6, 202, 163.0, 183.0, 185.89999999999998, 201.92999999999995, 0.3381600037873921, 0.05705129126397446, 0.23319500651803407], "isController": false}, {"data": ["Delete Language", 100, 2, 2.0, 41.17, 5, 66, 41.0, 48.80000000000001, 50.0, 65.95999999999998, 0.33832475116214555, 0.06418588809401368, 0.21101023982149986], "isController": false}, {"data": ["Add Listing", 100, 0, 0.0, 164.47000000000003, 144, 603, 156.0, 177.9, 185.84999999999997, 598.8699999999978, 0.3386581686043558, 0.07408147438220283, 0.7510670907231367], "isController": false}, {"data": ["SignIn", 100, 0, 0.0, 160.59999999999997, 145, 644, 155.0, 167.0, 172.0, 639.3699999999976, 0.3366810653935633, 0.16176473063831365, 0.12261240518219496], "isController": false}, {"data": ["Update Language", 100, 0, 0.0, 153.76, 46, 193, 154.0, 175.9, 180.95, 192.92999999999995, 0.33817487022539355, 0.07130403928746555, 0.21091676036928697], "isController": false}, {"data": ["Delete Certification", 100, 5, 5.0, 40.8, 5, 55, 42.5, 47.0, 48.94999999999999, 54.969999999999985, 0.33833390850097783, 0.06493764294607635, 0.2333149311405913], "isController": false}, {"data": ["Delete Skill", 100, 0, 0.0, 19.070000000000004, 1, 57, 3.5, 46.0, 48.0, 56.97999999999999, 0.33829155996387045, 0.07701749157654016, 0.2154626517660511], "isController": false}, {"data": ["Update Skill", 100, 0, 0.0, 84.71000000000002, 38, 474, 45.0, 170.9, 179.89999999999998, 471.1799999999986, 0.33775225871823017, 0.0811957749303386, 0.21511916321877902], "isController": false}]}, function(index, item){
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
