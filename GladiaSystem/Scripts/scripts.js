$("#close-sidebar").click(function() {
  $(".page-wrapper").removeClass("toggled");
});
$("#show-sidebar").click(function() {
  $(".page-wrapper").addClass("toggled");
});

// Jquery Dependency

$("input[data-type='currency']").on({
    keyup: function () {
        formatCurrency($(this));
    },
    blur: function () {
        formatCurrency($(this), "blur");
    }
});


function formatNumber(n) {
    // format number 1000000 to 1,234,567
    return n.replace(/\D/g, "").replace(/\B(?=(\d{3})+(?!\d))/g, ",")
}

google.charts.load('current', { packages: ['corechart', 'bar'] });
google.charts.setOnLoadCallback(drawTitleSubtitle);

function drawTitleSubtitle() {


    var data = google.visualization.arrayToDataTable([
        ['', '', { role: 'style' }],
        ['Pequeno', 7.94, '#b87333'],            // RGB value
        ['Médio', 10.49, 'silver'],
        ['Grande', 11.49, 'silver'],    // English color name
    ]);

    var materialOptions = {
        chart: {
            title: 'Percentual de cada porte',
            subtitle: '',
            width: 600,
            height: 400,
        },
        hAxis: {
            title: 'Total Population',
            minValue: 0,
        },
        vAxis: {
            title: 'City'
        },
        bars: 'horizontal'
    };

    var materialChart = new google.charts.Bar(document.getElementById('firt-graph'));
    materialChart.draw(data, materialOptions);
}

google.charts.load('current', { 'packages': ['corechart'] });
google.charts.setOnLoadCallback(drawChart);
google.charts.setOnLoadCallback(pet);

function drawChart() {

    var data = google.visualization.arrayToDataTable([
        ['Category', 'Product per category'],
        ['Comida', 11],
        ['Limpeza', 2],
        ['Remédio', 2],
        ['Brinquedo', 2]
    ]);

    var options = {
        title: 'Percentual de Categoria'
    };

    var chart = new google.visualization.PieChart(document.getElementById('second-graph'));

    chart.draw(data, options);
}

function pet() {
    var data = google.visualization.arrayToDataTable([
        ['Pets', 'Pets per Agenda'],
        ['Léo', 11],
        ['Paçoca', 2],
        ['Mel', 2],
        ['Belinha', 2],
        ['Bufos', 7]
    ]);

    var options = {
        title: 'Agendamentos por pet',
        pieHole: 0.4,
    };

    var chart = new google.visualization.PieChart(document.getElementById('third-graph'));
    chart.draw(data, options);
}


function shortNumber() {
    document.getElementById("sub-value").innerHTML = value;
    var str = value;
    var length = str.length;
    var res = str.slice(12, length);
    document.getElementById("demo").innerHTML = res;
    return res;
}

function formatCurrency(input, blur) {
    // appends $ to value, validates decimal side
    // and puts cursor back in right position.

    // get input value
    var input_val = input.val();

    // don't validate empty input
    if (input_val === "") { return; }

    // original length
    var original_len = input_val.length;

    // initial caret position 
    var caret_pos = input.prop("selectionStart");

    // check for decimal
    if (input_val.indexOf(".") >= 0) {

        // get position of first decimal
        // this prevents multiple decimals from
        // being entered
        var decimal_pos = input_val.indexOf(".");

        // split number by decimal point
        var left_side = input_val.substring(0, decimal_pos);
        var right_side = input_val.substring(decimal_pos);

        // add commas to left side of number
        left_side = formatNumber(left_side);

        // validate right side
        right_side = formatNumber(right_side);

        // On blur make sure 2 numbers after decimal
        if (blur === "blur") {
            right_side += "00";
        }

        // Limit decimal to only 2 digits
        right_side = right_side.substring(0, 2);

        // join number by .
        input_val = "R$" + left_side + "." + right_side;

    } else {
        // no decimal entered
        // add commas to number
        // remove all non-digits
        input_val = formatNumber(input_val);
        input_val = "R$" + input_val;

        // final formatting
        if (blur === "blur") {
            input_val += ".00";
        }
    }

    // send updated string to input
    input.val(input_val);

    // put caret back in the right position
    var updated_len = input_val.length;
    caret_pos = updated_len - original_len + caret_pos;
    input[0].setSelectionRange(caret_pos, caret_pos);
}

