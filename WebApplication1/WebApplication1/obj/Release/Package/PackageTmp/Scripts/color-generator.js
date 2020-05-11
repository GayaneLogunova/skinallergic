function get_region_attr(num, disease) {
    console.info(num, disease);
    if (typeof regionsColors[parseInt(disease)][parseInt(num)] === 'undefined')
        return null;
    return regionsColors[parseInt(disease)][parseInt(num)] ;
}