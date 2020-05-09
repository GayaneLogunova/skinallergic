function calc_date(month, year, num) {
    if (month > num) {
        return (String(month - num) + "." + String(year));
    } else {
        return (String(12 - num + month) + "." + String(year - 1));
    }
}


function get_quant_of_people(json) {
    var today = new Date();
    var year = today.getFullYear();
    var month = today.getMonth() + 1;
    var data = [];
    console.info(json["3.2020"])
    for (var i = 0; i < 12; i++) {
        if (typeof json[calc_date(month, year, i)] === 'undefined' || json[calc_date(month, year, i)] === null) {
            data.unshift(0 );
        } else {
            data.unshift(json[calc_date(month, year, i)])
        }
    }
    for (var i = 1; i < data.length; i++) {
        data[i] += data[i - 1];
    }
    return data;
}


function month_data() {
    var month_dict = {
        1: 'Январь', 2: 'Февраль', 3: 'Март', 4: 'Апрель', 5: 'Май', 6: 'Июнь', 7: 'Июль', 8: 'Август', 9: 'Сентябрь', 10: 'Октябрь', 11: 'Ноябрь', 12: 'Декабрь'
    };
    var monthes = [];
    var today = new Date();
    var month = today.getMonth() + 1;
    var num;
    for (var i = 0; i < 12; i++) {
        if (month > i) {
            num = month - i;
        } else { num = month - i + 12 }
        monthes.unshift(month_dict[num]);
    }
    return monthes;
}